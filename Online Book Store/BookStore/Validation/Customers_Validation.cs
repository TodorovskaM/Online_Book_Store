using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BookStore.Models;

namespace BookStore.Validation
{
    public class Customers_Validation : AbstractValidator<Customers>
    {
        public Customers_Validation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required!");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required!");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required!");
            RuleFor(x => x.BirthDate).Must(Validate_Age).WithMessage("Age has to be at least 18!");
        }

        public bool Validate_Age(DateTime birthDate)
        {
            DateTime Current = DateTime.Today;
            int age = Current.Year - Convert.ToDateTime(birthDate).Year;

            if (age < 18)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
