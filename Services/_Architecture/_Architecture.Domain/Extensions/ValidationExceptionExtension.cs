namespace _Architecture.Domain.Extensions;

public static class ValidationExceptionExtension
{
    public static Dictionary<string, List<string>> GetErrors(this ValidationResult validation)
    {
        var result = new Dictionary<string, List<string>>();

        foreach (var propName in validation.Errors.Select(e => e.PropertyName))
        {
            if (result.TryGetValue(propName, out var errors)) continue;

            var error = validation.Errors
                                  .Where(x => x.PropertyName == propName)
                                  .Select(x => x.ErrorMessage)
                                  .ToList();
            result.Add(propName, error);
        }

        return result;
    }
}