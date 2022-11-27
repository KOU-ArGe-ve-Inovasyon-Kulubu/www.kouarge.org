namespace KouArge.Core.DTOs.UpdateDto
{
    public class SponsorAndPartnersUpdateDto : UpdateDto
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
