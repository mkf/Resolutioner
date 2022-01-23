﻿namespace Resolutioner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.desiredWidthField = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.desiredHeightField = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.restoreHeightField = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.restoreWidthField = new System.Windows.Forms.NumericUpDown();
            this.swapResolutionsButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.nowDesiredButton = new System.Windows.Forms.Button();
            this.nowRestoreButton = new System.Windows.Forms.Button();
            this.loginCheckBox = new System.Windows.Forms.CheckBox();
            this.switchCheckBox = new System.Windows.Forms.CheckBox();
            this.logoffCheckBox = new System.Windows.Forms.CheckBox();
            this.shutdownCheckBox = new System.Windows.Forms.CheckBox();
            this.stateConfigSavedCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.desiredWidthField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.desiredHeightField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoreHeightField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoreWidthField)).BeginInit();
            this.SuspendLayout();
            // 
            // desiredWidthField
            // 
            this.desiredWidthField.Location = new System.Drawing.Point(91, 74);
            this.desiredWidthField.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.desiredWidthField.Minimum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.desiredWidthField.Name = "desiredWidthField";
            this.desiredWidthField.Size = new System.Drawing.Size(240, 39);
            this.desiredWidthField.TabIndex = 0;
            this.desiredWidthField.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desired resolution for own use";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "width";
            // 
            // desiredHeightField
            // 
            this.desiredHeightField.Location = new System.Drawing.Point(91, 117);
            this.desiredHeightField.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.desiredHeightField.Minimum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.desiredHeightField.Name = "desiredHeightField";
            this.desiredHeightField.Size = new System.Drawing.Size(240, 39);
            this.desiredHeightField.TabIndex = 3;
            this.desiredHeightField.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "height";
            // 
            // restoreHeightField
            // 
            this.restoreHeightField.Location = new System.Drawing.Point(507, 117);
            this.restoreHeightField.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.restoreHeightField.Minimum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.restoreHeightField.Name = "restoreHeightField";
            this.restoreHeightField.Size = new System.Drawing.Size(240, 39);
            this.restoreHeightField.TabIndex = 9;
            this.restoreHeightField.Value = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(319, 32);
            this.label6.TabIndex = 7;
            this.label6.Text = "Desired resolution to restore";
            // 
            // restoreWidthField
            // 
            this.restoreWidthField.Location = new System.Drawing.Point(507, 74);
            this.restoreWidthField.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.restoreWidthField.Minimum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.restoreWidthField.Name = "restoreWidthField";
            this.restoreWidthField.Size = new System.Drawing.Size(240, 39);
            this.restoreWidthField.TabIndex = 6;
            this.restoreWidthField.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            // 
            // swapResolutionsButton
            // 
            this.swapResolutionsButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.swapResolutionsButton.Location = new System.Drawing.Point(346, 74);
            this.swapResolutionsButton.Name = "swapResolutionsButton";
            this.swapResolutionsButton.Size = new System.Drawing.Size(76, 77);
            this.swapResolutionsButton.TabIndex = 11;
            this.swapResolutionsButton.Text = "🔁";
            this.swapResolutionsButton.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Resolutioner";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // nowDesiredButton
            // 
            this.nowDesiredButton.Location = new System.Drawing.Point(91, 176);
            this.nowDesiredButton.Name = "nowDesiredButton";
            this.nowDesiredButton.Size = new System.Drawing.Size(150, 46);
            this.nowDesiredButton.TabIndex = 12;
            this.nowDesiredButton.Text = "Now";
            this.nowDesiredButton.UseVisualStyleBackColor = true;
            // 
            // nowRestoreButton
            // 
            this.nowRestoreButton.Location = new System.Drawing.Point(507, 176);
            this.nowRestoreButton.Name = "nowRestoreButton";
            this.nowRestoreButton.Size = new System.Drawing.Size(150, 46);
            this.nowRestoreButton.TabIndex = 13;
            this.nowRestoreButton.Text = "Now";
            this.nowRestoreButton.UseVisualStyleBackColor = true;
            // 
            // loginCheckBox
            // 
            this.loginCheckBox.AutoSize = true;
            this.loginCheckBox.Location = new System.Drawing.Point(47, 271);
            this.loginCheckBox.Name = "loginCheckBox";
            this.loginCheckBox.Size = new System.Drawing.Size(187, 36);
            this.loginCheckBox.TabIndex = 14;
            this.loginCheckBox.Text = "on user login";
            this.loginCheckBox.UseVisualStyleBackColor = true;
            // 
            // switchCheckBox
            // 
            this.switchCheckBox.AutoSize = true;
            this.switchCheckBox.Location = new System.Drawing.Point(47, 313);
            this.switchCheckBox.Name = "switchCheckBox";
            this.switchCheckBox.Size = new System.Drawing.Size(199, 36);
            this.switchCheckBox.TabIndex = 15;
            this.switchCheckBox.Text = "on user switch";
            this.switchCheckBox.UseVisualStyleBackColor = true;
            // 
            // logoffCheckBox
            // 
            this.logoffCheckBox.AutoSize = true;
            this.logoffCheckBox.Location = new System.Drawing.Point(47, 355);
            this.logoffCheckBox.Name = "logoffCheckBox";
            this.logoffCheckBox.Size = new System.Drawing.Size(203, 36);
            this.logoffCheckBox.TabIndex = 16;
            this.logoffCheckBox.Text = "on user logout";
            this.logoffCheckBox.UseVisualStyleBackColor = true;
            // 
            // shutdownCheckBox
            // 
            this.shutdownCheckBox.AutoSize = true;
            this.shutdownCheckBox.Location = new System.Drawing.Point(298, 355);
            this.shutdownCheckBox.Name = "shutdownCheckBox";
            this.shutdownCheckBox.Size = new System.Drawing.Size(267, 36);
            this.shutdownCheckBox.TabIndex = 17;
            this.shutdownCheckBox.Text = "on system shutdown";
            this.shutdownCheckBox.UseVisualStyleBackColor = true;
            // 
            // stateConfigSavedCheckBox
            // 
            this.stateConfigSavedCheckBox.AutoSize = true;
            this.stateConfigSavedCheckBox.Location = new System.Drawing.Point(288, 200);
            this.stateConfigSavedCheckBox.Name = "stateConfigSavedCheckBox";
            this.stateConfigSavedCheckBox.Size = new System.Drawing.Size(188, 36);
            this.stateConfigSavedCheckBox.TabIndex = 18;
            this.stateConfigSavedCheckBox.Text = "Config Saved";
            this.stateConfigSavedCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stateConfigSavedCheckBox);
            this.Controls.Add(this.shutdownCheckBox);
            this.Controls.Add(this.logoffCheckBox);
            this.Controls.Add(this.switchCheckBox);
            this.Controls.Add(this.loginCheckBox);
            this.Controls.Add(this.nowRestoreButton);
            this.Controls.Add(this.nowDesiredButton);
            this.Controls.Add(this.swapResolutionsButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.restoreHeightField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.restoreWidthField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.desiredHeightField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.desiredWidthField);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.desiredWidthField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.desiredHeightField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoreHeightField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoreWidthField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown desiredWidthField;
        private Label label1;
        private Label label2;
        private NumericUpDown desiredHeightField;
        private Label label3;
        private Label label4;
        private NumericUpDown restoreHeightField;
        private Label label5;
        private Label label6;
        private NumericUpDown restoreWidthField;
        private Button swapResolutionsButton;
        private NotifyIcon notifyIcon1;
        private Button nowDesiredButton;
        private Button nowRestoreButton;
        private CheckBox loginCheckBox;
        private CheckBox switchCheckBox;
        private CheckBox logoffCheckBox;
        private CheckBox shutdownCheckBox;
        private CheckBox stateConfigSavedCheckBox;
    }
}