// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Crew
{
    public Guid CrewId { get; set; }
    public Guid TeamId { get; set; }
    public Guid MemberId { get; set; }
    public CrewStatus Status { get; set; }
    public bool TeamAdmin { get; set; }

    public virtual Team Team { get; set; } = null!;
    public virtual Member Member { get; set; } = null!;
}