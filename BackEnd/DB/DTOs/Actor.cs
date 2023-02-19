using AstroTogether.Common;

namespace AstroTogether.BackEnd.DB;

public partial class Actor
{
    public Guid ActorId { get; set; }
    public EmailAddress Email { get; set; }
    public string FirstName { get; set; } = null!;
    public char? Initial { get; set; }
    public string LastName { get; set; } = null!;
    public ActorStatus Status { get; set; }

    public virtual ICollection<Member> Members { get; } = new List<Member>();
}
