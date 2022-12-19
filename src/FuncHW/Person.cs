using System;

namespace FuncHW
{
    public record Person
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}
