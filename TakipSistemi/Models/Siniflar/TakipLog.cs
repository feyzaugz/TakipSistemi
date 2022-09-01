using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakipSistemi.Models.Siniflar
{
    [Table("TakipLoglar")]
    public class TakipLog
    {
        [Key]
        [StringLength(20)]
        public string KullaniciAd { get; set; }

        public DateTime Tarih { get; set; }

        [StringLength(150)]
        public string DurumAciklama { get; set; }
    }
}