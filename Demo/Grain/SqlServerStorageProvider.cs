// *********************************************************************** Assembly : Demo Author :
// qiu.yanjun Created : 09-26-2017
//
// Last Modified By : qiu.yanjun Last Modified On : 09-26-2017
// ***********************************************************************
// <copyright file="SqlServerStorageProvider.cs" company="">Copyright © 2017</copyright>
// <summary></summary>
// ***********************************************************************

using System.Configuration;
using System.Threading.Tasks;
using Orleans;
using Orleans.Providers;
using Orleans.Runtime;
using Orleans.Storage;

namespace Demo
{
    /// <summary>Class SqlServerStorageProvider.</summary>
    /// <seealso cref="Orleans.Storage.IStorageProvider"/>
    public class SqlServerStorageProvider : IStorageProvider
    {
        /// <summary>The connection</summary>
        private string connection;

        /// <summary>Logger used by this storage provider instance.</summary>
        /// <value>The log.</value>
        /// <seealso cref="T:Orleans.Runtime.Logger"/>
        public Logger Log { get; }

        /// <summary>The name of this provider instance, as given to it in the config.</summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>Delete / Clear data function for this storage provider instance.</summary>
        /// <param name="grainType">Type of this grain [fully qualified class name]</param>
        /// <param name="grainReference">Grain reference object for this grain.</param>
        /// <param name="grainState">Copy of last-known state data object for this grain.</param>
        /// <returns>Completion promise for the Delete operation on the specified grain.</returns>
        public Task ClearStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            this.connection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            return Task.CompletedTask;
        }

        /// <summary>Close function for this provider instance.</summary>
        /// <returns>Completion promise for the Close operation on this provider.</returns>
        public Task Close()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Initialization function called by Orleans Provider Manager when a new provider class
        /// instance is created
        /// </summary>
        /// <param name="name">Name assigned for this provider</param>
        /// <param name="providerRuntime">
        /// Callback for accessing system functions in the Provider Runtime
        /// </param>
        /// <param name="config">Configuration metadata to be used for this provider instance</param>
        /// <returns>Completion promise Task for the inttialization work for this provider</returns>
        public Task Init(string name, IProviderRuntime providerRuntime, IProviderConfiguration config)
        {
            this.connection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            return Task.CompletedTask;
        }

        /// <summary>Read data function for this storage provider instance.</summary>
        /// <param name="grainType">Type of this grain [fully qualified class name]</param>
        /// <param name="grainReference">Grain reference object for this grain.</param>
        /// <param name="grainState">State data object to be populated for this grain.</param>
        /// <returns>Completion promise for the Read operation on the specified grain.</returns>
        public Task ReadStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            this.connection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            return Task.CompletedTask;
        }

        /// <summary>Write data function for this storage provider instance.</summary>
        /// <param name="grainType">Type of this grain [fully qualified class name]</param>
        /// <param name="grainReference">Grain reference object for this grain.</param>
        /// <param name="grainState">State data object to be written for this grain.</param>
        /// <returns>Completion promise for the Write operation on the specified grain.</returns>
        public Task WriteStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            this.connection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            return Task.CompletedTask;
        }
    }
}