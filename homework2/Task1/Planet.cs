namespace Task1
{
    public class Planet
    {
        private double _mass;
        private double _radius;
        private readonly int[] _coords = new int[3];

        public int X
        {
            get => _coords[0];
            set => _coords[0] = value;
        }

        public int Y {
            get => _coords[1];
            set => _coords[1] = value;
        }
        public int Z {
            get => _coords[2];
            set => _coords[2] = value;
        }

        public double Mass
        {
            get => _mass;
            set
            {
                if (value < 0)
                {
                    _mass = 0;
                }
                else
                {
                    _mass = value;
                }
            }
        }

        public double Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                {
                    _radius = 0;
                }
                else
                {
                    _radius = value;
                }
            }
        }

        public bool IsZero()
        {
            return (X == 0) & (Y == 0) & (Z == 0);
        }

        public double EvaluateDistance(Planet planet)
        {
            double deltaX = X - planet.X;
            double deltaY = Y - planet.Y;
            double deltaZ = Z - planet.Z;
            return (Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ));
        }

        public static bool DetectCollisions(params Planet[] planets)
        {
            if (planets.Length < 2)
            {
                return false;
            }
            for (var i = 0; i < (planets.Length - 1); i++)
            {
                for (var j = i + 1; j < planets.Length; j++)
                {
                    if (planets[i].EvaluateDistance(planets[j]) - (planets[i].Radius + planets[j].Radius) <= 0)
                    {
                        return true;
                    }
                }
                
            }
            return false;
        }
    }
}
