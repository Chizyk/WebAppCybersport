using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjectR.Models
{
    public class PlayerTeam
    {
        public int Id { get; set; }

        public int IdSozd { get; set; }

        public int IdIgr1 { get; set; }

        public int IdIgr2 { get; set; }

        public int IdIgr3 { get; set; }

        public int IdIgr4 { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}