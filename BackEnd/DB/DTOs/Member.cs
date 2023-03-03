// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Member
{
    public Guid MemberId { get; set; }
    public Guid ClubId { get; set; }
    public Guid PersonId { get; set; }
    public MemberStatus Status { get; set; }
    public bool ClubAdmin { get; set; }

    public virtual Person Person { get; set; } = null!;
    public virtual Club Club { get; set; } = null!;
    public virtual ICollection<Attendee> Attendees { get; } = new List<Attendee>();
    public virtual ICollection<Crew> Crews { get; } = new List<Crew>();
}