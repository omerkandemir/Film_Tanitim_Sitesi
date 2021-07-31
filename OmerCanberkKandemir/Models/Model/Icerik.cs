using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerCanberkKandemir.Models.Model
{
    [Table("Icerik")]
    public class Icerik
    {
        public int IcerikID { get; set; }
        public string Başlık { get; set; }
        public string icerik { get; set; }
        public string ResimURL { get; set; }
        public int? KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}