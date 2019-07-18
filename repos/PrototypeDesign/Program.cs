using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrototypeDesign
{
    /*
    *原型模式：用原型实例指定创建对象的种类，并且通过拷贝这些原型，创建新的实例 
    */
    class Program
    {
        static void Main(string[] args)
        {

            //ConcretePortotype concrete = new ConcretePortotype("112");
            //var concrete2 = (ConcretePortotype)concrete.Clone();

            //Console.WriteLine(concrete.ID);
            //Console.WriteLine(concrete2.ID);

            //Console.ReadKey();

            #region 浅表复制

            // var start = DateTime.Now;
            //var resume = new Resume("张三");
            //resume.SetExperience("chinese company", "China");


            ////一般在初始化的信息不发生变化的情况下，克隆是最好的办法，这既隐藏了对象创建的细节，又能调高性能
            //var r2 = (Resume)resume.Clone();
            //resume.SetExperience("american company", "China");
            //resume.Display();
            //r2.Display();
            ////var resume1 = new Resume("张四");
            ////resume1.Experience = "C# 工作5年";
            ////resume1.Display();
            //Console.WriteLine($"it took {(DateTime.Now - start).TotalMilliseconds} millseconds ");
            //Console.ReadKey();

            //var start = DateTime.Now;
            //var resume = new Resume("张三");
            //resume.SetExperience("chinese company", "China");

            #endregion
            var start = DateTime.Now;
            var resume = new Resume1("张三");
            resume.SetExperience("chinese company", "China");
            //一般在初始化的信息不发生变化的情况下，克隆是最好的办法，这既隐藏了对象创建的细节，又能调高性能
            var r2 = (Resume1)resume.Clone();
            r2.SetExperience("american company", "China");
            resume.Display();
            r2.Display();
           
            Console.WriteLine($"it took {(DateTime.Now - start).TotalMilliseconds} millseconds ");
            Console.ReadKey();
        }
    }

    //深复制demo
    class Resume1 : ICloneable
    {
        private string _name;
        public Resume1(string name)
        {
            Thread.Sleep(1000);
            work = new WorkExperience1();
            _name = name;
        }
        private Resume1(WorkExperience1 work1)
        {
            work = (WorkExperience1)work1.Clone();
        }
        private string Address { get; set; }

        private WorkExperience1 work { get; set; }

        public void SetExperience(string company, string address)
        {
            work.Company = company;
            Address = address;
        }
        public void Display()
        {
            Console.WriteLine($"{_name}工作单位{work.Company},地址{Address}");
        }
        public object Clone()
        {
            Resume1 resume1 = new Resume1(this.work);
            resume1._name = this._name;
            resume1.Address = this.Address;
            return resume1;
        }
    }

    class WorkExperience1:ICloneable
    {
        public string Company { get; set; }

        public object Clone()
        {
            return (WorkExperience1)this.MemberwiseClone();
        }
    }



    //原型demo 浅表复制

    class Resume : ICloneable
    {
        private string _name;
        public Resume(string name)
        {
            Thread.Sleep(1000);
            work = new WorkExperience();
            _name = name;
        }
        private string Address { get; set; }

        private WorkExperience work { get; set; }

        public void SetExperience(string company, string address)
        {
            work.Company = company;
            Address = address;
        }
        public void Display()
        {
            Console.WriteLine($"{_name}工作单位{work.Company},地址{Address}");
        }
        public object Clone()
        {
            return (Resume)MemberwiseClone();
        }
    }

    class WorkExperience
    {
        public string Company { get; set; }
    }


    #region 原型模式

    abstract class ProtoType
    {
        public ProtoType(string id)
        {
            _id = id;
        }
        private string _id;
        public string ID { get { return _id; } }

        public abstract ProtoType Clone();
    }

    class ConcretePortotype : ProtoType
    {
        public ConcretePortotype(string id) : base(id)
        {

        }
        public override ProtoType Clone()
        {
            return (ProtoType)this.MemberwiseClone();
            /*
             MemberwiseClone 创建当前对象的浅表副本。方法是创建一个新对象，
             然后将当前对象的非静态字段复制到该新对象。如果字段是值类型的，则
             对该字段执行逐位复制。如果字段是引用类型，则复制引用，但不复制引用
             的对象，因此，原始对象及其副本引用同一对象。
             */
        }
    }

    #endregion

}
