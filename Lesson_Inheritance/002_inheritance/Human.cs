namespace _002_inheritance
{
    class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public string FullName => $"{Surname} {Name}";
    }
}
