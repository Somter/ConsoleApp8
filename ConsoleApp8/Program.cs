using ConsoleApp8;

class MainClass
{
    public static void Main()
    {
        try
        {
           ClassMenu menu = new ClassMenu();
           menu.ShowMenu();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}