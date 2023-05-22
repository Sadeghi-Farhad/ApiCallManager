using System.Diagnostics;
using ApiCallManager;

namespace WinFormsTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelUrl.Text = string.Empty;
            labelUrl.MaximumSize = new Size(200, 200);
        }

        private async void button_call_Click(object sender, EventArgs e)
        {
            ApiManager apiManager = new ApiManager("https://gateway.mytest.com");
            labelUrl.Text = "/Auth/Auth/MyProfileInfo";

            string input = richTextBox_request.Text;
            string token = richTextBox_token.Text;

            apiManager.SetTokens("", "", "/auth/auth/refresh", true);
            var result = await apiManager.GetAsync<string>(labelUrl.Text, true);
            richTextBox_response.Text = result.ToString();
        }
    }
}