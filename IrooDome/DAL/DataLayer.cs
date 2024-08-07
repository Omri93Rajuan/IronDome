using Microsoft.EntityFrameworkCore;
using IrooDome.Models;
using System;

namespace IrooDome.DAL
{
    //קלאס שמייצג את שכבת הנתונים, יורש מקלאס בשם DbContext
    public class DataLayer : DbContext
    {
        //קונסטרקטור שמקבל מחרוזת חיבור ומעביר אותה לקונסטרקטור של הקלאס האב
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();

            //להכניס נתונים בפעם הראשונה
            Seed();
        }
        //יצירת טבלה בדאטא בייס
        public DbSet<DefenceAmmuntion> DefenceAmmuntions { get; set; }

        //יצירת טבלה בדאטא בייס
        public DbSet<TerrorOrg> TerrorOrgs { get; set; }

        //יצירת טבלה בדאטא בייס
        public DbSet<Threat> Threats { get; set; }

        //יצירת טבלה בדאטא בייס
        public DbSet<ThreatAmmunition> ThreatAmmunitions { get; set; }

        //פונקציה להכנסת ערך ראשוני
        private void Seed()
        {
            if (!DefenceAmmuntions.Any())
            {
                DefenceAmmuntion defence1 = new DefenceAmmuntion { Name = "Iron Dome Missle", Amount = 100 };
                DefenceAmmuntion defence2 = new DefenceAmmuntion { Name= "Patriot Missle" , Amount = 50};
                DefenceAmmuntions.AddRange(defence1, defence2);
                SaveChanges();
                
            }

            if (!TerrorOrgs.Any())
            {
                TerrorOrgs.AddRange(
                    new TerrorOrg { Name ="Hamas", Location = " Lebanon", Distance = 45},
                    new TerrorOrg { Name = "Hezbollah", Location = " Lebanon",Distance=200},
                    new TerrorOrg { Name = "Houthi", Location = " Yamen",Distance=2377},
                    new TerrorOrg { Name = "Iran", Location = " Iran",Distance=1600}
                    );
                SaveChanges();
            }

            if (!ThreatAmmunitions.Any())
            {
                ThreatAmmunitions.AddRange(
                    new ThreatAmmunition { Name = "Balisti", Speed = 18000 },
                    new ThreatAmmunition { Name = "Rocket", Speed = 880 },
                    new ThreatAmmunition { Name = "Katbam", Speed = 300 });
                SaveChanges();
            }


            if (!Threats.Any())
            {
                TerrorOrg? Hamas = TerrorOrgs.FirstOrDefault(t => t.Name == "Hamas");
                ThreatAmmunition? Rocket = ThreatAmmunitions.FirstOrDefault(t => t.Name == "Rocket");

                if (Hamas != null && Rocket != null) 
                {
                    Threats.AddRange(
                        new Threat 
                        {
                            org = Hamas,
                            type = Rocket,
                        }
                        );
                SaveChanges();
                }
            }
        }


        //פונקציה שמחזירה את אפשרויות התחברות למסד נתונים
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), connectionString)
                .Options;
        }
    }
}
