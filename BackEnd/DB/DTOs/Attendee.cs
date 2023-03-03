// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Attendee
{
    public Guid AttendeeId { get; set; }
    public Guid MeetId { get; set; }
    public Guid? PersonId { get; set; }
    public Guid? MemberId { get; set; }
    public AttendeeStatus Status { get; set; }
    public bool MeetAdmin { get; set; }

    public virtual Meet Meet { get; set; } = null!;
    public virtual Member? Member { get; set; }
    public virtual Person? Person { get; set; }
}