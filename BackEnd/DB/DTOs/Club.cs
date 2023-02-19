using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Club
{
    public Guid ClubId { get; set; }
    public string Name { get; set; } = null!;
    public ClubStatus Status { get; set; }

    public virtual ICollection<Site> Sites { get; } = new List<Site>();
    public virtual ICollection<Team> Teams { get; } = new List<Team>();
    public virtual ICollection<Member> Members { get; } = new List<Member>();
}
