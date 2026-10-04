using System;

namespace Problem4_Stack
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    struct Operation
    {
        public string Action;
        public string StudentNumber;
        public string StudentName;
    }

    class Problem4
    {
        static Student[] students = new Student[10];
        static int studentCount = 0;
        static Stack<Operation> operationHistory = new Stack<Operation>();

        static void Main()
        {
            int choice = 0;

            while (choice != 7)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("        STUDENT RECORD MANAGEMENT");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Operation History");
                Console.WriteLine("7. Exit");
                Console.WriteLine();
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = 0;
                }
                Console.WriteLine();

                if (choice == 1) AddStudent();
                else if (choice == 2) DisplayAll();
                else if (choice == 3) SearchStudent();
                else if (choice == 4) UpdateStudent();
                else if (choice == 5) DeleteStudent();
                else if (choice == 6) HistoryMenu();
                else if (choice == 7) Console.WriteLine("Program exited.");
                else Console.WriteLine("Invalid choice. Please try again.");

                Console.WriteLine();
            }
        }


        static void RecordOperation(string action, Student s)
        {
            Operation op = new Operation();
            op.Action = action;
            op.StudentNumber = s.StudentNumber;
            op.StudentName = s.Name;
            operationHistory.Push(op);
        }

        static void HistoryMenu()
        {
            int choice = 0;

            while (choice != 4)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("            OPERATION HISTORY");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.WriteLine("1. View Operation History");
                Console.WriteLine("2. View Last Operation");
                Console.WriteLine("3. Remove Last Operation");
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
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("No recorded operations.");
                    }
                    else
                    {
                        Console.WriteLine("OPERATION HISTORY");
                        Console.WriteLine();

                        Operation[] ops = operationHistory.ToArray();
                        int number = 1;
                        for (int i = ops.Length - 1; i >= 0; i--)
                        {
                            Console.WriteLine(number + ". " + ops[i].Action + " " + ops[i].StudentName);
                            number++;
                        }
                    }
                }
                else if (choice == 2)
                {
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("No recorded operations.");
                    }
                    else
                    {
                        Operation last = operationHistory.Peek();
                        Console.WriteLine("Last Operation: " + last.Action + " " + last.StudentName);
                    }
                }
                else if (choice == 3)
                {
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("No recorded operations.");
                    }
                    else
                    {
                        operationHistory.Pop();
                        Console.WriteLine("Last operation removed successfully!");
                    }
                }
                else if (choice == 4)
                
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
            }
        }


        static int FindIndex(string number)
        {
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].StudentNumber == number)
                {
                    return i;
                }
            }
            return -1;
        }

        static int ReadYearLevel()
        {
            int year;
            while (true)
            {
                Console.Write("Enter Year Level: ");
                if (int.TryParse(Console.ReadLine(), out year) && year >= 1 && year <= 4)
                {
                    return year;
                }
                Console.WriteLine("Year level must be 1, 2, 3, or 4.");
            }
        }

        static void PrintStudent(Student s)
        {
            Console.WriteLine("Student Number: " + s.StudentNumber);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Program: " + s.Program);
            Console.WriteLine("Year Level: " + s.YearLevel);
        }

        static void AddStudent()
        {
            if (studentCount >= 10)
            {
                Console.WriteLine("Cannot add more students. The list is full (10 max).");
                return;
            }

            Student s = new Student();
            Console.Write("Enter Student Number: ");
            s.StudentNumber = Console.ReadLine();

            if (FindIndex(s.StudentNumber) != -1)
            {
                Console.WriteLine("Student Number already exists.");
                return;
            }

            Console.Write("Enter Name: ");
            s.Name = Console.ReadLine();
            Console.Write("Enter Program: ");
            s.Program = Console.ReadLine();
            s.YearLevel = ReadYearLevel();

            students[studentCount] = s;
            studentCount++;
            RecordOperation("Added", s);

            Console.WriteLine();
            Console.WriteLine("Student added successfully!");
        }

        static void DisplayAll()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("            STUDENT RECORDS");
            Console.WriteLine("========================================");

            if (studentCount == 0)
            {
                Console.WriteLine("No student records found.");
                return;
            }

            for (int i = 0; i < studentCount; i++)
            {
                PrintStudent(students[i]);
                Console.WriteLine();
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter Student Number to search: ");
            string number = Console.ReadLine();
            int index = FindIndex(number);

            Console.WriteLine();
            if (index == -1)
            {
                Console.WriteLine("Student not found.");
            }
            else
            {
                Console.WriteLine("Student Found!");
                PrintStudent(students[index]);
            }
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student Number to update: ");
            string number = Console.ReadLine();
            int index = FindIndex(number);

            if (index == -1)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter new Name: ");
            students[index].Name = Console.ReadLine();
            Console.Write("Enter new Program: ");
            students[index].Program = Console.ReadLine();
            students[index].YearLevel = ReadYearLevel();

            RecordOperation("Updated", students[index]);

            Console.WriteLine();
            Console.WriteLine("Student updated successfully!");
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student Number to delete: ");
            string number = Console.ReadLine();
            int index = FindIndex(number);

            if (index == -1)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            RecordOperation("Deleted", students[index]);

            for (int i = index; i < studentCount - 1; i++)
            {
                students[i] = students[i + 1];
            }
            studentCount--;

            Console.WriteLine();
            Console.WriteLine("Student deleted successfully!");
        }
    }
}
