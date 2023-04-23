namespace VatCalculator.Domain.Entities
{
    public class VatCalculation
    {
        public float VatRate { get; set; }

        public double PriceWithoutVat { get; set; }

        public double Vat { get; set; }

        public double PriceWithVat { get; set; }

    }
}