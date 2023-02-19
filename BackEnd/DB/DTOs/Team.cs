using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Team
{
    public Guid TeamId { get; set; }
    public Guid ClubId { get; set; }
    public Guid AdminId { get; set; }
    public string Name { get; set; } = null!;
    public TeamStatus Status { get; set; }
    public TeamPolicy Policy { get; set; } = null!;

    public virtual Member Admin { get; set; } = null!;
    public virtual Club Club { get; set; } = null!;
    public virtual ICollection<Meet> Meets { get; } = new List<Meet>();
}
