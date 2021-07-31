using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerCanberkKandemir.Models.Model
{
    [Table("gezegen")]
    public class gezegen
    {
        [Key]
        public int gezegenID { get; set; }
        public string Gezegenadi { get; set; }
        public string GezegenResim { get; set; }
        public ICollection<karakter> karakters { get; set; }
    }
}