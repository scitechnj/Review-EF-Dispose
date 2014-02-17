using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace ConsoleApplication33
{
    class Program
    {
        static void Main(string[] args)
        {
            #region old
            //MyClass mc = new MyClass();
            //Method(mc);

            //Method(new OtherClass());

            //mc.Foo();
            //var oc = new OtherClass();
            //oc.Foo();
            #endregion

            //Console.WriteLine("Enter a number");
            //string x = Console.ReadLine();
            //try
            //{
            //    int y = int.Parse(x);
            //    Console.WriteLine("You're good at following instructions");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Are you serious???");
            //}

            //Method2(new DerivedClass(10));

            Person p1 = new Person();
            p1.FirstName = "Avrumi";
            p1.LastName = "Friedman";
            p1.Age = 45;
            p1.Id = 1;
            p1.Orders = new List<Order>();
            for (int i = 3; i <= 5; i++)
            {
                p1.Orders.Add(new Order
                    {
                        Id = i,
                        ProductName = "Second Product",
                        Quantity = 183,
                        PersonId = p1.Id
                    });
            }

            p1.Orders.First().Quantity = 83692364;
            using (var dl = new MyDataLayer())
            {
                dl.Update(p1);
            }

            Console.ReadKey(true);

        }

        private static void Method2(BaseClass bc)
        {
            bc.Foo();
        }

        private static void Method(IMyInterface imi)
        {
            MyClass mc = (MyClass)imi;
            mc.Bar();
        }
    }
    #region old
    public interface IMyInterface
    {
        void Foo();
    }

    public interface IOtherInterface
    {
        string Foo();
    }

    public class OtherClass : IMyInterface, IOtherInterface
    {
        void IMyInterface.Foo()
        {

        }

        public string Foo()
        {
            return "";
        }
    }

    public class MyClass : IMyInterface
    {
        public void Foo()
        {

        }

        public void Bar()
        {

        }
    }
    #endregion
    public class BaseClass
    {
        public BaseClass(int x)
        {
        }

        public virtual void Foo()
        {
            Console.WriteLine("From the base");
        }
    }

    public class DerivedClass : BaseClass
    {
        public DerivedClass(int x)
            : base(x)
        {

        }

        public override void Foo()
        {
            Console.WriteLine("From the derived");
            base.Foo();
        }

    }

    public abstract class MyAbstractClass
    {
        public abstract void Foobar();

        public void Something()
        {
            Console.WriteLine("");
        }
    }
}
