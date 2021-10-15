using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.IO;

namespace lesson5_09
{
    public struct Student
    {
        public string name;
        public string surname;
        public int year;
        public string exam;
        public int mark;
    }
    public struct Employer
    {
        public string name;
        public string post;
        public int impudence;
        public bool stupidity;

    }
    public struct Tables
    {
        public int number;
        public string color;
    }
    class Program
    {
        static string GameOfCalmar(int[] firstTeam, int[] secondTeam)
        {
            int countFirst = 0, countSecond = 0;
            for (int i = 0; i < firstTeam.Length; i++)
            {
                if (firstTeam[i] == 5)
                {
                    countFirst++;
                }
            }
            for (int i = 0; i < secondTeam.Length; i++)
            {
                if (secondTeam[i] == 5)
                {
                    countSecond++;
                }
            }
            if (countSecond == countFirst)
            {
                return "«Drinks All Round! Free Beers on Bjorg!";
            }
            return "Бьорг - пончик! Ни для кого пива!";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Exersise 1");
            Random r = new Random();
            int[] firstTeam = new int[r.Next(1, 40)];
            int[] secondTeam = new int[r.Next(1, 40)];
            for (int i = 0; i < firstTeam.Length; i++)
            {
                firstTeam[i] = r.Next(0, 9);
            }
            for (int i = 0; i < secondTeam.Length; i++)
            {
                secondTeam[i] = r.Next(0, 9);
            }
            Console.WriteLine(GameOfCalmar(firstTeam, secondTeam));

            Console.WriteLine("Exersise 2");
            var listImage = new List<string/*Image*/>();
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\makur\source\repos\Classwork\lesson5_09\bin\Debug");

            foreach (var file in dir.EnumerateFiles("*.jpg"))
            {
                listImage.Add(/*Image.FromFile*/(file.FullName));

            }
            foreach (var file in dir.EnumerateFiles("*.jpg"))
            {
                listImage.Add(/*Image.FromFile*/(file.FullName));

            }
            foreach (var file in dir.EnumerateFiles("*.jpg"))
            {
                Console.WriteLine(file.FullName);

            }
            foreach (var file in dir.EnumerateFiles("*.jpg"))
            {
                Console.WriteLine(file.FullName);

            }
            for (int i = 0; i < listImage.Count; i++)
            {
                var temp = listImage[i];
                int swapIndex = r.Next(0, listImage.Count);
                listImage[i] = listImage[swapIndex];
                listImage[swapIndex] = temp;
            }
            Console.WriteLine("\n\n замешанный :\n\n");
            foreach (var image in listImage)
            {
                Console.WriteLine(image);
            }
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exersise 3");
            StreamReader sr = new StreamReader("Students.txt");
            int countStudents = 0;
            while (sr.ReadLine() != null)
            {
                countStudents++;
            }
            sr = new StreamReader("Students.txt");
            var students = new Dictionary<string, Student>();
            for (int i = 1; i < countStudents + 1; i++)
            {
                string[] allInfo = sr.ReadLine().Split(' ');
                Student student = new Student();
                student.name = allInfo[0];
                student.surname = allInfo[1];
                student.year = int.Parse(allInfo[2]);
                student.exam = allInfo[3];
                student.mark = int.Parse(allInfo[4]);
                students.Add($"student #{i}", student);

            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("input command of : output, add, remove, sort, exit");

                string input = Console.ReadLine().ToLower();
                if (input.Equals("output"))
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Key} {student.Value.name} {student.Value.surname} {student.Value.year} {student.Value.exam} {student.Value.mark}");
                    }
                }
                else if (input.Equals("exit"))
                {
                    flag = false;
                }
                else if (input.Equals("add"))
                {
                    Student student = new Student();
                    Console.Write("Input name : ");
                    student.name = Console.ReadLine();
                    Console.Write("Input surname : ");
                    student.surname = Console.ReadLine();
                    Console.Write("Input birthYear : ");
                    while (!int.TryParse(Console.ReadLine(), out student.year))
                    {
                        Console.WriteLine("try to input again!");
                    }
                    Console.Write("input exam : ");
                    student.exam = Console.ReadLine();
                    Console.Write("input mark :");
                    while (!int.TryParse(Console.ReadLine(), out student.mark))
                    {
                        Console.WriteLine("try to input again!");
                    }
                    students.Add($"student #{students.Count + 1}", student);
                }
                else if (input.Equals("remove"))
                {
                    Console.Write("Input name :");
                    string name = Console.ReadLine();
                    Console.Write("Input surname : ");
                    string surname = Console.ReadLine();
                    for (int i = 1; i < students.Count + 1; i++)
                    {
                        if (students["student #" + i].name.Equals(name) && students["student #" + i].surname.Equals(surname))
                        {
                            var tempStudent = students["student #" + i];
                            students["student #" + i] = students["student #" + students.Count];
                            students["student #" + students.Count] = tempStudent;
                            students.Remove($"student #{students.Count}");
                        }
                    }
                }
                else if (input.Equals("sort"))
                {
                    for (int i = 1; i < students.Count + 1; i++)
                    {
                        for (int j = 1; j < students.Count - i + 1; j++)
                        {
                            if (students["student #" + j].mark > students["student #" + (j + 1).ToString()].mark)
                            {
                                var temp = students["student #" + j];
                                students["student #" + j] = students["student #" + (j + 1)];
                                students["student #" + (j + 1)] = temp;

                            }
                        }
                    }
                }

            }

            Console.WriteLine("Exersise 4");
            Console.Write("input amount of employers :");
            int amountEmployers;
            while (!int.TryParse(Console.ReadLine(), out amountEmployers) || amountEmployers < 0)
            {
                Console.WriteLine("input amount of employers correctly :  ");
            }
            var employers = new List<Employer>();
            for (int i = 1; i < amountEmployers + 1; i++)
            {
                Employer employer = new Employer();
                Console.Write("Input name : ");
                employer.name = Console.ReadLine();
                Console.Write("input post : ");
                employer.post = Console.ReadLine();
                Console.Write("input degree of stupidity. true or false, please : ");
                while (!bool.TryParse(Console.ReadLine(), out employer.stupidity))
                {
                    Console.Write("input degree of stupidity. true or false, please : ");
                }
                Console.WriteLine("input degree of impudence from 0  to 5 : ");
                while (!int.TryParse(Console.ReadLine(), out employer.impudence) || employer.impudence<0 || employer.impudence >5)
                {
                    Console.WriteLine("input degree of impudence from 0  to 5 : ");
                }
                Console.WriteLine();
                employers.Add(employer);
            }
            for (int j = 1; j < employers.Count; j++)
            {
                if ((employers[j].impudence> employers[j + 1].impudence) && employers[j].stupidity)
                {
                    var temp = employers[j + employers[j].impudence];
                    employers[j + employers[j].impudence] = employers[j];
                    employers[j] = temp;
                }
            }
            
            var queue = new Queue<Employer>();
            foreach (var employer in employers)
            {
                queue.Enqueue(employer);
            }
            var tables = new List<Stack<Employer>>();
            int capasityOfTables = 3;
            int amoutOfTabels = 0;
            Console.Write("input amount of tabels :");
            while (!int.TryParse(Console.ReadLine(), out  amoutOfTabels ))
            {
                Console.Write("input amount of tabels :");
            }
            for (int i = 0; i < amoutOfTabels; i++)
            {
                tables.Add(new Stack<Employer>());
                for (int j = 0; j < capasityOfTables; j++)
                {
                    tables[i].Push(queue.Peek());
                }
            }
            

            Console.WriteLine("task 5");
            


        }
    }
}
