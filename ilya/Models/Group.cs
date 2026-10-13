
namespace ilya.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; } = string.Empty;

        public int Course { get; set; }

        public int SpecialityId { get; set; }

        public Speciality Speciality { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
