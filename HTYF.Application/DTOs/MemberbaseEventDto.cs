namespace HTYF.Application.DTOs
{
    public class MemberbaseEventDto
    {
        public string ExternalId { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = default!;
        public int Capacity { get; set; }
    }
}
