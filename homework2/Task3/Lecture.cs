namespace Task3
{
    public class Lecture : TrainingMaterial
    {
        public string? Theme { get; }
        public Lecture(string? description, string? theme) : base(description)
        {
            Theme = theme;
        }
    }
}
