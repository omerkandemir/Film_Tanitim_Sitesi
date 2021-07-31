using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerCanberkKandemir.Models.Model
{
    [Table("mezhep")]
    public class mezhep
    {
        [Key]
        public int mezhepID { get; set; }
        public string Mezhepadi { get; set; }
        public ICollection<karakter> karakters { get; set; }
    }
}