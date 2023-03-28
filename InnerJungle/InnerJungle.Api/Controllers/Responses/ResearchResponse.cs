using InnerJungle.Domain.Entities;

namespace InnerJungle.Controllers.Responses
{
    public record ResearchResponse
    {
        public string UserName { get; set; }
        public string InstitutionName { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public bool Done { get; set; }

        public ResearchResponse Parse(Research research)
        {
            return new ResearchResponse
            {
                UserName = research.User.FirstName,
                InstitutionName = research.Institution.Name,
                Title = research.Title,
                Start = research.Start,
                Done = research.Done,
            };
        }

    };
    
}
