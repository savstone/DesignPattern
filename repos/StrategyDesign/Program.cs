using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesign
{
    /*策略模式：定义了算法家族，分别分装起来，让他们之间可以相互替代，此模式让算法的用户，不会影响大使用算法的客户*/
    /* 策略模式是一种定义一系列算法的方法，从概念上来看，所有这些算法都是完成相同工作，
     * 只是实现不同，它可以以相同的方式调用所有算法，减少了各种算法类与使用算法类之间
     * 的耦合        
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入收费类型，1 正常收费，2，折扣 3，满减");

            var result = Console.ReadLine();
            //策略模式和简单工厂模式结合
            CheckOutContext context = new CheckOutContext(result);
            var total = context.GetTotalFee(1000);
            Console.WriteLine($"费用是{total}");
        }
    }

    class CheckOutContext
    {
        CheckOut _checkOut = null;
        public CheckOutContext(string result)
        {
            switch (result)
            {
                case "1":
                    _checkOut = new NomalCheckOut();
                    break;
                case "2":

                    _checkOut = new DiscountCheckOut(5);
                    break;
                case "3":
                    _checkOut = new ReturnCheckOut(300, 70);
                    break;
                default:
                    break;
            }
        }
        public decimal GetTotalFee(decimal origianlPrice)
        {
            return _checkOut.GetTotalFee(origianlPrice);
        }

    }


    /// <summary>
    /// 结算父类
    /// </summary>
    class CheckOut
    {
        public virtual decimal GetTotalFee(decimal origianlPrice)
        {
            return origianlPrice;
        }
    }

    /// <summary>
    /// 正常收费
    /// </summary>
    class NomalCheckOut : CheckOut
    {

    }

    /// <summary>
    /// 满多少返现
    /// </summary>
    class ReturnCheckOut : CheckOut
    {
        public ReturnCheckOut(decimal maxFee, decimal returnMoney)
        {
            MaxFee = maxFee;
            ReturnMoney = returnMoney;
        }
        private decimal MaxFee;
        private decimal ReturnMoney;

        public override decimal GetTotalFee(decimal origianlPrice)
        {
            if (origianlPrice > MaxFee)
            {
                return origianlPrice - ReturnMoney;
            }
            else
                return origianlPrice;
        }
    }

    /// <summary>
    /// 打折
    /// </summary>
    class DiscountCheckOut : CheckOut
    {
        private decimal _discount;

        public DiscountCheckOut(decimal discount)
        {
            _discount = discount;
        }
        public override decimal GetTotalFee(decimal origianlPrice)
        {
            return base.GetTotalFee(origianlPrice * _discount / 10);
        }
    }
}


/*
 * 单一职责原则：就一个类而言，应该仅有一个引起它变化的原因。
 * 
 * 依赖倒置原则：1、抽象不应该依赖于细节，细节应该依赖于抽象 2、高层模块不应该依赖底层模块，两者都应该依赖抽象。
 * 
 * 迪米特法则：如果两个类不必彼此直接通信，那么这两个类就不应当发生直接的相互作用。如果其中一个类需要调用另一个
 * 类的某一个方法的话，可以通过第三方转发这个调用。 强调了类之间的松耦合。
*/
