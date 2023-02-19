using System.ComponentModel.DataAnnotations;

namespace Medicoz.Models
{
    public class Department
    {
        public int Id { get; set; }
        [StringLength(maximumLength:30)]
        public string Name { get; set; }
        public List<Doctor>? Doctors { get; set; }

    }
}
