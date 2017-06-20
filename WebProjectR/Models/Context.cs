using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace WebProjectR.Models
{
    public class Context : DbContext
    {
        public Context() : base("RegisterProj2")
        { }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; } 
        public DbSet<Dics> Dicss { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
   
        static Context()
        {
            Database.SetInitializer<Context>(new ReqInitializer());
        }

    }
    //DropCreateDatabaseAlways<ReqContext>//System.Data.Entity.
    class ReqInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context db)
        {
            Dics e1 = new Dics { NameDiscipline = "Dota2" };
            db.Dicss.Add(e1);
            Dics e2 = new Dics { NameDiscipline = "Lol" };
            db.Dicss.Add(e2);

            Country c1 = new Country { NameCountry = "Россия" };
            db.Countrys.Add(c1);
            Country c2 = new Country { NameCountry = "США" };
            db.Countrys.Add(c2);
            Country c3 = new Country { NameCountry = "Англия" };
            db.Countrys.Add(c3);
            Country c4 = new Country { NameCountry = "Китай" };
            db.Countrys.Add(c4);
            Country c5 = new Country { NameCountry = "Украина" };
            db.Countrys.Add(c5);

            Position p1 = new Position { NamePosition = "Капитан команды" };
            db.Positions.Add(p1);
            Position p2 = new Position { NamePosition = "Игрок" };
            db.Positions.Add(p2);

            
            db.SaveChanges();
        }
    }
}