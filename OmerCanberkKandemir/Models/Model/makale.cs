using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerCanberkKandemir.Models.Model
{
    [Table("makale")]
    public class makale
    {
        [Key]
        public int makaleID { get; set; }
        public string baslik { get; set; }
        public string ResimURL { get; set; }
        public string yazi { get; set; }
        public int? karakterID { get; set; }
        public karakter karakter { get; set; }
    }
}