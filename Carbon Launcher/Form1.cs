using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Carbon_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            if (Directory.Exists(@"C:/Carbon"))
            {
                client.DownloadFile("https://cdn.discordapp.com/attachments/1153935427464601610/1177673238512410685/Carbon.Client.zip?ex=65735cac&is=6560e7ac&hm=7189425643e011cdbc01da4df6750fbde7bd7e3aa741cd60468cbd32255b291f&", "C:/Carbon/carbon.zip");
                File.Move("C:/Carbon/carbon.zip", "C:/Program Files (x86)/Steam/steamapps/common/Rust/carbon.zip");
                Process.Start("cmd.exe", "/c" + "cd C:/Program Files (x86)/Steam/steamapps/common/Rust/ &tar -xf carbon.zip");
                MessageBox.Show("Carbon is installed");
            }
            else
            {
                Directory.CreateDirectory(@"C:/Carbon");

                client.DownloadFile("https://cdn.discordapp.com/attachments/1153935427464601610/1177673238512410685/Carbon.Client.zip?ex=65735cac&is=6560e7ac&hm=7189425643e011cdbc01da4df6750fbde7bd7e3aa741cd60468cbd32255b291f&", "C:/Carbon/carbon.zip");
                File.Move("C:/Carbon/carbon.zip", "C:/Program Files (x86)/Steam/steamapps/common/Rust/carbon.zip");



                Process.Start("cmd.exe", "/c" + "cd C:/Program Files (x86)/Steam/steamapps/common/Rust/ &tar -xf carbon.zip");
                MessageBox.Show("Carbon is installed");
            }


        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            File.Delete("C:/Program Files (x86)/Steam/steamapps/common/Rust/winhttp.dll");
            File.Delete("C:/Program Files (x86)/Steam/steamapps/common/Rust/carbon.zip");
            MessageBox.Show("Carbon is uninstalled");

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/c" + "cd C:/Program Files (x86)/Steam/steamapps/common/Rust/ &start RustClient.exe -logs -silent-crashes -logfile output_log.txt +prewarm \"false\" +connect \"167.86.121.152:29000\" +global.skipassetwarmup_crashes \"1\"\r\n");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:/Program Files (x86)/Steam/steamapps/common/Rust/winhttp.dll"))
            {
                isInstalled.Text = "Carbon is installed";
            }
            else
            {
                isInstalled.Text = "We cant find the carbon";

            }
        }
    }
}
