// <copyright file="ClubProject.cs" company="Chandler_Guthrie-WSU_ID:011801740">
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
    /// club project.
    /// </summary>
    internal class ClubProject : Project
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClubProject"/> class.
        /// </summary>
        /// <param name="name"> project name. </param>
        /// <param name="description"> project description. </param>
        /// <param name="targetAmount"> project target amount. </param>
        /// <param name="startDate"> project start date. </param>
        /// <param name="endDate"> project end date. </param>
        public ClubProject(string name, string description, double targetAmount, DateTime startDate, DateTime endDate)
            : base(name, description, targetAmount, startDate, endDate)
        {
        }

        /// <summary>
        /// add member to project.
        /// </summary>
        /// <param name="user"> the user being added as a memeber. </param>
        public override void AddMemberToProject(IUser user)
        {
            this.projectMembers.Add(user.Username, user);
        }
    }
}
