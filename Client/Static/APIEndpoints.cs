namespace Client.Static;

internal static class APIEndpoints
{
#if DEBUG
    private const string ServerBaseUrl = "https://localhost:7192";
#else
    private const string ServerBaseUrl = "https://crudcustomersdataapp-server.azurewebsites.net";
#endif
    internal const string CustomersAll = $"{ServerBaseUrl}/api/customers";
    internal const string CustomersAdd = $"{ServerBaseUrl}/api/customers";

    internal static string CustomersUpdate(Guid id) => $"{ServerBaseUrl}/api/customers/{id}";
    internal static string CustomersDelete(Guid id) => $"{ServerBaseUrl}/api/customers/{id}";
}
