using System.ComponentModel.DataAnnotations;

namespace API.Dto
{
    public class RegisterDto
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool is_active { get; set; }
        public bool email_verified { get; set; }
        public DateTime last_login { get; set; } 
        public string role { get; set; }
    }
}
