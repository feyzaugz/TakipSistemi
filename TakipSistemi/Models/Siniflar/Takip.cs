using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakipSistemi.Models.Siniflar
{
    [Table("Takipler")]
    public class Takip
    {
        [Key]
        public int TakipId { get; set; }

        public string DosyaNo { get; set; }

        public int TalepNo { get; set; }

        public DateTime Tarih { get; set; }

       
        public string Yetkili { get; set; }

       
        public string Tanim { get; set; }

        public bool Durum { get; set; }
        public string DurumAciklama { get; set; }

        public string KullaniciAdSoyad { get; set; }
    }
}