// <copyright file="StudentLogic.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicEngine
{
    /// <summary>
    /// student specific logic.
    /// </summary>
    internal static class StudentLogic
    {
        /// <summary>
        /// Gets all the club names the student has from the Database.
        /// </summary>
        /// <param name="database"> database where clubs exist. </param>
        /// <param name="userStudent"> user to check. </param>
        /// <returns> gets the current existing clubs names. </returns>
        public static IEnumerable<string> GetMemberedClubNames(Database database, IUser userStudent)
        {
            IUser? studentInClub = null;
            return database.GetAllClubNames().Where(
                (clubname) => database.GetClubByName(clubname)!.CurrentMembers.TryGetValue(userStudent.Username, out studentInClub));
        }

        /// <summary>
        /// gets list of student applied scholarships.
        /// </summary>
        /// <param name="database"> database to search for scholarships. </param>
        /// <param name="currentUser"> user to match scholarships applied. </param>
        /// <returns> student applied scholarships. </returns>
        public static IEnumerable<Scholarship> GetStudentScholarships(Database database, IUser currentUser)
        {
            return database.Scholarships.Where(
                (scholarship) => scholarship.StudentApplications.Find(
                    (application) => application.Student.Username == currentUser.Username) != null);
        }

        /// <summary>
        /// get a student users projects.
        /// </summary>
        /// <param name="database"> database to search for project. </param>
        /// <param name="currentUser">  user to match projects participated. </param>
        /// <returns> student user projects. </returns>
        public static IEnumerable<Project> GetStudentUserProjects(Database database, IUser currentUser)
        {
            return database.Projects.Where(
                (project) => project.GetMemberByUsername(currentUser.Username) != null);
        }

        /// <summary>
        /// create student from registration information.
        /// </summary>
        /// <param name="username"> new student username. </param>
        /// <param name="password"> new student password. </param>
        /// <param name="fullname"> new student fullname. </param>
        /// <param name="email"> new student email. </param>
        /// <param name="address"> new student address. </param>
        /// <param name="wsuid"> new student wsuid. </param>
        /// <param name="clubNamesToAdd"> club names that student is apart of. </param>
        /// <param name="database"> database to add new student. </param>
        /// <returns> true if user is create false if not. </returns>
        public static bool CreateStudentUser(string username, string password, string fullname, string email, string address, string wsuid, List<string> clubNamesToAdd, ref Database database)
        {
            // strings empty
            if (username == string.Empty ||
                password == string.Empty ||
                fullname == string.Empty ||
                email == string.Empty ||
                address == string.Empty ||
                wsuid == string.Empty)
            {
                return false;
            }

            try
            {
                UserStudent newUserStudent = new UserStudent(username, password, fullname, email, address, wsuid);
                database.AddUser(newUserStudent);
                foreach (string clubName in clubNamesToAdd)
                {
                    if (database.GetClubByName(clubName) == null)
                    {
                        throw new NullReferenceException("club is not in database");
                    }

                    database.GetClubByName(clubName)!.AddMember(newUserStudent);
                }

                return true;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }

        /// <summary>
        /// saves information from student profile to user.
        /// </summary>
        /// <param name="password"> possible new password. </param>
        /// <param name="name"> possible new name. </param>
        /// <param name="email"> possible new email. </param>
        /// <param name="address"> possible new address. </param>
        /// <param name="wsuid"> possible new wsuid. </param>
        /// <param name="clubNamesToAdd"> possible clubs joined. </param>
        /// <param name="clubNamesToRemove"> possible clubs left. </param>
        /// <param name="database"> database to find clubs to add and remove. </param>
        /// <param name="currentUser"> user to save info. </param>
        public static void SaveStudentUserInfo(string password, string name, string email, string address, string wsuid, List<string> clubNamesToAdd, List<string> clubNamesToRemove, ref Database database, ref IUser currentUser)
        {
            GeneralLogic.SaveGeneralUserInfo(ref currentUser, password, name, email, address);
            UserStudent studentUser = (UserStudent)currentUser;
            studentUser.WSUID = wsuid;

            foreach (string clubName in clubNamesToRemove)
            {
                if (database.GetClubByName(clubName) == null)
                {
                    throw new NullReferenceException("club is not in database");
                }

                // if user is in club then remove.
                if (database.GetClubByName(clubName)!.CurrentMembers.ContainsValue(studentUser))
                {
                    database.GetClubByName(clubName)!.RemoveMember(studentUser);
                }
            }

            foreach (string clubName in clubNamesToAdd)
            {
                if (database.GetClubByName(clubName) == null)
                {
                    throw new NullReferenceException("club is not in database");
                }

                // if user isnt already a member of the club.
                if (!database.GetClubByName(clubName)!.CurrentMembers.ContainsValue(studentUser))
                {
                    database.GetClubByName(clubName)!.AddMember(studentUser);
                }
            }
        }

        /// <summary>
        /// creating a project as a student.
        /// </summary>
        /// <param name="database"> database to add project to and find club. </param>
        /// <param name="currentUser"> user to add to new project. </param>
        /// <param name="name"> name of new project. </param>
        /// <param name="description"> decription of new project. </param>
        /// <param name="targetAmount"> target amount of new project.</param>
        /// <param name="endDate"> endtime of new project.</param>
        /// <param name="projectTypeName"> project name type for new project. </param>
        /// <param name="clubName"> !optional! club type of a club new project.</param>
        /// <returns> true if project created otherwise something went wrong. </returns>
        public static bool CreateProject(ref Database database, IUser currentUser, string name, string description, string targetAmount, string endDate, string projectTypeName, string clubName)
        {
            // make sure endtime is in right format
            Regex regexEndDate = new Regex("(\\d\\d)/(\\d\\d)/(\\d\\d)");
            Match matchEndDate = regexEndDate.Match(endDate);

            // make sure targetamount is only a (positive)number
            Regex regexTargetAmount = new Regex("([\\d]+)");
            Match matchTargetAmount = regexTargetAmount.Match(targetAmount);

            // using regex does checks and makes sure entries aren't empty
            if (projectTypeName == string.Empty ||
                name == string.Empty ||
                targetAmount == string.Empty ||
                endDate == string.Empty ||
                description == string.Empty ||
                (matchEndDate.Groups[0].Value != endDate) ||
                (matchTargetAmount.Groups[0].Value != targetAmount))
            {
                return false;
            }

            // club has to be selected if its a club project.
            if (projectTypeName == "ClubProject")
            {
                if (clubName == string.Empty)
                {
                    return false;
                }
                else
                {
                    if (database.GetClubByName(clubName) == null)
                    {
                        throw new NullReferenceException("club does not exist in database");
                    }
                }
            }

            DateTime endTime;

            try
            {
                endTime = new DateTime(Convert.ToInt32("20" + matchEndDate.Groups[3].Value), Convert.ToInt32(matchEndDate.Groups[1].Value), Convert.ToInt32(matchEndDate.Groups[2].Value), 23, 59, 59);
            }
            catch
            {
                return false;
            }

            // if end date is a date already passed.
            if (endTime.Ticks <= DateTime.Now.Ticks)
            {
                return false;
            }

            // creates project
            Project project = ProjectFactory.CreateProject(
                    projectTypeName,
                    name,
                    description,
                    Convert.ToDouble(targetAmount),
                    new DateTime(DateTime.Now.Ticks),
                    endTime);

            // depending on if a clubName was presented then its a clubProject which is different from normal projects.
            if (clubName != string.Empty && projectTypeName == "ClubProject")
            {
                database.GetClubByName(clubName)!.AddClubProject((ClubProject)project);
            }
            else
            {
                project.AddMemberToProject(currentUser);
            }

            // adds project to database
            database.Projects.Insert(0, project);

            return true;
        }

        /// <summary>
        /// takes current user that is a student and creates a application to apply to a scholarship.
        /// </summary>
        /// <param name="criteriaToAnswer"> answers to the criteria. </param>
        /// <param name="scholarship"> the scholarship being applied to. </param>
        /// <param name="currentUser"> user creating the application. </param>
        /// <returns> true if application is successfull or not. </returns>
        public static bool CreateApplication(Dictionary<Criteria, string> criteriaToAnswer, ref Scholarship scholarship, ref IUser currentUser)
        {
            foreach (string answer in criteriaToAnswer.Values)
            {
                if (answer == string.Empty)
                {
                    return false;
                }
            }

            if (criteriaToAnswer.Count != scholarship.Criteria.Count)
            {
                throw new ArgumentException("too few or too many criteria answers compared to expected criteria answers");
            }

            int criteriaIndex = 0;
            foreach (Criteria criteria in criteriaToAnswer.Keys)
            {
                if ((object)criteria != (object)scholarship.Criteria[criteriaIndex])
                {
                    return false;
                }

                criteriaIndex++;
            }

            return scholarship.AddApplication(new Application(currentUser, criteriaToAnswer));
        }

        /// <summary>
        /// gets the current users student WSUID for the application.
        /// </summary>
        /// <param name="user"> studentuser retrieving data from. </param>
        /// <returns> the student users WSUID. </returns>
        public static string GetStudentUsersWSUID(IUser user)
        {
            return ((UserStudent)user).WSUID;
        }
    }
}
