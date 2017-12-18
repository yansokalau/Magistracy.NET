using System;

namespace BinaryTreeUnitTests
{
    public class Student : IComparable<Student>
    {
        public string firstName;
        public string lastName;

        public string courseName;
        public DateTime dateOfTest;
        public int mark;

        public int CompareTo(Student student)
        {
            return mark.CompareTo(student.mark);
        }
    }
}