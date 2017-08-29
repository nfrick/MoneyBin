using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataClasses {
    public class Classificacao {
        private List<ClassificacaoItem> GCSs = null;

        public Classificacao() {
            GCSs = MoneyBinDB.GetClassificacao();
        }

        private AutoCompleteStringCollection CreateCollection(string[] array) {
            var source = new AutoCompleteStringCollection();
            source.AddRange(array);
            return source;
        }

        public AutoCompleteStringCollection Grupos() {
            var array = (from p in GCSs
                          select p.Grupo).ToArray();
            return CreateCollection(array);
        }

        public AutoCompleteStringCollection Categorias(BalanceItem bi) {
            var array = (from p in GCSs
                              where p.Grupo == bi.Grupo
                              select p.Categoria).ToArray();
            return CreateCollection(array);
        }


        public AutoCompleteStringCollection SubCategorias(BalanceItem bi) {
            var array = (from p in GCSs
                            where p.Grupo == bi.Grupo && p.Categoria == bi.Categoria
                            select p.SubCategoria).ToArray();
            return CreateCollection(array);
        }

        public AutoCompleteStringCollection Descricoes(BalanceItem bi) {
            var array = (from p in GCSs
                              where p.Grupo == bi.Grupo && 
                                    p.Categoria == bi.Categoria && 
                                    p.SubCategoria == bi.SubCategoria
                              select p.Descricao).ToArray();
            return CreateCollection(array);
        }
    }
}
