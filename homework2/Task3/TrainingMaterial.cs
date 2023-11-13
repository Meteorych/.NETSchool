using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public abstract class TrainingMaterial
    {
        protected TrainingMaterial(string? description)
        {
            Description = description;
        }

        public string? Description { get; }

    }
}
