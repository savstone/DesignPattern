using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDesign
{
    /*
     * 状态模式：当一个对象的内在状态改变时允许改变其行为，这个对象看起来像是改变了其类。
     * 
     * 状态模式主要解决的是当控制一个对象状态转换的条件表达式过于复杂的情况。把状态的判断逻辑转移到
     * 表示不同状态的一系列类中，可以把复杂的逻辑判断简化。
     * 
     * 好处：将与特定状态相关的行为局部化，并且将不同状态的行为分割开来。
       
     */
    class Program
    {
        static void Main(string[] args)
        {
            //Work work = new Work();
            //work.Hour = 12;
            //work.WrietePrograme();
            //Console.Read();


            //Context context = new Context(new ConcreteStateA());
            //context.Request();
            //context.Request();
            //context.Request();
            //context.Request();

            WorkState state = new MorinigState();
            WorkContext context = new WorkContext(state);

            context.Hourt = 18;
            context.DoWork();

            Console.Read();
        }
    }

    #region 状态模式的基本结构

    class Context
    {
        private State _state;
        public Context(State state)
        {
            State = state;
        }

        public State State { get => _state; set { _state = value; Console.WriteLine($"当前状态{State.GetType().Name}"); } }
        public void Request()
        {
            _state.Handle(this);
        }
    }

    abstract class State
    {
        public abstract void Handle(Context context);

    }

    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }


    #endregion

    /// <summary>
    /// 由此引出状态模式
    /// </summary>
    class Work
    {
        public int Hour { get; set; }
        public bool IsFinished { get; set; }

        public void WrietePrograme()
        {
            if (Hour < 12)
            {
                Console.WriteLine($"当前时间{Hour},上午工作，精神爽");
            }
            else if (Hour < 13)
            {
                Console.WriteLine($"当前时间{Hour},吃完饭，犯困");
            }
            else if (Hour < 17)
            {
                Console.WriteLine($"当前时间{Hour},状态还不错");
            }
            else
            {
                if (IsFinished)
                {
                    Console.WriteLine($"当前时间{Hour},下班了。拜拜");
                }
                else
                {
                    if (Hour < 21)
                    {
                        Console.WriteLine($"当前时间{Hour},加班，疲劳至极");
                    }
                    else
                    {
                        Console.WriteLine($"当前时间{Hour},哦哦，睡着了");
                    }
                }
            }
        }
    }

    class WorkContext
    {
        private WorkState state;
        public WorkContext(WorkState state)
        {
            this.State = state;
        }
        public int Hourt { get; set; }
        public bool IsFinished { get; set; }
        internal WorkState State { get => state; set => state = value; }

        public void DoWork()
        {
            State.WritePrograme(this);
        }
    }

    abstract class WorkState
    {
        public abstract void WritePrograme(WorkContext context);
    }

    class MorinigState : WorkState
    {
        public override void WritePrograme(WorkContext context)
        {
            if (context.Hourt < 12)
            {
                Console.WriteLine($"当前时间{context.Hourt},上午工作，精神爽");
            }
            else
            {
                context.State = new NoonState();
                context.DoWork();
            }
        }
    }

    class NoonState : WorkState
    {
        public override void WritePrograme(WorkContext context)
        {
            if (context.Hourt < 13)
            {
                Console.WriteLine($"当前时间{context.Hourt},吃完饭，犯困");
            }
            else
            {
                context.State = new AfternoonState();
                context.DoWork();
            }
        }
    }

    class AfternoonState : WorkState
    {
        public override void WritePrograme(WorkContext context)
        {
            if (context.Hourt < 17)
            {
                Console.WriteLine($"当前时间{context.Hourt},状态还不错");
            }
            else
            {
                context.State = null;
                context.DoWork();
            }
        }
    }
    class RelaxState : WorkState
    {
        public override void WritePrograme(WorkContext context)
        {
            Console.WriteLine($"当前时间{context.Hourt},下班回家了");

        }
    }
    class SleepingState : WorkState
    {
        public override void WritePrograme(WorkContext context)
        {
            Console.WriteLine($"当前时间{context.Hourt},困的不行了。睡觉了。");

        }
    }
    class EveningState : WorkState
    {
        public override void WritePrograme(WorkContext context)
        {
            if (context.IsFinished)
            {
                context.State = new RelaxState();
                context.DoWork();
            }
            else
            {
                if (context.Hourt < 21)
                {
                    Console.WriteLine($"当前时间{context.Hourt},加班，疲劳至极");
                }
                else
                {
                    context.State = new SleepingState();
                    context.DoWork();
                }
            }
        }
    }
}
