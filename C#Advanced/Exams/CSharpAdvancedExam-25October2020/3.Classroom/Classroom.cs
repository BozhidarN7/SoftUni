using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private readonly List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public int Capacity { get; set; }
        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            int removed = students.RemoveAll(x => x.FirstName == firstName && x.LastName == lastName);
            if (removed > 0)
            {
                return $"Dismissed student {firstName} {lastName}";
            }
            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            List<Student> enrolled = students.Where(x => x.Subject == subject).ToList();
            if (enrolled.Count == 0)
            {
                return "No students enrolled for the subject";
            }
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Subject: {subject}");
            result.AppendLine($"Students:");

            result.Append(string.Join(Environment.NewLine, enrolled.Select(x => $"{x.FirstName} {x.LastName}")));
            return result.ToString();
        }
        public int GetStudentsCount()
        {
            return Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }

    }
}
