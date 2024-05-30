using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YTRKDotNetCore.WinFormsApp
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void newBlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBlog frm = new FrmBlog();
            //frm.Show(); //show ကကျတော့ တစ်ခြားတွေကိုလဲ နှိပ်လို့ ရတယ် 
            frm.ShowDialog(); // showdialog ကျတော့ ဒါကိုမ နှိပ် မချင်း တခြားဟာနှိပ်လို့ မရဘူး
        }

        private void blogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBlogList frm = new FrmBlogList();
            frm.ShowDialog();
        }
    }
}
