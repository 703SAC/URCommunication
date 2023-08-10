using System;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace HttpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string taskInterfaceUrl = "http://192.168.0.200/AsInterfaceHttp/AutoStoreHttpInterface.aspx";

            HttpClient client = new HttpClient();
            //var res = client.GetAsync("").Result;
            //Console.WriteLine("Response : " + res.StatusCode);

            XmlDocument requestXml = new XmlDocument();

            requestXml.Load("C:\\Users\\getPortStatus.xml");
            string stringXml = requestXml.OuterXml;


            
            StringContent stringContent = new StringContent(stringXml, Encoding.UTF8);
            

            var response = client.PostAsync(taskInterfaceUrl, stringContent).Result;
            

            Console.WriteLine("statusCode: " + response.StatusCode + " Content: " + response.Content);
            


        }
    }
}
