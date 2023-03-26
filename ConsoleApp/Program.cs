using DLL;
using DLL.EntityFramework;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static DBContext _dbContext = new DBContext();
    static void Main(string[] args)
    {
        int operation = 1;
        do
        {
            Console.WriteLine("Wybierz z listy zadanie");
            Console.WriteLine("1. Dodaj studenta ");
            Console.WriteLine("Wybierz nr operacji: ");
            operation = Convert.ToInt32(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    AddStudent();
                    break;
                case 12:
                    operation = 0;
                    break;

            }
        }
        while (operation != 0);
    }

    public static void AddStudent()
    {
        Console.WriteLine("Podaj imie studenta: ");
        string name = Console.ReadLine();
        Console.WriteLine("Podaj nazwisko studenta: ");
        string surname = Console.ReadLine();

        StudentDTO newUser = new StudentDTO(name,surname);
        GroupDTO newGroup = new GroupDTO("Grupa 3");
        GroupDTO newGroup2 = new GroupDTO("Grupa 4");
        newUser.Groups.Add(newGroup);
        newUser.Groups.Add(newGroup2);
        _dbContext.Users.Add(newUser);
        _dbContext.SaveChanges();

        var user_with_group = _dbContext.Students.Where(x => x.Id == 4).Include(x => x.Groups).FirstOrDefault();
        foreach(var group in user_with_group.Groups)
        {
            Console.WriteLine("Grupa: "+ group.Name);
        }
    }
}

