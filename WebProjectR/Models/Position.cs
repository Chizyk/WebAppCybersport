using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebProjectR.Models
{
    public class Position
    {
        [Key]
        public int IdPosition { get; set; }

        [Display(Name = "Позиция игрока:")]
        public string NamePosition { get; set; }

        public ICollection<Player> Players { get; set; }

        public Position()
        {
            Players = new List<Player>();
        }
    }
}