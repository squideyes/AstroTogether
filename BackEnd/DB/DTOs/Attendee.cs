using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Attendee
{
    public Guid AttendeeId { get; set; }
    public Guid MeetId { get; set; }
    public Guid MemberId { get; set; }
    public AttendeeStatus Status { get; set; }

    public virtual Meet Meet { get; set; } = null!;
    public virtual Member Member { get; set; } = null!;
}
