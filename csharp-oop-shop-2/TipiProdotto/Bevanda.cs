namespace c_sharp_shop_2 {
    public class Bevanda : Prodotto {

        // PROPRIETA / ATTRIBUTI
        public readonly double massimoLitri = 1.5;
        public double Litri {
            get => peso;
            set => peso = Math.Clamp(value, 0.0, this.massimoLitri);
        }

        private new readonly UnitaProdotto unita = UnitaProdotto.L;
        public override UnitaProdotto Unita {
            get => unita;
        }

        // COSTRUTTORI
        public Bevanda(string nome, string descrizione, double prezzoBase, double iva, double litri) : base(nome, descrizione, prezzoBase, iva) {
            this.Litri = litri;
        }

        // METODI PUBBLICI
        public override string ToString() {
            return base.ToString() + $@"Litri Massimi: {massimoLitri}{Unita}";
        }

        // METODI PRIVATI

    }
}
