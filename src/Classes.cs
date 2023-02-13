public class Organisasjonsform {
    public string? kode { get; set; }
    public string? beskrivelse { get; set; }
}
public class Naeringskode {
    public string? kode { get; set; }
    public string? beskrivelse { get; set; }
}

public class Company {

    public string organisasjonsnummer { get; set; }
    public string navn { get; set; }
    public Naeringskode naeringskode1 { get; set; }
    public Organisasjonsform organisasjonsform { get; set; }
    public int antallAnsatte { get; set; }
    public string? po_navn { get; set; }
    public string? slettedato { get; set; }
    public Company(string organisasjonsnummer, int antallAnsatte, Organisasjonsform organisasjonsform, Naeringskode naeringskode1, string navn, string slettedato) {
        this.organisasjonsnummer = organisasjonsnummer;
        this.antallAnsatte = antallAnsatte;
        this.naeringskode1 = naeringskode1;
        this.organisasjonsform = organisasjonsform;
        this.navn = navn;
        this.slettedato = slettedato;
    }
}

class Company2 {
    public string? organisasjonsnummer { get; set; }
    public string? navn { get; set; }
    public string? naeringskode1 { get; set; }
    public string? organisasjonsform { get; set; }
    public int antallAnsatte { get; set; }
    public string? po_navn { get; set; }
}
