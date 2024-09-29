using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using miniStore.Data.EF;
using miniStore.ViewModels.Common;
using miniStore.ViewModels.System.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniStore.Application.System.Laguages
{
    public class LanguageService : ILanguageService
    {
        private readonly miniStoreDbContext _context;
        private readonly IConfiguration _configuration;

        public LanguageService(miniStoreDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ApiResult<List<LanguageVM>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageVM()
            {
                Id = x.Id,
                Name = x.Name, 
            }).ToListAsync();

            return new ApiSuccessResult<List<LanguageVM>>(languages); 
        }
    }
}
