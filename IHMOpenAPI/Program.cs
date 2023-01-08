// See https://aka.ms/new-console-template for more information
using IHMOpenAPI;

//Création d'un client relié à tous nos points d'entrée du Projet "TestWebAPI)
//via OpenAPI
var httpClient = new HttpClient();
var client = new WebAPIClient(
     "https://localhost:7109",
     httpClient);

//Initialisation d'une liste de client
ICollection<Customer > customers = null;
try
{
    customers = await client.ReadAll2Async();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
if (customers == null)
    return;
foreach (var item in customers)
{
    Console.WriteLine($"{item.FirstName} {item.LastName}");
}
