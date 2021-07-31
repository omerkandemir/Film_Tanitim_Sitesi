using OmerCanberkKandemir.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OmerCanberkKandemir.Models.DataContext
{
    public class infinitextContext:DbContext
    {
        public infinitextContext():base("infinitextDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Icerik> Icerik { get; set; }
        public DbSet<karakter> karakter { get; set; }
        public DbSet<makale> makale { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<mezhep> mezhep { get; set; }
        public DbSet<silah> silah { get; set; }
        public DbSet<gezegen> gezegen { get; set; }
        public DbSet<Tur> Tur { get; set; }
    }
}