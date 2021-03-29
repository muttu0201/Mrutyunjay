using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SantoshApp.Models
{
    public class HotelModel
    {
        [Key]
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelType { get; set; }
        public string Comments { get; set; }

    }
}
