using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Net;
using System.IO;

namespace projectName
{
    class Program
    {
        public static string username;
        public static string password;

        static void Main(string[] args)
        {
            Console.Write("Kullanıcı Adı : ");
            string username = Console.ReadLine();
            Program.username = username;

            Console.Write("Şifre : ");
            string password = Console.ReadLine();
            Program.password = password;

            if(login())
            {
                Console.WriteLine("Giriş başarılı.");
            } else
            {
                Console.WriteLine("Giriş başarısız.");
            }

            // getCredit();
            // getUUID();
            // getName();

            Console.ReadKey();
        }

        public static bool login()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost/getinfo.php?username=" + username + "&password=" + password);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if(responseString.Equals("true"))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static string getCredit()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost/getinfo.php?username=" + username + "&get=credit");
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        public static string getUUID()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost/getinfo.php?username=" + username + "&get=uuid");
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        public static string getName()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost/getinfo.php?username=" + username + "&get=name");
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
    }
}
