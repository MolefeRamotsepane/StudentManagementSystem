using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

// Define the namespace for the StudentManagementSystem services
namespace StudentManagementSystem.Services
{
    // Define a public class called StudentService, which will manage student-related operations
    public class StudentService
    {
        // Initialize private lists to store students, courses, and enrollments
        private List<Student> students = new List<Student>(); // List to store student objects
        private List<Course> courses = new List<Course>(); // List to store course objects
        private List<Enrollment> enrollments = new List<Enrollment>(); // List to store enrollment objects

        // Initialize a private integer to keep track of the next available ID
        private int studentIdCounter;
        private int courseIdCounter;

        // Constructor for the StudentService class
        public StudentService() 
        {
            // If there are existing students, set the IdCounter to the next available ID
            // Otherwise, set it to 1
            studentIdCounter = students.Any() ? students.Max(x => x.StudentId) + 1 : 1;
            courseIdCounter = students.Any() ? students.Max(x => x.StudentId) + 1 : 1;
        }

        // Method to add a new student to the system
        public void AddStudent(string fullName, string email) 
        {
            // Create a new Student object with the provided full name and email
            var student = new Student(studentIdCounter++, fullName, email);
            // Add the new student to the list of students
            students.Add(student);
            // Print a success message to the console
            Console.WriteLine("\nStudent added successfully!\n");
        }

        // Method to add a new course to the system
        public void AddCourse(string courseName) 
        {
            // Create a new Course object with the provided course name
            var course = new Course(cousreIdCounter++, courseName);
            // Add the new course to the list of courses
            courses.Add(course);
            // Print a success message to the console
            Console.WriteLine("\nCourse added successfully!\n");
        }

        // Method to enroll a student in a course
        public void EnrollStudent(int studentId, int courseId)
        {
            // Find the student with the provided student ID
            var student = students.FirstOrDefault(x => x.StudentId == studentId);
            // Find the course with the provided course ID
            var course = courses.FirstOrDefault(x => x.CourseId == courseId);

            // Check if the student or course was not found
            if (student == null || course == null)
            {
                // Print an error message to the console
                Console.WriteLine("\nStudent or course not found!\n");
                // Return from the method without enrolling the student
                return;
            }
            else
            {
                // Create a new Enrollment object with the student ID and course ID
                var enrollment = new Enrollment(studentId, courseId);
                // Add the new enrollment to the list of enrollments
                enrollments.Add(enrollment);
                // Print a success message to the console
                Console.WriteLine("\nStudent has successfully been enrolled in the course.\n");
            }
        }

        // Method to display all students in the system
        public void ViewStudents()
        {
            // Iterate through each student in the list of students
            foreach (var student in students)
            {
                // Print a horizontal line to separate each student's information
                Console.WriteLine("--------------------------------------------");
        
                // Print a header to indicate that the following information is for all students
                Console.WriteLine("All Students");
        
                // Print another horizontal line to separate the header from the student's information
                Console.WriteLine("--------------------------------------------\n");
        
                // Print the student's information to the console
                Console.WriteLine(student);
            }
        }

        // Method to display all courses in the system
        public void ViewCourses()
        {
            // Iterate through each course in the list of courses
            foreach (var course in courses)
            {
                // Print a horizontal line to separate each course's information
                Console.WriteLine("--------------------------------------------");
        
                // Print a header to indicate that the following information is for all courses
                Console.WriteLine("All Courses");
        
                // Print another horizontal line to separate the header from the course's information
                Console.WriteLine("--------------------------------------------\n");
        
                // Print the course's information to the console
                Console.WriteLine(course);
            }
        }

        // Method to display all enrollments in the system
        public void ViewEnrollments()
        {
            // Iterate through each enrollment in the list of enrollments
            foreach (var enrollment in enrollments)
            {
                // Print a horizontal line to separate each enrollment's information
                Console.WriteLine("--------------------------------------------");
        
                // Print a header to indicate that the following information is for all enrollments
                Console.WriteLine("All Enrollments");
        
                // Print another horizontal line to separate the header from the enrollment's information
                Console.WriteLine("--------------------------------------------\n");
        
                // Print the enrollment's information to the console
                Console.WriteLine(enrollment);
            }
        }
    }
}