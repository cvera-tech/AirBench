using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AirBench.Models.ViewModels
{
    public class BenchAddViewModel
    {
        [Required]
        public string Description { get; set; }
        
        [Required, Range(-90.0, 90.0, ErrorMessage = "Latitude must be in range (-90, 90)")]
        public float? Latitude { get; set; }

        [Required, Range(-180.0, 180.0, ErrorMessage = "Longitude must be in range (-180, 180)")]
        public float? Longitude { get; set; }
        
        [Display(Name = "Number of Seats")]
        public int NumberSeats { get; set; }

        public List<SelectListItem> SeatsItems { get; private set; }

        public BenchAddViewModel()
        {
            SeatsItems = new List<SelectListItem>();
            for (int i = 1; i < 11; i++)
            {
                SeatsItems.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }
        }

        public override string ToString()
        {
            return $"({Latitude}, {Longitude}) {Description}, {NumberSeats} seats";
        }
    }
}