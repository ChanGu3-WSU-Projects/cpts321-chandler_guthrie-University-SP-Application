// <copyright file="IndividualProject.cs" company="Chandler_Guthrie-WSU_ID:011801740">
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
    /// individual project.
    /// </summary>
    internal class IndividualProject : Project
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualProject"/> class.
        /// </summary>
        /// <param name="name"> project name. </param>
        /// <param name="description"> project description. </param>
        /// <param name="targetAmount"> project target amount. </param>
        /// <param name="startDate"> project start date. </param>
        /// <param name="endDate"> project end date. </param>
        public IndividualProject(string name, string description, double targetAmount, DateTime startDate, DateTime endDate)
            : base(name, description, targetAmount, startDate, endDate)
        {
        }

        /// <summary>
        /// add member to project. if more than one member is added throws an exception.
        /// </summary>
        /// <param name="user"> the uer being added as a memeber. </param>
        public override void AddMemberToProject(IUser user)
        {
            if (this.projectMembers.Count == 0)
            {
                this.projectMembers.Add(user.Username, user);
                return;
            }

            throw new InvalidOperationException("Individual Project Cannot have more than one member");
        }
    }
}
