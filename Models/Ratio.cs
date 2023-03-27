namespace MinApiDemo.Models;

public class Ratio
{
    public int Id { get; set; }
    public decimal LowerBound { get; set; } 
    public decimal UpperBound { get; set; }
    public decimal Value { get; set; }
}