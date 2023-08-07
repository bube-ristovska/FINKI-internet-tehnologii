using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace TheNeighborhoodArtStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name of product")]

        public string ProductName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Image of product")]
        public string Image { get; set; }
        [Display(Name = "Color")]
        public string Color { get; set; }
        public double Price { get; set; }
        //who made the product
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }


    }
}