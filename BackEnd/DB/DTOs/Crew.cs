using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Crew
{
    public Guid CrewId { get; set; }
    public Guid ClubId { get; set; }
    public Guid AdminId { get; set; }
    public string Name { get; set; } = null!;
    public CrewStatus Status { get; set; }
    public CrewPolicy Policy { get; set; } = null!;

    public virtual Member Admin { get; set; } = null!;
    public virtual Club Club { get; set; } = null!;
    public virtual ICollection<Meet> Meets { get; } = new List<Meet>();
}
