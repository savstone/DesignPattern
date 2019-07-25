using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteDemo
{
    class Program
    {
        public static string AA { get; set; }
        private static Testdelegate _testdelegate;
        public static Testdelegate T
        {
            //get; set;
            get
            {
                _testdelegate = (args) =>
                {
                    return new TestInfo() { ID = args };
                };
                return _testdelegate;
            }
            set { }
        }
        static void Main(string[] args)
        {
            var aa = T("100");


            //T += (a) => { return new TestInfo { ID = a }; };
            //T("1111");
        }
    }

    public delegate TestInfo Testdelegate(string id);

    public class TestInfo
    {
        public string ID { get; set; }
    }
}
