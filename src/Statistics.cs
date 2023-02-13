using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

class Statistics {
 
    public static Dictionary<string, int> GetStatistics(string csv) {

        var statistics = new Dictionary<string, int>();
        statistics.Add("ENK", 0);
        statistics.Add("AS", 0);
        statistics.Add("FLI", 0);
        statistics.Add("0-4 ANSATTE", 0);
        statistics.Add("5-9 ANSATTE", 0);
        statistics.Add("<10 ANSATTE>", 0);

        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            HasHeaderRecord = true,
            MissingFieldFound = null,
        };

        using (StreamReader reader = new StreamReader(csv))
        using (CsvReader file = new CsvReader(reader, configuration))
        {
            var companies = file.GetRecords<Company2>();

            foreach (var company in companies) {
                
                if (company.organisasjonsform == "ENK") {
                    statistics["ENK"]++;
                }
                else if (company.organisasjonsform == "AS") {
                    statistics["AS"]++;
                }
                else if (company.organisasjonsform == "FLI") {
                    statistics["FLI"]++;
                }

                if (company.antallAnsatte < 5) {
                    statistics["0-4 ANSATTE"]++;
                }
                else if (company.antallAnsatte < 10) {
                    statistics["5-9 ANSATTE"]++;
                }
                else {
                    statistics["<10 ANSATTE>"]++;
                }
            }
        }
        return statistics;
    }
}
