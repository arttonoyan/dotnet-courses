namespace _001_Linq
{
    class Student
    {
        public string name;
        public string surname;

        public string Fullname => $"{surname} {name}";

        public byte mark;
        public byte age;

        public University university;

        public override string ToString() => university.ToString();
    }

    public enum University : byte
    {
        /// <summary>State Engineering University of Armenia</summary>
        SEUA = 1,
        /// <summary>Yerevan State University</summary>
        YSU,
        /// <summary>American University of Armenia</summary>
        AUA
    }
}
