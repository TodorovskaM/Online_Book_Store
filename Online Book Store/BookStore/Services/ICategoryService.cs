using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services
{
    public interface ICategoryService
    {
        bool AddACategory(Category category);
        Book SelectByCategory(string category);
    }
}
