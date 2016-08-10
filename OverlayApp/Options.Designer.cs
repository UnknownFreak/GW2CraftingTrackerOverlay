namespace OverlayApp
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.opacitySlider = new System.Windows.Forms.TrackBar();
            this.opacityLabel = new System.Windows.Forms.Label();
            this.numericOpacity = new System.Windows.Forms.Label();
            this.opacityPanel = new System.Windows.Forms.Panel();
            this.APIKeyPanel = new System.Windows.Forms.Panel();
            this.apiKeyField = new System.Windows.Forms.TextBox();
            this.APIKeyLabel = new System.Windows.Forms.Label();
            this.panelUpdateFrequency = new System.Windows.Forms.Panel();
            this.updateSlider = new System.Windows.Forms.TrackBar();
            this.numericUpdateTime = new System.Windows.Forms.Label();
            this.updateFrequency = new System.Windows.Forms.Label();
            this.overlayMenuBarVisibleOnStart = new System.Windows.Forms.CheckBox();
            this.resetSettings = new System.Windows.Forms.Button();
            this.removeCompletedSubItems = new System.Windows.Forms.CheckBox();
            this.removeCompletedItemList = new System.Windows.Forms.CheckBox();
            this.removeItemProject = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).BeginInit();
            this.opacityPanel.SuspendLayout();
            this.APIKeyPanel.SuspendLayout();
            this.panelUpdateFrequency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // opacitySlider
            // 
            this.opacitySlider.Location = new System.Drawing.Point(6, 16);
            this.opacitySlider.Maximum = 100;
            this.opacitySlider.Minimum = 30;
            this.opacitySlider.Name = "opacitySlider";
            this.opacitySlider.Size = new System.Drawing.Size(430, 45);
            this.opacitySlider.TabIndex = 1;
            this.opacitySlider.TickFrequency = 10;
            this.opacitySlider.Value = 80;
            this.opacitySlider.Scroll += new System.EventHandler(this.OpacityScroll);
            // 
            // opacityLabel
            // 
            this.opacityLabel.AutoSize = true;
            this.opacityLabel.Location = new System.Drawing.Point(3, 0);
            this.opacityLabel.Name = "opacityLabel";
            this.opacityLabel.Size = new System.Drawing.Size(43, 13);
            this.opacityLabel.TabIndex = 2;
            this.opacityLabel.Text = "Opacity";
            // 
            // numericOpacity
            // 
            this.numericOpacity.AutoSize = true;
            this.numericOpacity.Location = new System.Drawing.Point(442, 16);
            this.numericOpacity.Name = "numericOpacity";
            this.numericOpacity.Size = new System.Drawing.Size(27, 13);
            this.numericOpacity.TabIndex = 3;
            this.numericOpacity.Text = "80%";
            // 
            // opacityPanel
            // 
            this.opacityPanel.Controls.Add(this.opacitySlider);
            this.opacityPanel.Controls.Add(this.numericOpacity);
            this.opacityPanel.Controls.Add(this.opacityLabel);
            this.opacityPanel.Location = new System.Drawing.Point(12, 63);
            this.opacityPanel.Name = "opacityPanel";
            this.opacityPanel.Size = new System.Drawing.Size(472, 65);
            this.opacityPanel.TabIndex = 4;
            // 
            // APIKeyPanel
            // 
            this.APIKeyPanel.Controls.Add(this.apiKeyField);
            this.APIKeyPanel.Controls.Add(this.APIKeyLabel);
            this.APIKeyPanel.Location = new System.Drawing.Point(12, 12);
            this.APIKeyPanel.Name = "APIKeyPanel";
            this.APIKeyPanel.Size = new System.Drawing.Size(472, 45);
            this.APIKeyPanel.TabIndex = 5;
            // 
            // apiKeyField
            // 
            this.apiKeyField.Location = new System.Drawing.Point(6, 16);
            this.apiKeyField.Name = "apiKeyField";
            this.apiKeyField.Size = new System.Drawing.Size(463, 20);
            this.apiKeyField.TabIndex = 3;
            this.apiKeyField.TextChanged += new System.EventHandler(this.APIKeyTextChanged);
            // 
            // APIKeyLabel
            // 
            this.APIKeyLabel.AutoSize = true;
            this.APIKeyLabel.Location = new System.Drawing.Point(3, 0);
            this.APIKeyLabel.Name = "APIKeyLabel";
            this.APIKeyLabel.Size = new System.Drawing.Size(40, 13);
            this.APIKeyLabel.TabIndex = 2;
            this.APIKeyLabel.Text = "ApiKey";
            // 
            // panelUpdateFrequency
            // 
            this.panelUpdateFrequency.Controls.Add(this.updateSlider);
            this.panelUpdateFrequency.Controls.Add(this.numericUpdateTime);
            this.panelUpdateFrequency.Controls.Add(this.updateFrequency);
            this.panelUpdateFrequency.Location = new System.Drawing.Point(12, 134);
            this.panelUpdateFrequency.Name = "panelUpdateFrequency";
            this.panelUpdateFrequency.Size = new System.Drawing.Size(472, 65);
            this.panelUpdateFrequency.TabIndex = 5;
            // 
            // updateSlider
            // 
            this.updateSlider.LargeChange = 10;
            this.updateSlider.Location = new System.Drawing.Point(6, 16);
            this.updateSlider.Maximum = 300;
            this.updateSlider.Minimum = 1;
            this.updateSlider.Name = "updateSlider";
            this.updateSlider.Size = new System.Drawing.Size(408, 45);
            this.updateSlider.SmallChange = 5;
            this.updateSlider.TabIndex = 4;
            this.updateSlider.TickFrequency = 60;
            this.updateSlider.Value = 1;
            this.updateSlider.Scroll += new System.EventHandler(this.updateFrequencyScroll);
            // 
            // numericUpdateTime
            // 
            this.numericUpdateTime.AutoSize = true;
            this.numericUpdateTime.Location = new System.Drawing.Point(420, 16);
            this.numericUpdateTime.Name = "numericUpdateTime";
            this.numericUpdateTime.Size = new System.Drawing.Size(49, 13);
            this.numericUpdateTime.TabIndex = 5;
            this.numericUpdateTime.Text = "00:00:00";
            // 
            // updateFrequency
            // 
            this.updateFrequency.AutoSize = true;
            this.updateFrequency.Location = new System.Drawing.Point(3, 0);
            this.updateFrequency.Name = "updateFrequency";
            this.updateFrequency.Size = new System.Drawing.Size(95, 13);
            this.updateFrequency.TabIndex = 2;
            this.updateFrequency.Text = "Update Frequency";
            // 
            // overlayMenuBarVisibleOnStart
            // 
            this.overlayMenuBarVisibleOnStart.AutoSize = true;
            this.overlayMenuBarVisibleOnStart.Location = new System.Drawing.Point(12, 205);
            this.overlayMenuBarVisibleOnStart.Name = "overlayMenuBarVisibleOnStart";
            this.overlayMenuBarVisibleOnStart.Size = new System.Drawing.Size(197, 17);
            this.overlayMenuBarVisibleOnStart.TabIndex = 6;
            this.overlayMenuBarVisibleOnStart.Text = "Overlay Menu Expanded On Startup";
            this.overlayMenuBarVisibleOnStart.UseVisualStyleBackColor = true;
            this.overlayMenuBarVisibleOnStart.CheckedChanged += new System.EventHandler(this.overlayMenuBarVisibleOnStart_CheckedChanged);
            // 
            // resetSettings
            // 
            this.resetSettings.Location = new System.Drawing.Point(18, 410);
            this.resetSettings.Name = "resetSettings";
            this.resetSettings.Size = new System.Drawing.Size(75, 23);
            this.resetSettings.TabIndex = 7;
            this.resetSettings.Text = "Reset Settings";
            this.resetSettings.UseVisualStyleBackColor = true;
            this.resetSettings.Click += new System.EventHandler(this.resetSettings_Click);
            // 
            // removeCompletedSubItems
            // 
            this.removeCompletedSubItems.AutoSize = true;
            this.removeCompletedSubItems.Location = new System.Drawing.Point(12, 228);
            this.removeCompletedSubItems.Name = "removeCompletedSubItems";
            this.removeCompletedSubItems.Size = new System.Drawing.Size(194, 17);
            this.removeCompletedSubItems.TabIndex = 8;
            this.removeCompletedSubItems.Text = "Auto Remove Completed Sub Items";
            this.removeCompletedSubItems.UseVisualStyleBackColor = true;
            this.removeCompletedSubItems.CheckedChanged += new System.EventHandler(this.removeCompletedSubItems_CheckedChanged);
            // 
            // removeCompletedItemList
            // 
            this.removeCompletedItemList.AutoSize = true;
            this.removeCompletedItemList.Location = new System.Drawing.Point(12, 251);
            this.removeCompletedItemList.Name = "removeCompletedItemList";
            this.removeCompletedItemList.Size = new System.Drawing.Size(186, 17);
            this.removeCompletedItemList.TabIndex = 9;
            this.removeCompletedItemList.Text = "Auto Remove Completed Item List";
            this.removeCompletedItemList.UseVisualStyleBackColor = true;
            this.removeCompletedItemList.CheckedChanged += new System.EventHandler(this.removeCompletedItemList_CheckedChanged);
            // 
            // removeItemProject
            // 
            this.removeItemProject.AutoSize = true;
            this.removeItemProject.Location = new System.Drawing.Point(12, 274);
            this.removeItemProject.Name = "removeItemProject";
            this.removeItemProject.Size = new System.Drawing.Size(203, 17);
            this.removeItemProject.TabIndex = 10;
            this.removeItemProject.Text = "Auto Remove Completed Item Project\r\n";
            this.removeItemProject.UseVisualStyleBackColor = true;
            this.removeItemProject.CheckedChanged += new System.EventHandler(this.removeItemProject_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 445);
            this.Controls.Add(this.removeItemProject);
            this.Controls.Add(this.removeCompletedItemList);
            this.Controls.Add(this.removeCompletedSubItems);
            this.Controls.Add(this.resetSettings);
            this.Controls.Add(this.overlayMenuBarVisibleOnStart);
            this.Controls.Add(this.panelUpdateFrequency);
            this.Controls.Add(this.APIKeyPanel);
            this.Controls.Add(this.opacityPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).EndInit();
            this.opacityPanel.ResumeLayout(false);
            this.opacityPanel.PerformLayout();
            this.APIKeyPanel.ResumeLayout(false);
            this.APIKeyPanel.PerformLayout();
            this.panelUpdateFrequency.ResumeLayout(false);
            this.panelUpdateFrequency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TrackBar opacitySlider;
        private System.Windows.Forms.Label opacityLabel;
        private System.Windows.Forms.Label numericOpacity;
        private System.Windows.Forms.Panel opacityPanel;
        private System.Windows.Forms.Panel APIKeyPanel;
        private System.Windows.Forms.TextBox apiKeyField;
        private System.Windows.Forms.Label APIKeyLabel;
        private System.Windows.Forms.Panel panelUpdateFrequency;
        private System.Windows.Forms.Label updateFrequency;
        private System.Windows.Forms.Label numericUpdateTime;
        private System.Windows.Forms.TrackBar updateSlider;
        private System.Windows.Forms.CheckBox overlayMenuBarVisibleOnStart;
        private System.Windows.Forms.Button resetSettings;
        private System.Windows.Forms.CheckBox removeCompletedSubItems;
        private System.Windows.Forms.CheckBox removeCompletedItemList;
        private System.Windows.Forms.CheckBox removeItemProject;
    }
}