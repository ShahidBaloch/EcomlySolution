namespace Ecomly.Core.DTOs;
public record AuthenticationResponse(
    Guid UserID,
    string? Email,
    string? PersonName,
    string? Gender,
    string? Token,
    bool Success
    )
{
    // parameterless constructor
    public AuthenticationResponse() : this(default, default, default, default, default, default) { }
}

