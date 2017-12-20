using System;

namespace WpfApp
{
    [Serializable]
    public class StudentData : IComparable<StudentData>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TestName { get; set; }
        public int TestMark { get; set; }
        public DateTime TestDate { get; set; }

        public int CompareTo(StudentData st)
        {
            return TestMark.CompareTo(st.TestMark);
        }

        public int Compare(StudentData st1, StudentData st2)
        {
            return st1.CompareTo(st2);
        }

        public override string ToString()
        {       
            return $"{FirstName} {LastName}, test info: {TestName.ToUpper()} '{TestMark}': {TestDate.ToString("MMMM dd, yyyy")}";
        }
    }
}