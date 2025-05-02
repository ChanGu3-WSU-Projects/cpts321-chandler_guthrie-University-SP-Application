// <copyright file="ProfilePanelForm1.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System.Text;
using LogicEngine;

namespace UserInterface
{
    /// <summary>
    /// the Profile panel of Form1.
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// sets the profile info to nothing.
        /// </summary>
        private void ResetPanelProfileInfo()
        {
            WinformObjects.HideDisableControlObject(this.panelProfileStudent);
            WinformObjects.HideDisableControlObject(this.panelProfileDonor);

            if (this.controllerManager.CurrentUserState == UserState.GUEST)
            {
            }
            else if (this.controllerManager.CurrentUserState == UserState.STUDENT)
            {
                this.ResetStudentProfileInfo();
            }
            else if (this.controllerManager.CurrentUserState == UserState.DONOR)
            {
                this.ResetDonorProfileInfo();
            }

            this.textBoxProfileFullName.Text = string.Empty;
            this.textBoxProfileAddress.Text = string.Empty;
            this.textBoxProfileEmail.Text = string.Empty;
            this.textBoxProfileUsername.Text = string.Empty;
        }

        /// <summary>
        /// set the student profile info to nothing.
        /// </summary>
        private void ResetStudentProfileInfo()
        {
            this.textBoxProfileStudentWSUID.Text = string.Empty;
            this.comboBoxProfileStudentClubsNotIn.Items.Clear();
            this.comboBoxProfileStudentClubsIn.Items.Clear();
            this.dataGridViewProfileStudentScholarships.Rows.Clear();
        }

        /// <summary>
        /// set the donor profile info to nothing.
        /// </summary>
        private void ResetDonorProfileInfo()
        {
            this.textBoxProfileCompany.Text = string.Empty;
            this.textBoxProfileCCICardNumber.Text = string.Empty;
            this.textBoxProfileCCINameOnCard.Text = string.Empty;
            this.textBoxProfileCCIAddress.Text = string.Empty;
            this.textBoxProfileCCICountry.Text = string.Empty;
            this.textBoxProfileCCICVV.Text = string.Empty;
            this.textBoxProfileCCIExpDate.Text = string.Empty;
            this.comboBoxProfileDSDefaultNameAnonymous.SelectedIndex = -1;
            this.comboBoxProfileDSDefaultAmountAnonymous.SelectedIndex = -1;
        }

        /// <summary>
        /// adds user profile info.
        /// </summary>
        private void PopulateGeneralProfileInfo()
        {
            this.textBoxProfileFullName.Text = this.controllerManager.GetUsersFullName();
            this.textBoxProfileAddress.Text = this.controllerManager.GetUsersAddress();
            this.textBoxProfileEmail.Text = this.controllerManager.GetUsersEmail();
            this.textBoxProfileUsername.Text = this.controllerManager.GetUsersUsername();
            this.textBoxProfilePassword.Text = this.controllerManager.GetUsersPassword();
        }

        /// <summary>
        /// adds student user profile info.
        /// </summary>
        private void PopulateStudentProfileInfo()
        {
            this.PopulateGeneralProfileInfo();

            this.textBoxProfileStudentWSUID.Text = this.controllerManager.GetStudentUsersWSUID();

            foreach (string clubName in this.controllerManager.GetNameOfClubs())
            {
                if (!this.controllerManager.GetStudentsClubNames().ToList().Contains(clubName))
                {
                    this.comboBoxProfileStudentClubsNotIn.Items.Add($"{clubName}");
                }
            }

            foreach (string clubName in this.controllerManager.GetStudentsClubNames())
            {
                this.comboBoxProfileStudentClubsIn.Items.Add($"{clubName}");
            }

            foreach (Scholarship scholarship in this.controllerManager.GetStudentScholarships().ToList())
            {
                string awardedText = string.Empty;
                if (scholarship.Awarded == true)
                {
                    awardedText = $"Awarded";
                }
                else
                {
                    awardedText = $"NotAwarded";
                }

                int numStudents = 0;
                StringBuilder studentList = new StringBuilder(string.Empty);
                foreach (IUser user in scholarship.StudentsToAward)
                {
                    studentList.Append($"- {user.FullName}{Environment.NewLine}");
                    numStudents++;
                }

                int newRowIndex = this.dataGridViewProfileStudentScholarships.Rows.Add(
                    $"{scholarship.Name}",
                    $"{awardedText}",
                    $"{studentList}");

                // When more students increase row height.
                if (numStudents != 0)
                {
                    this.dataGridViewProfileStudentScholarships.Rows[newRowIndex].Height = 20 + ((numStudents - 1) * 12);
                }
            }

            this.buttonProfileSaveChanges.Enabled = false;
        }

        /// <summary>
        /// adds donor user profile info.
        /// </summary>
        private void PopulateDonorProfileInfo()
        {
            this.PopulateGeneralProfileInfo();
            this.textBoxProfileCompany.Text = this.controllerManager.GetDonorUsersCompanyName();
            this.textBoxProfileCCICardNumber.Text = this.controllerManager.GetDonorUsersCIICardNumber();
            this.textBoxProfileCCINameOnCard.Text = this.controllerManager.GetDonorUsersCCINameOnCard();
            this.textBoxProfileCCIAddress.Text = this.controllerManager.GetDonorUsersCCIAddress();
            this.textBoxProfileCCICountry.Text = this.controllerManager.GetDonorUsersCCICountry();
            this.textBoxProfileCCICVV.Text = this.controllerManager.GetDonorUsersCCICVV();
            this.textBoxProfileCCIExpDate.Text = this.controllerManager.GetDonorUsersCCIEXPDate();

            if (this.controllerManager.GetIsDonorUsersDSNameAnonymous())
            {
                this.comboBoxProfileDSDefaultNameAnonymous.Text = "True";
            }
            else
            {
                this.comboBoxProfileDSDefaultNameAnonymous.Text = "False";
            }

            if (this.controllerManager.GetIsDonorUsersDSAmountAnonymous())
            {
                this.comboBoxProfileDSDefaultAmountAnonymous.Text = "True";
            }
            else
            {
                this.comboBoxProfileDSDefaultAmountAnonymous.Text = "False";
            }

            this.buttonProfileSaveChanges.Enabled = false;
        }

