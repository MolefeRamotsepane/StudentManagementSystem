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
        // Define private constants for file paths to store student, course, and enrollment data
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
            LoadCourses(); // Load existing courses from file
            LoadStudents(); // Load existing students from file
            LoadEnrollments(); // Load existing enrollments from file
            // If there are existing students, set the IdCounter to the next available ID
            // Otherwise, set it to 1
            studentIdCounter = students.Any() ? students.Max(x => x.StudentId) + 1 : 1;
            courseIdCounter = students.Any() ? students.Max(x => x.StudentId) + 1 : 1;
        }

        // Method to add a new student to the system
        public void AddStudent(string fullName, string email) 
        {
            // Check if a student with the same full name and email already exists
            if (students.Any(x => x.Email == email && x.FullName == fullName))
            {
                Console.WriteLine("\nEmail already exists!\n");
                Console.WriteLine("Press Enter to return to the main menu.");
                Console.ReadLine();
                return;
            }
            else
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
        }

        // Method to add a new course to the system
        public void AddCourse(string courseName) 
        {
            // Check if a course with the same name already exists
            if (courses.Any(x => x.CourseName == courseName))
            {
                Console.WriteLine("\nCourse already exists!\n");
                Console.WriteLine("Press Enter to return to the main menu.");
                Console.ReadLine();
                return;
            }
            else
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

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                Console.WriteLine("\nPress Enter to return to the main menu.");
                Console.ReadLine();
                return;
            } else
            {
                // Iterate through each student in the list of students
                foreach (var student in students)
                {
                    // Print the student's information to the console
                    Console.WriteLine(student);
                }
                Console.WriteLine("\nPress Enter to return to the main menu.");
                Console.ReadLine();
            }
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
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found.");
                Console.WriteLine("\nPress Enter to return to the main menu.");
                Console.ReadLine();
                return;
            } else
            {
                foreach (var course in courses)
                {
                    // Print the course's information to the console
                    Console.WriteLine(course);
                }
                Console.WriteLine("\nPress Enter to return to the main menu.");
                Console.ReadLine();
            }
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
            if (enrollments.Count == 0)
            {
                Console.WriteLine("No enrollments found.");
                Console.WriteLine("\nPress Enter to return to the main menu.");
                Console.ReadLine();
                return;
            } else
            {
                // Iterate through each enrollment in the list of enrollments
                foreach (var enrollment in enrollments)
                {
                    // Print the enrollment's information to the console
                    Console.WriteLine(enrollment);
                }
                Console.WriteLine("\nPress Enter to return to the main menu.");
                Console.ReadLine();
            }
        }

        // Method to save the list of students to a file in JSON format
        private void SaveStudents()
        {
            // Serialize the list of students into a JSON string
            var json = JsonSerializer.Serialize(students);
    
            // Write the JSON string to the file specified by studentFilePath
            File.WriteAllText(studentFilePath, json);
        }

        // Method to load the list of students from a file in JSON format
        private void LoadStudents()
        {
            // Check if the file specified by studentFilePath exists
            if (File.Exists(studentFilePath))
            {
                // Read the contents of the file into a string
                var json = File.ReadAllText(studentFilePath);
        
                // Deserialize the JSON string into a list of Student objects
                // If the deserialization fails, return an empty list
                students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }
        }

        // Method to save the list of courses to a file in JSON format
        private void SaveCourses()
        {
            // Serialize the list of courses into a JSON string
            var json = JsonSerializer.Serialize(courses);
    
            // Write the JSON string to the file specified by courseFilePath
            File.WriteAllText(courseFilePath, json);
        }

        // Method to load the list of courses from a file in JSON format
        private void LoadCourses()
        {
            // Check if the file specified by courseFilePath exists
            if (File.Exists(courseFilePath))
            {
                // Read the contents of the file into a string
                var json = File.ReadAllText(courseFilePath);
        
                // Deserialize the JSON string into a list of Course objects
                // If the deserialization fails, return an empty list
                courses = JsonSerializer.Deserialize<List<Course>>(json) ?? new List<Course>();
            }
        }

        // Method to save the list of enrollments to a file in JSON format
        private void SaveEnrollments()
        {
            // Serialize the list of enrollments into a JSON string
            var json = JsonSerializer.Serialize(enrollments);
    
            // Write the JSON string to the file specified by enrollmentFilePath
            File.WriteAllText(enrollmentFilePath, json);
        }

        // Method to load the list of enrollments from a file in JSON format
        private void LoadEnrollments()
        {
            // Check if the file specified by enrollmentFilePath exists
            if (File.Exists(enrollmentFilePath))
            {
                // Read the contents of the file into a string
                var json = File.ReadAllText(enrollmentFilePath);
        
                // Deserialize the JSON string into a list of Enrollment objects
                // If the deserialization fails, return an empty list
                enrollments = JsonSerializer.Deserialize<List<Enrollment>>(json) ?? new List<Enrollment>();
            }
        }
    }
}