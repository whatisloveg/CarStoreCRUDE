namespace CarStoreCRUDE.Server.Contracts
{
    public record CarRequest(
        string CarMake,
        string CarName,
        decimal Price);
}
