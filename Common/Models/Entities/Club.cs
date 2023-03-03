// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using FluentValidation;
using SquidEyes.Basics;

namespace AstroTogether.Common;

public class Club
{
    public class Validator : AbstractValidator<Club>
    {
        public Validator()
        {
            RuleFor(x => x.ClubId)
                .NotEmpty();

            RuleFor(x => x.Name)
                .Must(v => v.IsNonEmptyAndTrimmed(3, 50));

            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.City)
                .Must(v => v.IsNonEmptyAndTrimmed(3, 25));

            RuleFor(x => x.Region)
                .Must(v => v.IsNonEmptyAndTrimmed(3, 25));

            RuleFor(x => x.Country)
                .Length(2)
                .Must(v => v.All(c => char.IsAscii(c)));

            RuleFor(x => x.Website)
                .NotEmpty()
                .Must(v => v.IsAbsoluteUri);
        }
    }

    public required Guid ClubId { get; set; }
    public required string Name { get; set; }
    public required ClubStatus Status { get; set; }
    public required string City { get; set; }
    public required string Region { get; set; }
    public required string Country { get; set; }
    public required Uri Website { get; set; }
}