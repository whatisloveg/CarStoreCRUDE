namespace CarStoreCRUDE.Server.Contracts
{
    public record CarResponse(
        Guid Id,
        string CarMake,
        string CarName,
        decimal Price);

}
