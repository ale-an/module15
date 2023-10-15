namespace Module15
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task_15_1_4();
            Task_15_1_5();
            Task_15_1_6();
            Task_15_2_1(5);
            Task_15_2_2();
            Task_15_2_3(new[] {1, 2, 3, 4});
            Task_15_2_8();
            Task_15_3_3();
            Task_15_4_1();
            Task_15_4_2();
            Task_15_5_4();
            Practice();
        }

        private static void Task_15_1_4()
        {
            Console.WriteLine("Введите первое слово");
            var word1 = Console.ReadLine();

            Console.WriteLine("Введите второе слово");
            var word2 = Console.ReadLine();

            var sameSymbol = word2.Intersect(word1);

            foreach (var s in sameSymbol)
            {
                Console.WriteLine(s);
            }
        }

        private static void Task_15_1_5()
        {
            var softwareManufacturers = new List<string>()
            {
                "Microsoft", "Apple", "Oracle"
            };

            var hardwareManufacturers = new List<string>()
            {
                "Apple", "Samsung", "Intel"
            };

            var itCompanies = softwareManufacturers.Union(hardwareManufacturers);

            foreach (var c in itCompanies)
            {
                Console.WriteLine(c);
            }
        }

        private static void Task_15_1_6()
        {
            char[] marks = {' ', ',', '.', ';', ':', '?', '!'};

            Console.WriteLine("Напишите что-нибудь");
            var suggestion = Console.ReadLine();

            if (string.IsNullOrEmpty(suggestion))
            {
                Console.WriteLine("Попытайтесь ещё");
                return;
            }

            var symbols = suggestion.Except(marks).Distinct().Count();

            Console.WriteLine($"Уникальных символов: {symbols}");
        }

        static long Task_15_2_1(int number)
        {
            var numbers = new List<long>();

            for (int i = 1; i <= number; i++)
            {
                numbers.Add(i);
            }

            return numbers.Aggregate((x, y) => x * y);
        }

        private static void Task_15_2_2()
        {
            var contacts = new List<Contact>()
            {
                new Contact("Андрей", 79994500508),
                new Contact("Сергей", 799990455),
                new Contact("Иван", 79999675334),
                new Contact("Игорь", 8884994),
                new Contact("Анна", 665565656),
                new Contact("Василий", 343)
            };

            var incorrectContacts =
                contacts.Count(s => s.Phone.ToString().Length != 11 || s.Phone.ToString()[0] != '7');

            Console.WriteLine($"Неверных номеров телефонов: {incorrectContacts}");
        }

        static double Task_15_2_3(int[] numbers)
        {
            return numbers.Sum() / (double) numbers.Length;
        }

        private static void Task_15_2_8()
        {
            var numbers = new List<int>();

            while (true)
            {
                Console.WriteLine("Введите число, пожалуйста");
                var text = Console.ReadLine();

                if (string.IsNullOrEmpty(text))
                {
                    continue;
                }

                if (!int.TryParse(text, out var number))
                {
                    continue;
                }

                numbers.Add(number);

                var count = numbers.Count;
                var sum = numbers.Sum();
                var max = numbers.Max();
                var min = numbers.Min();
                var average = numbers.Average();

                Console.WriteLine($"Чисел в списке: {count}");
                Console.WriteLine($"Сумма всех чисел: {sum}");
                Console.WriteLine($"Наибольшее число: {max}");
                Console.WriteLine($"Наименьшее число: {min}");
                Console.WriteLine($"Среднее значение: {average}");
            }
        }

        private static void Task_15_3_3()
        {
            var phoneBook = new List<Contact>();

// добавляем контакты
            phoneBook.Add(new Contact("Игорь", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", 799900000013, "serg@gmail.com"));
            phoneBook.Add(new Contact("Иннокентий", 799900000013, "innokentii@example.com"));

            var group = phoneBook
                .GroupBy(x => x.Email.Substring(x.Email.IndexOf('@')));

            foreach (var contacts in group)
            {
                var realOrFake = contacts.Key.Contains("example") ? "Фейковые адреса" : "Реальные адреса";

                Console.WriteLine($"{realOrFake}:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"{contact.Name} — {contact.Email} — {contact.Phone}");
                }
            }
        }

        private static void Task_15_4_1()
        {
            var departments = new List<Department>()
            {
                new Department() {Id = 1, Name = "Программирование"},
                new Department() {Id = 2, Name = "Продажи"}
            };

            var employees = new List<Employee>()
            {
                new Employee() {DepartmentId = 1, Name = "Инна", Id = 1},
                new Employee() {DepartmentId = 1, Name = "Андрей", Id = 2},
                new Employee() {DepartmentId = 2, Name = "Виктор ", Id = 3},
                new Employee() {DepartmentId = 3, Name = "Альберт ", Id = 4},
            };

            var result = departments.Join(employees,
                department => department.Id,
                emp => emp.DepartmentId,
                (d, e) =>
                    new
                    {
                        Name = e.Name,
                        DepartmentName = d.Name
                    });

            foreach (var elem in result)
            {
                Console.WriteLine($"{elem.Name} - {elem.DepartmentName}");
            }
        }

        private static void Task_15_4_2()
        {
            var departments = new List<Department>()
            {
                new Department() {Id = 1, Name = "Программирование"},
                new Department() {Id = 2, Name = "Продажи"}
            };

            var employees = new List<Employee>()
            {
                new Employee() {DepartmentId = 1, Name = "Инна", Id = 1},
                new Employee() {DepartmentId = 1, Name = "Андрей", Id = 2},
                new Employee() {DepartmentId = 2, Name = "Виктор ", Id = 3},
                new Employee() {DepartmentId = 3, Name = "Альберт ", Id = 4},
            };

            var result = departments.GroupJoin(employees,
                department => department.Id,
                emp => emp.DepartmentId,
                (d, e) =>
                    new
                    {
                        Employees = e,
                        DepartmentName = d.Name
                    });

            foreach (var group in result)
            {
                Console.WriteLine(group.DepartmentName + ":");
                foreach (var employ in group.Employees)
                {
                    Console.WriteLine(employ.Name);
                }
            }
        }

        private static void Task_15_5_4()
        {
            var animals = new List<string>() {"Кошка", "Собака", "Хомяк", "Хамелеон"};

            var attempt = animals.Where(animal => animal.StartsWith("Х"));

            animals.Remove("Кошка");

            foreach (var a in attempt)
                Console.WriteLine(a);
        }

        private static void Practice()
        {
            var classes = new[]
            {
                new Classroom {Students = {"Evgeniy", "Sergey", "Andrew"},},
                new Classroom {Students = {"Anna", "Viktor", "Vladimir"},},
                new Classroom {Students = {"Bulat", "Alex", "Galina"},}
            };
            var allStudents = GetAllStudents(classes);

            Console.WriteLine(string.Join(" ", allStudents));
        }

        static string[] GetAllStudents(Classroom[] classes)
        {
            return classes.SelectMany(x => x.Students).ToArray();
        }
    }
}