using Payments.Domain.Enums;

namespace Payments.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid FromAccountId { get; set; }
    public Guid ToAccountId { get; set; }
    public decimal Ammount { get; set; }
    public TransactionStatus Status { get; set; }
    public string IdempotencyKey { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public Account FromAccount { get; set; } = null!;
    public Account ToAccount { get; set; } = null!;
    public ICollection<LedgerEntry> LedgerEntries { get; set; } = [];
}