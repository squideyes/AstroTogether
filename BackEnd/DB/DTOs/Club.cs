using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Club
{
    public Guid ClubId { get; set; }
    public string Name { get; set; } = null!;
    public ClubStatus Status { get; set; }
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Website { get; set; } = null!;

    public virtual ICollection<Member> Members { get; } = new List<Member>();
    public virtual ICollection<Site> Sites { get; } = new List<Site>();
    public virtual ICollection<Team> Teams { get; } = new List<Team>();
}
