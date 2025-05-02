// <copyright file="WinformObjects.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace UserInterface
{
    /// <summary>
    /// Create grouped control objects relative to another control object.
    /// (Note: may Be empty due to me finding another way).
    /// </summary>
    internal static class WinformObjects
    {
        /// <summary>
        /// hides and disables a control object.
        /// </summary>
        /// <param name="controlObject"> control object in windform. </param>
        public static void HideDisableControlObject(Control controlObject)
        {
            controlObject.Visible = false;
            controlObject.Enabled = false;
        }

        /// <summary>
        /// unhides and enables a control object.
        /// </summary>
        /// <param name="controlObject"> control object in windform. </param>
        public static void UnHideEnableControlObject(Control controlObject)
        {
            controlObject.Visible = true;
            controlObject.Enabled = true;
        }

        /// <summary>
        /// sets the parent of the controlobject to the forms.
        /// </summary>
        /// <param name="controlNewParent"> new control parent of control child. </param>
        /// <param name="controlChild"> Control wanting to change child to controlnewparent. </param>
        public static void SetNewParentForControlChild(Control controlNewParent, Control controlChild)
        {
            if (controlChild.Parent is not null)
            {
                controlChild.Parent.Controls.Remove(controlChild);
                controlNewParent.Controls.Add(controlChild);
            }
            else
            {
                controlNewParent.Controls.Add(controlChild);
            }
        }

        /// <summary>
        /// create a new combobox local to a parent control.
        /// </summary>
        /// <param name="localParent"> parent of the new control object. </param>
        /// <param name="localPoint"> parents point and act as the new origin. </param>
        /// <param name="comboboxSize"> size of the textbox. </param>
        /// <param name="comboboxName"> name of the combobox. </param>
        /// <returns> the new combobox. </returns>
        public static ComboBox CreateComboBoxLocalToParent(Control localParent, Point localPoint, Size comboboxSize, string comboboxName)
        {
            ComboBox newComboBox = new ComboBox();
            newComboBox.FormattingEnabled = true;
            newComboBox.Name = comboboxName;
            newComboBox.Size = comboboxSize;
            newComboBox.TabIndex = 6;
            newComboBox.Location = new Point(localPoint.X, localPoint.Y);
            newComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            WinformObjects.SetNewParentForControlChild(localParent, newComboBox);

            return newComboBox;
        }

        /// <summary>
        /// create a new textbox local to a parent control.
        /// </summary>
        /// <param name="localParent"> parent of the new control object. </param>
        /// <param name="localPoint"> parents point and act as the new origin. </param>
        /// <param name="textboxSize"> size of the textbox. </param>
        /// <param name="textboxName"> name of the textbox. </param>
        /// <returns> the new textbox. </returns>
        public static TextBox CreateTextBoxLocalToParent(Control localParent, Point localPoint, Size textboxSize, string textboxName)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Name = textboxName;
            newTextBox.Size = textboxSize;
            newTextBox.TabIndex = 5;
            newTextBox.Location = new Point(localPoint.X, localPoint.Y);
            WinformObjects.SetNewParentForControlChild(localParent, newTextBox);

            return newTextBox;
        }

        /// <summary>
        /// create a new label local to a parent control.
        /// </summary>
        /// <param name="localParent"> parent of the new control object. </param>
        /// <param name="localPoint"> parents point and act as the new origin. </param>
        /// <param name="labelSize"> size of the label. </param>
        /// <param name="labelName"> name of the label. </param>
        /// <param name="text"> the text of the label. </param>
        /// <returns> the new label. </returns>
        public static Label CreateLabelLocalToParent(Control localParent, Point localPoint, Size labelSize, string labelName, string text)
        {
            Label newLabel = new Label();
            newLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            newLabel.AutoSize = true;
            newLabel.Name = labelName;
            newLabel.Size = labelSize;
            newLabel.TabIndex = 7;
            newLabel.Text = text;
            newLabel.Location = new Point(localPoint.X, localPoint.Y);
            WinformObjects.SetNewParentForControlChild(localParent, newLabel);

            return newLabel;
        }

        /// <summary>
        /// create a new button local to a parent control.
        /// </summary>
        /// <param name="localParent"> parent of the new control object. </param>
        /// <param name="localPoint"> parents point and act as the new origin. </param>
        /// <param name="buttonSize"> size of the button. </param>
        /// <param name="buttonName"> name of the button. </param>
        /// <param name="buttonText"> the text of the button. </param>
        /// <param name="listeners"> listeners wanting to add to button upon creation. </param>
        /// <returns> the new button. </returns>
        public static Button CreateButtonLocalToParent(Control localParent, Point localPoint, Size buttonSize, string buttonName, string buttonText, List<EventHandler> listeners)
        {
            Button newButton = new Button();
            newButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            newButton.AutoSize = true;
            newButton.Font = new Font("Segoe UI", 9F);
            newButton.MaximumSize = buttonSize;
            newButton.Name = buttonName;
            newButton.Size = buttonSize;
            newButton.TabIndex = 5;
            newButton.Text = buttonText;
            newButton.UseVisualStyleBackColor = true;
            foreach (EventHandler listener in listeners)
            {
                newButton.Click += listener;
            }

            newButton.Location = new Point(localPoint.X, localPoint.Y);
            WinformObjects.SetNewParentForControlChild(localParent, newButton);

            return newButton;
        }
    }
}