        /// <summary>
        /// adds club to user clubs.
        /// </summary>
        /// <param name="sender"> add button. </param>
        /// <param name="e"> arguments. </param>
        private void OnProfileStudentAddClubClick(object sender, EventArgs e)
        {
            // when there is no selection cant add club
            if (this.comboBoxProfileStudentClubsNotIn.Text == string.Empty || this.comboBoxProfileStudentClubsNotIn.SelectedIndex == -1)
            {
                return;
            }

            this.comboBoxProfileStudentClubsIn.Items.Add(this.comboBoxProfileStudentClubsNotIn.Text);
            this.comboBoxProfileStudentClubsNotIn.Items.Remove(this.comboBoxProfileStudentClubsNotIn.Text);
            this.comboBoxProfileStudentClubsNotIn.SelectedIndex = -1;

            this.buttonProfileSaveChanges.Enabled = true;
        }

        /// <summary>
        /// removes club from user clubs.
        /// </summary>
        /// <param name="sender"> remove button. </param>
        /// <param name="e"> arguments. </param>
        private void OnProfileStudentRemoveClubClick(object sender, EventArgs e)
        {
            // when there is no selection cant remove club
            if (this.comboBoxProfileStudentClubsIn.Text == string.Empty || this.comboBoxProfileStudentClubsIn.SelectedIndex == -1)
            {
                return;
            }

            this.comboBoxProfileStudentClubsNotIn.Items.Add(this.comboBoxProfileStudentClubsIn.Text);
            this.comboBoxProfileStudentClubsIn.Items.Remove(this.comboBoxProfileStudentClubsIn.Text);
            this.comboBoxProfileStudentClubsIn.SelectedIndex = -1;

            this.buttonProfileSaveChanges.Enabled = true;
        }

        /// <summary>
        /// profile texts changed.
        /// </summary>
        /// <param name="sender"> profile textbox. </param>
        /// <param name="e"> arguments. </param>
        private void OnProfileInfoChanged(object sender, EventArgs e)
        {
            this.buttonProfileSaveChanges.Enabled = true;
        }

        /// <summary>
        /// saves the changes of the current profile when button is pressed.
        /// </summary>
        /// <param name="sender"> save changes button. </param>
        /// <param name="e"> arguments. </param>
        private void OnSaveChangesClick(object sender, EventArgs e)
        {
            switch (this.controllerManager.CurrentUserState)
            {
                case UserState.STUDENT:
                    List<string> clubNamesToAdd = new List<string>();
                    for (int i = 0; i < this.comboBoxProfileStudentClubsIn.Items.Count; i++)
                    {
                        clubNamesToAdd.Add((string)this.comboBoxProfileStudentClubsIn.Items[i]!);
                    }

                    List<string> clubNamesToRemove = new List<string>();
                    for (int i = 0; i < this.comboBoxProfileStudentClubsNotIn.Items.Count; i++)
                    {
                        clubNamesToRemove.Add((string)this.comboBoxProfileStudentClubsNotIn.Items[i]!);
                    }

                    this.controllerManager.SaveStudentUserInfo(
                        this.textBoxProfilePassword.Text,
                        this.textBoxProfileFullName.Text,
                        this.textBoxProfileEmail.Text,
                        this.textBoxProfileAddress.Text,
                        this.textBoxProfileStudentWSUID.Text,
                        clubNamesToAdd,
                        clubNamesToRemove);
                    break;
                case UserState.DONOR:
                    this.controllerManager.SaveDonorUserInfo(
                        this.textBoxProfilePassword.Text,
                        this.textBoxProfileFullName.Text,
                        this.textBoxProfileEmail.Text,
                        this.textBoxProfileAddress.Text,
                        this.textBoxProfileCompany.Text,
                        this.textBoxProfileCCICardNumber.Text,
                        this.textBoxProfileCCINameOnCard.Text,
                        this.textBoxProfileCCIAddress.Text,
                        this.textBoxProfileCCICountry.Text,
                        this.textBoxProfileCCICVV.Text,
                        this.textBoxProfileCCIExpDate.Text,
                        this.comboBoxProfileDSDefaultNameAnonymous.Text == "True",
                        this.comboBoxProfileDSDefaultAmountAnonymous.Text == "True");
                    break;
            }

            this.buttonProfileSaveChanges.Enabled = false;
        }

        /// <summary>
        /// logging out of profile.
        /// </summary>
        /// <param name="sender"> logout button. </param>
        /// <param name="e"> arguments. </param>
        private void OnProfileLogoutClick(object sender, EventArgs e)
        {
            this.controllerManager.Logout();

            // send to login page.
            WinformObjects.HideDisableControlObject(this.currentPanel);
            this.currentPanel = this.panelLogin;
            this.ResetPanelProfileInfo();
            WinformObjects.UnHideEnableControlObject(this.panelLogin);
        }
    }
}
