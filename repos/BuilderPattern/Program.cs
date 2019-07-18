using System;

namespace BuilderPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Builder builder = new ZhangsanBuilder();
            var director = new Director(builder);
            director.Construct();
            DecorateHouse decorateHouse = builder.GetResult();
            decorateHouse.Show();

            Console.Read();
        }
    }

    internal class DecorateHouse
    {
        public string TV { get; set; }

        public string Wall { get; set; }

        public string Lamp { get; set; }

        public void Show()
        {
            Console.WriteLine($"{TV + "----" + Wall + "------" + Lamp }");
        }
    }

    internal class Director
    {
        private Builder _builder;
        public Director(Builder builder)
        {
            _builder = builder;
        }
        public void Construct()
        {
            _builder.InstallLamp();
            _builder.InstallTv();
            _builder.PaintingWall();
        }
    }

    internal abstract class Builder
    {
        public abstract void InstallTv();
        public abstract void PaintingWall();
        public abstract void InstallLamp();
        public abstract DecorateHouse GetResult();
    }

    internal class ZhangsanBuilder : Builder
    {
        private DecorateHouse house = new DecorateHouse();
        public override DecorateHouse GetResult()
        {
            return house;
        }

        public override void InstallLamp()
        {
            house.Lamp = "安装灯具1";
        }

        public override void InstallTv()
        {
            house.TV = "安装电视1";
        }

        public override void PaintingWall()
        {
            house.Wall = "刷墙1";
        }
    }

    internal class LisiBuilder : Builder
    {
        private DecorateHouse house = new DecorateHouse();
        public override DecorateHouse GetResult()
        {
            return house;
        }

        public override void InstallLamp()
        {
            house.Lamp = "安装灯具2";
        }

        public override void InstallTv()
        {
            house.Lamp = "安装电视2";
        }

        public override void PaintingWall()
        {
            house.Wall = "刷墙2";
        }
    }

}
