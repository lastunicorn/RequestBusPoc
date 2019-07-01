using RequestBusPoc.Domain.RequestBusModel;

namespace RequestBusPoc.Application.CreateBookmark
{
    public class CreateBookmarkRequest : IValidatableObject
    {
        public string FeatureId { get; set; }

        public void Validate()
        {
            if (FeatureId == null)
                throw new ValidationException("The " + nameof(FeatureId) + " is null.");
        }
    }
}