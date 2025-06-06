using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define a namespace to organize related classes and types
namespace StudentManagementSystem.Models
{
    // Define a public class named Student to represent a student entity
    public class Student
    {
        // Define public properties to store student data
        // These properties have getter and setter accessors to control access to the data
        public int StudentId { get; set; } // Unique identifier for the student
        public string FullName { get; set; } // Full name of the student
        public string Email { get; set; } // Email address of the student

        // Define a constructor to initialize a new Student object
        // This constructor takes three parameters: studentId, fullName, and email
        public Student(int studentId, string fullName, string email)
        {
            // Assign the constructor parameters to the corresponding properties
            StudentId = studentId;
            FullName = fullName;
            Email = email;
        }

        // Override the ToString method to provide a human-readable representation of the Student object
        // This method returns a string that includes the student's ID, full name, and email
        public override string ToString()
        {
            return $"Student ID: {StudentId} - {FullName} - {Email}";
        }
    }
}
