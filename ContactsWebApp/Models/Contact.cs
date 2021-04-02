using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//utrošeno vrijeme: 5 min

namespace ContactsWebApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
    }
}
