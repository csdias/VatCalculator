using FluentAssertions;
using VatCalculator.Application.Queries.GetVatCalculationQuery;
using VatCalculator.Application.Validators;
using Xunit;

namespace VatCalculator.Application.UnitTests.Queries;

public class GetCalculationGivenVatRequestValidatorTests
{

    public GetCalculationGivenVatRequestValidatorTests()
    {
    }

    [Fact]
    public async Task Validate_When_InputIsCorrect_Then_ResultIsValid()
    {
        // arrange
        var query = new GetCalculationGivenVatRequest() { VatRate = 13, PriceWithoutVat = 0, Vat = 32.50m, PriceWithVat = 0 };
        var validator = new GetVatCalculationRequestValidator();

        // act
        var result = validator.Validate(query);

        // assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public async Task Validate_When_VatRateIsMissing_Then_ResultIsInvalid()
    {
        // arrange
        var query = new GetCalculationGivenVatRequest() { PriceWithoutVat = 0, Vat = 32.50m, PriceWithVat = 0 };
        var validator = new GetVatCalculationRequestValidator();
            
        // act
        var result = validator.Validate(query);

        // assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage == 
        "Invalid VAT rate. Please, choose a value between 10, 13 and 20.");
    }

    [Fact]
    public async Task Validate_When_VatRateIsInvalid_Then_ResultIsInvalid()
    {
        // arrange
        var query = new GetCalculationGivenVatRequest() { VatRate = 7 };
        var validator = new GetVatCalculationRequestValidator();

        // act
        var result = validator.Validate(query);

        // assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage ==
        "Invalid VAT rate. Please, choose a value between 10, 13 and 20.");
    }

    [Fact]
    public async Task Validate_When_InputContainsMoreThanOneValue_Then_ResultIsInvalid()
    {
        // arrange
        var query = new GetCalculationGivenVatRequest() { VatRate = 13, PriceWithoutVat = 250, Vat = 32.5m, PriceWithVat = 0 };
        var validator = new GetVatCalculationRequestValidator();

        // act
        var result = validator.Validate(query);

        // assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain( e => e.ErrorMessage == 
            "More than one value error. Please enter only one value between VAT, Price without VAT and Price with VAT.");
    }

    [Fact]
    public async Task Validate_When_InputIsIncomplete_Then_ResultIsInvalid()
    {
        // arrange
        var query = new GetCalculationGivenVatRequest() { VatRate = 20, PriceWithoutVat = 0, Vat = 0, PriceWithVat = 0 };
        var validator = new GetVatCalculationRequestValidator();

        // act
        var result = validator.Validate(query);

        // assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage == 
            "There must be at least one value between VAT, Price without VAT and Price with VAT");
    }

}
