// Ignore warning
#pragma warning disable CS8602

class Reader {
    
    public static List<string[]> ReadCsv(string path) {
        List<string[]> lines = new List<string[]>();
        using (StreamReader reader = new StreamReader(path)) {
            while (!reader.EndOfStream) {
                if (reader.ReadLine() != null) {                            // Lines on format OrgNr;Name
                    lines.Add(reader.ReadLine().Split(';'));
                }
            }
        }
        return lines;
    }
}
