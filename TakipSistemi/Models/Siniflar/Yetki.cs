using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakipSistemi.Models.Siniflar
{
    [Table("Yetkiler")]
    public class Yetki
    {
        [Key]
        public int YetkiId { get; set; }

        [Display(Name = "Yetki Adı")]
        public string YetkiAdi { get; set; }

        public virtual ICollection<Kullanici> Kullanici { get; set; }
    }
}