using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using Method;

namespace UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private MethodSpider mSpider;

        private void srcBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (fbd.SelectedPath != null)
                {
                    this.srcFile.Text = fbd.SelectedPath;
                    this.startBtn.Enabled = true;
                }
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            mSpider = new MethodSpider(targetUrl.Text);
            textBox1.Text = mSpider.RequestWEB(targetUrl.Text);
        }


        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            targetUrl.Text = "http://www.huaxiuluo.com/xs/25591/8340564";
            startBtn.Enabled = false;
            var appName = Process.GetCurrentProcess().MainModule.ModuleName;
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", appName, 9999, RegistryValueKind.DWord);
        }
    }
}
    