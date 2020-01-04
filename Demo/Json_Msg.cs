using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;

namespace Demo
{
    class Json_Msg
    {
        public int error { get; set; }
        public string msg { get; set; }
        public static Json_Msg JsonStrToList(string json)
        {
            //反序列化
            Json_Msg model = new Json_Msg();
            model = JsonConvert.DeserializeObject<Json_Msg>(json);
            return model;
        }

        public static void ShowMsg(Json_Msg jmsg)
        {
            MessageBox.Show(jmsg.msg, "异常提醒", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public class User_SelfInfo
    {
        public string userId { get; set; }
        public string department { get; set; }
        public int rank { get; set; }
        public int companyId { get; set; }
        public string companyName { get; set; }
        public string realName { get; set; }
        public string contactInfo { get; set; }
        public string token { get; set; }

        public User_SelfInfo() { }
        public User_SelfInfo(string userId, string department, int rank, int companyId, string companyName, string realName, string contactInfo, string token)
        {
            this.userId = userId;
            this.department = department;
            this.rank = rank;
            this.companyId = companyId;
            this.companyName = companyName;
            this.realName = realName;
            this.contactInfo = contactInfo;
            this.token = token;
        }
    }

    class Json_Login
    {
        public int error { get; set; }
        public string userId { get; set; }
        public string department { get; set; }
        public int rank { get; set; }
        public int companyId { get; set; }
        public string companyName { get; set; }
        public string realName { get; set; }
        public string contactInfo { get; set; }
        public string token { get; set; }
        public static Json_Login JsonStrToList(string json)
        {
            //反序列化
            Json_Login model = new Json_Login();
            model = JsonConvert.DeserializeObject<Json_Login>(json);
            return model;
        }
        
    }


}
