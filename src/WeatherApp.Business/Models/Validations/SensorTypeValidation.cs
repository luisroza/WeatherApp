using FluentValidation;

namespace WeatherApp.Business.Models.Validations
{
    public class SensorTypeValidation : AbstractValidator<SensorType>
    {
        public SensorTypeValidation()
        {
            RuleFor(s => s.TimeStamp)
                .NotEmpty()
                .WithMessage("Field {PropertyName} must not be null");

            RuleFor(c => c.Measure)
                .NotEmpty()
                .WithMessage("Field {PropertyName} must not be null");
        }
    }
}
