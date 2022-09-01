using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakipSistemi.Models.Siniflar
{
    [Table("Kullanıcılar")]
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }

        public string KullaniciAd { get; set; }


        public string KullaniciSoyad { get; set; }


        public string KullaniciMail { get; set; }

        public string Parola { get; set; }


        public bool Durum { get; set; }

        public virtual Yetki Yetki { get; set; }

        public int YetkiId { get; set; }
    }
}