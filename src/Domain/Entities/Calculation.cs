namespace VatCalculator.Domain.Entities;

public class Calculation
{
    public decimal VatRate { get; set; }

    public decimal PriceWithoutVat { get; set; }

    public decimal Vat { get; set; }

    public decimal PriceWithVat { get; set; }
}

