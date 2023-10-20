namespace Identity.Domain.Types;

public class Result<TResult, TError> where TResult : notnull where TError : Error
{
    private readonly TResult? _result;
    private readonly TError? _error;

    protected Result(TResult? result)
    {
        _result = result;
        _error = default;
    }
    
    protected Result(TError error)
    {
        _result = default;
        _error = error;
    }
    
    public static Result<TResult, TError> Success(TResult result) => new Result<TResult, TError>(result);
    public static Result<TResult, TError> Failure(TError error) => new Result<TResult, TError>(error);
    
    public bool IsSuccess => _result is not null;
    public bool IsFailure => _error is not null;
    
    public TResult? GetResult() => _result;
    public TError? GetError() => _error;

    public TError? GetFilteredErrors(Func<Error, bool> filter)
    {
        var filteredError = _error;

        if (filteredError is null || !filter(filteredError))
        {
            return null;
        }
        
        if (filteredError.IncludeErrors is null)
        {
            return filteredError;
        }

        var errors = new List<Error>();
        foreach (var error in filteredError.IncludeErrors)
        {
            var newFilteredError = GetFilteredError(filter, error);
            if (newFilteredError is not null)
            {
                errors.Add(newFilteredError);
            }
        }
        
        filteredError.IncludeSomeErrors(errors.ToArray());

        return filteredError;
    }

    private Error? GetFilteredError(Func<Error, bool> filter, Error filteredError)
    {
        if (!filter(filteredError))
        {
            return null;
        }

        if (filteredError.IncludeErrors is null)
        {
            return filteredError;
        }
        
        var errors = new List<Error>();
        foreach (var error in filteredError.IncludeErrors)
        {
            var newFilteredError = GetFilteredError(filter, error);
            if (newFilteredError is not null)
            {
                errors.Add(newFilteredError);
            }
        }
        
        filteredError.IncludeSomeErrors(errors.ToArray());
        
        return filteredError;
    }

    public static implicit operator Result<TResult, TError>(TResult result) => Success(result);
    public static implicit operator Result<TResult, TError>(TError error) => Failure(error);
    
    public TValue? Match<TValue>(Func<TResult, TValue> onSuccess, Func<TError, TValue> onFailure) => IsSuccess ? onSuccess(_result!) : onFailure(_error!);
}