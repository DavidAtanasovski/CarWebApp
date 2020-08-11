using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApp.Models
{
    public class CarDto
    {
        [Required]
        public string ProductLabel { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string Seats { get; set; }
        [Required]
        public string Wheels { get; set; }
        [Required]
        public string EngineLabel { get; set; }
        [Required]
        public int MaxEngPower { get; set; }
        [Required]
        public int MaxTorqPower { get; set; }
        [Required]
        public string FuelType { get; set; }
        [Required]
        public int OverallLenght { get; set; }
        [Required]
        public int OverallWidth { get; set; }
        [Required]
        public int OverallHeight { get; set; }
        [Required]
        public int LightestCurbWeight { get; set; }
        [Required]
        public int HeaviestCurbWeight { get; set; }
        [Required]
        public int Tires { get; set; }

        public string Photo { get; set; }
    }
}
