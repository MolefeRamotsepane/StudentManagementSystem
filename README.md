# StudentManagementSystem

This is a student management system built in C# as a console application. This project is similar to the expense management system as well as the inventory management system, it was just meant to still strengthen my understanding of object-oriented programming, file persistence, and clean code architecture. I continue to imporve my way of dealing with Git and GitHub version control practices. I finally found the perfect format for writitng commits. I am trying not to rely on the applications that I have built, instead put my understanding and strengthen to use. Adn that is what I did. And I am proud of it. Repetition has made a huge difference for me. 

## 🚧 Development Phases

### Phase 1: Basic structure and functionality
- Student: Represents a student with ID, name, age, and course list.
- Course: Represents a course with code, title, and instructor.
- Enrollment: Connects students to courses with enrollment dates.
- StudentService handles operations for each entity.
- Add, update, delete, and view students and courses.
- Prevent duplicate enrollments and handle edge cases.

### Phase 2: Improving Structure
- Structured menu-based navigation in Program.cs.
- Followed separation of concerns:
- Data logic in manager classes.
- UI handled in Program.cs.
- Implemented validation for user input.
- Improved feedback and error messaging.

### Phase 3: Persistence
- Implemented file-based persistence using System.Text.Json.
- Saved and loaded student, course, and enrollment data from .json files.
- Ensured data remains consistent across sessions.
- Handled file reading/writing gracefully (checked for empty/missing files).

### Phase 4: Preparing for GitHub
- Added `.gitignore` to avoid committing VS-generated files
- Committed code in meaningful steps to show real development progress
- Wrote documentation (this README)

## 🛠️ Technologies Used

- Language: C#
- IDE: Visual Studio / Visual Studio Code
- .NET: .NET Framework 8 / .NET Core Console App
- Git & GitHub for version control

## 🧱 Challenges Encountered

- I did not really have any challenges this time, it was just a matter of finding the most efficient way of implementing persistancy and I believe I have achieved it.

## Learnings & Growth
This project taught me how to:
- Use object-oriented programming practically, also getting better at it
-- Getting efficient with basic file-based data persistence
-- Using Git & GitHub better
-- Debug and refactor with purpose

## 👨‍💻 Author

**Molefe Ramotsepane**  
[GitHub Profile](https://github.com/MolefeRamotsepane)  
Aspiring Software Engineer and Web Developer

## 📜 License
MIT License
