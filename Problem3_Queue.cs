using System;

namespace Problem3_Queue
{
    struct StudentRequest
    {
        public string StudentNumber;
        public string StudentName;
        public string RequestType;
    }

    class Problem3
    {
        static void Main()
        {
            Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();
            int choice = 0;

            while (choice != 4)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("          STUDENT REQUEST QUEUE");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. View Pending Requests");
                Console.WriteLine("3. Process Request");
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
                    StudentRequest r = new StudentRequest();
                    Console.Write("Enter Student Number: ");
                    r.StudentNumber = Console.ReadLine();
                    Console.Write("Enter Student Name: ");
                    r.StudentName = Console.ReadLine();
                    Console.Write("Enter Request Type: ");
                    r.RequestType = Console.ReadLine();

                    requestQueue.Enqueue(r);

                    Console.WriteLine();
                    Console.WriteLine("Request added successfully!");
                }
                else if (choice == 2)
                {
                    if (requestQueue.Count == 0)
                    {
                        Console.WriteLine("No pending requests.");
                    }
                    else
                    {
                        Console.WriteLine("REQUEST QUEUE");
                        int number = 1;
                        foreach (StudentRequest r in requestQueue)
                        {
                            Console.WriteLine(number + ". " + r.StudentName + " - " + r.RequestType);
                            number++;
                        }
                    }
                }
                else if (choice == 3)
                {
                    if (requestQueue.Count == 0)
                    {
                        Console.WriteLine("No pending requests.");
                    }
                    else
                    {
                        StudentRequest r = requestQueue.Dequeue();
                        Console.WriteLine("Processing Request: " + r.StudentName + " - " + r.RequestType);
                        Console.WriteLine();
                        Console.WriteLine("Request processed successfully!");
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
