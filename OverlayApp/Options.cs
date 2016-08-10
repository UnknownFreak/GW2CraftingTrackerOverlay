using System;
using System.Windows.Forms;

namespace OverlayApp
{
    public partial class Settings : Form
    {
        public event EventHandler<int> onOpacityChange = null;
        public event EventHandler<string> onAPIKeyChange = null;
        public event EventHandler onUpdateFrequencyChange = null;
        public Settings()
        {
            InitializeComponent();
            onInit();
        }
        private void onInit()
        {
            opacitySlider.Value = Properties.Settings.Default.Opacity;
            apiKeyField.Text = Properties.Settings.Default.APIKey;
            numericOpacity.Text = opacitySlider.Value + "%";
            updateSlider.Value = Convert.ToInt32(Properties.Settings.Default.UpdateTime.TotalSeconds);
            numericUpdateTime.Text = Properties.Settings.Default.UpdateTime.ToString();
            overlayMenuBarVisibleOnStart.Checked = Properties.Settings.Default.MenuExpanderSetting;
            removeCompletedSubItems.Checked = Properties.Settings.Default.AutoRemoveSubItems;
            removeCompletedItemList.Checked = Properties.Settings.Default.AutoRemoveCompletedItem;
            removeItemProject.Checked = Properties.Settings.Default.AutoRemoveProject;
        }

        private void overlayMenuBarVisibleOnStart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MenuExpanderSetting = overlayMenuBarVisibleOnStart.Checked;
        }

        private void resetSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
        }

        private void updateFrequencyScroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.UpdateTime = TimeSpan.FromSeconds(updateSlider.Value);
            numericUpdateTime.Text = Properties.Settings.Default.UpdateTime.ToString();
            onUpdateFrequencyChange?.Invoke(this,e);
        }

        private void APIKeyTextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.APIKey = apiKeyField.Text;
            onAPIKeyChange?.Invoke(this, apiKeyField.Text);
        }

        private void OpacityScroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.Opacity = opacitySlider.Value;
            numericOpacity.Text = opacitySlider.Value + "%";
            onOpacityChange?.Invoke(this, opacitySlider.Value);
        }

        private void removeCompletedSubItems_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoRemoveSubItems = removeCompletedSubItems.Checked;
        }

        private void removeCompletedItemList_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoRemoveCompletedItem = removeCompletedItemList.Checked;
        }

        private void removeItemProject_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoRemoveProject = removeItemProject.Checked;
        }
    }
}
