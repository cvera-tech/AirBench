using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AirBench.Models.ViewModels
{
    public class BenchAddViewModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public float Latitude { get; set; }

        [Required]
        public float Longitude { get; set; }

        [Required]
        public int NumberSeats { get; set; }

        public List<SelectListItem> SeatsItems
        {
            get
            {
                var list = new List<SelectListItem>();
                for(int i = 1; i < 11; i++)
                {
                    list.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
                }
                return list;
            }
        }

        public override string ToString()
        {
            return $"({Latitude}, {Longitude}) {Description}, {NumberSeats} seats";
        }
    }
}