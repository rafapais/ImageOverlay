using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ImageOverlay
{
    public partial class FrmOpcoes : Form
    {
        public FrmOpcoes()
        {
            InitializeComponent();
        }

        //Verifica se a Aplicação está a arrancar com o Windows
        private bool IsStartupItem()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (rkApp.GetValue("Image Overlay") == null)
                return false;
            else
                return true;
        }



        private void FrmOpcoes_Load(object sender, EventArgs e)
        {
            TxtLocalImagem.Text = Properties.Settings.Default.Imagem;
            if(IsStartupItem())
            {
                ChkStartupWindows.Checked = true;
            }
            else
            {
                ChkStartupWindows.Checked = false;
            }

            if(Properties.Settings.Default.Skype == true)
            {
                ChkSkype.Checked = true;
            }
            else
            {
                ChkSkype.Checked = false;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnProcurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Abrir Imagem";
            dlg.Filter = "Ficheiros de Imagem |*.jpg;*.png;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TxtLocalImagem.Text = dlg.FileName;
            }
       
            dlg.Dispose();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ChkSkype.Checked == true)
            {
                Properties.Settings.Default.Skype = true;
            }
            else
            {
                Properties.Settings.Default.Skype = false;
            }

            Properties.Settings.Default.Imagem = TxtLocalImagem.Text;
            Properties.Settings.Default.Save();

            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if(ChkStartupWindows.Checked == true)
            {
                rkApp.SetValue("Image Overlay", Application.ExecutablePath.ToString());
            }
            else
            {
                rkApp.DeleteValue("Image Overlay", false);
            }

            Application.Restart();
        }

        private void linkLblSobre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new FrmSobre();
            frm.Show();
        }
    }
}
