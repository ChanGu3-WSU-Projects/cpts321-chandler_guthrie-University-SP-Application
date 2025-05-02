// <copyright file="Project.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// base class for projects what projects need to have.
    /// </summary>
    public abstract class Project
    {
        /// <summary>
        /// members in the project by username.
        /// </summary>
        protected Dictionary<string, IUser> projectMembers = new Dictionary<string, IUser>();

        /// <summary>
        /// End Date of the project.
        /// </summary>
        private DateTime endDate;

        /// <summary>
        /// raised amount of the project.
        /// </summary>
        private double raisedAmount = 0f;

        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        /// <param name="name"> project name. </param>
        /// <param name="description"> project description. </param>
        /// <param name="targetAmount"> project target amount. </param>
        /// <param name="startDate"> project start date. </param>
        /// <param name="endDate"> project end date. </param>
        public Project(string name, string description, double targetAmount, DateTime startDate, DateTime endDate)
        {
            this.Name = name;
            this.Description = description;
            this.TargetAmount = targetAmount;
            this.StartDate = startDate;
            this.endDate = endDate;
        }

        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the description of the project.
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the target amount of the project.
        /// </summary>
        public double TargetAmount
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the Start Date of the project.
        /// </summary>
        public DateTime StartDate
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets donations of the project.
        /// </summary>
        public List<Donation> Donations
        {
            get;
        }

        = new List<Donation>();

        /// <summary>
        /// adds donation to donation list in project adding to the total.
        /// </summary>
        /// <param name="newDonation"> new donation added to project. </param>
        public void AddDonation(Donation newDonation)
        {
            this.raisedAmount += newDonation.ActualAmount;
            this.Donations.Add(newDonation);
        }

        /// <summary>
        /// using the current time and the end date time checks if the project is active.
        /// </summary>
        /// <returns> true when end date current time passed endate.</returns>
        public bool IsActive()
        {
            return DateTime.Now.Ticks <= this.endDate.Ticks;
        }

        /// <summary>
        /// using the raised amount calculates the percentage amount of money raised to the clubs target amount.
        /// </summary>
        /// <returns> the raised amount to the target as a percent. </returns>
        public int PercentRaised()
        {
            return Convert.ToInt32((this.raisedAmount / this.TargetAmount) * 100d);
        }

        /// <summary>
        /// using the DateTime of now and the endate calculate the number of days left.
        /// </summary>
        /// <returns> days left of project. </returns>
        public int DaysLeft()
        {
             DateTime newTime = new DateTime(DateTime.Now.Ticks);
             int dayCount = 0;

             while (newTime.Ticks < this.endDate.Ticks)
             {
                dayCount++;
                newTime = newTime.AddDays(1);
             }

             return dayCount;
        }

        /// <summary>
        /// trys to get a user in the project.
        /// </summary>
        /// <param name="username"> username of user in project. </param>
        /// <returns> null if user does not exist otherwise the user. </returns>
        public IUser? GetMemberByUsername(string username)
        {
            IUser? user = null;
            if (this.projectMembers.TryGetValue(username, out user))
            {
                return user;
            }

            return null;
        }

        /// <summary>
        /// add member to project may be different for other projects.
        /// </summary>
        /// <param name="user"> the uer being added as a memeber. </param>
        public abstract void AddMemberToProject(IUser user);
    }
}
