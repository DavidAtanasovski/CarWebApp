using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarWebCore
{
    public class Car
    {
        public int Id { get; set; }
        [Required, Display(Name ="Product Label")]
        public string ProductLabel { get; set; }
        [Required, Display(Name = "Model Name")]
        public string ModelName { get; set; }
        [Required, Display(Name = "Seats")]
        public string Seats { get; set; }
        [Required, Display(Name = "Wheels name")]
        public string Wheels { get; set; }
        [Required, Display(Name = "Engine Label")]
        public string EngineLabel { get; set; }
        [Required, Display(Name = "Max Engine Power")]
        public int MaxEngPower { get; set; }
        [Required, Display(Name = "Max Torque Power")]
        public int MaxTorqPower { get; set; }
        [Required, Display(Name = "Fuel Type")]
        public string FuelType { get; set; }
        [Required, Display(Name = "Overall Lenght")]
        public int OverallLenght { get; set; }
        [Required, Display(Name = "Overall Width")]
        public int OverallWidth { get; set; }
        [Required, Display(Name = "Overall Height")]
        public int OverallHeight { get; set; }
        [Required, Display(Name = "Lightest Curb Weight")]
        public int LightestCurbWeight { get; set; }
        [Required, Display(Name = "Heaviest Curb Weight")]
        public int HeaviestCurbWeight { get; set; }
        [Required, Display(Name = "Tires Name")]
        public int Tires { get; set; }
       
        public string Photo { get; set; }
    }
}
