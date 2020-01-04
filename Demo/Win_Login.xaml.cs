using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_Audit;

namespace Demo
{
    class Account
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        public Account(string name)
        {
            this.name = name;
        }
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Win_Login : Window
    {
        private string serverIp;
        private List<Account> list_User = new List<Account>();
        private string alluser;

        public static Wpf_Audit.User_SelfInfo user { get; set; }
        public Win_Login()
        {
            serverIp = ConfigHelper.GetAppConfig("IP");
            alluser = ConfigHelper.GetAppConfig("User");
            if (serverIp != null && serverIp != string.Empty)
                SetUrl(serverIp);
            InitializeComponent();
            
        }

        private void SetUrl(string IP)
        {
            Net.Url_Login = @"http://" + IP.Trim() + @"/api/user.php?act=login";
            Net.Url_Logout = @"http://" + IP.Trim() + @"/api/user.php?act=logout";
        }

        private void Btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Btn_Setting_Click(object sender, RoutedEventArgs e)
        {
            if(Tbx_IP.Visibility==Visibility.Visible)
            {
                Lab_IP.Visibility = Visibility.Hidden;
                Tbx_IP.Visibility = Visibility.Hidden;
            }
            else
            {
                Lab_IP.Visibility = Visibility.Visible;
                Tbx_IP.Visibility = Visibility.Visible;
            }
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            }
            catch { }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                softkeyboard.ButtonGrid.Visibility = Visibility.Hidden;
                Lab_IP.Visibility = Visibility.Hidden;
                Tbx_IP.Visibility = Visibility.Hidden;
            }
            catch { }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Button selectedButton = sender as Button;
            if (selectedButton.Tag.ToString() == Cbx_User.Text)
                Cbx_User.Text = string.Empty;
            list_User.RemoveAll(u => u.Name == selectedButton.Tag.ToString());
            Cbx_User.ItemsSource = list_User;
            Cbx_User.Items.Refresh();
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if (Cbx_User.Text.Equals(string.Empty) || softkeyboard.Pbx_Password.Password.Equals(string.Empty))
                return;
            if (Tbx_IP.Text.Length <= 0 || Tbx_IP.Text.Equals(string.Empty))
            {
                MessageBox.Show("请设置服务器IP地址", "消息提示", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            Login(Cbx_User.Text, softkeyboard.Pbx_Password.Password);
        }

        private void Login(string userId, string password)
        {
            using (var client = new HttpClient())
            {
                var mulContent = new MultipartFormDataContent();
                var list = new List<KeyValuePair<string, string>>();
                Net.GetKeyValuePairList("user", userId, ref list);
                Net.GetKeyValuePairList("password", password, ref list);
                Net.GetKeyValueMultipartContent(list, ref mulContent);

                try
                {
                    var response = client.PostAsync(Net.Url_Login, mulContent).Result.Content.ReadAsStringAsync().Result;
                    if (response.StartsWith("{\"error\":0"))
                    {
                        var json = Json_Login.JsonStrToList(response);
                        Win_Login.user = new Wpf_Audit.User_SelfInfo(json.userId, json.department, json.rank, json.companyId, json.companyName, json.realName, json.contactInfo, json.userId + '|' + json.token);
                        string[] users;
                        if (alluser != null && !alluser.Equals(string.Empty))
                        {
                            users = alluser.Split('|');
                            alluser = Cbx_User.Text + '|';
                            foreach (var item in users)
                            {
                                if (Cbx_User.Text == item)
                                {
                                    continue;
                                }
                                else
                                {
                                    alluser += item + '|';
                                }
                            }
                            alluser = alluser.Trim('|');
                        }
                        else
                        {
                            alluser = Cbx_User.Text;
                        }
                        ConfigHelper.UpdateAppConfig("User", alluser);

                        Wpf_Audit.Win_Audit win = new Win_Audit(serverIp, user);
                        win.Show();
                        this.Close();
                    }
                    else
                    {
                        var json = Json_Msg.JsonStrToList(response);
                        Json_Msg.ShowMsg(json);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n请检查您的网络、服务器IP地址或本机防火墙设置", "异常信息", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Tbx_IP.Text = serverIp != null ? serverIp : string.Empty;
                if (alluser != null && !alluser.Equals(string.Empty))
                {
                    string[] users = alluser.Split('|');
                    Cbx_User.Text = users[0];
                    list_User.Clear();
                    foreach (var item in users)
                    {
                        list_User.Add(new Account(item));
                    }
                }
                Cbx_User.ItemsSource = list_User;
            }
            catch { }
        }

        private void Tbx_IP_TextChanged(object sender, TextChangedEventArgs e)
        {
            serverIp = Tbx_IP.Text;
            SetUrl(serverIp);
            ConfigHelper.UpdateIPConfig("IP", Tbx_IP.Text);
        }


    }
}
