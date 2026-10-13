
namespace ilya.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public int GroupId { get; set; }

        public Group Group { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
