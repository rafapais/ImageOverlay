using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using System.Reflection;

namespace ImageOverlay
{
    public partial class FrmPrincipal : Form
    {
        public System.Threading.Thread ThreadSkype;

        public bool ModoMover = false;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int LPAR);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;  //this indicates that the action takes place on the title bar

        private void MoveJanela(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //Para Ficar Invisível:

        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int LWA_ALPHA = 2;

        private void FormFade()
        {
            var style = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, style | WS_EX_LAYERED | WS_EX_TRANSPARENT);
            var percent = 0.1;
            var alpha = 255 * percent;
            SetLayeredWindowAttributes(this.Handle, 0, (byte)alpha, LWA_ALPHA);
        }

        private void FormUnfade()
        {
            var _initialStyle = GetWindowLong(Handle, -20);
            SetWindowLong(this.Handle, -20, _initialStyle & ~(0x80000 | 0x20));
        }

        //FIM
        
      
        //Verifica se a Janela do Skype está aberta
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle()
        
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public void SkypeRunning()
        {
            visivelNoSkypeToolStripMenuItem.Visible = true;
            toolStripSeparator2.Visible = true;

            while (true)
            {
                String nomejanela = GetActiveWindowTitle();
                if (nomejanela != null)
                {
                    if (nomejanela.Contains("Skype") == true)
                    {
                        //Console.WriteLine("Aberto");
                        FormHandler_FrmPrincipalShow();
                    }
                    else
                    {
                        //Console.WriteLine("Fechado");
                        FormHandler_FrmPrincipalHide();
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        private void FormHandler_FrmPrincipalHide()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => { FormHandler_FrmPrincipalHide(); }));
            }
            else
            {
                Hide();
            }
        }

        private void FormHandler_FrmPrincipalShow()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => { FormHandler_FrmPrincipalShow(); }));
            }
            else
            {
                Show();
            }

        }

        //FIM


        public FrmPrincipal()
        {
            this.MouseDown += new MouseEventHandler(MoveJanela);
            InitializeComponent();
        }

        private void AbrirImagem()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Abrir Imagem";
            dlg.Filter = "Ficheiros de Imagem |*.jpg;*.png;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Image myimage = new Bitmap(dlg.FileName);
                Properties.Settings.Default.Imagem = dlg.FileName;
                Properties.Settings.Default.Save();
                this.BackgroundImage = myimage;
                this.Width = myimage.Width;
                this.Height = myimage.Height;
            }
            else
            {
                Application.Exit();
            }

            dlg.Dispose();
        }


        private bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            System.IO.FileSystemInfo fileInfo = new System.IO.FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            bool bCreatedNew;

            Mutex mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
            if (bCreatedNew)
                mutex.ReleaseMutex();

            return !bCreatedNew;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if(!IsAlreadyRunning())
            {
                if (Properties.Settings.Default.Skype == true)
                {
                    ThreadSkype = new System.Threading.Thread(SkypeRunning);
                    ThreadSkype.Start();
                }

                try
                {
                    if (Properties.Settings.Default.Imagem == string.Empty)
                    {
                        MessageBox.Show("Imagem não Configurada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AbrirImagem();
                    }
                    else
                    {
                        Image myimage = new Bitmap(Properties.Settings.Default.Imagem);
                        this.BackgroundImage = myimage;
                        this.Width = myimage.Width;
                        this.Height = myimage.Height;


                        if (ThreadSkype != null)
                        {
                            notifyIcon1.ShowBalloonTip(3000, "Image Overlay", "Programa a Correr" + System.Environment.NewLine + "Visível somente no Skype", ToolTipIcon.Info);
                        }
                    }
                }
                catch (System.ArgumentException)
                {
                    MessageBox.Show("Imagem não Configurada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AbrirImagem();
                }

            }
            else
            {
                MessageBox.Show("A Aplicação já está a correr!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            //Guardar Posição da Janela

            if (Properties.Settings.Default.F1Size.Width == 0 || Properties.Settings.Default.F1Size.Height == 0)
            {
                // first start
                // optional: add default values
            }
            else
            {
                this.WindowState = Properties.Settings.Default.F1State;

                // we don't want a minimized window at startup
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                this.Location = Properties.Settings.Default.F1Location;
                this.Size = Properties.Settings.Default.F1Size;
            }

        }

        private void FrmPrincipal_MouseEnter(object sender, EventArgs e)
        {
            if (ModoMover == false)
            {
                FormFade();
            }
        }

        private void FrmPrincipal_MouseLeave(object sender, EventArgs e)
        {
            if (ModoMover == false)
            {
                System.Threading.Thread.Sleep(2000);
                FormUnfade();
            }     
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.F1State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                Properties.Settings.Default.F1Location = this.Location;
                Properties.Settings.Default.F1Size = this.Size;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.F1Location = this.RestoreBounds.Location;
                Properties.Settings.Default.F1Size = this.RestoreBounds.Size;
            }

            // don't forget to save the settings
            Properties.Settings.Default.Save();

            if (ThreadSkype != null)
            {
                ThreadSkype.Abort();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void modoMoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modoMoverToolStripMenuItem.Checked == true)
            {
                if (ThreadSkype != null)
                {
                    ThreadSkype.Abort();
                }
                ModoMover = true;
                Sizer.Visible = true;
                FormHandler_FrmPrincipalShow();
            }
            else
            {
                if (ThreadSkype != null)
                {
                    ThreadSkype = new System.Threading.Thread(SkypeRunning);
                    ThreadSkype.Start();
                }
                ModoMover = false;
                Sizer.Visible = false;
            }
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmOpcoes();
            frm.Show();
        }

        //Redimensiona Janela
        int Mx;
        int My;
        int Sw;
        int Sh;

        bool mov;

        void SizerMouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            My = MousePosition.Y;
            Mx = MousePosition.X;
            Sw = Width;
            Sh = Height;
        }

        void SizerMouseMove(object sender, MouseEventArgs e)
        {
            if (mov == true)
            {
                Width = MousePosition.X - Mx + Sw;
                Height = MousePosition.Y - My + Sh;
            }
        }

        void SizerMouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
        }
        //FIM
    }
}
