// *********************************************************************** Assembly : Demo Author :
// qiu.yanjun Created : 09-26-2017
//
// Last Modified By : qiu.yanjun Last Modified On : 09-26-2017
// ***********************************************************************
// <copyright file="BaseGrain.cs" company="">Copyright © 2017</copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using Orleans;

namespace Demo
{
    /// <summary>Class BaseGrain.</summary>
    /// <typeparam name="TState">The type of the t state.</typeparam>
    /// <seealso cref="Orleans.Grain{TState}"/>
    /// <seealso cref="Orleans.IGrain"/>
    /// <seealso cref="Orleans.IGrainState"/>
    public class BaseGrain<TState> : Grain<TState>, IGrain, IGrainState where TState : new()
    {
        /// <summary>
        /// An e-tag that allows optimistic concurrency checks at the storage provider level.
        /// </summary>
        /// <value>The e tag.</value>
        public string ETag { get; set; }

        /// <summary>Strongly typed accessor for the grain state</summary>
        /// <value>The state.</value>
        public object State { get; set; }

        /// <summary>
        /// This method is called at the end of the process of activating a grain. It is called
        /// before any messages have been dispatched to the grain. For grains with declared
        /// persistent state, this method is called after the State property has been populated.
        /// </summary>
        /// <returns>Task.</returns>
        public override Task OnActivateAsync()
        {
            Console.WriteLine("OnActivateAsync");
            this.ReadStateAsync();
            return base.OnActivateAsync();
        }

        /// <summary>
        /// This method is called at the begining of the process of deactivating a grain.
        /// </summary>
        /// <returns>Task.</returns>
        public override Task OnDeactivateAsync()
        {
            Console.WriteLine("OnDeactivateAsync");
            this.WriteStateAsync();
            return base.OnDeactivateAsync();
        }
    }
}