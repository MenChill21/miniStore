using miniStore.Data.EF;
using miniStore.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace miniStore.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly miniStoreDbContext _contextl;

        public CategoryService(miniStoreDbContext contextl) { 
            _contextl = contextl;
        }
        public async Task<List<CategoryVM>> GetAll(string languageId)
        {
            var query = from c in _contextl.Categories
                        join ct in _contextl.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVM
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParenId= x.c.ParentId,
            }).ToListAsync();
        }
    }
}
