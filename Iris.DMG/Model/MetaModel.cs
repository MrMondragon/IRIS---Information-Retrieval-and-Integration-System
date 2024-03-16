namespace Iris.DMG.Model
{
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class MetaModel : DbContext
  {
    public MetaModel()
      : base("name=MetaModel")
    {
    }

    public virtual DbSet<mtd_con_Conceitos> mtd_con_Conceitos { get; set; }
    public virtual DbSet<mtd_con_Conceitos_Dominios> mtd_con_Conceitos_Dominios { get; set; }
    public virtual DbSet<mtd_con_Conceitos_x_Conjuntos> mtd_con_Conceitos_x_Conjuntos { get; set; }
    public virtual DbSet<mtd_con_ConjuntoConceito> mtd_con_ConjuntoConceito { get; set; }
    public virtual DbSet<mtd_con_GrupoConceito> mtd_con_GrupoConceito { get; set; }
    public virtual DbSet<mtd_con_SubgrupoConceito> mtd_con_SubgrupoConceito { get; set; }
    public virtual DbSet<mtd_conTipoConceito> mtd_conTipoConceito { get; set; }
    public virtual DbSet<mtd_dwh_Dimensoes> mtd_dwh_Dimensoes { get; set; }
    public virtual DbSet<mtd_dwh_Tabfatos> mtd_dwh_Tabfatos { get; set; }
    public virtual DbSet<mtd_dwhTipoDimensao> mtd_dwhTipoDimensao { get; set; }
    public virtual DbSet<mtd_dwhTipoDimensao_Campos> mtd_dwhTipoDimensao_Campos { get; set; }
    public virtual DbSet<mtd_dwhTipoTabfato> mtd_dwhTipoTabfato { get; set; }
    public virtual DbSet<mtd_dwhTipoTabfato_Campos> mtd_dwhTipoTabfato_Campos { get; set; }
    public virtual DbSet<mtd_fnt_Fontes> mtd_fnt_Fontes { get; set; }
    public virtual DbSet<mtd_fnt_Fontes_Campos> mtd_fnt_Fontes_Campos { get; set; }
    public virtual DbSet<mtd_fnt_Fontes_Valores_x_Dominios> mtd_fnt_Fontes_Valores_x_Dominios { get; set; }
    public virtual DbSet<mtd_fnt_Fontes_x_Conceitos> mtd_fnt_Fontes_x_Conceitos { get; set; }
    public virtual DbSet<mtd_fntTipoCampo> mtd_fntTipoCampo { get; set; }
    public virtual DbSet<mtd_fntTipoFonte> mtd_fntTipoFonte { get; set; }
    public virtual DbSet<mtd_sys_Parametros> mtd_sys_Parametros { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<mtd_con_Conceitos>()
          .Property(e => e.Conceito_Id)
          .IsFixedLength()
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_Conceitos>()
          .Property(e => e.Conceito)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_Conceitos>()
          .Property(e => e.Conceito_Descricao)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_Conceitos>()
          .Property(e => e.Conceito_Nome)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_Conceitos>()
          .Property(e => e.Conceito_Abreviacao)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_Conceitos>()
          .HasMany(e => e.mtd_con_Conceitos_Dominios)
          .WithRequired(e => e.mtd_con_Conceitos)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_con_Conceitos>()
          .HasMany(e => e.mtd_con_Conceitos_x_Conjuntos)
          .WithRequired(e => e.mtd_con_Conceitos)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_con_Conceitos>()
          .HasMany(e => e.mtd_fnt_Fontes_x_Conceitos)
          .WithRequired(e => e.mtd_con_Conceitos)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_con_Conceitos_Dominios>()
          .Property(e => e.Conceito_Id)
          .IsFixedLength()
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_Conceitos_Dominios>()
          .Property(e => e.Dominio_Rotulo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_Conceitos_Dominios>()
          .Property(e => e.Dominio_Abreviacao)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_Conceitos_Dominios>()
          .HasMany(e => e.mtd_fnt_Fontes_Valores_x_Dominios)
          .WithRequired(e => e.mtd_con_Conceitos_Dominios)
          .HasForeignKey(e => new { e.Conceito_Id, e.Dominio_Valor })
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_con_Conceitos_x_Conjuntos>()
          .Property(e => e.Conceito_Id)
          .IsFixedLength()
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_ConjuntoConceito>()
          .Property(e => e.Conceito_Conjunto)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_ConjuntoConceito>()
          .Property(e => e.Conceito_Prefixo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_ConjuntoConceito>()
          .HasMany(e => e.mtd_con_Conceitos_x_Conjuntos)
          .WithRequired(e => e.mtd_con_ConjuntoConceito)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_con_GrupoConceito>()
          .Property(e => e.Grupo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_con_GrupoConceito>()
          .HasMany(e => e.mtd_con_SubgrupoConceito)
          .WithRequired(e => e.mtd_con_GrupoConceito)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_con_SubgrupoConceito>()
          .Property(e => e.Subgrupo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_conTipoConceito>()
          .Property(e => e.Conceito_Tipo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_dwh_Dimensoes>()
          .Property(e => e.Dimensao)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_dwh_Dimensoes>()
          .Property(e => e.Dimensao_Id)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_dwh_Dimensoes>()
          .Property(e => e.Conceito_Id)
          .IsFixedLength()
          .IsUnicode(false);

      modelBuilder.Entity<mtd_dwh_Dimensoes>()
          .HasMany(e => e.mtd_dwh_Tabfatos)
          .WithMany(e => e.mtd_dwh_Dimensoes)
          .Map(m => m.ToTable("mtd_dwh_Tafatos_x_Dimensoes").MapLeftKey("Dimensao").MapRightKey("Tabfato"));

      modelBuilder.Entity<mtd_dwh_Tabfatos>()
          .Property(e => e.Tabfato)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_dwhTipoDimensao>()
          .Property(e => e.Dimensao_Tipo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_dwhTipoDimensao>()
          .HasMany(e => e.mtd_dwh_Dimensoes)
          .WithRequired(e => e.mtd_dwhTipoDimensao)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_dwhTipoDimensao>()
          .HasMany(e => e.mtd_dwhTipoDimensao_Campos)
          .WithRequired(e => e.mtd_dwhTipoDimensao)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_dwhTipoDimensao_Campos>()
          .Property(e => e.Campo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_dwhTipoDimensao_Campos>()
          .Property(e => e.Tipo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_dwhTipoTabfato>()
          .Property(e => e.Tabfato_Tipo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_dwhTipoTabfato>()
          .HasMany(e => e.mtd_dwh_Tabfatos)
          .WithRequired(e => e.mtd_dwhTipoTabfato)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_dwhTipoTabfato>()
          .HasMany(e => e.mtd_dwhTipoTabfato_Campos)
          .WithRequired(e => e.mtd_dwhTipoTabfato)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_dwhTipoTabfato_Campos>()
          .Property(e => e.Campo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_dwhTipoTabfato_Campos>()
          .Property(e => e.Tipo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_dwhTipoTabfato_Campos>()
          .Property(e => e.Valor_Default)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes>()
          .Property(e => e.Fonte)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes>()
          .Property(e => e.Fonte_Descricao)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes>()
          .Property(e => e.Fonte_Origem)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes>()
          .Property(e => e.Fonte_Grupo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes>()
          .HasMany(e => e.mtd_fnt_Fontes_Campos)
          .WithRequired(e => e.mtd_fnt_Fontes)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_fnt_Fontes_Campos>()
          .Property(e => e.Campo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes_Campos>()
          .Property(e => e.Fonte_Id_Origem)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes_Campos>()
          .HasMany(e => e.mtd_fnt_Fontes_Valores_x_Dominios)
          .WithRequired(e => e.mtd_fnt_Fontes_Campos)
          .HasForeignKey(e => new { e.Fonte_Id, e.Campo })
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_fnt_Fontes_Campos>()
          .HasMany(e => e.mtd_fnt_Fontes_x_Conceitos)
          .WithRequired(e => e.mtd_fnt_Fontes_Campos)
          .HasForeignKey(e => new { e.Fonte_Id, e.Campo })
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<mtd_fnt_Fontes_Valores_x_Dominios>()
          .Property(e => e.Campo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes_Valores_x_Dominios>()
          .Property(e => e.Fonte_Valor)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes_Valores_x_Dominios>()
          .Property(e => e.Conceito_Id)
          .IsFixedLength()
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes_x_Conceitos>()
          .Property(e => e.Conceito_Id)
          .IsFixedLength()
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes_x_Conceitos>()
          .Property(e => e.Campo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes_x_Conceitos>()
          .Property(e => e.xCampo1)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fnt_Fontes_x_Conceitos>()
          .Property(e => e.xCampo2)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fntTipoCampo>()
          .Property(e => e.Campo_Tipo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fntTipoCampo>()
          .Property(e => e.Campo_Descricao)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_fntTipoFonte>()
          .Property(e => e.Fonte_Tipo)
          .IsUnicode(false);

      modelBuilder.Entity<mtd_sys_Parametros>()
          .Property(e => e.QVS_Path)
          .IsUnicode(false);
    }
  }
}
