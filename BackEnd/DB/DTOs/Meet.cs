﻿using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Meet
{
    public Guid MeetId { get; set; }
    public Guid SiteId { get; set; }
    public Guid CrewId { get; set; }
    public DateTime Date { get; set; }
    public MeetStatus Status { get; set; }
    public MeetDetails Details { get; set; } = null!;

    public virtual Site Site { get; set; } = null!;
    public virtual Crew Crew { get; set; } = null!;
    public virtual ICollection<Attendee> Attendees { get; } = new List<Attendee>();
}