using System.ComponentModel.DataAnnotations;

namespace Registration.DataAccess
{
    public class Register
    {
        public int Id { get; set; }
       
        public string FullName { get; set; }
     
        public string Phone { get; set; }
      
        public string Email { get; set; }
       
        public string Login { get; set; }
       
        public string Password { get; set; }
    }
}
