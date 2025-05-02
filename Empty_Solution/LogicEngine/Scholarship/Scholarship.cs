// <copyright file="Scholarship.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// scholarship donor can create and students can apply.
    /// </summary>
    public class Scholarship
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Scholarship"/> class.
        /// </summary>
        /// <param name="userDonor"> the donor that created the scholarship. </param>
        /// <param name="name"> the name of the scholarship. </param>
        /// <param name="description"> the description of the scholarship. </param>
        /// <param name="endDate"> the End Date of the scholarship. </param>
        /// <param name="criteria"> the criteria need to fill out for the scholarship. </param>
        /// <param name="donorDonation"> the donation attached to the scholarship. </param>
        internal Scholarship(IUser userDonor, string name, string description, DateTime endDate, List<Criteria> criteria, Donation donorDonation)
        {
            this.Donor = userDonor;
            this.Name = name;
            this.Description = description;
            this.EndDate = endDate;
            this.Criteria = criteria;
            this.Donation = donorDonation;
        }

        /// <summary>
        /// gets the donor of the scholarship.
        /// </summary>
        public IUser Donor
        {
            get;
            private set;
        }

        /// <summary>
        /// gets the donation that the donor created when making the scholarship.
        /// </summary>
        public Donation Donation
        {
            get;
            private set;
        }

        /// <summary>
        /// gets the name of the scolarship.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the description of the scholarship.
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the criteria that the donor created for the scholarship.
        /// </summary>
        public List<Criteria> Criteria
        {
            get;
            private set;
        }

        = new List<Criteria>();

        /// <summary>
        /// Gets the ending date for the scholarship where student can no longer apply.
        /// </summary>
        public DateTime EndDate
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the students that applied to the scholarship.
        /// </summary>
        public List<Application> StudentApplications
        {
            get;
            private set;
        }

        = new List<Application>();

        /// <summary>
        /// Gets the students that have/will be awarded.
        /// </summary>
        public List<IUser> StudentsToAward
        {
            get;
            private set;
        }

        = new List<IUser>();

        /// <summary>
        /// Gets a value indicating whether the students chosen by the donor been awarded.
        /// </summary>
        public bool Awarded
        {
            get;
            private set;
        }

        /// <summary>
        /// changes the state of the scholarship to awarded.
        /// </summary>
        public void AwardStudents()
        {
            this.Awarded = true;
        }

        /// <summary>
        /// adds a student to the awarded students list.
        /// </summary>
        /// <param name="userStudent"> student to be awarded for schoarship. </param>
        public void AddStudentToScholarship(IUser userStudent)
        {
            this.StudentsToAward.Add(userStudent);
        }

        /// <summary>
        /// adds an application to this scholarship object only if the application isn't a student that has applied before.
        /// </summary>
        /// <param name="application"> the application tied to a student. </param>
        /// <returns> true if student has not applied to scholarship otherwise false. </returns>
        public bool AddApplication(Application application)
        {
            if (this.StudentApplications.Find((existingApplication) => existingApplication.Student == application.Student) == null)
            {
                this.StudentApplications.Add(application);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the time of scolarship ending and the current to check if the scholarship is over.
        /// </summary>
        /// <returns> true when scholarship is still active otherwise false. </returns>
        public bool IsActive()
        {
            return DateTime.Now.Ticks <= this.EndDate.Ticks;
        }

        /// <summary>
        /// using the DateTime of now and the endate calculate the number of days left.
        /// </summary>
        /// <returns> days left of scholarship. </returns>
        public int DaysLeft()
        {
            DateTime newTime = new DateTime(DateTime.Now.Ticks);
            int dayCount = 0;

            while (newTime.Ticks < this.EndDate.Ticks)
            {
                dayCount++;
                newTime = newTime.AddDays(1);
            }

            return dayCount;
        }
    }
}
