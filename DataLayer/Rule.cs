//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rule
    {
        public int ID { get; set; }
        public string Banco { get; set; }
        public string Historico { get; set; }
        public int Comparacao { get; set; }
        public bool AfetaSaldo { get; set; }
        public string Grupo { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string Descricao { get; set; }
        public Nullable<int> Ocorrencias { get; set; }
        public bool AddToDatabase { get; set; }
    
        public virtual Bank Bank { get; set; }
    }
}
