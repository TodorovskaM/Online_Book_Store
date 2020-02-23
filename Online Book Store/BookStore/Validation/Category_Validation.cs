using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BookStore.Models;

namespace BookStore.Validation
{
    public class Category_Validation : AbstractValidator<Category>
    {
        public Category_Validation()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name is required!");
        }
    }
}
