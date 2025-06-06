using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;
using System.Text.Json;

// Define the namespace for the StudentManagementSystem services
namespace StudentManagementSystem.Services
{
    // Define a public class called StudentService, which will manage student-related operations
    public class StudentService
    {

        private readonly string studentFilePath = "studentData.json";
        private readonly string courseFilePath = "courseData.json";
        private readonly string enrollmentFilePath = "enrollmentData.json";
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
            courses = LoadCourses(); // Load existing courses from file
            students = LoadStudents(); // Load existing students from file
            enrollments = LoadEnrollments(); // Load existing enrollments from file
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
            SaveStudents();
            // Print a success message to the console
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nStudent added successfully!\n");
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }

        // Method to add a new course to the system
        public void AddCourse(string courseName) 
        {
            // Create a new Course object with the provided course name
            var course = new Course(courseIdCounter++, courseName);
            // Add the new course to the list of courses
            courses.Add(course);
            SaveCourses();
            // Print a success message to the console
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCourse added successfully!\n");
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nStudent or course not found!\n");
                
                Console.WriteLine("Press Enter to return to the main menu.");
                Console.ReadLine();
                // Return from the method without enrolling the student
                return;
            }
            else
            {
                // Create a new Enrollment object with the student ID and course ID
                var enrollment = new Enrollment(studentId, courseId);
                // Add the new enrollment to the list of enrollments
                enrollments.Add(enrollment);
                SaveEnrollments();
                // Print a success message to the console
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nStudent has successfully been enrolled in the course.\n");

                Console.WriteLine("Press Enter to return to the main menu.");
                Console.ReadLine();
            }
        }

        // Method to display all students in the system
        public void ViewStudents()
        {
            // Print a horizontal line to separate each student's information
            Console.WriteLine("--------------------------------------------");

            // Print a header to indicate that the following information is for all students
            Console.WriteLine("All Students");

            // Print another horizontal line to separate the header from the student's information
            Console.WriteLine("--------------------------------------------\n");
            // Iterate through each student in the list of students
            foreach (var student in students)
            {
                // Print the student's information to the console
                Console.WriteLine(student);
            }
            Console.WriteLine("\nPress Enter to return to the main menu.");
            Console.ReadLine();
        }

        // Method to display all courses in the system
        public void ViewCourses()
        {
            // Print a horizontal line to separate each course's information
            Console.WriteLine("--------------------------------------------");

            // Print a header to indicate that the following information is for all courses
            Console.WriteLine("All Courses");

            // Print another horizontal line to separate the header from the course's information
            Console.WriteLine("--------------------------------------------\n");

            // Iterate through each course in the list of courses
            foreach (var course in courses)
            {
                // Print the course's information to the console
                Console.WriteLine(course);
            }
            Console.WriteLine("\nPress Enter to return to the main menu.");
            Console.ReadLine();
        }

        // Method to display all enrollments in the system
        public void ViewEnrollments()
        {
            // Print a horizontal line to separate each enrollment's information
            Console.WriteLine("--------------------------------------------");

            // Print a header to indicate that the following information is for all enrollments
            Console.WriteLine("All Enrollments");

            // Print another horizontal line to separate the header from the enrollment's information
            Console.WriteLine("--------------------------------------------\n");
            // Iterate through each enrollment in the list of enrollments
            foreach (var enrollment in enrollments)
            {
                // Print the enrollment's information to the console
                Console.WriteLine(enrollment);
            }
            Console.WriteLine("\nPress Enter to return to the main menu.");
            Console.ReadLine();
        }

        private void SaveStudents()
        {
            
            var json = JsonSerializer.Serialize(students);
            File.WriteAllText(studentFilePath, json);
        }

        private List<Student> LoadStudents()
        {
            if (File.Exists(studentFilePath))
            {
                var json = File.ReadAllText(studentFilePath);
                students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }

            return new List<Student>();
        }

        private void SaveCourses()
        {
            var json = JsonSerializer.Serialize(courses);
            File.WriteAllText(courseFilePath, json);
        }

        private List<Course> LoadCourses()
        {
            if (File.Exists(courseFilePath))
            {
                var json = File.ReadAllText(courseFilePath);
                courses = JsonSerializer.Deserialize<List<Course>>(json) ?? new List<Course>();
            }

            return new List<Course>();
        }

        private void SaveEnrollments()
        {
            var json = JsonSerializer.Serialize(enrollments);
            File.WriteAllText(enrollmentFilePath, json);
        }

        private List<Enrollment> LoadEnrollments()
        {
            if (File.Exists(enrollmentFilePath))
            {
                var json = File.ReadAllText(enrollmentFilePath);
                enrollments = JsonSerializer.Deserialize<List<Enrollment>>(json) ?? new List<Enrollment>();
            }

            return new List<Enrollment>();
        }
    }
}