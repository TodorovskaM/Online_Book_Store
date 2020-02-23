using BookStore.Models;
using BookStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IDbRepository repo;
        public CategoryService(IDbRepository repo)
        {
            this.repo = repo;
        }


        public bool AddACategory(Category category)
        {
            if (category == null) return false;

            return repo.AddACategory(category);
        }

        public Book SelectByCategory(string category)
        {
            return repo.SelectByCategory(category);
        }

    }
}
