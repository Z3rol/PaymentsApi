namespace Payments.Domain.Entities;

public class Account
{
    public Guid Id { get; set; }
    public string OwnerId { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<LedgerEntry> LedgerEntries { get; set; } = [];
}