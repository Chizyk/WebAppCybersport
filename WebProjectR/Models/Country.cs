using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebProjectR.Models
{
    public class Country
    {
        [Key]
        public int IdCountry { get; set; }

        [Display(Name = "Страна:")]
        public string NameCountry { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}