
using System.Diagnostics;

namespace ilya.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
