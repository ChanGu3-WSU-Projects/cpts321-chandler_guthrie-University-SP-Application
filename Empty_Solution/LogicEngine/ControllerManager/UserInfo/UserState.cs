// <copyright file="UserState.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicEngine
{
    /// <summary>
    /// the user state based on the type of user.
    /// </summary>
    public enum UserState
    {
        /// <summary>
        /// user is a guest
        /// </summary>
        GUEST,

        /// <summary>
        /// user is a student
        /// </summary>
        STUDENT,

        /// <summary>
        /// user is a donor
        /// </summary>
        DONOR,
    }
}
