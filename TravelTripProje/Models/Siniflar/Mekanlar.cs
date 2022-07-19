using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class Mekanlar
    {
        [Key]
        public int ID { get; set; }
        public string MEKANAD { get; set; }
        public ICollection<Rehber>Rehbers{ get; set; }


    }
}