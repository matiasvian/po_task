using Serilog;

class PO_APP {
    public static void Main(string[] args) {

        // ----------------- LOGGING -----------------

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/logfile.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        // --------------- READING FILE ---------------

        List<string[]> ClientList = Reader.ReadCsv("data/po-kunder.csv");

        // ----------- RETREVING INFORMATION -----------

        StreamWriter writer = new StreamWriter("data/po-kunder-brr.csv");
        writer.WriteLine("organisasjonsnummer;navn;naeringskode1;organisasjonsform;antallAnsatte;po_navn");

        Console.WriteLine(ClientList.Count);

        for (int i = 1; i < ClientList.Count; i++) {

            var client = ClientList[i];
            var company = BrrAPI.GetCompany(client[0]);

            if (company != null) {
                
                if (company.navn.ToLower() != client[1].ToLower()) {
                company.po_navn = client[1];
                }
                else {
                    company.po_navn = company.navn;
                }

                writer.WriteLine(company.organisasjonsnummer + ";" + company.navn + ";" + company.naeringskode1?.kode + ";" + company.organisasjonsform.kode + ";" + company.antallAnsatte + ";" + company.po_navn);
            }
        }
        writer.Close();

        // --------------- STATISTICS ---------------

        var statistics = Statistics.GetStatistics("data/po-kunder-brr.csv");

        foreach (var stat in statistics) {
            Console.WriteLine(stat.Key + ": " + stat.Value + " (" + Math.Round((double)stat.Value / ClientList.Count * 100, 2) + "%)");
        }
        
        Log.Information("Done.");
    }
}
