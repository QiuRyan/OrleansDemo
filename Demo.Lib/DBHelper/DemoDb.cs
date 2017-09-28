// *********************************************************************** Assembly : Demo.Lib Author
// : qiu.yanjun Created : 09-26-2017
//
// Last Modified By : qiu.yanjun Last Modified On : 09-26-2017
// ***********************************************************************
// <copyright file="DemoDb.cs" company="">Copyright © 2017</copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Entity;

namespace Demo.Lib
{
    /// <summary>Class DemoDb.</summary>
    /// <seealso cref="System.Data.Entity.DbContext"/>
    public class DemoDb : DbContext
    {
        /// <summary>Initializes a new instance of the <see cref="DemoDb"/> class.</summary>
        /// <param name="connection">The connection.</param>
        public DemoDb(string connection)
            : base(connection)
        {
        }

        /// <summary>Gets or sets the user.</summary>
        /// <value>The user.</value>
        public DbSet<UserInfo> User { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context. The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">
        /// The builder that defines the model for the context being created.
        /// </param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created. The model for that context is then cached and is for all further instances of
        /// the context in the app domain. This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and
        /// DbContextFactory classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserInfoMap());
        }
    }
}