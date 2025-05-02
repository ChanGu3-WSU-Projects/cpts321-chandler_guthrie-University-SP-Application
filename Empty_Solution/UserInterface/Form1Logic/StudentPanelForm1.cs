// <copyright file="StudentPanelForm1.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;
using LogicEngine;

namespace UserInterface
{
    /// <summary>
    /// the Student Panel logic for the Form1.
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// add the student useres projects that they have been apart of.
        /// </summary>
        private void PopulateStudentProjects()
        {
            this.dataGridViewStudentProjects.Rows.Clear();

            foreach (Project studentProject in this.controllerManager.GetStudentUserProjects().ToList())
            {
                this.dataGridViewStudentProjects.Rows.Add(studentProject.Name, $"Donations: {studentProject.Donations.Count}", $"Goal Amount: {studentProject.TargetAmount}", $"Funded: %{(int)studentProject.PercentRaised()}", $"Days Left: {studentProject.DaysLeft()}");
            }
        }

        /// <summary>
        /// resets the answers to the new project panel.
        /// </summary>
        private void ResetNewProjectPanel()
        {
            // reset club selection.
            WinformObjects.HideDisableControlObject(this.labelStudentNewProjectFor);
            WinformObjects.HideDisableControlObject(this.comboBoxStudentNewProjectFor);
            this.comboBoxStudentNewProjectFor.Items.Clear();
            this.comboBoxStudentNewProjectFor.SelectedIndex = -1;
            this.labelStudentNewProjectFor.Text = string.Empty;

            // reset project type selection
            this.comboBoxStudentNewProjectProjectType.Items.Clear();
            this.comboBoxStudentNewProjectProjectType.SelectedIndex = -1;

            // reset the rest of textbox fields
            this.textBoxStudentNewProjectProjectName.Text = string.Empty;
            this.textBoxStudentNewProjectTargetAmount.Text = string.Empty;
            this.textBoxStudentNewProjectStartDate.Text = string.Empty;
            this.textBoxStudentNewProjectEndDate.Text = string.Empty;
            this.richTextBoxStudentNewProjectDescription.Text = string.Empty;
        }

        /// <summary>
        /// goes to the new project panel.
        /// </summary>
        /// <param name="sender"> create new button. </param>
        /// <param name="e"> arguments. </param>
        private void OnStudentCreateNewProjectClick(object sender, EventArgs e)
        {
            this.ResetNewProjectPanel();
            foreach (string projectTypeName in this.controllerManager.GetLoadedProjectTypeNames().ToList())
            {
                this.comboBoxStudentNewProjectProjectType.Items.Add(projectTypeName);
            }

            this.OpenPopUp(this.panelStudentNewProject);
        }

        /// <summary>
        /// create the new project if info is filled.
        /// </summary>
        /// <param name="sender"> create button. </param>
        /// <param name="e"> arguments. </param>
        private void OnStudentNewProjectCreateClick(object sender, EventArgs e)
        {
            if (!this.controllerManager.CreateProject(
                this.textBoxStudentNewProjectProjectName.Text,
                this.richTextBoxStudentNewProjectDescription.Text,
                this.textBoxStudentNewProjectTargetAmount.Text,
                this.textBoxStudentNewProjectEndDate.Text,
                this.comboBoxStudentNewProjectProjectType.Text,
                this.comboBoxStudentNewProjectFor.Text))
            {
                // returns as it did not create project.
                return;
            }

            // refills student projects on success since the new project need to be added to list.
            this.dataGridViewStudentProjects.Rows.Clear();
            this.PopulateStudentProjects();

            // not subscribing since it only closes when register is succesful.
            this.OnCloseClick(sender, e);
        }

        /// <summary>
        /// depending on the type of project creates new selections.
        /// </summary>
        /// <param name="sender"> combobox project type. </param>
        /// <param name="e"> arguments. </param>
        private void OnStudentNewProjectProjectTypeChanged(object sender, EventArgs e)
        {
            // clears clubs combobox and club label
            WinformObjects.HideDisableControlObject(this.labelStudentNewProjectFor);
            WinformObjects.HideDisableControlObject(this.comboBoxStudentNewProjectFor);
            this.comboBoxStudentNewProjectFor.Items.Clear();
            this.labelStudentNewProjectFor.Text = string.Empty;

            if (sender is not null)
            {
                ComboBox comboBoxProjectType = (ComboBox)sender;

                switch (comboBoxProjectType.Text)
                {
                    case "IndividualProject":
                        break;
                    case "ClubProject":
                        this.labelStudentNewProjectFor.Text = "Club:";
                        foreach (string clubName in this.controllerManager.GetStudentsClubNames())
                        {
                            this.comboBoxStudentNewProjectFor.Items.Add($"{clubName}");
                        }

                        WinformObjects.UnHideEnableControlObject(this.labelStudentNewProjectFor);
                        WinformObjects.UnHideEnableControlObject(this.comboBoxStudentNewProjectFor);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
