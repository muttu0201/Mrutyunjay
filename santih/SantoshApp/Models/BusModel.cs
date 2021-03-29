using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SantoshApp.Models
{
    public class BusModel
    {
        [Key]
        public int BusId { get; set; }
        public string BusName { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
