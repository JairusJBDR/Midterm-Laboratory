using System;

namespace Problem2_Dictionary
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    class Problem2
    {
        static void Main()
        {
            Student[] students = new Student[10];
            int studentCount = 0;
            Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();

            int choice = 0;

            while (choice != 4)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("     STUDENT LOOKUP USING DICTIONARY");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Display All Students");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = 0;
                }
                Console.WriteLine();

                if (choice == 1)
                {
                    if (studentCount >= 10)
                    {
                        Console.WriteLine("Cannot add more students. The list is full (10 max).");
                    }
                    else
                    {
                        Student s = new Student();
                        Console.Write("Enter Student Number: ");
                        s.StudentNumber = Console.ReadLine();

                        if (studentDictionary.ContainsKey(s.StudentNumber))
                        {
                            Console.WriteLine("Student Number already exists.");
                        }
                        else
                        {
                            Console.Write("Enter Name: ");
                            s.Name = Console.ReadLine();
                            Console.Write("Enter Program: ");
                            s.Program = Console.ReadLine();

                            int year;
                            while (true)
                            {
                                Console.Write("Enter Year Level: ");
                                if (int.TryParse(Console.ReadLine(), out year) && year >= 1 && year <= 4)
                                {
                                    break;
                                }
                                Console.WriteLine("Year level must be 1, 2, 3, or 4.");
                            }
                            s.YearLevel = year;

                            students[studentCount] = s;
                            studentCount++;
                            studentDictionary.Add(s.StudentNumber, s);

                            Console.WriteLine();
                            Console.WriteLine("Student added successfully!");
                        }
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Student Number to search: ");
                    string number = Console.ReadLine();
                    Console.WriteLine();

                    if (studentDictionary.ContainsKey(number))
                    {
                        Student found = studentDictionary[number];
                        Console.WriteLine("Student Found!");
                        Console.WriteLine("Student Number: " + found.StudentNumber);
                        Console.WriteLine("Name: " + found.Name);
                        Console.WriteLine("Program: " + found.Program);
                        Console.WriteLine("Year Level: " + found.YearLevel);
                    }
                    else
                    {
                        Console.WriteLine("Student Number does not exist.");
                    }
                }
                else if (choice == 3)
                {
                    if (studentCount == 0)
                    {
                        Console.WriteLine("No student records found.");
                    }
                    else
                    {
                        for (int i = 0; i < studentCount; i++)
                        {
                            Console.WriteLine("Student Number: " + students[i].StudentNumber);
                            Console.WriteLine("Name: " + students[i].Name);
                            Console.WriteLine("Program: " + students[i].Program);
                            Console.WriteLine("Year Level: " + students[i].YearLevel);
                            Console.WriteLine();
                        }
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Program exited.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
            }
        }
    }
}
