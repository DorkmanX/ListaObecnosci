using BLL;
using DLL;
using DLL.EntityFramework;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static void Main(string[] args)
    {
        MainController controller = new MainController();
        int operation;
        do
        {
            Console.WriteLine("\nWybierz z listy zadanie");
            Console.WriteLine("1. Dodaj studenta ");
            Console.WriteLine("2. Wyswietl liste studentów ");
            Console.WriteLine("3. Utwórz zajęcia");
            Console.WriteLine("4. Wyświetl listę zajęć");
            Console.WriteLine("5. Utwórz grupę zajęciową");
            Console.WriteLine("6. Wyświetl liste grup zajęciowych");
            Console.WriteLine("7. Przypisz studenta do grupy zajęciowej");
            Console.WriteLine("8. Utwórz zajęcia");
            Console.WriteLine("9. Sprawdź obecność na zajęciach");
            Console.WriteLine("10. Wpisz oceny z zajęć");

            Console.Write("Wybierz nr operacji: ");
            operation = Convert.ToInt32(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    controller.AddStudent();
                    break;
                case 2:
                    controller.PrintStudents();
                    break;
                case 3:
                    controller.AddCourse();
                    break;
                case 4:
                    controller.PrintCourses();
                    break;
                case 5:
                    controller.AddGroup();
                    break;
                case 6:
                    controller.PrintGroups();
                    break;
                case 7:
                    controller.AddUserToGroup();
                    break;
                case 8:
                    controller.CreateLesson();
                    break;
                case 9:
                    controller.CheckPresenceOnLessons();
                    break;
                case 10:
                    controller.AddMark();
                    break;
                case 12:
                    operation = 0;
                    break;

            }
        }
        while (operation != 0);
    }
}

