namespace MyLittleCoffeeShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICoffee basicCoffee = new BasicCoffee();
            Console.WriteLine(basicCoffee.GetDescription());
            Console.WriteLine(basicCoffee.GetCost());

            ICoffee galao = new GalaoDecorator(basicCoffee);
            Console.WriteLine(galao.GetDescription());
            Console.WriteLine(galao.GetCost());
        }

        public interface ICoffee
        {
            string GetDescription();
            double GetCost();
        }

        public class BasicCoffee : ICoffee
        {
            public string GetDescription()
            {
                return "Basic Coffee";
            }
            public double GetCost()
            {
                return 5.0;
            }
        }

        public abstract class CoffeDecorator : ICoffee
        {
            protected ICoffee _coffee;
            public CoffeDecorator(ICoffee coffee)
            {
                _coffee = coffee;
            }
            public virtual double GetCost()
            {
                return _coffee.GetCost();
            }

            public virtual string GetDescription()
            {
                return _coffee.GetDescription();
            }
        }

        public class GalaoDecorator : CoffeDecorator
        {
            public GalaoDecorator(ICoffee coffee) : base(coffee)
            {

            }

            public override string GetDescription()
            {
                return base.GetDescription() + ", with Milk";
            }

            public override double GetCost()
            {
                return base.GetCost() + 2.0;
            }
        }


    }
}