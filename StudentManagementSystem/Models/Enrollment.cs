using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define a namespace to organize related classes and types
namespace StudentManagementSystem.Models
{
    // Define a public class named Enrollment to represent an enrollment entity
    public class Enrollment
    {
        // Define public properties to store the course ID and student ID
        // These properties have getter and setter methods to access and modify their values
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int  EnrollmentId { get; set; }

        // Define a constructor to initialize a new Enrollment object
        // This constructor takes two parameters: courseID and studentID, enrollmentID
        public Enrollment(int enrollmentID, int courseID, int studentID)
        {
            // Assign the constructor parameters to the corresponding properties
            EnrollmentId = enrollmentID;
            CourseId = courseID;
            StudentId = studentID;
        }

        // Override the ToString method to provide a human-readable representation of the Enrollment object
        // This method returns a string that includes the student's ID and the course ID they are enrolled in
        public override string ToString()
        {
            // Use string interpolation to format the string with the student's ID and course ID
            return $"{EnrollmentId} Student ID: {StudentId} is enrolled in Course ID: {CourseId}";
        }
    }
}