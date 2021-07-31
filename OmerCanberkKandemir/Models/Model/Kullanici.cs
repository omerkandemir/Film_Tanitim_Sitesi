using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerCanberkKandemir.Models.Model
{
    [Table("Kullanıcı")]
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }
        [Required]
        public string kullaniciadi { get; set; }
        [Required]
        public string Eposta { get; set; }
        [Required]
        public string Sifre { get; set; }
        public ICollection<Icerik> Iceriks { get; set; }
    }
}