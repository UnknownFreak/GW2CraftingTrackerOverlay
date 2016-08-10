using System;
using System.Windows.Forms;
namespace GW2APIComponent.GW2Components.Forms
{
    public partial class SetAPIKeyForm : Form
    {
        APIKeyInfoComponent myKey;
        public SetAPIKeyForm(APIKeyInfoComponent info)
        {
            InitializeComponent();
            myKey = info;
            keyField.Text = info.getAPIKey();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myKey.setAPIKey(keyField.Text);
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
