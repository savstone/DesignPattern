
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildDesign
{
    /*建造者模式:将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示
     * 
     * 场景：主要是用于创建一些复杂的对象，这些对象内部构建间的建造顺序通常是稳定的，但对象内部的构建通常
     * 面临着复杂的变化。
           
         */
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            Builder builder1 = new ConcretBuilderA();
            director.Construct(builder1);
            Product product = builder1.GetProduct();
            product.Show();
        }
    }
    //产品类，由多个部件组成
    class Product
    {
        private List<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("产品构建-----");
            foreach (var item in parts)
            {
                Console.WriteLine(item);
            }
        }
    }
    abstract class Builder
    {
        public abstract void BuilderA();
        public abstract void BuilderB();
        public abstract Product GetProduct();
    }

    class ConcretBuilderA : Builder
    {
        Product product = new Product();
        public override void BuilderA()
        {
            product.Add("part A");
        }

        public override void BuilderB()
        {
            product.Add("part A");
        }

        public override Product GetProduct()
        {
            return product;
        }
    }

    class ConcretBuilderB : Builder
    {
        Product product = new Product();
        public override void BuilderA()
        {
            product.Add("part A");
        }

        public override void BuilderB()
        {
            product.Add("part A");
        }

        public override Product GetProduct()
        {
            return product;
        }
    }

    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuilderA();
            builder.BuilderB();
        }
    }

}
