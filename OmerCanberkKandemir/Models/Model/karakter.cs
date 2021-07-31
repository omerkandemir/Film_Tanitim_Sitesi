using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerCanberkKandemir.Models.Model
{
    [Table("karakter")]
    public class karakter
    {
        [Key]
        public int karakterID { get; set; }
        public string baslik { get; set; }
        public string ResimURL { get; set; }
        public string yazi { get; set; }
        public ICollection<makale> makales { get; set; }
        public int? mezhepID { get; set; }
        public mezhep mezhep { get; set; }
        public int? silahID { get; set; }
        public silah silah { get; set; }
        public int? gezegenID { get; set; }
        public gezegen gezegen { get; set; }
        public int? turID { get; set; }
        public Tur Tur { get; set; }
        public string usta { get; set; }
        public string padawan { get; set; }
        public string dogduguyil { get; set; }
        public string olumyili { get; set; }
    }
}