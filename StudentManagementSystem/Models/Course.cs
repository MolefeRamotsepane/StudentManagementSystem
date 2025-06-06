using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define a namespace to organize related classes and types
namespace StudentManagementSystem.Models
{
    // Define a public class named Course to represent a course entity
    public class Course
    {
        // Define a public property to store the unique identifier of the course
        public int CourseId { get; set; }

        // Define a public property to store the name of the course
        public string CourseName { get; set; }

        // Define a constructor to initialize a new Course object
        // This constructor takes two parameters: courseId and courseName
        public Course(int courseId, string courseName)
        {
            // Assign the constructor parameters to the corresponding properties
            CourseId = courseId;
            CourseName = courseName;
        }

        // Override the ToString method to provide a human-readable representation of the Course object
        // This method returns a string that includes the course ID and course name
        public override string ToString()
        {
            // Use string interpolation to format the string with the course ID and course name
            return $"Course ID: {CourseId} - {CourseName}";
        }
    }
}