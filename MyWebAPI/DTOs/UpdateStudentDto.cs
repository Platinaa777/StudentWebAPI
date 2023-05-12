namespace MyWebAPI.DTOs
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }
        public int Class { get; set; }
    }
}
