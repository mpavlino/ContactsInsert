using ContactsWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebApp.Models
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        //Provjera duplikata - Dohvati email iz baze koji odgovara unesenom email-u u polju
        //te ukoliko postoji zapis ispiši upozorenje/grešku.
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var _dbContext = (ContactDbContext)validationContext.GetService(typeof(ContactDbContext));
            var entity = _dbContext.Contact.SingleOrDefault(e => e.Email == value.ToString());

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string email)
        {
            return $"Email {email} is already in use.";
        }
    }
}
