namespace Petfy.Domain.DTO
{
    public class PetDTO
    {
        public string Name { get; set; }
        public int? PetNumber { get; set; }
        public string Description { get; set; }
        public string Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Type { get; set; }
        public int OwnerID { get; set; }
    }
}
