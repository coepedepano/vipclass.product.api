using System;

public class TimedAuctions
{
    public int IdTimedAuction { get; set; }
    public int IdProduct { get; set; }
    public decimal MinimumBid { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}