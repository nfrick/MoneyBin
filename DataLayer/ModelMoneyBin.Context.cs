﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MoneyBinEntities : DbContext
    {
        public MoneyBinEntities()
            : base("name=MoneyBinEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CalendarItem> Calendar { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<BalanceItemComSaldo> BalanceComSaldo { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<DataMaxMin> DataMaxsMins { get; set; }
    
        public virtual int sp_BalanceItemDelete(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_BalanceItemDelete", iDParameter);
        }
    
        public virtual int sp_BalanceItemInsert(string banco, Nullable<System.DateTime> data, string historico, string documento, Nullable<decimal> valor, Nullable<bool> afetaSaldo, string grupo, string categoria, string subCategoria, string descricao, string novoGrupo, string novaCategoria, string novaSubCategoria)
        {
            var bancoParameter = banco != null ?
                new ObjectParameter("Banco", banco) :
                new ObjectParameter("Banco", typeof(string));
    
            var dataParameter = data.HasValue ?
                new ObjectParameter("Data", data) :
                new ObjectParameter("Data", typeof(System.DateTime));
    
            var historicoParameter = historico != null ?
                new ObjectParameter("Historico", historico) :
                new ObjectParameter("Historico", typeof(string));
    
            var documentoParameter = documento != null ?
                new ObjectParameter("Documento", documento) :
                new ObjectParameter("Documento", typeof(string));
    
            var valorParameter = valor.HasValue ?
                new ObjectParameter("Valor", valor) :
                new ObjectParameter("Valor", typeof(decimal));
    
            var afetaSaldoParameter = afetaSaldo.HasValue ?
                new ObjectParameter("AfetaSaldo", afetaSaldo) :
                new ObjectParameter("AfetaSaldo", typeof(bool));
    
            var grupoParameter = grupo != null ?
                new ObjectParameter("Grupo", grupo) :
                new ObjectParameter("Grupo", typeof(string));
    
            var categoriaParameter = categoria != null ?
                new ObjectParameter("Categoria", categoria) :
                new ObjectParameter("Categoria", typeof(string));
    
            var subCategoriaParameter = subCategoria != null ?
                new ObjectParameter("SubCategoria", subCategoria) :
                new ObjectParameter("SubCategoria", typeof(string));
    
            var descricaoParameter = descricao != null ?
                new ObjectParameter("Descricao", descricao) :
                new ObjectParameter("Descricao", typeof(string));
    
            var novoGrupoParameter = novoGrupo != null ?
                new ObjectParameter("NovoGrupo", novoGrupo) :
                new ObjectParameter("NovoGrupo", typeof(string));
    
            var novaCategoriaParameter = novaCategoria != null ?
                new ObjectParameter("NovaCategoria", novaCategoria) :
                new ObjectParameter("NovaCategoria", typeof(string));
    
            var novaSubCategoriaParameter = novaSubCategoria != null ?
                new ObjectParameter("NovaSubCategoria", novaSubCategoria) :
                new ObjectParameter("NovaSubCategoria", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_BalanceItemInsert", bancoParameter, dataParameter, historicoParameter, documentoParameter, valorParameter, afetaSaldoParameter, grupoParameter, categoriaParameter, subCategoriaParameter, descricaoParameter, novoGrupoParameter, novaCategoriaParameter, novaSubCategoriaParameter);
        }
    
        public virtual int sp_BalanceItemUpdate(Nullable<int> iD, Nullable<bool> afetaSaldo, string grupo, string categoria, string subCategoria, string descricao, string novoGrupo, string novaCategoria, string novaSubCategoria)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var afetaSaldoParameter = afetaSaldo.HasValue ?
                new ObjectParameter("AfetaSaldo", afetaSaldo) :
                new ObjectParameter("AfetaSaldo", typeof(bool));
    
            var grupoParameter = grupo != null ?
                new ObjectParameter("Grupo", grupo) :
                new ObjectParameter("Grupo", typeof(string));
    
            var categoriaParameter = categoria != null ?
                new ObjectParameter("Categoria", categoria) :
                new ObjectParameter("Categoria", typeof(string));
    
            var subCategoriaParameter = subCategoria != null ?
                new ObjectParameter("SubCategoria", subCategoria) :
                new ObjectParameter("SubCategoria", typeof(string));
    
            var descricaoParameter = descricao != null ?
                new ObjectParameter("Descricao", descricao) :
                new ObjectParameter("Descricao", typeof(string));
    
            var novoGrupoParameter = novoGrupo != null ?
                new ObjectParameter("NovoGrupo", novoGrupo) :
                new ObjectParameter("NovoGrupo", typeof(string));
    
            var novaCategoriaParameter = novaCategoria != null ?
                new ObjectParameter("NovaCategoria", novaCategoria) :
                new ObjectParameter("NovaCategoria", typeof(string));
    
            var novaSubCategoriaParameter = novaSubCategoria != null ?
                new ObjectParameter("NovaSubCategoria", novaSubCategoria) :
                new ObjectParameter("NovaSubCategoria", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_BalanceItemUpdate", iDParameter, afetaSaldoParameter, grupoParameter, categoriaParameter, subCategoriaParameter, descricaoParameter, novoGrupoParameter, novaCategoriaParameter, novaSubCategoriaParameter);
        }
    
        public virtual ObjectResult<BalanceItemComSaldo> AcertosPendentes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BalanceItemComSaldo>("AcertosPendentes");
        }
    
        public virtual ObjectResult<BalanceItemComSaldo> AcertosPendentes(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BalanceItemComSaldo>("AcertosPendentes", mergeOption);
        }
    }
}
