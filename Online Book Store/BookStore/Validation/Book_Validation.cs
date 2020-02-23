using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BookStore.Models;
using BookStore.DBAccess;

namespace BookStore.Validation
{
    public class Book_Validation : AbstractValidator<Book>
    {
        public Book_Validation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required!");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required!");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stock is required!");
        }
    }
}
