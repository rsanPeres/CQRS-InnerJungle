using FluentValidation;
using InnerJungle.Controllers.Requests.Validators;
using InnerJungle.Domain.Entities;

namespace InnerJungle.Controllers.Requests
{
    public class CreateResearchRequest
    {
        public User User { get; set; }
        public Institution Institution { get; set; }
        public Eletrode Eletrode { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
        public void Validate()
        {
            var validationResult = new CreateResearchRequestValidator().Validate(this);
            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public Research CreateDomainObject()
        {
            return new Research(Title, Eletrode, Institution, User);
        }
    }
}
