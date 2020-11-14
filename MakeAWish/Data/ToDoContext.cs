using MakeAWish.DataConfig;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MakeAWish.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoContext> ToDoList { get; set; }

        public ToDoContext() : base(GetConnection(), false)
        {

        }

        public static DbConnection GetConnection()
        {
            var connection = ConfigurationManager.ConnectionStrings["SQLiteConnection"];
            var factory = DbProviderFactories.GetFactory(connection.ProviderName);
            var dbCon = factory.CreateConnection();
            dbCon.ConnectionString = connection.ConnectionString;
            return dbCon;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ToDoConfig());
            base.OnModelCreating(modelBuilder);
        }

    }
}