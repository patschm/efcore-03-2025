namespace EFBasics;

public class Merk
{
    public Merk()
    {
        Products = new HashSet<Product>();
    }
    public long Id { get; set; }
    public string? Naam { get; set; }
    public string? Website { get; set; }
    
    public virtual ICollection<Product> Products { get; set; }
}
