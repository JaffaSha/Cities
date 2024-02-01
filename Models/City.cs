using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Cities.Models
{
    public class City
    {
        [StringLength(200)]
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CityName { get; set; } 
    }
}
