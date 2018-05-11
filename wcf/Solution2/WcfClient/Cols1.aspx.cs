using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfClient.WcfService;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using StackExchange.Redis;
using ServiceStack.Redis;

namespace WcfClient
{
    public partial class Cols1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserClient user = new UserClient();
            string result = user.ShowName("wcf");
            Thread.Sleep(20);
            Response.Write(result+"</br>");
           


            //mysql数据库查询
            MySqlConnection MySqlconn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConStr"].ConnectionString.ToString());
            try
            {
                MySqlconn.Open();
                string MySqlcommand = "select T_Flowers.name as fname, T_Flowers.price as fprice, T_House.hname as hnames from T_Flowers left join T_House on T_Flowers.id = T_House.flowerid where T_House.hname = 'house1'";
                MySqlCommand cmd = new MySqlCommand(MySqlcommand, MySqlconn);
                Thread.Sleep(20);
                MySqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {
                    for (int i=0;i<=2;i++)
                    {
                        Response.Write(myreader[i].ToString()+"    ");
                    }
                  
                    myreader.Close();
                }
               
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (MySqlconn != null)
                {
                    MySqlconn.Close();
                }
                Response.Write("Mysql"+"</br>");
            }


          

            //连接数据库 StackExchange.Redis
            string conn = ConfigurationManager.AppSettings["redis"].ToString();
            Thread.Sleep(20);
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(conn);
            //访问数据库  给db赋值
            IDatabase db = redis.GetDatabase();

            db.StringSet("rr", "StackExchange redisTest");
            string value = db.StringGet("rr");
            Response.Write(value+"</br>");
            db.KeyDelete("rr");


            //ServiceStack.Redis
            //连接数据库
            string conn2 =ConfigurationManager.AppSettings["redis2"].ToString();
            RedisClient dbclient = new RedisClient(conn2);
            Thread.Sleep(20);
            dbclient.Set<string>("ee", "ServiceStack.Redis test");
            string ee = dbclient.Get<string>("ee");
            Response.Write(ee + "</br>");
            dbclient.Set<int>("w22", 23);
            dbclient.Get<int>("w22");
            dbclient.Del("ee");
            dbclient.Del("w22");





        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WCFTest.aspx");
        }
    }
}