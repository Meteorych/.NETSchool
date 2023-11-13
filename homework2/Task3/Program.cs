using Task3;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            var training1 = new Training("Liliput", new TrainingMaterial[] { new PracticeExercise(null, null, null) });
            Console.WriteLine("Should be true: " + training1.IsPractical());
            var training2 = new Training("Giant",
                new TrainingMaterial[] { new Lecture("Joy", null), new PracticeExercise("Nice!", null, null) });
            training2.Add(new Lecture("Shish", "Nice"));
            var training3 = new Training(training2);
            Console.WriteLine("Should be 'Joy', 'Nice!' and 'Shish': " + training3.Exercises[0].Description + " " + 
                              training3.Exercises[1].Description + " " + training3.Exercises[2].Description);
        }
    }
}