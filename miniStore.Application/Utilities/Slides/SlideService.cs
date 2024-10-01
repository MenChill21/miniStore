using Microsoft.EntityFrameworkCore;
using miniStore.Data.EF;
using miniStore.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniStore.Application.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly miniStoreDbContext _context;

        public SlideService(miniStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<SlideVM>> GetAll()
        {
            var slides =await _context.Slides.OrderBy(x => x.SortOrder)
                .Select(x => new SlideVM()
                {
                    Id =x.Id,
                    Name = x.Name,
                    Url = x.Url,
                    Image = x.Image,
                    Description = x.Description,
                }).ToListAsync();
            return slides;
        }
    }
}
