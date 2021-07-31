using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerCanberkKandemir.Models.Model
{
    [Table("Tür")]
    public class Tur
    {
        [Key]
        public int turID { get; set; }
        public string turadi { get; set; }
        public ICollection<karakter> karakters { get; set; }
    }
}