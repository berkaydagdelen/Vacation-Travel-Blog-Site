using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class Rehber
    {
        [Key]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }

        public string Fotograf { get; set; }
        public int MekanlarID { get; set; }
        public virtual Mekanlar Mekanlar { get; set; }

        //public int BlogID { get; set; }
        //public virtual Blog Blog { get; set; }
        public ICollection<RehberYorumlar> RehberYorumlars { get; set; }

    }
}