using DLL;
using DLL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class MainController
    {
        private DBContext _dbContext;
        private TeacherDTO _teacher;
        public MainController() { _dbContext = new DBContext(); }

        public bool Login()
        {
            Console.Write("Podaj login: ");
            string login = Console.ReadLine();
            Console.Write("Podaj hasło: ");
            string password = Console.ReadLine();

            try
            {
                var techer = _dbContext.Teachers.Where(x => string.Compare(x.Login,login) == 0 && string.Compare(x.Password,password) == 0).FirstOrDefault();
                if (techer != null)
                {
                    _teacher = techer;
                    Console.WriteLine("Zalogowano pomyślnie");
                    return true;
                }
                else
                {
                    Console.WriteLine("Niepoprawny login i hasło");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool AddTeacher()
        {
            Console.Write("Podaj login: ");
            string login = Console.ReadLine();
            Console.Write("Podaj hasło: ");
            string password = Console.ReadLine();
            Console.Write("Podaj imie: ");
            string name = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            string surname = Console.ReadLine();

            try
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(surname))
                {
                    Console.WriteLine("Wprowadziles pusty login lub hasło lub imie lub nazwisko");
                    return false;
                }
                TeacherDTO newTeacher = new TeacherDTO()
                {
                    Name = name,
                    Surname = surname,
                    Login = login,
                    Password = password
                };

                _dbContext.Add(newTeacher);
                _dbContext.SaveChanges();

                Console.WriteLine("Dodano nowego nauczyciela");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool AddStudent()
        {
            Console.Write("Podaj imie studenta: ");
            string name = Console.ReadLine();
            Console.Write("Podaj nazwisko studenta: ");
            string surname = Console.ReadLine();

            StudentDTO newUser = new StudentDTO()
            {
                Name = name,
                Surname = surname
            };

            try
            {
                _dbContext.Students.Add(newUser);
                _dbContext.SaveChanges();
                Console.WriteLine("Operacja wykonana pomyślnie");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool PrintStudents()
        {
            List<StudentDTO> students = _dbContext.Students.ToList();
            if (students.Any())
            {
                foreach (StudentDTO student in students)
                {
                    Console.WriteLine("ID: " + student.Id + " Imie: " + student.Name + " Nazwisko: " + student.Surname);
                }
                return true;
            }
            Console.WriteLine("Lista studentów jest pusta");
            return false;
        }
        public bool AddCourse()
        {
            Console.Write("Podaj nazwe zajęć: ");
            string name = Console.ReadLine();
            Console.Write("Podaj opis grupy(opcjonalnie): ");
            string description = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrEmpty(name))
            {
                CourseDTO newCourse = new CourseDTO()
                {
                    Name = name,
                    Description = description,
                    Teacher = _teacher
                };

                try
                {
                    List<GroupDTO> groups = _dbContext.Groups.ToList();
                    if (!groups.Any())
                    {
                        Console.WriteLine("Nie ma grup do wyboru. Najpierw utworz grupe");
                        return false;
                    }
                    foreach (var group in groups)
                    {
                        Console.WriteLine("ID " + group.Id + " Nazwa " + group.Name);
                    }
                    Console.WriteLine("Wybierz ID grupy");
                    int groupId = Convert.ToInt32(Console.ReadLine());

                    GroupDTO selectedGroup = groups.Where(x => x.Id == groupId).First();
                    newCourse.Group = selectedGroup;

                    _dbContext.Courses.Add(newCourse);
                    _dbContext.SaveChanges();
                    Console.WriteLine("Operacja wykonana pomyślnie");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine("Wybrałeś złe ID lub takie nie istnieje w bazie");
                    return false;
                }
                return true;
            }
            Console.WriteLine("Nazwa jest pusta");
            return false;
        }

        public bool PrintCourses()
        {
            List<CourseDTO> courses = _dbContext.Courses.Include(x => x.Teacher).Include(x => x.Group).Include(x => x.Lessons).ToList();
            if (courses.Any())
            {
                Console.WriteLine("Lista zajęć: ");
                foreach (CourseDTO course in courses)
                {
                    Console.WriteLine("ID: " + course.Id + " Name: " + course.Name + " Opis: " + course.Description +
                        " Nauczyciel prowadzący: " + (course?.Teacher?.Name) + " " + (course?.Teacher?.Surname) 
                        + " Grupa zajęciowa: " + course?.Group?.Name ?? "Nieprzypisana ");
                }
                return true;
            }
            Console.WriteLine("Lista zajęć jest pusta");
            return false;
        }
        public bool AddGroup()
        {
            Console.Write("Podaj nazwe grupy: ");
            string name = Console.ReadLine();
            Console.Write("Podaj opis grupy(opcjonalnie): ");
            string description = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrEmpty(name))
            {
                GroupDTO newGroup = new GroupDTO()
                {
                    Name = name,
                    Description = description,
                    Teacher = _teacher
                };

                try
                {
                    _dbContext.Groups.Add(newGroup);
                    _dbContext.SaveChanges();
                    Console.WriteLine("Operacja wykonana pomyślnie");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                return true;
            }
            Console.WriteLine("Nazwa jest pusta");
            return false;
        }

        public bool PrintGroups()
        {
            List<GroupDTO> groups = _dbContext.Groups.Include(x => x.Students).ToList();
            if (groups.Count > 0)
            {
                foreach (GroupDTO group in groups)
                {
                    Console.WriteLine("ID: " + group.Id + " Nazwa " + group.Name);
                    Console.WriteLine("Lista studentów przypisanych do grupy: ");
                    foreach (StudentDTO student in group?.Students ?? new List<StudentDTO>())
                    {
                        Console.WriteLine("ID: " + student.Id + " Name: " + student.Name + " Surname: " + student.Surname);
                    }
                }
                return true;
            }
            Console.WriteLine("Lista grup jest pusta:");
            return false;
        }
        public bool AddUserToGroup()
        {
            Console.WriteLine("Lista obecnych grup");
            List<GroupDTO> groups = _dbContext.Groups.ToList();
            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Console.WriteLine("ID: " + group.Id + " Nazwa " + group.Name);
                }
                try
                {
                    Console.WriteLine("Wpisz numer ID grupy do której chcesz dodać studenta");
                    int groupId = Convert.ToInt32(Console.ReadLine());
                    GroupDTO selectedGroup = groups.Where(x => x.Id == groupId).First();

                    Console.WriteLine("Wybierz ID studenta ktorego chcesz dodać");
                    List<StudentDTO> students = _dbContext.Students.ToList();
                    if (students.Any())
                    {
                        foreach (var student in students)
                        {
                            Console.WriteLine("ID: " + student.Id + " Nazwa" + student.Name + " " + student.Surname);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lista studentow jest pusta, najpierw utworz studenta");
                        return false;
                    }
                    Console.WriteLine("Wybierz ID studenta ktorego chcesz dodać");
                    int studentId = Convert.ToInt32(Console.ReadLine());
                    StudentDTO selectedStudent = students.Where(x => x.Id == studentId).First();
                    selectedGroup.Students.Add(selectedStudent);

                    _dbContext.Update(selectedGroup);
                    _dbContext.SaveChanges();
                    Console.WriteLine("Operacja przebiegła pomyślnie");
                    return true;
                }
                catch
                {
                    Console.WriteLine("Podałeś zły numer ID lub taki nie istnieje już w bazie");
                    return false;
                }
            }
            Console.WriteLine("Lista grup jest pusta, najpierw utworz grupę");
            return false;
        }
        public bool CreateLesson()
        {
            Console.WriteLine("Wybierz kurs dla którego chcesz utworzyć zajęcia");
            List<CourseDTO> courses = _dbContext.Courses.Include(x => x.Group).ThenInclude(x => x.Students).ToList();
            if (!courses.Any())
            {
                Console.WriteLine("Nie ma kursów do wyboru. Najpierw utworz kurs");
                return false;
            }
            foreach (var course in courses)
            {
                Console.WriteLine("ID " + course.Id + " Nazwa " + course.Name);
            }

            try
            {
                Console.WriteLine("Wybierz ID kursu");
                int courseId = Convert.ToInt32(Console.ReadLine());
                CourseDTO selectedCourse = courses.Where(x => x.Id == courseId).First();

                Console.WriteLine("Wybierz termin zajęć. Wprowadź go w formacie dzień/miesiąc/rok godzina:minuta:sekunda");
                string dateTime = Console.ReadLine();
                DateTime date = DateTime.Parse(dateTime);
                bool isDone = DateTime.Compare(date, DateTime.Now) <= 0 ? true : false;

                LessonDTO newLesson = new LessonDTO()
                {
                    CourseId = courseId,
                    LessonDate = date,
                    IsDone = isDone
                };

                if(isDone)
                {
                    Console.WriteLine("Sprawdź obecność: ");
                    var studentsList = selectedCourse?.Group?.Students;
                    if (studentsList != null)
                    {
                        foreach(var student in studentsList)
                        {
                            Console.WriteLine("ID: " + student.Id + " Imie i nazwisko " + student.Name + " " + student.Surname);
                            Console.WriteLine("Wpisz 'true' jeżeli obecny w przeciwny razie 'false'");
                            try
                            {
                                bool presence = Convert.ToBoolean(Console.ReadLine());
                                TimesheetDTO timeSheet = new TimesheetDTO()
                                {
                                    Date = date,
                                    IsPresence = presence,
                                    Student = student
                                };
                                newLesson.Timesheets.Add(timeSheet);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                return false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lista studentów jest pusta");
                        return false;
                    }
                }
                _dbContext.Add(newLesson);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool CheckPresenceOnLessons()
        {
            Console.WriteLine("Lista kursów");
            List<CourseDTO> courses = _dbContext.Courses.Include(x => x.Teacher).Include(x => x.Group).Include(x => x.Lessons).ToList();
            if (courses.Any())
            {
                foreach (CourseDTO course in courses)
                {
                    Console.WriteLine("ID: " + course.Id + " Name: " + course.Name + " Opis: " + course.Description +
                        " Nauczyciel prowadzący: " + (course?.Teacher?.Name ?? " Nieprzypisany ") + " Grupa zajęciowa: " + course?.Group?.Name ?? "Nieprzypisana ");
                }
                Console.WriteLine("Wybierz ID kursu");
                try
                {
                    int courseId = Convert.ToInt32(Console.ReadLine());
                    CourseDTO selectedCourse = courses.Where(x => x.Id == courseId).First();
                    List<LessonDTO> lessons = selectedCourse.Lessons.Where(x => x.IsDone == false).ToList();
                    if(!lessons.Any())
                    {
                        Console.WriteLine("Lista zajęć z niesprawdzoną obecnością jest pusta, najpierw utwórz zajęcia");
                        return false;
                    }
                    foreach(LessonDTO lesson in lessons)
                    {
                        Console.WriteLine("ID: " + lesson.Id + "Data: " + lesson.LessonDate.ToString());
                    }

                    Console.WriteLine("Wybierz ID zajęć");
                    int lessonId = Convert.ToInt32(Console.ReadLine());
                    LessonDTO selectedLesson = lessons.Where(x => x.Id == lessonId).First();

                    var students = selectedCourse?.Group?.Students;
                    if (students is null)
                    {
                        Console.WriteLine("Lista studentów w grupie jest pusta, najpierw dodaj studentów");
                        return false;
                    }

                    foreach (StudentDTO student in students)
                    {
                        Console.WriteLine("ID: " + student.Id + " Name: " + student.Name + " Surname: " + student.Surname);
                        Console.WriteLine("Obecny ? Wpisz true jeżeli tak inaczej false");
                        bool presence = Convert.ToBoolean(Console.ReadLine());
                        TimesheetDTO timesheetDTO = new TimesheetDTO()
                        {
                            Date = selectedLesson.LessonDate,
                            IsPresence = presence,
                            Student = student
                        };
                        selectedLesson.Timesheets.Add(timesheetDTO);
                    }
                    selectedLesson.IsDone = true;

                    _dbContext.Update(selectedLesson);
                    _dbContext.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            Console.WriteLine("Lista kursów jest pusta, najpierw utwórz kurs");
            return false;
        }
        public bool AddMark()
        {
            Console.WriteLine("Lista kursów");
            List<CourseDTO> courses = _dbContext.Courses.Include(x => x.Teacher).Include(x => x.Marks).Include(x => x.Group).ThenInclude(x => x.Students).ToList();
            if (courses.Any())
            {
                foreach (CourseDTO course in courses)
                {
                    Console.WriteLine("ID: " + course.Id + " Name: " + course.Name + " Opis: " + course.Description +
                        " Nauczyciel prowadzący: " + (course?.Teacher?.Name ?? " Nieprzypisany ") + " Grupa zajęciowa: " + course?.Group?.Name ?? "Nieprzypisana ");
                }
                Console.WriteLine("Wybierz ID kursu");
                try
                {
                    int courseId = Convert.ToInt32(Console.ReadLine());
                    CourseDTO selectedCourse = courses.Where(x => x.Id == courseId).First();
                    Console.WriteLine("Lista studentów");
                    var students = selectedCourse?.Group?.Students;
                    if(students is null) 
                    {
                        Console.WriteLine("Lista uczestnikow w grupie jest pusta. Najpierw dodaj studentów");
                        return false;
                    }
                    Console.WriteLine("Wybierz ID studenta");
                    foreach (var student in students)
                    {
                        Console.WriteLine("ID: " + student.Id + " Imie i nazwisko " + student.Name + " " + student.Surname);
                    }
                    int studentId = Convert.ToInt32(Console.ReadLine());
                    StudentDTO selectedStudent = students.Where(x => x.Id == studentId).First();
                    
                    Console.WriteLine("Podaj ocene");
                    int mark = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("Wybierz termin zajęć. Wprowadź go w formacie dzień/miesiąc/rok godzina:minuta:sekunda");
                    string dateTime = Console.ReadLine();
                    DateTime date = DateTime.Parse(dateTime);

                    MarkDTO newMark = new MarkDTO()
                    {
                        Date = date,
                        Mark = mark,
                        Student = selectedStudent,
                        Course = selectedCourse,
                        Group = selectedCourse.Group,
                    };

                    selectedCourse.Marks.Add(newMark);
                    _dbContext.Update(newMark);
                    _dbContext.SaveChanges();

                    Console.WriteLine("Operacja przebiegła pomyślnie");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                return true;
            }
            Console.WriteLine("Lista kursów jest pusta");
            return false;
        }

        public bool CheckPresenceStatistics()
        {
            Console.WriteLine("Lista kursów");
            List<CourseDTO> courses = _dbContext.Courses.Include(x => x.Teacher).Include(x => x.Group).ThenInclude(x => x.Students).ToList();
            if (courses.Any())
            {
                foreach (CourseDTO course in courses)
                {
                    Console.WriteLine("ID: " + course.Id + " Name: " + course.Name + " Opis: " + course.Description +
                        " Nauczyciel prowadzący: " + (course?.Teacher?.Name ?? " Nieprzypisany ") + " Grupa zajęciowa: " + course?.Group?.Name ?? "Nieprzypisana ");
                }
                Console.WriteLine("Wybierz ID kursu");
                try
                {
                    int courseId = Convert.ToInt32(Console.ReadLine());
                    CourseDTO selectedCourse = courses.Where(x => x.Id == courseId).First();
                    Console.WriteLine("Lista studentów");
                    var students = selectedCourse?.Group?.Students;
                    if (students is null)
                    {
                        Console.WriteLine("Lista uczestnikow w grupie jest pusta. Najpierw dodaj studentów");
                        return false;
                    }
                    foreach (var student in students)
                    {
                        Console.WriteLine("ID: " + student.Id + " Imie i nazwisko " + student.Name + " " + student.Surname);
                    }
                    Console.WriteLine("Wybierz ID studenta");
                    int studentId = Convert.ToInt32(Console.ReadLine());

                    var timesheets = _dbContext.Lessons.Where(x => x.CourseId == courseId).Include(x => x.Timesheets).SelectMany(x => x.Timesheets).ToList();
                    timesheets = timesheets.Where(x => x.StudentId == studentId).ToList();
                    if(timesheets is not null || !timesheets.Any())
                    {
                        int present = 0;
                        int notPresent = 0;
                        double percentage = 0.0;
                        foreach(var timesheet in timesheets)
                        {
                            if (timesheet.IsPresence)
                                present++;
                            else if (!timesheet.IsPresence)
                                notPresent++;
                        }
                        percentage = (double)(present / timesheets.Count()) * 100;
                        Console.WriteLine($"Statystyki: Obecny: {present} Nieobecny: {notPresent} Frekwencja: {percentage}%");
                    }
                    else
                    {
                        Console.WriteLine("Student nie był sprawdzany ani raz na liście obecności");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return false;
                }
            }
            Console.WriteLine("Nie ma dostępnych kursów. Najpier utwórz kurs");
            return false;
        }

        public bool CheckMarksForStudent()
        {
            Console.WriteLine("Lista kursów");
            List<CourseDTO> courses = _dbContext.Courses.Include(x => x.Teacher).Include(x => x.Group).ToList();
            if (courses.Any())
            {
                foreach (CourseDTO course in courses)
                {
                    Console.WriteLine("ID: " + course.Id + " Name: " + course.Name + " Opis: " + course.Description +
                        " Nauczyciel prowadzący: " + (course?.Teacher?.Name ?? " Nieprzypisany ") + " Grupa zajęciowa: " + course?.Group?.Name ?? "Nieprzypisana ");
                }
                Console.WriteLine("Wybierz ID kursu");
                try
                {
                    int courseId = Convert.ToInt32(Console.ReadLine());
                    CourseDTO selectedCourse = _dbContext.Courses.Where(x => x.Id ==  courseId).Include(x => x.Marks).First();
                    Console.WriteLine("Lista studentów");
                    var students = _dbContext.Groups.Where(x => x.Id == selectedCourse.GroupId).Include(x => x.Students).First().Students;
                    if (students is null)
                    {
                        Console.WriteLine("Lista uczestnikow w grupie jest pusta. Najpierw dodaj studentów");
                        return false;
                    }
                    foreach (var student in students)
                    {
                        Console.WriteLine("ID: " + student.Id + " Imie i nazwisko " + student.Name + " " + student.Surname);
                    }
                    Console.WriteLine("Wybierz ID studenta");
                    int studentId = Convert.ToInt32(Console.ReadLine());

                    var marks = selectedCourse?.Marks?.Where(x => x.StudentId == studentId);
                    if(marks is not null)
                    {
                        Console.WriteLine("Lista ocen:");
                        foreach (var mark in marks.OrderBy(x => x.Date))
                        {
                            Console.WriteLine("Ocena " + mark.Mark.ToString() + " Data " + mark.Date.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lista ocen w kursie dla wybranego studenta jest pusta. Najpierw dodaj oceny");
                        return false;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Nie ma dostępnych kursów. Najpier utwórz kurs");
                return false;
            }
        }

        public bool CheckMarksForAllStudentsInGroup()
        {
            Console.WriteLine("Lista kursów");
            List<CourseDTO> courses = _dbContext.Courses.Include(x => x.Teacher).Include(x => x.Group).ToList();
            if (courses.Any())
            {
                foreach (CourseDTO course in courses)
                {
                    Console.WriteLine("ID: " + course.Id + " Name: " + course.Name + " Opis: " + course.Description +
                    " Nauczyciel prowadzący: " + (course?.Teacher?.Name ?? " Nieprzypisany ") + " Grupa zajęciowa: " + course?.Group?.Name ?? "Nieprzypisana ");
                }
                Console.WriteLine("Wybierz ID kursu");
                try
                {
                    int courseId = Convert.ToInt32(Console.ReadLine());
                    CourseDTO selectedCourse = _dbContext.Courses.Where(x => x.Id == courseId).Include(x => x.Marks).First();
                    int groupId = selectedCourse?.Group?.Id ?? 0;
                    var students = _dbContext.Groups.Where(x => x.Id == groupId).Include(x => x.Students).First().Students;
                    if (students is null)
                    {
                        Console.WriteLine("Lista uczestnikow w grupie jest pusta. Najpierw dodaj studentów");
                        return false;
                    }

                    Dictionary<int, int> marksSum = new Dictionary<int, int>();
                    var marks = selectedCourse.Marks;
                    if (marks is null)
                    {
                        Console.WriteLine("Brak wystawionych ocen w kursie dla wybranej grupy");
                        return false;
                    }

                    foreach (MarkDTO mark in marks) 
                    {
                        if (marksSum.ContainsKey(mark.Mark))
                            marksSum[mark.Mark] += 1;
                        else
                            marksSum.Add(mark.Mark, 1);
                    }

                    foreach(var stat in marksSum)
                    {
                        Console.WriteLine("Ocena: " + stat.Key + " Ilość: " + stat.Value);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Nie ma dostępnych kursów. Najpier utwórz kurs");
                return false;
            }
        }
    }
}