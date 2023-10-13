namespace UnitTestingSamples.Sample7;

public enum ErrorCode {
  InvalidName,
  InvalidAge,
  InvalidEmail
}
public record Error(string ErrorDescription, ErrorCode ErrorCode);
public record ValidationResult(bool IsValid, IEnumerable<Error> Errors);

class Validator
{
  public ValidationResult Validate(string name, int age, string email)
  {
    var errors = new List<Error>();
    if (string.IsNullOrEmpty(name) || name.Length > 100)
      errors.Add(new Error("Name can't be null, empty or longer than 100 chars", ErrorCode.InvalidName));
    if (age is < 16 or > 200)
      errors.Add(new Error("The age is invalid", ErrorCode.InvalidAge));
    if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
      errors.Add(new Error("Email should be longer than 5 chars, contain '.' and '@' chars", ErrorCode.InvalidEmail));
    return new ValidationResult(errors.Count == 0, errors);
  } 
}


public class ValidatorTests
{
  [InlineData("Andrii", 27, "apodkolzin@kse.org.ua", true, null, null)]
  [InlineData("Andrii", 15, "apodkolzin@kse.org.ua", false, "The age is invalid", ErrorCode.InvalidAge)]
  [InlineData("Andrii", 201, "apodkolzin@kse.org.ua", false, "The age is invalid", ErrorCode.InvalidAge)]
  [InlineData("", 27, "apodkolzin@kse.org.ua", false, "Name can't be null, empty or longer than 100 chars", ErrorCode.InvalidName)]
  [InlineData(null, 27, "apodkolzin@kse.org.ua", false, "Name can't be null, empty or longer than 100 chars", ErrorCode.InvalidName)]
  [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 27, "apodkolzin@kse.org.ua", false, "Name can't be null, empty or longer than 100 chars", ErrorCode.InvalidName)]
  [InlineData("Andrii", 27, "apodkolzinkse.org.ua", false, "Email should be longer than 5 chars, contain '.' and '@' chars", ErrorCode.InvalidEmail)]
  [InlineData("Andrii", 27, "apodkolzin@kseorgua", false, "Email should be longer than 5 chars, contain '.' and '@' chars", ErrorCode.InvalidEmail)]
  [InlineData("Andrii", 27, "a@a.", false, "Email should be longer than 5 chars, contain '.' and '@' chars", ErrorCode.InvalidEmail)]
  [Theory]
  public void When_DataIsFilled_Result_ShouldBeAsExpected(string name, int age, string email, bool isValid, string? errorDescription, ErrorCode? errorCode)
  {
    // Arrange
    var validator = new Validator();
    
    // Act
    var result = validator.Validate(name, age, email);
    
    // Assert
    Assert.Equal(isValid, result.IsValid);
    if (!isValid)
    {
      Assert.Equal(errorCode, result.Errors.Single().ErrorCode);
      Assert.Equal(errorDescription, result.Errors.Single().ErrorDescription);
    }
    else
    {
      Assert.Empty(result.Errors);
    }
  }
}