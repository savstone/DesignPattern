using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a flag");
                var flag = Console.ReadLine();
                //if (flag == "1")
                //{
                //    Console.WriteLine($"{flag}录入ok");
                //}
                //else if (flag == "2")
                //{
                //    Console.WriteLine($"{flag}录入异常");
                //}
                //else if (flag == "-1")
                //{
                //    Console.WriteLine($"{flag}已存在");
                //}

                Console.WriteLine(ShowMsgFactory.CreateShowMsg(flag).ShowMsg(flag));
                Console.ReadKey();


            }
        }
    }


    public class ShowMsgFactory
    {
        public static IShowMsg CreateShowMsg(string errorCode)
        {
            IShowMsg showMsg = null;
            switch (errorCode)
            {
                case "1":
                case "2":
                    showMsg = new ResultShowMsg();
                    break;
                case "-1":
                    showMsg = new ExistShowMsg();
                    break;
                default:
                    showMsg = new EmtipyShowMsg();
                    break;
            }
            return showMsg;
        }

    }
    public interface IShowMsg
    {
        string ShowMsg(string flag);
    }
    public class EmtipyShowMsg : IShowMsg
    {
        public string ShowMsg(string flag)
        {
            return $"null";
        }
    }
    public class ResultShowMsg : IShowMsg
    {
        public string ShowMsg(string flag)
        {
            return $"修改{(flag == "1" ? "OK" : "ERror")}";
        }
    }
    public class ExistShowMsg : IShowMsg
    {
        public string ShowMsg(string flag)
        {
            return $"已经存在";
        }
    }
    public class ExceptionShowMsg : IShowMsg
    {
        public string ShowMsg(string flag)
        {
            return $"出现错误信息";
        }
    }


}
