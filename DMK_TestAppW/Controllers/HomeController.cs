using DMK_TestAppW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DMK_TestAppW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            db = applicationContext;
        }
        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext filterContext)
        {
            ViewBag.SessionId = HttpContext?.Session?.GetString("Id");
            ViewBag.SessionUsername = HttpContext?.Session?.GetString("Username");
        }

        public IActionResult Index()
        {
            ViewBag.BooksCount = db.Books.Count();
            ViewBag.UsersCount = db.Users.Count();
            ViewBag.ReadsCount = db.Users.SelectMany(x => x.Books).Count();
            return View();
        }

        private async Task GetListOfBooks(Book[] bookSet)
        {
            int booksCount = bookSet.Count();
            ViewBag.BookListCount = booksCount;
            Book[] bookArray = new Book[booksCount];
            Array.Copy(bookSet.ToArray(), bookArray, booksCount);


            if (null != HttpContext.Session.GetString("Username"))
            {
                var readedBookList = db.Users.First(x => x.Username == HttpContext.Session.GetString("Username")).Books;
                if (readedBookList != null)
                {
                    foreach (var book in readedBookList)
                    {
                        ViewData[$"IsReaded{book.BookId}"] = true;
                    }
                }
            }

            ViewBag.BookList = bookArray;
        }

        [HttpGet]
        public async Task<IActionResult> Books()
        {
            await GetListOfBooks(db.Books.ToArray());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Books(string TitleName)
        {
            TitleName = TitleName ?? String.Empty;
            ViewBag.SearchField = TitleName;
            await GetListOfBooks(db.Books.Where(x => x.Title.Contains(TitleName)).ToArray());
            return View();
        }

        public async Task<IActionResult> AddBook(int id)
        {
            string username = HttpContext.Session.GetString("Username");
            if (null == username)
                return await SetMessageAsync("Вы не авторизованы!", "~/Home/Login");

            User currentUser = await db.Users.FirstAsync(x => x.Username == username);
            currentUser.Books.Add(db.Books.First(x => x.BookId == id));
            await db.SaveChangesAsync();
            return await SetMessageAsync("Книга добавлена в список прочитанных!", "~/Home/Books");
        }
        public async Task<IActionResult> RemoveBook(int id, string redirect = "Books")
        {
            string username = HttpContext.Session.GetString("Username");
            if (null == username)
                return await SetMessageAsync("Вы не авторизованы!", "~/Home/Login");

            User currentUser = await db.Users.FirstAsync(x => x.Username == username);
            currentUser.Books.Remove(db.Books.First(x => x.BookId == id));
            await db.SaveChangesAsync();
            return await SetMessageAsync(
                "Книга удалена из списка прочитанных!",
                redirect == "Profile"
                    ? "~/Home/Profile"
                    : "~/Home/Books"
            );
        }

        /*
         * Авторизация и регистрация *
         */

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            if (null != HttpContext.Session.GetString("Id"))
            {
                HttpContext.Session.Remove("Id");
                HttpContext.Session.Remove("Username");
            }
            else
                return await SetMessageAsync("Вы не авторизованы");
            return Redirect("~/");
        }

        [HttpGet]
        public async Task<ActionResult> Login()
        {
            if (null != HttpContext.Session.GetString("Id"))
            {
                return await SetMessageAsync("Авторизация уже выполнена ранее.");
            }
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            if ("" != user.Password)
                user.Password = Models.User.CreateMD5(user.Password);
            List<User> FindUser = await Task.Run(() => db
                .Users
                .Where(x => x.Password == user.Password && x.Username == user.Username)
                .ToList<User>());
            if (1 == FindUser.Count)
            {
                HttpContext.Session.SetString("Id", FindUser[0].UserId.ToString());
                HttpContext.Session.SetString("Username", FindUser[0].Username);
            }
            else
            {
                return await SetMessageAsync("Неверная комбинация имени пользователя и пароля", "~/Home/Login");
            }
            return Redirect("~/");
        }

        [HttpGet]
        public async Task<ActionResult> Register()
        {
            if (null != HttpContext.Session.GetString("Id"))
            {
                return await SetMessageAsync("Авторизация уже выполнена ранее.");
            }

            ViewBag.Title = "Регистрация";
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Register(RegisteringUser registeringUser)
        {
            User user;
            if ("" != registeringUser.Password && registeringUser.Password == registeringUser.Password2)
            {
                user = new User { Username = registeringUser.Username, Password = Models.User.CreateMD5(registeringUser.Password) };
                var FindUser = await db.Users.FirstOrDefaultAsync(x => x.Username == user.Username);

                if (FindUser == null)
                {
                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();
                    HttpContext.Session.SetString("Id", user.UserId.ToString());
                    HttpContext.Session.SetString("Username", user.Username);

                    return await SetMessageAsync("Вы успешно зарегистрировались!", "~/");
                }
                else
                    return await SetMessageAsync("Пользователь с таким именем уже существует!", "~/Home/Register");
            }
            else return await SetMessageAsync("Введённые пароли не совпадают!", "~/Home/Register");
        }

        public async Task<ActionResult> ShowProfile(int id, string TitleName)
        {
            if (id == 0)
            {
                if (null == HttpContext.Session.GetString("Id"))
                {
                    return await SetMessageAsync("Для продолжения требуется авторизация.", "~/Home/Login");
                }

                return Redirect($"~/Home/Profile?id={HttpContext.Session.GetString("Id")}");
            }


            var user = await db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (null == user)
                return await SetMessageAsync("Пользователя не существует.", "~/Home/");

            ViewBag.ProfileId = id.ToString();
            await GetListOfBooks((TitleName == String.Empty ? user.Books : user.Books.Where(x => x.Title.Contains(TitleName))).ToArray());
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            return await ShowProfile(id, String.Empty);
        }


        [HttpPost]
        public async Task<IActionResult> Profile(int id, string TitleName)
        {
            TitleName = TitleName ?? String.Empty;
            ViewBag.SearchField = TitleName;
            return await ShowProfile(id, TitleName);
        }


        public RedirectResult SetMessage(string Str)
        {
            return SetMessage(Str, "~/");
        }

        public RedirectResult SetMessage(string Str, string ViewRed)
        {
            TempData["Message"] = Str;
            return Redirect(ViewRed);
        }

        public async Task<RedirectResult> SetMessageAsync(string Str) => await Task.Run(() => SetMessage(Str));
        public async Task<RedirectResult> SetMessageAsync(string Str, string ViewRed) => await Task.Run(() => SetMessage(Str, ViewRed));

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}