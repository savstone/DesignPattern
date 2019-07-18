using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityDesign
{
    /*职责链模式：使多个对象都有机会处理请求，从而避免请求的发送者和接收者之间的耦合关系。将
     这个对象连成一条链，并沿着这条链传递请求，直到有一个对象处理它为止。
         */
    class Program
    {
        static void Main(string[] args)
        {
            var h1 = new CocreteHandler1();
            var h2 = new CocreteHandler2();
            var h3 = new CocreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            var aa = new int[] { 1, 2, 4, 12, 21, 14, 11 };
            foreach (var item in aa)
            {
                h1.HandlerRequest(item);
            }
            Console.Read();
        }
    }

    abstract class Handler
    {
        protected Handler _successor;
        public void SetSuccessor(Handler successor)
        {
            _successor = successor;
        }
        public abstract void HandlerRequest(int request);
    }

    class CocreteHandler1 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request > 1 && request < 10)
            {
                Console.WriteLine($"{GetType().Name}处理了{request}");
            }
            else if (_successor != null)
            {
                _successor.HandlerRequest(request);
            }
        }
    }

    class CocreteHandler2 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine($"{GetType().Name}处理了{request}");
            }
            else if (_successor != null)
            {
                _successor.HandlerRequest(request);
            }
        }
    }

    class CocreteHandler3 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request >= 20 && request < 300)
            {
                Console.WriteLine($"{GetType().Name}处理了{request}");
            }
            else if (_successor != null)
            {
                _successor.HandlerRequest(request);
            }
        }
    }

}
