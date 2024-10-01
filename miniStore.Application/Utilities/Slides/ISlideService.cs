using miniStore.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace miniStore.Application.Utilities.Slides
{
    public interface ISlideService
    {
        Task<List<SlideVM>> GetAll();
    }
}
