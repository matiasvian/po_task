using System.Text.Json;
using Serilog;

// Ignore warnings
#pragma warning disable CS8602
#pragma warning disable CS8603

public class BrrAPI {
    private static JsonSerializerOptions options = new JsonSerializerOptions {IncludeFields = true};
    private static HttpClient client = new HttpClient();

    public static Company GetCompany(string OrgNr) {

        string url = "https://data.brreg.no/enhetsregisteret/api/enheter/" + OrgNr;
        HttpResponseMessage response = client.GetAsync(url).Result;

        if (response.IsSuccessStatusCode) {
            
            string json = response.Content.ReadAsStringAsync().Result;
            var company = JsonSerializer.Deserialize<Company>(json, options);

            if (company.slettedato != null) {
                Log.Error("Error: Company " + company.navn + " (OrgNr.: " + company.organisasjonsnummer + ") is deleted.");
                return null;
            }
            return company;
        }
        else {
            Log.Error("Error: Company not found " + response.StatusCode);
            return null;
        }
    }
}
