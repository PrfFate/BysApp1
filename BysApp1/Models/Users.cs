using System.ComponentModel.DataAnnotations;

namespace BysApp1.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash
        {
            get;
            set;
        }
        public string Role { get; set; }
        public int? RelatedID { get; set; }
        public string Email { get; set; }
    }
}