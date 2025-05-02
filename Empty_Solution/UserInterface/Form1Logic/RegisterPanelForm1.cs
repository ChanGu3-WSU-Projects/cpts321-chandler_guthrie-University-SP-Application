// <copyright file="RegisterPanelForm1.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    /// <summary>
    /// the register panel portion of the form logic.
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// holds info about the user question and answer control objects. (To dispose of later).
        /// </summary>
        private List<(Control?, Control?)> userSpecificPairs = new List<(Control?, Control?)>();

        /// <summary>
        /// clears any user fields from the register panel.
        /// </summary>
        private void ClearUserFieldFromRegister()
        {
            foreach ((Control?, Control?) userControlPair in this.userSpecificPairs)
            {
                if (userControlPair.Item1 is not null)
                {
                    userControlPair.Item1.Dispose();
                }

                if (userControlPair.Item2 is not null)
                {
                    userControlPair.Item2.Dispose();
                }
            }

            this.userSpecificPairs.Clear();
            this.buttonRegisterRegister.Location = new Point(775, 400);
            this.buttonRegisterCancel.Location = new Point(792, 450);
        }

        /// <summary>
        /// add the donor fields to the register panel.
        /// </summary>
        private void AddUserDonorFieldsToRegister()
        {
            Control item1;
            Control item2;
            ComboBox newComboBox;

            // Company
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(600, 390), new Size(40, 20), "labelRegisterCompany", "Company:");
            item2 = WinformObjects.CreateTextBoxLocalToParent(this.panelRegister, new Point(725, 390), new Size(220, 23), "textBoxRegisterCompany");
            this.userSpecificPairs.Add((item1, item2));

            // Credit Card Info
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(600, 430), new Size(563, 430), "labelRegisterCreditCardInfo", "Credit Card Info:");
            this.userSpecificPairs.Add((item1, null));

            // credit card info field
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(700, 470), new Size(40, 20), "labelRegisterCardNumber", "Card Number:");
            item2 = WinformObjects.CreateTextBoxLocalToParent(this.panelRegister, new Point(870, 470), new Size(220, 23), "textBoxRegisterCardNumber");
            this.userSpecificPairs.Add((item1, item2));

            // credit card info field
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(700, 510), new Size(40, 20), "labelRegisterNameOnCard", "Name On Card:");
            item2 = WinformObjects.CreateTextBoxLocalToParent(this.panelRegister, new Point(870, 510), new Size(220, 23), "textBoxRegisterNameOnCard");
            this.userSpecificPairs.Add((item1, item2));

            // credit card info field
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(700, 550), new Size(40, 20), "labelRegisterAddress", "Address:");
            item2 = WinformObjects.CreateTextBoxLocalToParent(this.panelRegister, new Point(870, 550), new Size(220, 23), "textBoxRegisterAddress");
            this.userSpecificPairs.Add((item1, item2));

            // credit card info field
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(700, 590), new Size(40, 20), "labelRegisterCountry", "Country:");
            item2 = WinformObjects.CreateTextBoxLocalToParent(this.panelRegister, new Point(870, 590), new Size(220, 23), "textBoxRegisterCountry");
            this.userSpecificPairs.Add((item1, item2));

            // credit card info field
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(700, 630), new Size(40, 20), "labelRegisterCVV", "CVV:");
            item2 = WinformObjects.CreateTextBoxLocalToParent(this.panelRegister, new Point(870, 630), new Size(220, 23), "textBoxRegisterCVV");
            this.userSpecificPairs.Add((item1, item2));

            // credit card info field
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(700, 670), new Size(40, 20), "labelRegisterExpDate", "ExpDate:");
            item2 = WinformObjects.CreateTextBoxLocalToParent(this.panelRegister, new Point(870, 670), new Size(220, 23), "textBoxRegisterExpDate");
            this.userSpecificPairs.Add((item1, item2));

            // Settings
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(600, 710), new Size(563, 430), "labelRegisterSettings", "Settings:");
            this.userSpecificPairs.Add((item1, null));

            // settings field
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(700, 750), new Size(40, 20), "labelRegisterIsAnonymousName", "Anonymous Name:");
            newComboBox = WinformObjects.CreateComboBoxLocalToParent(this.panelRegister, new Point(870, 750), new Size(220, 23), "textBoxRegisterExpDate");
            newComboBox.Items.Add("True");
            newComboBox.Items.Add("False");
            this.userSpecificPairs.Add((item1, newComboBox));

            // settings field
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(700, 790), new Size(40, 20), "labelRegisterExpDate", "ExpDate:");
            newComboBox = WinformObjects.CreateComboBoxLocalToParent(this.panelRegister, new Point(870, 790), new Size(220, 23), "textBoxRegisterExpDate");
            newComboBox.Items.Add("True");
            newComboBox.Items.Add("False");
            this.userSpecificPairs.Add((item1, newComboBox));

            this.buttonRegisterRegister.Location = new Point(775, 400 + (11 * 40));
            this.buttonRegisterCancel.Location = new Point(792, 450 + +(11 * 40));
        }

        /// <summary>
        /// add the student fields to the register panel.
        /// </summary>
        private void AddUserStudentFieldToRegister()
        {
            Control item1;
            Control item2;
            ComboBox newComboBox;

            // WSU ID
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(600, 390), new Size(40, 20), "labelRegisterWSUID", "*WSU ID:");
            item2 = WinformObjects.CreateTextBoxLocalToParent(this.panelRegister, new Point(725, 390), new Size(220, 23), "textBoxRegisterWSUID");
            this.userSpecificPairs.Add((item1, item2));

            // AddClub
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(600, 430), new Size(40, 20), "labelRegisterClubAdd", "Clubs Left (Add):");
            newComboBox = WinformObjects.CreateComboBoxLocalToParent(this.panelRegister, new Point(820, 430), new Size(220, 23), "comboBoxClubAdd");
            this.userSpecificPairs.Add((item1, newComboBox));

            foreach (string clubName in this.controllerManager.GetNameOfClubs())
            {
                newComboBox.Items.Add($"{clubName}");
            }

            // RemoveClub
            item1 = WinformObjects.CreateLabelLocalToParent(this.panelRegister, new Point(600, 470), new Size(40, 20), "labelRegisterClubRemove", "Your Clubs (Remove):");
            newComboBox = WinformObjects.CreateComboBoxLocalToParent(this.panelRegister, new Point(820, 470), new Size(220, 23), "comboBoxClubRemove");
            this.userSpecificPairs.Add((item1, newComboBox));

            item1 = WinformObjects.CreateButtonLocalToParent(this.panelRegister, new Point(1050, 430), new Size(20, 20), "buttonRegisterClubAdd", "+", new List<EventHandler>() { this.OnAddClubClick! });
            item2 = WinformObjects.CreateButtonLocalToParent(this.panelRegister, new Point(1050, 470), new Size(20, 20), "buttonRegisterClubRemove", "-", new List<EventHandler>() { this.OnRemoveClubClick! });

            this.userSpecificPairs.Add((item1, item2));

            this.buttonRegisterRegister.Location = new Point(775, 400 + (3 * 40));
            this.buttonRegisterCancel.Location = new Point(792, 450 + +(3 * 40));
        }

        /// <summary>
        /// user add a club to possible clubs.
        /// </summary>
        /// <param name="sender"> comboboxAdd. </param>
        /// <param name="e"> arguments. </param>
        private void OnAddClubClick(object sender, EventArgs e)
        {
            ComboBox comboBoxAddClub = (this.userSpecificPairs[1].Item2 as ComboBox)!;
            ComboBox comboBoxRemoveClub = (this.userSpecificPairs[2].Item2 as ComboBox)!;

            if (comboBoxAddClub.Text == string.Empty)
            {
                return;
            }

            comboBoxRemoveClub.Items.Add(comboBoxAddClub.Text);
            comboBoxAddClub.Items.Remove(comboBoxAddClub.Text);
        }

        /// <summary>
        /// user removes a club to possible clubs.
        /// </summary>
        /// <param name="sender"> comboboxAdd. </param>
        /// <param name="e"> arguments. </param>
        private void OnRemoveClubClick(object sender, EventArgs e)
        {
            ComboBox comboBoxAddClub = (this.userSpecificPairs[1].Item2 as ComboBox)!;
            ComboBox comboBoxRemoveClub = (this.userSpecificPairs[2].Item2 as ComboBox)!;

            if (comboBoxRemoveClub.Text == string.Empty)
            {
                return;
            }

            comboBoxAddClub.Items.Add(comboBoxRemoveClub.Text);
            comboBoxRemoveClub.Items.Remove(comboBoxRemoveClub.Text);
        }

        /// <summary>
        /// when user complete registeration and click the button for complete register.
        /// </summary>
        /// <param name="sender"> register panel resgiter button. </param>
        /// <param name="e"> arguments. </param>
        private void OnCompleteRegisterClick(object sender, EventArgs e)
        {
            switch (this.comboBoxRegisterUserType.Text)
            {
                case "Student":
                    List<string> clubNamesToAdd = new List<string>();
                    for (int i = 0; i < (this.userSpecificPairs[2].Item2! as ComboBox)!.Items.Count; i++)
                    {
                        clubNamesToAdd.Add((string)(this.userSpecificPairs[2].Item2! as ComboBox)!.Items[i]!);
                    }

                    if (!this.controllerManager.CreateStudentUser(
                        this.textBoxRegisterUsername.Text,
                        this.textBoxRegisterPassword.Text,
                        this.textBoxRegisterName.Text,
                        this.textBoxRegisterEmail.Text,
                        this.textBoxRegisterAddress.Text,
                        this.userSpecificPairs[0].Item2!.Text,
                        clubNamesToAdd))
                    {
                        this.OpenPopUp(this.panelRegisterRequired);
                        this.panelRegister.Enabled = false;
                        return;
                    }

                    break;
                case "Donor":
                    if (!this.controllerManager.CreateDonorUserInfo(
                        this.textBoxRegisterUsername.Text,
                        this.textBoxRegisterPassword.Text,
                        this.textBoxRegisterName.Text,
                        this.textBoxRegisterEmail.Text,
                        this.textBoxRegisterAddress.Text,
                        this.userSpecificPairs[0].Item2!.Text,
                        this.userSpecificPairs[2].Item2!.Text,
                        this.userSpecificPairs[3].Item2!.Text,
                        this.userSpecificPairs[4].Item2!.Text,
                        this.userSpecificPairs[5].Item2!.Text,
                        this.userSpecificPairs[6].Item2!.Text,
                        this.userSpecificPairs[7].Item2!.Text,
                        this.userSpecificPairs[9].Item2!.Text == "True",
                        this.userSpecificPairs[10].Item2!.Text == "True"))
                    {
                        this.OpenPopUp(this.panelRegisterRequired);
                        this.panelRegister.Enabled = false;
                        return;
                    }

                    break;
                default:
                    break;
            }

            // not subscribing since it only closes and resets when register is succesful.
            this.OnCloseClick(sender, e);
            this.OnResetRegisterClick(sender, e);
        }

        /// <summary>
        /// when clicking the required ok click sloes the popup.
        /// </summary>
        /// <param name="sender"> register required ok button. </param>
        /// <param name="e"> arguments. </param>
        private void OnRegisterRequiredOkClick(object sender, EventArgs e)
        {
            this.ClosePopUp(this.panelRegisterRequired);
            this.panelRegister.Enabled = true;
        }

        /// <summary>
        /// when user changes the combobox field. add the field corresponding to specific user.
        /// </summary>
        /// <param name="sender"> combobox usertype. </param>
        /// <param name="e"> arguments. </param>
        private void OnComboBoxRegisterUserTypeChanged(object sender, EventArgs e)
        {
            this.ClearUserFieldFromRegister();

            if (sender is not null)
            {
                ComboBox comboBoxSearchType = (ComboBox)sender;

                switch (comboBoxSearchType.Text)
                {
                    case "Student":
                        this.AddUserStudentFieldToRegister();
                        break;
                    case "Donor":
                        this.AddUserDonorFieldsToRegister();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// when the user exits registering. reseting the entire register.
        /// </summary>
        private void OnResetRegisterClick(object sender, EventArgs e)
        {
            this.ClearUserFieldFromRegister();

            this.textBoxRegisterName.Text = string.Empty;
            this.textBoxRegisterAddress.Text = string.Empty;
            this.textBoxRegisterEmail.Text = string.Empty;
            this.textBoxRegisterUsername.Text = string.Empty;
            this.textBoxRegisterPassword.Text = string.Empty;
            this.comboBoxRegisterUserType.SelectedIndex = -1;
            this.comboBoxRegisterUserType.Text = string.Empty;
            this.comboBoxRegisterUserType.SelectedItem = null;
        }
    }
}
