public class Decorator
{
    static void Main(string[] args)
    {
        Pizza pizza1 = new ItalianPizza();
        pizza1 = new TomatoPizza(pizza1); 
        Console.WriteLine("Name: {0}", pizza1.Name);
        Console.WriteLine("Cost: {0}", pizza1.GetCost());

        Pizza pizza2 = new ItalianPizza();
        pizza2 = new CheesePizza(pizza2);
        Console.WriteLine("Name: {0}", pizza2.Name);
        Console.WriteLine("Cost: {0}", pizza2.GetCost());

        Pizza pizza3 = new BulgarianPizza();
        pizza3 = new TomatoPizza(pizza3);
        pizza3 = new CheesePizza(pizza3);/
        Console.WriteLine("Name: {0}", pizza3.Name);
        Console.WriteLine("Cost: {0}", pizza3.GetCost());

        
    }
}

abstract class Pizza
{
    public Pizza(string n)
    {
        Name = n;
    }
    public string Name { get; protected set; }
    public abstract int GetCost();
}

class ItalianPizza : Pizza
{
    public ItalianPizza() : base("Italian pizza")
    { }
    public override int GetCost()
    {
        return 10;
    }
}
class BulgarianPizza : Pizza
{
    public BulgarianPizza()
        : base("Bulgarian Pizza")
    { }
    public override int GetCost()
    {
        return 8;
    }
}

abstract class PizzaDecorator : Pizza
{
    protected Pizza pizza;
    public PizzaDecorator(string n, Pizza pizza) : base(n)
    {
        this.pizza = pizza;
    }
}

class TomatoPizza : PizzaDecorator
{
    public TomatoPizza(Pizza p)
        : base(p.Name + ", with tomatoes", p)
    { }

    public override int GetCost()
    {
        return pizza.GetCost() + 3;
    }
}

class CheesePizza : PizzaDecorator
{
    public CheesePizza(Pizza p)
        : base(p.Name + ", with cheese", p)
    { }

    public override int GetCost()
    {
        return pizza.GetCost() + 5;
    }
}
