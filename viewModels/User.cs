using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPCAuthenticationModule.viewModels
{
    public class User
    {
        public int ID { get; set; }

        [Required, StringLength(15, MinimumLength = 5), Display(Name ="Username")]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password",ErrorMessage ="The password don't match")]
        public string ConfirmPassword { get; set; }

        [Required, Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
