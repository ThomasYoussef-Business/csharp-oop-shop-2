namespace CSharpShop {
    public class Prodotto {

        // PROPRIETA / ATTRIBUTI
        public string Codice { get; init; }
        public string Nome { get; set; }
        public string NomeEsteto => Codice + Nome;
        public string Descrizione { get; set; }
        private double prezzoBase;
        public double PrezzoBase {
            get => prezzoBase;
            set {
                if (value is < 0) {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} non può essere meno di zero");
                }
                prezzoBase = value;
            }
        }
        private double iva;
        public double Iva {
            get => iva;
            set {
                if (value is < 0 or > 1) {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} deve essere tra 0 e 1");
                }
                iva = value;
            }
        }
        public double PrezzoConIva => PrezzoBase + (PrezzoBase * Iva);

        // COSTRUTTORI
        public Prodotto(string nome, string descrizione, double prezzoBase, double iva) {
            Codice = new Random().Next(1, 100_000_000).ToString(); // Valori casuali da 1 a 99,999,999
            Nome = NullCheck(nome);
            Descrizione = NullCheck(descrizione);
            PrezzoBase = prezzoBase;
            Iva = iva;
        }

        // METODI PUBBLICI
        public string FormattaProdotto() {
            return $@"{Nome} [{NomeEsteto}]:
Desc - {Descrizione}
EUR {PrezzoConIva}
IVA {Iva}";
        }

        // METODI PRIVATI
        private static string NullCheck(string nome) {
            return nome ?? throw new ArgumentNullException(nameof(nome), $"{nameof(nome)} non può essere nullo");
        }
    }
}
