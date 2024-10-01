using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.ViewModels.Utilities.Slides
{
    public class SlideVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }

        public int SortOrder { get; set; }

    }
}
