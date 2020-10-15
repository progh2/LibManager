using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Text = "도서관 관리";
            label6.Text = DataManager.Books.Count.ToString();
            label7.Text = DataManager.Users.Count.ToString();
            label8.Text = DataManager.Books.Where((x)=>x.isBorrowed).Count().ToString();
            label9.Text = DataManager.Books.Where((x)=>
            {
                return x.isBorrowed && x.BorrowedAt.AddDays(7) < DateTime.Now;
            }).Count().ToString();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
