namespace c_sharp_shop_2 {
    public class Prodotto {

        // PROPRIETA / ATTRIBUTI
        protected string codice;
        protected string nome;
        protected string descrizione;
        protected double prezzoBase;
        protected double iva;
        protected double peso;
        protected UnitaProdotto unita;

        // ACCESSORS
        public string Codice { get => codice; init => codice = value; }
        public string Nome { get => nome; init => nome = value; }
        public string Descrizione { get => descrizione; init => descrizione = value; }
        public virtual UnitaProdotto Unita { get => unita; init => unita = value; }
        public double PrezzoBase {
            get => prezzoBase;
            set {
                if (value is < 0) {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} non può essere meno di zero");
                }
                prezzoBase = value;
            }
        }
        public virtual double Peso {
            get => peso;
            init {
                if (peso is < 0) {
                    throw new ArgumentException(nameof(peso));
                }
                peso = value;
            }
        }
        public double Iva {
            get => iva;
            set {
                if (value is < 0 or > 1) {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} deve essere tra 0 e 1");
                }
                iva = value;
            }
        }
        public string NomeEsteto => Codice + Nome;
        public double PrezzoConIva => PrezzoBase + (PrezzoBase * Iva);

        // COSTRUTTORI
#pragma warning disable CS8618
        public Prodotto(string nome, string descrizione, double prezzoBase, double iva) {
            Codice = new Random().Next(1, 100_000_000).ToString(); // Valori casuali da 1 a 99,999,999
            Nome = NullCheck(nome);
            Descrizione = NullCheck(descrizione);
            PrezzoBase = prezzoBase;
            Iva = iva;
        }
#pragma warning restore CS8618

        // METODI PUBBLICI
        public override string ToString() {
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

    public enum UnitaProdotto {
        KG,
        g,
        L,
        ml
    }
}
