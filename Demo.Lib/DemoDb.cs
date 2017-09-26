using System.Data.Entity;

namespace Demo.Lib
{
    public class DemoDb : DbContext
    { 
        public DemoDb(string connection)
            : base(connection)
        {
        }

        public DbSet<UserInfo> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserInfoMap());
        }
    }
}