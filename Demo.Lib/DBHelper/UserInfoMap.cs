// ***********************************************************************
// Assembly         : Demo.Lib
// Author           : qiu.yanjun
// Created          : 09-26-2017
//
// Last Modified By : qiu.yanjun
// Last Modified On : 09-26-2017
// ***********************************************************************
// <copyright file="UserInfoMap.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Entity.ModelConfiguration;

namespace Demo.Lib
{
    /// <summary>
    /// Class UserInfoMap.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{Demo.Lib.UserInfo}" />
    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoMap"/> class.
        /// </summary>
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