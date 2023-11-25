using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carbon_Launcher
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }
            

        private void fileButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                // Kullanıcıya ileti mesajı
                folderDialog.Description = "Bir klasör seçiniz.";

                // Klasör seçimi gerçekleştiyse
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Seçilen klasörün yolu TextBox'a atanır.
                    txtFolderPath.Text = folderDialog.SelectedPath.Replace("\\", "/");
                }
            }
        }

        private void contButton_Click(object sender, EventArgs e)
        {
            Settings1.Default.fileLocation = txtFolderPath.Text;
            Settings1.Default.Save();
            Form1 form1 = new Form1();
            form1.Show(); 
            this.Hide();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            txtFolderPath.Text = Settings1.Default.fileLocation;

        }
    }
}
