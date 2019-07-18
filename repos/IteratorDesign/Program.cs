using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDesign
{
    /*迭代器模式：提供一种方法顺序访问一个聚合对象中的各个元素，而又不暴露该对象的内部表示*/
    class Program
    {
        static void Main(string[] args)
        {
            CocreteAggregate cocrete = new CocreteAggregate();
            cocrete[0] = "张三";
            cocrete[1] = "李四";
            cocrete[2] = "王五";
            cocrete[3] = "赵六";
            cocrete[4] = "刘七";

            Iterator i = new CocreteIterator(cocrete);
            i.First();
            while (!i.IsDone())
            {
                Console.WriteLine($"{i.CurrentItem().ToString()}的请买票");
                i.Next();
            }

            Console.Read();
        }
    }
    abstract class Aggregate
    {
        //public abstract Iterator CreateIterator();
    }

    class CocreteAggregate : Aggregate
    {
        private List<object> items = new List<object>();
        //public override Iterator CreateIterator()
        //{
        //    return new CocreteIterator(this);
        //}

        public int Count => items.Count;

        public object this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }

    }

    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();

        public abstract bool IsDone();

        public abstract object CurrentItem();
    }

    class CocreteIterator : Iterator
    {
        private CocreteAggregate _cocreteAggregate;
        private int currentCount = 0;
        public CocreteIterator(CocreteAggregate cocreteAggregate)
        {
            _cocreteAggregate = cocreteAggregate;
        }
        public override object CurrentItem()
        {
            return _cocreteAggregate[currentCount];
        }

        public override object First()
        {
            return _cocreteAggregate[0];
        }

        public override bool IsDone()
        {
            return currentCount >= _cocreteAggregate.Count ? true : false;
        }

        public override object Next()
        {
            object obj = null;
            currentCount++;
            if (currentCount < _cocreteAggregate.Count)
            {
                return _cocreteAggregate[currentCount];
            }
            return obj;
        }
    }
}
