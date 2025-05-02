// <copyright file="TestProject.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using LogicEngine;

namespace LogicEngine_Tests.ProjectTesting
{
    /// <summary>
    /// testing project.
    /// </summary>
    internal class TestProject : Project
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestProject"/> class.
        /// </summary>
        /// <param name="name"> project name. </param>
        /// <param name="description"> project description. </param>
        /// <param name="targetAmount"> project target amount. </param>
        /// <param name="startDate"> project start date. </param>
        /// <param name="endDate"> project end date. </param>
        public TestProject(string name, string description, double targetAmount, DateTime startDate, DateTime endDate)
            : base(name, description, targetAmount, startDate, endDate)
        {
        }

        /// <summary>
        /// does nothing.
        /// </summary>
        /// <param name="user"> user to add. </param>
        public override void AddMemberToProject(IUser user)
        {
            this.projectMembers.Add(user.Username, user);
        }
    }
}
