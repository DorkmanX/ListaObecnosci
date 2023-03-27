using DLL;
using DLL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class MainController
    {
        private DBContext _dbContext;
        public MainController() { _dbContext = new DBContext(); }

        public bool AddStudent()
        {
            Console.Write("Podaj imie studenta: ");
            string name = Console.ReadLine();
            Console.Write("Podaj nazwisko studenta: ");
            string surname = Console.ReadLine();

            StudentDTO newUser = new StudentDTO(name, surname);

            try
            {
                _dbContext.Students.Add(newUser);
                _dbContext.SaveChanges();
                Console.Write("Operacja wykonana pomyślnie");
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public bool AddGroup()
        {
            Console.Write("Podaj nazwe grupy: ");
            string name = Console.ReadLine();
            Console.Write("Podaj opis grupy(opcjonalnie): ");
            string description = Console.ReadLine() ?? string.Empty;

            GroupDTO newGroup = new GroupDTO(name, description);

            try
            {
                _dbContext.Groups.Add(newGroup);
                _dbContext.SaveChanges();
                Console.Write("Operacja wykonana pomyślnie");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public bool AddUserToGroup()
        {
            Console.WriteLine("Lista obecnych grup");
            var groups = _dbContext.Groups.ToList();
            //AdminUserView adminUser = _mapper.Map<UserDTO, AdminUserView>(user);
            foreach (var group in groups) 
            {
                Console.WriteLine(group.Name);
            }
            return true;
        }
    }
}