using System.ComponentModel.DataAnnotations.Schema;

namespace DMK_TestAppW.Models
{
    public class Book
    {
        public Book()
        {
            this.Users = new HashSet<User>();
        }
        public int BookId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<User> Users { get; set; }
        //[NotMapped]
        //public bool IsReaded { get; set; }
    }

    public class UserBook : Book
    {
        public bool IsReaded { get; set; }
    }
}
