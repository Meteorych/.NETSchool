namespace Task3
{
    public class PracticeExercise : TrainingMaterial
    {
        public string? LinkCondition { get; }
        public string? LinkSolution { get; }

        public PracticeExercise(string? description, string? linkCondition, string? linkSolution) : base(description)
        {
            LinkCondition = linkCondition;
            LinkSolution = linkSolution;
        }
    }
}
