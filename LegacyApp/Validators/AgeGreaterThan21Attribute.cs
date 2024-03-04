using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.Validators
{
    public class AgeGreaterThan21Attribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateOfBirth)
            {
                int age = CalculateAge(dateOfBirth);
                return age > 21;
            }
            return false;
        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)
                age--;
            return age;
        }
    }
}
