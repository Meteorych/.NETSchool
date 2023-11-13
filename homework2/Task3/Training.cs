using System.ComponentModel;

namespace Task3
{
    public class Training
    {
        public string? Description { get; }
        private TrainingMaterial[] _exercises;

        /// <summary>
        /// Тестовое свойство
        /// </summary>
        public TrainingMaterial[] Exercises => _exercises;

        public Training(string? description, TrainingMaterial[] exercises)
        {
            Description = description;
            _exercises = exercises;

        }

        public Training(Training originalTraining)
        {
            Description = originalTraining.Description;
            _exercises = new TrainingMaterial[originalTraining._exercises.Length];
            for (var i = 0; i < originalTraining._exercises.Length; i++)
            {
                _exercises[i] = originalTraining._exercises[i] switch
                {
                    Lecture l => new Lecture(l.Description, l.Theme),
                    PracticeExercise p => new PracticeExercise(p.Description, p.LinkCondition, p.LinkCondition),
                    _ => _exercises[i]
                };
            }
        }

        public void Add(TrainingMaterial trainingMaterial)
        {
            Array.Resize(ref _exercises, _exercises.Length + 1);
            _exercises[^1] = trainingMaterial;
        }

        public bool IsPractical()
        {
            foreach (var exercise in _exercises)
            {
                if (exercise is Lecture) return false;
            }
            return true;
        }
    }
}
