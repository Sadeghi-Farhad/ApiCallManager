using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsFrameworkTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ApiCallManager.NetFramework.ApiManager x = new ApiCallManager.NetFramework.ApiManager();
            var res = await x.GetAsync<string>("https://gateway.crouseco.com/home");

            if (res.IsSuccess)
                label1.Text = res.Result;
            else
                label1.Text = res.Problem.Title;
        }
    }
}
