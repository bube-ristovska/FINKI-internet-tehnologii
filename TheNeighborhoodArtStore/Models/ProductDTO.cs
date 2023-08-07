using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TheNeighborhoodArtStore.Models
{
    public class ProductDTO
    {
        
        public int Id { get; set; }
      
        public string ProductName { get; set; }
       
        public string Description { get; set; }
     
        public string Image { get; set; }
       
        public string Color { get; set; }
        public double Price { get; set; }
        //who made the product
        public int ArtistId { get; set; }
      
        public Artist Artist { get; set; }

    }
}