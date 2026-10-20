using System;
using System.Collections.Generic;

//Student

class Student
{
    public int StudentId { get; }
    public string Name { get; }
    public int Age { get; }
    public List<Course> Courses { get; }

    public Student(int studentId, string name, int age)
    {
        StudentId = studentId;
        Name = name;
        Age = age;
        Courses = new List<Course>();
    }

    public bool Enroll(Course course)
    {
        for (int i = 0; i < Courses.Count; i++)
        {
            if (Courses[i].CourseId == course.CourseId)
            {
                return false;
            }
        }

        Courses.Add(course);
        return true;
    }

    public string PrintDetails()
    {
        string details = "Student ID: " + StudentId + " Name: " + Name+ " Age: " + Age;

        for (int i = 0; i < Courses.Count; i++)
        {
            details += " Course: " + Courses[i].Title;
        }

        return details;
    }
}


//Instructor


class Instructor
{
    public int InstructorId { get; }
    public string Name { get; }
    public string Specialization { get; }

    public Instructor(int instructorId, string name, string specialization)
    {
        InstructorId = instructorId;
        Name = name;
        Specialization = specialization;
    }

    public string PrintDetails()
    {
        return "Instructor ID: " + InstructorId
             + " Name: " + Name
             + " Specialization: " + Specialization;
    }
}

//Course

class Course
{
    public int CourseId { get; }
    public string Title { get; }
    public Instructor Instructor { get; }

    public Course(int courseId, string title, Instructor instructor)
    {
        CourseId = courseId;
        Title = title;
        Instructor = instructor;
    }

    public string PrintDetails()
    {
        return "Course ID: " + CourseId
             + " Title: " + Title
             + " Instructor: " + Instructor.Name;
    }
}

//School

class School
{
    public List<Student> Students { get; }
    public List<Course> Courses { get; }
    public List<Instructor> Instructors { get; }

    public School()
    {
        Students = new List<Student>();
        Courses = new List<Course>();
        Instructors = new List<Instructor>();
    }

    public bool AddStudent(Student student)
    {
        for (int i = 0; i < Students.Count; i++)
        {
            if (Students[i].StudentId == student.StudentId)
            {
                return false;
            }
        }

        Students.Add(student);
        return true;
    }

    public bool AddInstructor(Instructor instructor)
    {
        for (int i = 0; i < Instructors.Count; i++)
        {
            if (Instructors[i].InstructorId == instructor.InstructorId)
            {
                return false;
            }
        }

        Instructors.Add(instructor);
        return true;
    }

    public bool AddCourse(Course course)
    {
        for (int i = 0; i < Courses.Count; i++)
        {
            if (Courses[i].CourseId == course.CourseId)
            {
                return false;
            }
        }

        Courses.Add(course);
        return true;
    }

    public Student FindStudent(int studentId)
    {
        for (int i = 0; i < Students.Count; i++)
        {
            if (Students[i].StudentId == studentId)
            {
                return Students[i];
            }
        }

        return null;
    }

    public Course FindCourse(int courseId)
    {
        for (int i = 0; i < Courses.Count; i++)
        {
            if (Courses[i].CourseId == courseId)
            {
                return Courses[i];
            }
        }

        return null;
    }

    public Instructor FindInstructor(int instructorId)
    {
        for (int i = 0; i < Instructors.Count; i++)
        {
            if (Instructors[i].InstructorId == instructorId)
            {
                return Instructors[i];
            }
        }

        return null;
    }

    public bool EnrollStudentInCourse(int studentId, int courseId)
    {
        Student student = FindStudent(studentId);
        Course course = FindCourse(courseId);

        if (student == null || course == null)
        {
            return false;
        }

        return student.Enroll(course);
    }
	
	
	//Bonus
	
	public bool IsStudentEnrolled(int studentId, int courseId)
   {
    Student student = FindStudent(studentId);
    Course course = FindCourse(courseId);

    if (student == null || course == null)
    {
        return false;
    }

    for (int i = 0; i < student.Courses.Count; i++)
    {
        if (student.Courses[i].CourseId == courseId)
        {
            return true;
        }
     }

     return false;
 }
	
	public string FindInstructorNameByCourseTitle(string courseTitle)
  {
    for (int i = 0; i < Courses.Count; i++)
    {
        if (Courses[i].Title == courseTitle)
        {
            return Courses[i].Instructor.Name;
        }
    }

    return null;
  }
}



