using miniStore.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace miniStore.ApiIntergration
{
    public interface ISlideApiClient
    {
        Task<List<SlideVM>> GetAll();
    }
}
