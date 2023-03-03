using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Member
{
    public Guid MemberId { get; set; }
    public Guid ClubId { get; set; }
    public Guid ActorId { get; set; }
    public bool CanAdmin { get; set; }
    public MemberStatus Status { get; set; }

    public virtual Actor Actor { get; set; } = null!;
    public virtual ICollection<Attendee> Attendees { get; } = new List<Attendee>();
    public virtual Club Club { get; set; } = null!;
    public virtual ICollection<Crew> Crews { get; } = new List<Crew>();
}
