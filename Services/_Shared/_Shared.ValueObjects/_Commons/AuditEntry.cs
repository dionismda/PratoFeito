namespace _Shared.ValueObjects._Commons;

public class AuditEntry : ValueObject<AuditEntry>
{
    public string Who { get; private set; }
    public DateTime Date { get; private set; }

    public AuditEntry(string who)
    {
        Who = who;
        Date = DateTime.UtcNow;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Who;
        yield return Date;
    }
}
