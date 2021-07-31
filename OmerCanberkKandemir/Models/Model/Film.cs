using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OmerCanberkKandemir.Models.Model
{
    [Table("Film")]
    public class Film
    {
        [Key]
        public int FilmID { get; set; }
        public string filmadi { get; set; }
    }
}