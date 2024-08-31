using miniStore.Data.EF;
using miniStore.Data.Entities;
using miniStore.ViewModels.Catalog.Products;
using miniStore.ViewModels.Common;
using miniStore.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using miniStore.Application.Common;
namespace miniStore.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly miniStoreDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(miniStoreDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations=new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name =  request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    }
                },
            };
            //save image
            if (request.ThumbnailImage != null) {
                product.ProductImages = new List<ProductImage>() { 
                    new ProductImage(){
                        Caption="Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product= await _context.Products.FindAsync(productId);
            if (product == null) throw new MiniStoreException($"Cannot find a product {productId}");

            var images = product.ProductImages.Where(x => x.ProductId == productId);
            foreach (var image in images) { 
                await _storageService.DeleteFileAsync(image.ImagePath);
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && 
            x.LanguageId == request.LanguageId);
            if (product == null || productTranslations == null) throw new MiniStoreException($"Cannot find a product with Id: {request.Id}");

            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;

            //save image
            var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(x => x.IsDefault == true && x.ProductId == request.Id);
            if (thumbnailImage != null) {
                thumbnailImage.FileSize = request.ThumbnailImage.Length;
                thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                _context.ProductImages.Update(thumbnailImage);
            }

            return await _context.SaveChangesAsync();

        }

        public async Task<int> AddViewcount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            if (!string.IsNullOrEmpty(request.Keyword)) { 
                query =query.Where(x => x.pt.Name.Contains(request.Keyword));
            }
            if (request.CategoryId.Count() > 0) {
                query = query.Where(x => request.CategoryId.Contains(x.pic.CategoryId));
            }

            int totalRow= await query.CountAsync();

            var data= await query.Skip((request.PageIndex - 1)* request.PageSize)
                .Take(request.PageSize)
                .Select(
                    x => new ProductViewModel()
                    {
                        Id = x.p.Id,
                        Name = x.pt.Name,
                        DateCreated = x.p.DateCreated,
                        Description = x.pt.Description,
                        Details = x.pt.Details,
                        LanguageId = x.pt.LanguageId,
                        OriginalPrice = x.p.OriginalPrice,
                        Price = x.p.Price,
                        SeoAlias = x.pt.SeoAlias,
                        SeoDescription = x.pt.SeoDescription,
                        SeoTitle = x.pt.SeoTitle,
                        Stock = x.p.Stock,
                        ViewCount = x.p.ViewCount
                    }).ToListAsync();
            var pageResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return pageResult;
        }


        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)  throw new MiniStoreException($"Cannot find a product with id {productId}");
            product.Price = newPrice;
            return _context.SaveChanges() > 0;
        }

        public async Task<int> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new MiniStoreException($"Cannot find a product with id {productId}");
            product.Stock += addedQuantity;
            return _context.SaveChanges();
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

    }
}
