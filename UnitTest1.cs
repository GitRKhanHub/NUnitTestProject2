using NUnit.Framework;
using System;
using System.Net;
using System.IO;
using System.Xml;
//using System.Text.Json;

using System.Linq;
using System.Xml.Linq;

using System.Collections.Generic;

namespace NUnitTestProject2
{
    public class Methods
    {
        public void Get_Id() // метод для вытаскивания Id необходимых каналов
        {
            WebClient client = new WebClient();
            string address = "http://demo.macroscop.com:8080/configex?login=root&password=";
            string reply = client.DownloadString(address);
            //выбрасываем не xml данные
            reply = reply.Remove(0, reply.IndexOf("<"));

            List<String> Street_chanels_list = new List<String>();
            XDocument My_XmlDocument = XDocument.Parse(reply); // парсинг полученной строки


            foreach (XElement el in My_XmlDocument.Element("Configuration").Elements("RootSecurityObject").Elements("ChildSecurityObjects").
                Elements("SecObjectInfo"))
            {
                if (el.Attribute("Name").Value == "Street")
                {
                    foreach (XElement subel in el.Elements("ChildChannels").Elements("ChannelId"))
                    {
                        //Console.WriteLine(subel.Value);
                        Street_chanels_list.Add(subel.Value); //список Id необходимых каналов
                    }
                }
            }
        }
        
    }
    //public class Tests
    //{
    //    [SetUp]
    //    public void Setup()
    //    {
    //    }

    //    [Test]
    //    public void Test1()
    //    {
    //        Assert.Pass();
    //    }
    //}
}