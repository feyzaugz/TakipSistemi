using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TakipSistemi.Models.Siniflar
{
    public class Context : DbContext
    {
        public Context(): base("name=TakipSistemiContext")
            {

            }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Takip> Takipler { get; set; }
        public DbSet<TakipLog> TakipLoglar { get; set; }
        public DbSet<Yetki> Yetkiler { get; set; }
    }
}