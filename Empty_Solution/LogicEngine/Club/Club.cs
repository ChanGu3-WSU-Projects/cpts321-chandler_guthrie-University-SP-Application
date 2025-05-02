// <copyright file="Club.cs" company="Chandler_Guthrie-WSU_ID:011801740">
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
    /// a active club.
    /// </summary>
    internal class Club
    {
        /// <summary>
        /// current projects the club is working on.
        /// </summary>
        private List<ClubProject> currentProjects = new List<ClubProject>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Club"/> class.
        /// </summary>
        /// <param name="name"> the name of the club. </param>
        public Club(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// invoked when member has been removed.
        /// </summary>
        public event EventHandler? MemberRemoved;

        /// <summary>
        /// Gets the name of the club.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the current projects club is working on.
        /// </summary>
        public List<ClubProject> CurrentProjects
        {
            get
            {
                this.UpdateCurrentProject();
                return this.currentProjects;
            }
        }

        /// <summary>
        /// Gets the current members of the club.
        /// </summary>
        public Dictionary<string, IUser> CurrentMembers
        {
            get;
        }

        = new Dictionary<string, IUser>();

        /// <summary>
        ///  Gets the club member log history of the club.
        /// </summary>
        public List<MemberLog> MemberLogHistory
        {
            get;
        }

        = new List<MemberLog>();

        /// <summary>
        /// Add a member to the club.
        /// </summary>
        /// <param name="userStudent"> new club memeber. </param>
        public void AddMember(IUser userStudent)
        {
            // need to update current projects or else will add user to projects that may be inactive.
            this.UpdateCurrentProject();

            // add as member to club.
            this.CurrentMembers.Add(userStudent.Username, userStudent);

            // create a memberlog.
            MemberLog memberLog = new MemberLog(userStudent);
            this.MemberRemoved += memberLog.MemberLeft!;
            this.MemberLogHistory.Insert(0, memberLog);

            // add new member to concurrent projects
            foreach (ClubProject project in this.currentProjects)
            {
                project.AddMemberToProject(userStudent);
            }
        }

        /// <summary>
        /// removed a member from the club.
        /// </summary>
        /// <param name="user"> club member leaving. </param>
        public void RemoveMember(IUser user)
        {
            if (!this.CurrentMembers.Remove(user.Username))
            {
                throw new ArgumentException("user does not exist in club");
            }

            // memberlog update
            this.MemberRemoved?.Invoke(user, EventArgs.Empty);
            this.MemberRemoved -= this.MemberLogHistory.First((memberLog) => (object)memberLog.Member == (object)user).MemberLeft!;
        }

        /// <summary>
        /// add a new club project to the club and add the members to it.
        /// </summary>
        /// <param name="clubProject"> the club projects. </param>
        public void AddClubProject(ClubProject clubProject)
        {
            foreach (IUser user in this.CurrentMembers.Values)
            {
                clubProject.AddMemberToProject(user);
            }

            this.currentProjects.Add(clubProject);
        }

        /// <summary>
        /// updates the current project by removing any projects out of date.
        /// </summary>
        private void UpdateCurrentProject()
        {
            // updates current projects that are active.
            foreach (ClubProject clubProject in this.currentProjects)
            {
                if (!clubProject.IsActive())
                {
                    this.CurrentProjects.Remove(clubProject);
                }
            }
        }
    }
}