public class Program
{
	public static void Main()
	{
		School school = new School();

while (true)
{
    Console.WriteLine("\n===== Student Management System =====");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Add Instructor");
    Console.WriteLine("3. Add Course");
    Console.WriteLine("4. Enroll Student in Course");
    Console.WriteLine("5. Show All Students");
    Console.WriteLine("6. Show All Courses");
    Console.WriteLine("7. Show All Instructors");
    Console.WriteLine("8. Find Student");
    Console.WriteLine("9. Find Course");
	Console.WriteLine("10. Check student enrollment");
	Console.WriteLine("11. Find instuctor by course name");
    Console.WriteLine("0. Exit");

    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();
	if (choice == null)
   {
       return;
   }

    switch (choice)
    {
        case "1":
            Console.Write("Enter Student ID: ");
            int studentid = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Student Name: ");
            string studentname = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            int studentage = Convert.ToInt32(Console.ReadLine());

            Student student = new Student(studentid, studentname, studentage);

            bool studentresult = school.AddStudent(student);

            if (studentresult)
            {
                Console.WriteLine("Student added successfully!");
            }
            else
            {
                Console.WriteLine("Student ID already exists!");
            }

            break;

        case "2":
            Console.Write("Enter Instructor ID: ");
            int instructorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Instructor Name: ");
            string instructorName = Console.ReadLine();

            Console.Write("Enter Instructor Specialization: ");
            string specialization = Console.ReadLine();

            Instructor instructor = new Instructor(instructorId,instructorName,specialization);

            bool instructorResult = school.AddInstructor(instructor);

            if (instructorResult)
            {
                Console.WriteLine("Instructor added successfully!");
            }
            else
            {
                Console.WriteLine("Instructor ID already exists!");
            }

            break;

        case "3":
             Console.Write("Enter Course ID: ");
            int courseId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Course Title: ");
            string courseTitel = Console.ReadLine();

			Console.WriteLine("Avaliable Instructors");

            for(int i=0;i < school.Instructors.Count;i++)
			{
				Console.WriteLine(school.Instructors[i].PrintDetails());
			}
			    Console.Write("Enter Instractor Id: ");
			
			   int instructorcourseId = Convert.ToInt32(Console.ReadLine());
			   Instructor instructorcourse = school.FindInstructor(instructorcourseId);

             if (instructorcourse == null)
            {
                Console.WriteLine("Instructor not found!");
                break;
             }

          Course courseinstructor = new Course(courseId, courseTitel,instructorcourse);

          bool courseresult = school.AddCourse(courseinstructor);

          if (courseresult)
          {
               Console.WriteLine("Course added successfully!");
          }
         else
          {
               Console.WriteLine("Course ID already exists!");
          }

             break;

        case "4":
             Console.Write("Enter Student ID: ");
             int studentId_course =Convert.ToInt32(Console.ReadLine());

              Console.Write("Enter Course ID: ");
              int courseId_student = Convert.ToInt32(Console.ReadLine());

              bool enrollResult = school.EnrollStudentInCourse(studentId_course, courseId_student);

             if (enrollResult)
          {
               Console.WriteLine("Student enrolled successfully!");
          } else
            {
                 Console.WriteLine("Enrollment failed! Student or course not found, or student is already enrolled.");
			}
               break;

        case "5":
            for (int i = 0; i < school.Students.Count; i++)
            {
                Console.WriteLine(school.Students[i].PrintDetails());
            }

            break;

        case "6":
            for (int i = 0; i < school.Courses.Count; i++)
            {
                Console.WriteLine(school.Courses[i].PrintDetails());
            }

            break;

        case "7":
            for (int i = 0; i < school.Instructors.Count; i++)
            {
                Console.WriteLine(school.Instructors[i].PrintDetails());
            }

            break;

        case "8":
             
            Console.Write("Enter Student ID: ");
           int studentId_found = Convert.ToInt32(Console.ReadLine());

          Student foundStudent = school.FindStudent(studentId_found);

         if (foundStudent != null)
        {
            Console.WriteLine(foundStudent.PrintDetails());
        }else
         {
             Console.WriteLine("Student not found!");
		 }
            break;

        case "9":
             Console.Write("Enter course ID: ");
           int courseId_found = Convert.ToInt32(Console.ReadLine());

          Course foundCourse = school.FindCourse(courseId_found);

         if (foundCourse!= null)
        {
            Console.WriteLine(foundCourse.PrintDetails());
        }else
         {
             Console.WriteLine("Course not found!"); 
		 }
            break;
			
		
		case "10":
                Console.Write("Enter Student ID: ");
                 int checkStudentId = Convert.ToInt32(Console.ReadLine());

                 Console.Write("Enter Course ID: ");
                int checkCourseId = Convert.ToInt32(Console.ReadLine());

                  bool isEnrolled = school.IsStudentEnrolled( checkStudentId, checkCourseId);

                 if (isEnrolled)
                {
                    Console.WriteLine("Student is enrolled in this course.");
                 }
                else
                {
                    Console.WriteLine("Student is not enrolled in this course, or the student/course was not found.");
                 }

                 break;
		case "11":
			  Console.Write("Enter Course Title: ");
              string searchTitle = Console.ReadLine();

          string instructorName_course = school.FindInstructorNameByCourseTitle(searchTitle);

        if (instructorName_course != null)
          {
             Console.WriteLine("Instructor Name: " + instructorName_course);
          }
           else
           {
               Console.WriteLine("Course not found!");
           }
			break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}
	}
}
