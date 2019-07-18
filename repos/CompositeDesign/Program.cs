using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesign
{
    /*组合模式，将对象组合成树形结以表示部分-整体的层次结构，组合模式使得用户对单个对象和组合对象的使用具有一致性
     
    场景：需求中体现部分与整体的层次结构；用户希望忽略组合对象与单个对象的不同，统一的使用组合结构中的所有对象时
         */
    class Program
    {
        static void Main(string[] args)
        {
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            var comp = new Composite("Composite X");
            comp.Add(new Leaf("LeafX A"));
            comp.Add(new Leaf("LeafX B"));
            root.Add(comp);

            var comp2 = new Composite("Composite XY");
            comp2.Add(new Leaf("Leaf XYA"));
            comp2.Add(new Leaf("Leaf XYB"));
            comp.Add(comp2);

            root.Add(new Leaf("Leaf C"));

            var leaf=new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            root.Display(1);
            Console.Read();
        }
    }

    abstract class Component
    {
        protected string name;
        public Component(string _name)
        {
            this.name = _name;
        }

        public abstract void Add(Component c);

        public abstract void Remove(Component c);

        public abstract void Display(int depth);
    }

    class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {

        }
        public override void Add(Component c)
        {
            Console.WriteLine("cannot add a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth)+ name);
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("cannot remove a leaf");
        }
    }

    class Composite : Component
    {
        private List<Component> children = new List<Component>();
        public Composite(string name) : base(name)
        {

        }
        public override void Add(Component c)
        {
            children.Add(c);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth)+ name);
            foreach (var c in children)
            {
                c.Display(depth + 2);
            }
        }

        public override void Remove(Component c)
        {
            children.Remove(c);
        }
    }
}
