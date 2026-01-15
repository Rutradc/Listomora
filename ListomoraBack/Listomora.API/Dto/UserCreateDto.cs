namespace Listomora.API.Dto
{
    public record UserCreateDto
    (
        // TODO : ajouter token de création de compte
        // string CreationToken,
        string Email,
        string FirstName,
        string? LastName,
        string Password
    );
}
