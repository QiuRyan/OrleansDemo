using System.Data.Entity.ModelConfiguration;

namespace Demo.Lib
{
    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            this.HasKey(t => t.UserIdentifier);
            this.Property(t => t.UserIdentifier).IsRequired().HasMaxLength(50);

            this.Property(t => t.Cellphone).HasMaxLength(20);


            this.ToTable("Users");
            this.Property(t => t.UserIdentifier).HasColumnName("UserIdentifier");
            this.Property(t => t.Cellphone).HasColumnName("Cellphone");
        }

    }
}