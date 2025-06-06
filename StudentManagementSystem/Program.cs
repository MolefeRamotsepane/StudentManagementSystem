using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementSystem.Services;
using StudentManagementSystem.Models;

// Define the namespace for the Student Management System
namespace StudentManagementSystem
{
    // Define the main class for the program
    class Program
    {
        // Define the main entry point for the program
        static void Main(string[] args)
        {
            // Create an instance of the StudentService class, which will manage student-related operations
            StudentService studentService = new();

            // Initialize a boolean variable to control the program's main loop
            bool running = true;

            // Set the title of the console window
            Console.Title = "Student Management System by Molefe Ramotsepane";

            // Enter the main program loop, which will continue to run until the user chooses to exit
            while (running)
            {
                // Set the foreground color of the console to cyan
                Console.ForegroundColor = ConsoleColor.Cyan;

                // Clear the console window to prepare for the next iteration of the loop

                Console.Clear();
                // Display the program's title and menu options
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Student Management System");
                Console.WriteLine("--------------------------------------------\n");
                Console.WriteLine("1. Add a Student");
                Console.WriteLine("2. Add a Course");
                Console.WriteLine("3. Enroll a Student in a Course");
                Console.WriteLine("4. View All Students");
                Console.WriteLine("5. View All Courses");
                Console.WriteLine("6. View All Enrollments");
                Console.WriteLine("7. Exit");
                Console.WriteLine("--------------------------------------------\n");
                Console.WriteLine("Choose an option (1-7): \n");

                // Read the user's input from the console
                string input = Console.ReadLine();

                // Use a switch statement to determine which action to take based on the user's input
                switch (input)
                {
                    // If the user chooses option 1, add a new student to the system
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Add a Student");
                        Console.WriteLine("--------------------------------------------\n");
                        Console.WriteLine("Enter the student's full name: ");
                        string fullName = Console.ReadLine();
                        Console.WriteLine("Enter the student's email address: ");
                        string email = Console.ReadLine();
                        studentService.AddStudent(fullName, email);
                        break;

                    // If the user chooses option 2, add a new course to the system
                    case "2":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Add a Course");
                        Console.WriteLine("--------------------------------------------\n");
                        Console.WriteLine("Enter the course name: ");
                        string courseName = Console.ReadLine();
                        studentService.AddCourse(courseName);
                        break;

                    // If the user chooses option 3, enroll a student in a course
                    case "3":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Enroll a Student in a Course");
                        Console.WriteLine("--------------------------------------------\n");
                        Console.WriteLine("Enter the student ID: ");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the course ID: ");
                        int courseId = Convert.ToInt32(Console.ReadLine());
                        studentService.EnrollStudent(studentId, courseId);
                        break;

                    // If the user chooses option 4, display all students in the system
                    case "4":
                        Console.Clear();
                        studentService.ViewStudents();
                        break;

                    // If the user chooses option 5, display all courses in the system
                    case "5":
                        Console.Clear();
                        studentService.ViewCourses();
                        break;

                    // If the user chooses option 6, display all enrollments in the system
                    case "6":
                        Console.Clear();
                        studentService.ViewEnrollments();
                        break;

                    // If the user chooses option 7, exit the program
                    case "7":
                        running = false;
                        break;

                    // If the user enters an invalid option, display an error message
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}