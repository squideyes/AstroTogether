// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Meet
{
    public Guid MeetId { get; set; }
    public Guid SiteId { get; set; }
    public DateTime Date { get; set; }
    public MeetStatus Status { get; set; }
    public MeetDetails Details { get; set; } = null!;

    public virtual Site Site { get; set; } = null!;
    public virtual ICollection<Attendee> Attendees { get; } = new List<Attendee>();
}