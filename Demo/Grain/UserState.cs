// *********************************************************************** Assembly : Demo Author :
// qiu.yanjun Created : 09-26-2017
//
// Last Modified By : qiu.yanjun Last Modified On : 09-26-2017
// ***********************************************************************
// <copyright file="UserState.cs" company="">Copyright © 2017</copyright>
// <summary></summary>
// ***********************************************************************
using Orleans;

namespace Demo
{
    /// <summary>Class UserState.</summary>
    /// <seealso cref="Orleans.IGrainState"/>
    public class UserState : IGrainState
    {
        /// <summary>
        /// An e-tag that allows optimistic concurrency checks at the storage provider level.
        /// </summary>
        /// <value>The e tag.</value>
        public string ETag { get; set; }

        /// <summary>The application level payload that is the actual state.</summary>
        /// <value>The state.</value>
        public object State { get; set; }
    }
}