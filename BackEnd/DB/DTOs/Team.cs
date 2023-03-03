// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Team
{
    public Guid TeamId { get; set; }
    public Guid ClubId { get; set; }
    public string Name { get; set; } = null!;
    public TeamPolicy Policy { get; set; } = null!;
    public TeamStatus Status { get; set; }

    public virtual Club Club { get; set; } = null!;
    public virtual ICollection<Crew> Crews { get; } = new List<Crew>();
}