// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Site
{
    public Guid SiteId { get; set; }
    public Guid ClubId { get; set; }
    public string Name { get; set; } = null!;
    public SiteStatus Status { get; set; }
    public SiteDetails Details { get; set; } = null!;

    public virtual Club Club { get; set; } = null!;
    public virtual ICollection<Meet> Meets { get; } = new List<Meet>();
}