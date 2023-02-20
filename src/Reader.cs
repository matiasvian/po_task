// Ignore warning
#pragma warning disable CS8602

class Reader {
    
    public static List<string[]> ReadCsv(string path) {
        List<string[]> lines = new List<string[]>();
        var file = File.ReadAllLines(path);
        for (int i = 0; i < file.Length; i++) {
            lines.Add(file[i].Split(';'));
        }
        return lines;
    }
}
