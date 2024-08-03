using Microsoft.AspNetCore.Identity;

namespace HairdressingSalons.Domain.Entities;

public class HairdressingSalon
{
    public required int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public HairdressingSalonContactDetails ContactDetails { get; set; } = default!;

    public string? CreatedById { get; set; }
    public IdentityUser? CreatedBy { get; set; }

    public string EncodedName { get; private set; } = default!;
    public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
}
