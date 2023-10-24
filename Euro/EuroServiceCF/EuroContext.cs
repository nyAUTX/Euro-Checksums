using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EuroServiceCF.Model;

namespace EuroServiceCF
{
    public class EuroContext : DbContext
    {
        public EuroContext() : base("Data Source=localhost;Initial Catalog=EuroDB;User ID=sa;Password=Passme1234!;Encrypt=False")
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EuropeSeries> EuropeSeries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LCity> LCities { get; set; }
        public DbSet<LCountry> LCountries { get; set; }
        public DbSet<LText> LTexts { get; set; }
        public DbSet<OldSeries> OldSeries { get; set; }
        public DbSet<Printery> Printeries { get; set; }
        public DbSet<Text> Texts { get; set; }

    }
}