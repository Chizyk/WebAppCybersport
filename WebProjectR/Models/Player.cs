using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebProjectR.Models
{
    public class Player
    {
        [Key]
        public int IdPlayer { get; set; }

        [Required]
        //[RegularExpression(@"[A-Za-z0-9._%+-]", ErrorMessage = "Некорректое имя")]
        [StringLength(100, ErrorMessage = "{0} должно содержать символов не менее: {2}.", MinimumLength = 4)]
        [Display(Name = "Имя игрока")]
        public string NamePlayer { get; set; }

        [Range(1, 100)]
        [Display(Name = "Возраст игрока")]
        public int Age { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }

        public int? PlayerTeamId { get; set; }
        public PlayerTeam PlayerTeam { get; set; }
    }
}