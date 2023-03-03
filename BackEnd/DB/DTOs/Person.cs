// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Person
{
    public Guid PersonId { get; set; }
    public EmailAddress Email { get; set; } = default;
    public PhoneNumber CellPhone { get; set; } = default;
    public string FirstName { get; set; } = null!;
    public char? Initial { get; set; }
    public string LastName { get; set; } = null!;
    public PersonStatus Status { get; set; }

    public virtual ICollection<Member> Members { get; } = new List<Member>();
    public virtual ICollection<Attendee> Attendees { get; } = new List<Attendee>();
}