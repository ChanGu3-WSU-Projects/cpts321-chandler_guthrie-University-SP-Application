// <copyright file="ProjectFactory.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// create projects based on its type.
    /// </summary>
    internal static class ProjectFactory
    {
        /// <summary>
        /// using the project class name creates an project instance and returns it.
        /// </summary>
        /// <param name="projectName"> project name of type. </param>
        /// <param name="name"> project name. </param>
        /// <param name="description"> project description. </param>
        /// <param name="targetAmount"> project target amount. </param>
        /// <param name="startDate"> project start date. </param>
        /// <param name="endDate"> project end date. </param>
        /// <returns> instance of a new project with the project type name. </returns>
        /// <exception cref="NotSupportedException"> when operator accessed is not returned. (should never really reach here). </exception>
        public static Project CreateProject(string projectName, string name, string description, double targetAmount, DateTime startDate, DateTime endDate)
        {
            object[] paramaters = new object[5] { name, description, targetAmount, startDate, endDate };

            object? project = Activator.CreateInstance(ProjectDataDictionary.Data[projectName], paramaters );
            if (project is not null)
            {
                return (project as Project)!;
            }

            throw new NotSupportedException($"Project Type \"{projectName}\" not supported.");
        }
    }
}
