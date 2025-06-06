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

                // Display the program's title and menu options
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Student Management System");
                Console.WriteLine("--------------------------------------------\n");
                Console.WriteLine("1. Add a Student");
                Console.WriteLine("2. Add a Course");
                Console.WriteLine("3. Delete Students by Student ID");
                Console.WriteLine("4. Delete Courses by Course ID");
                Console.WriteLine("5. Enroll a Student in a Course");
                Console.WriteLine("6. View All Students");
                Console.WriteLine("7. View All Courses");
                Console.WriteLine("8. View All Enrollments");
                Console.WriteLine("9. Delete an Enrollment by Enrollment ID");
                Console.WriteLine("0. Exit");
                Console.WriteLine("--------------------------------------------\n");
                Console.WriteLine("Choose an option (1-0): \n");

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
                        Console.Write("Enter the student's full name: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Enter the student's email address: ");
                        string email = Console.ReadLine();
                        studentService.AddStudent(fullName, email);
                        break;
                    // If the user chooses option 2, add a new course to the system
                    case "2":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Add a Course");
                        Console.WriteLine("--------------------------------------------\n");
                        Console.Write("Enter the course name: ");
                        string courseName = Console.ReadLine();
                        studentService.AddCourse(courseName);
                        break;
                    // If the user chooses option 3, delete a student
                    case "3":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Delete a Student by Student ID");
                        Console.WriteLine("--------------------------------------------\n");
                        Console.Write("Enter student ID: ");
                        int studentToDelete = Convert.ToInt32(Console.ReadLine());
                        studentService.DeleteStudent(studentToDelete);
                        break;
                    // If the user chooses option 4, delete a course
                    case "4":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Delete a Course by Course ID");
                        Console.WriteLine("--------------------------------------------\n");
                        Console.Write("Enter course ID: ");
                        int courseToDelete = Convert.ToInt32(Console.ReadLine());
                        studentService.DeleteCourse(courseToDelete);
                        break;

                    // If the user chooses option 5, enroll a student in a course
                    case "5":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Enroll a Student in a Course");
                        Console.WriteLine("--------------------------------------------\n");
                        Console.Write("Enter the student ID: ");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the course ID: ");
                        int courseId = Convert.ToInt32(Console.ReadLine());
                        studentService.EnrollStudent(studentId, courseId);
                        break;

                    // If the user chooses option 6, display all students in the system
                    case "6":
                        Console.Clear();
                        studentService.ViewStudents();
                        break;

                    // If the user chooses option 7, display all courses in the system
                    case "7":
                        Console.Clear();
                        studentService.ViewCourses();
                        break;

                    // If the user chooses option 8, display all enrollments in the system
                    case "8":
                        Console.Clear();
                        studentService.ViewEnrollments();
                        break;
                    // if user chooses option 9, delete an enrollment
                    case "9":
                        Console.Clear();
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Delete an Enrollment by Enrollment ID");
                        Console.WriteLine("--------------------------------------------\n");
                        Console.Write("Enter enrollment ID: ");
                        int enrollmentToDelete = Convert.ToInt32(Console.ReadLine());
                        studentService.DeleteEnrollment(enrollmentToDelete);
                        break;
                    // If the user chooses option 9, exit the program
                    case "0":
                        running = false;
                        break;

                    // If the user enters an invalid option, display an error message
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid option. Please try again.\n");
                        break;
                }
            }
        }
    }
}