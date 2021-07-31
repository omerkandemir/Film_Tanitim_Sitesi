using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerCanberkKandemir.Models.Model
{
    [Table("Işın Kılıcı")]
    public class silah
    {
        [Key]
        public int silahID { get; set; }
        public string KullandığıSilah { get; set; }
        public ICollection<karakter> karakters { get; set; }
    }
}