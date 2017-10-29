namespace DataLayer {
    public enum Comparacoes {
        Equals,
        Contains,
        Begins,
        Ends,
        Cents
    }
    public partial class Rule {

        public short Centavos => ComparacaoAsEnum == Comparacoes.Cents ? short.Parse(Historico) : (short)0;
    
        public Comparacoes ComparacaoAsEnum => (Comparacoes)Comparacao;
    }
}
