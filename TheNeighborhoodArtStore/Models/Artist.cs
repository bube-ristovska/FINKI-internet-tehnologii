using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TheNeighborhoodArtStore.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Display(Name = "Name of artist")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Biography")]
        public string Description { get; set; }
        [Display(Name = "Contact email")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Image of artist")]
        public string UrlImage { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Artist() { 
            Products = new List<Product>();
        }
        
    }
}