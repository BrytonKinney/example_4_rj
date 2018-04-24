namespace example_4_rj.DomainObjects
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SearchADO : DbContext
    {
        // Your context has been configured to use a 'CensusADO' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'example_4_rj.DomainObjects.CensusADO' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CensusADO' 
        // connection string in the application configuration file.
        public SearchADO() : base("name=SearchADO")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Census> C { get; set; }
        public virtual DbSet<Naturals> N { get; set; }
        public virtual DbSet<Obit> O { get; set; }
    }
    public class Obit
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
    public class Census
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
    public class Naturals
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
}