using miniStore.Data.EF;
using miniStore.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using miniStore.Data.Entities;
using miniStore.Utilities.Constants;
using miniStore.ViewModels.Catalog.Products;
using miniStore.ViewModels.Common;
using miniStore.Application.Common;
using miniStore.Utilities.Exceptions;

namespace miniStore.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly miniStoreDbContext _context;

        public CategoryService(miniStoreDbContext context) { 
            _context = context;
        }

        public async Task<int> Create(CategoryCreateRequest request)
        {
            var languages = _context.Languages;
            var translations = new List<CategoryTranslation>();

            foreach (var language in languages)
            {
                if (language.Id == request.LanguageId)
                {
                    translations.Add(new CategoryTranslation
                    {
                        Name = request.Name,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId,
                    });
                }
                else
                {
                    translations.Add(new CategoryTranslation
                    {
                        Name = SystemConstants.ProductConstants.NA,
                        SeoDescription = SystemConstants.ProductConstants.NA,
                        SeoAlias = SystemConstants.ProductConstants.NA,
                        SeoTitle= SystemConstants.ProductConstants.NA,
                        LanguageId = language.Id
                    });
                }
            }
            var maxSortOrder = _context.Categories.Max(x => (int?)x.SortOrder) ?? 0;
            var category = new Category()
            {
                CategoryTranslations = translations,
                ParentId = request.ParentId,
                IsShowOnHome = true,
                SortOrder = maxSortOrder + 1
            };
           
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<List<CategoryVM>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVM
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParenId= x.c.ParentId,
            }).ToListAsync();
        }

        public async Task<CategoryVM> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };
            return await query.Select(x => new CategoryVM
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParenId = x.c.ParentId,
            }).FirstOrDefaultAsync();
        }

        public async Task<PagedResult<CategoryVM>> GetAllPaging(GetCategoryPagingRequest request)
        {
            var query = from c in _context.Categories 
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == request.LanguageId 
                        select new { c ,ct};

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.ct.Name.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(
                    x => new CategoryVM()
                    {
                        Id = x.c.Id,
                        Name = x.ct.Name,   
                        ParenId= x.c.ParentId,
                    }).ToListAsync();
            var pageResult = new PagedResult<CategoryVM>()
            {
                TotalRecord = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };
            return pageResult;
        }

        public async Task<int> Delete(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null) throw new MiniStoreException($"Cannot find a category {categoryId}");

            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }
    }
}
