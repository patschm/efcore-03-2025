namespace DemoComplexTypes;

public class Reviewer
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public ReviewerCredential? Credentials { get; set; }
    public int[] AssignedNumbers { get; set; } = [];
    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}
