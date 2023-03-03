using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Club
{
    public Guid ClubId { get; set; }
    public string Name { get; set; } = null!;
    public ClubStatus Status { get; set; }

    public virtual ICollection<Site> Sites { get; } = new List<Site>();
    public virtual ICollection<Crew> Crews { get; } = new List<Crew>();
    public virtual ICollection<Member> Members { get; } = new List<Member>();
}
