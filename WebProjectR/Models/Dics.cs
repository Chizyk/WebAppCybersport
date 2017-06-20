using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebProjectR.Models
{
    public class Dics
    {
        [Key]
        public int IdDicsipline { get; set; }

        [Display(Name = "Дисциплина(Игра):")]
        public string NameDiscipline { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}