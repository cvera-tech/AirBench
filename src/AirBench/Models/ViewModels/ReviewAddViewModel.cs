using System.Collections.Generic;
using System.Web.Mvc;

namespace AirBench.Models.ViewModels
{
    public class ReviewAddViewModel
    {
        public Bench Bench { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public List<SelectListItem> RatingItems { get; private set; }

        public ReviewAddViewModel()
        {
            RatingItems = new List<SelectListItem>();
            for (int index = 5; index > 0; index -= 1)
            {
                RatingItems.Add(new SelectListItem()
                {
                    Value = index.ToString(),
                    Text = index.ToString()
                });
            }
        }

        public override string ToString()
        {
            return $"({Rating}: {Description}";
        }
    }
}