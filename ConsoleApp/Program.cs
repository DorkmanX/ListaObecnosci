using BLL;
using DLL;
using DLL.EntityFramework;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static void Main(string[] args)
    {
        MainController controller = new MainController();
        int operation = 1;
        do
        {
            Console.WriteLine("Wybierz z listy zadanie");
            Console.WriteLine("1. Dodaj studenta ");
            Console.WriteLine("2. Dodaj grupę ");
            Console.Write("Wybierz nr operacji: ");
            operation = Convert.ToInt32(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    controller.AddStudent();
                    break;
                case 2:
                    controller.AddGroup();
                    break;
                case 12:
                    operation = 0;
                    break;

            }
        }
        while (operation != 0);
    }
}

