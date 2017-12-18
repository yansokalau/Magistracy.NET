using System;

namespace ConsoleApp
{
    [Serializable]
    public class StudentData : IComparable<StudentData>
    {

        public string firstName;
        public string lastName;
        public string testName;
        public int testMark;
        public DateTime testDate;

        public int CompareTo(StudentData st)
        {
            return testMark.CompareTo(st.testMark);
        }

        public int Compare(StudentData st1, StudentData st2)
        {
            return st1.CompareTo(st2);
        }

        public override string ToString()
        {       
            return $"{firstName} {lastName}, test info: {testName.ToUpper()} '{testMark}': {testDate.ToString("MMMM dd, yyyy")}";
        }
    }
}