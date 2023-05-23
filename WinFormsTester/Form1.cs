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
            ClassHelper.apiManager = new ApiManager();
        }

        private async void button_login_Click(object sender, EventArgs e)
        {
            string username = textBox_username.Text;
            string password = textBox_password.Text;

            var res = await LoginAsync(username, password);
            if (res != null)
            {
                ClassHelper.apiManager.SetTokens(res.AccessToken, res.RefreshToken, "https://gorest.co.in/public/v2/refreshtoken", true);
            }
        }

        private async void button_adduser_Click(object sender, EventArgs e)
        {
            User newuser = new User()
            {
                Name = textBox_name.Text,
                Email = textBox_email.Text,
                Gender = comboBox_gender.SelectedItem.ToString(),
                Status = "active"
            };

            string res = await AddUserAsync(newuser);
        }

        private async void button_getlist_Click(object sender, EventArgs e)
        {
            listView_users.Clear();

            List<User>? users = await GetUsersAsync();
            if (users != null)
            {
                foreach (User user in users)
                {
                    listView_users.Items.Add(new ListViewItem($"{user.Id}\t{user.Name}"));
                }
            }
        }

        public async Task<AuthResultDTO?> LoginAsync(string username, string password)
        {
            var result = await ClassHelper.apiManager.PostAsync<KeyValuePair<string, string>, AuthResultDTO>("https://gorest.co.in/public/v2/login", new KeyValuePair<string, string>(username, password));

            if (result.IsSuccess)
            {
                return result.Result;
            }
            else
            {
                ClassHelper.ShowApiCallError(result.Problem);
                return null;
            }
        }

        public async Task<string> AddUserAsync(User newUser)
        {
            var result = await ClassHelper.apiManager.PostAsync<User, string>("https://gorest.co.in/public/v2/users", newUser);

            if (result.IsSuccess)
            {
                return result.Result;
            }
            else
            {
                ClassHelper.ShowApiCallError(result.Problem);
                return string.Empty;
            }
        }

        public async Task<List<User>?> GetUsersAsync()
        {
            var result = await ClassHelper.apiManager.GetAsync<List<User>>("https://gorest.co.in/public/v2/users");

            if (result.IsSuccess)
            {
                return result.Result;
            }
            else
            {
                ClassHelper.ShowApiCallError(result.Problem);
                return null;
            }
        }
    }
}