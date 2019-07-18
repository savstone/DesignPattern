using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesign
{
    /*装饰器模式：动态的为一个类添加额外的功能，就增加功能来说，装饰模式比生成子类更为灵活*/
    class Program
    {
        static void Main(string[] args)
        {
            Component component = new ConcoretComponent();
            var decorator1 = new ConcoretDecoratorA();
            var decorator2 = new ConcoretDecoratorB();
            decorator1.SetComponent(component);
            decorator2.SetComponent(decorator1);
            decorator2.show();

            Console.Read();
        }
    }

    //定义一个对象接口，可以给这些对象动态的添加职责
    interface Component
    {
        void show();
    }

    class ConcoretComponent : Component
    {
        public void show()
        {
            Console.WriteLine("具体的实现");
        }
    }


    abstract class Decorator : Component
    {
        protected Component component;
        public virtual void show()
        {
            if (component != null)
            {
                component.show();
            }
        }
    }

    class ConcoretDecoratorA : Decorator
    {
        private string State;
        
        public void SetComponent(Component component1)
        {
            component = component1;
        }
        public override void show()
        {
            base.show();
            Console.WriteLine("具体装饰对象的A的操作");
        }
    }
    class ConcoretDecoratorB : Decorator
    {
        private string State;
        public void SetComponent(Component component1)
        {
            component = component1;
        }
        public override void show()
        {
            base.show();
            Console.WriteLine("具体装饰对象的B的操作");
        }
    }
}
