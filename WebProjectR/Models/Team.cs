using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebProjectR.Models
{
    public class Team
    {
        [Key]
        public int IdTeam { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} должно содержать символов не менее {2} символов.", MinimumLength = 4)]
        [Display(Name = "Название команды")]
        public string NameTeam { get; set; }

        [Display(Name = "Дата создания команды")]
        [DataType(DataType.Date)]
        public DateTime DateCreate { get; set; }
        
        public int? DicsId { get; set; }
        public Dics Dics { get; set; }

        public int? TeamPlayerId { get; set; }
        public PlayerTeam PlayerTeam { get; set; }

    }
}