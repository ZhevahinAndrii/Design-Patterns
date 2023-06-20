class Program
{
    static void Main(string[] args)
    {
        Hero hero = new Hero();
        hero.Shoot(); // стріляємо, залишилось 9 патронів
        GameHistory game = new GameHistory();

        game.History.Push(hero.SaveState()); // зберігаємо гру

        hero.Shoot(); //стріляємо, залишилось 8 патронів

        hero.RestoreState(game.History.Pop());

        hero.Shoot(); //стріляємо , залишилось 8 патронів

      
    }
}

// Originator
class Hero
{
    private int patrons = 10; // amount of bulles
    private int lives = 5; // amount of lives

    public void Shoot()
    {
        if (patrons > 0)
        {
            patrons--;
            Console.WriteLine("Shoots.{0} bullets left", patrons);
        }
        else
            Console.WriteLine("There are no bullets anymore");
    }
    // сохранение состояния
    public HeroMemento SaveState()
    {
        Console.WriteLine("Saving. Parameters: {0} bullets, {1} lives", patrons, lives);
        return new HeroMemento(patrons, lives);
    }

    // восстановление состояния
    public void RestoreState(HeroMemento memento)
    {
        patrons = memento.Patrons;
        lives = memento.Lives;
        Console.WriteLine("Restoring. Parameters: {0} bullets, {1} lives", patrons, lives);
    }
}
// Memento
class HeroMemento
{
    public int Patrons { get; private set; }
    public int Lives { get; private set; }

    public HeroMemento(int patrons, int lives)
    {
        Patrons = patrons;
        Lives = lives;
    }
}

// Caretaker
class GameHistory
{
    public Stack<HeroMemento> History { get; private set; }
    public GameHistory()
    {
        History = new Stack<HeroMemento>();
    }
}
