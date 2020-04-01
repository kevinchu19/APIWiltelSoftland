using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSCobrosSoftland.Contexts
{
    public partial class WILTELContext : DbContext
    {
        public WILTELContext()
        {
        }

        public WILTELContext(DbContextOptions<WILTELContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entities.Vtrmvc> Vtrmvc { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Vtrmvc>(entity =>
            {
                entity.HasKey(e => new { e.VtrmvcCodemp, e.VtrmvcModfor, e.VtrmvcCodfor, e.VtrmvcNrofor, e.VtrmvcEmpapl, e.VtrmvcModapl, e.VtrmvcCodapl, e.VtrmvcNroapl, e.VtrmvcCuotas, e.VtrmvcClamov });

                entity.ToTable("VTRMVC");

                entity.HasIndex(e => new { e.VtrmvcModfcr, e.VtrmvcCodfcr, e.VtrmvcNrofcr })
                    .HasName("R_GR_FCRMVH");

                entity.HasIndex(e => new { e.VtrmvcModapl, e.VtrmvcCodapl, e.VtrmvcNroapl, e.VtrmvcCuotas })
                    .HasName("R_VT_USRREP");

                entity.HasIndex(e => new { e.VtrmvcNrocta, e.VtrmvcImptcn, e.VtrmvcCoflis, e.VtrmvcImpnac })
                    .HasName("W_GR_FCRMVH");

                entity.HasIndex(e => new { e.VtrmvcNrocta, e.VtrmvcModapl, e.VtrmvcCodapl, e.VtrmvcNroapl, e.VtrmvcCuotas })
                    .HasName("T_VT_VTRRCHWIZ");

                entity.HasIndex(e => new { e.VtrmvcNrocta, e.VtrmvcFchvnc, e.VtrmvcImpnac, e.VtrmvcModapl, e.VtrmvcCodapl, e.VtrmvcNroapl, e.VtrmvcCuotas })
                    .HasName("R_VT_GCRREP");

                entity.HasIndex(e => new { e.VtrmvcModfor, e.VtrmvcCodfor, e.VtrmvcNrofor, e.VtrmvcModapl, e.VtrmvcCodapl, e.VtrmvcNroapl, e.VtrmvcClamov, e.VtrmvcImpnac })
                    .HasName("W_EORMVHWIZ");

                entity.HasIndex(e => new { e.VtrmvcModapl, e.VtrmvcCodapl, e.VtrmvcNroapl, e.VtrmvcCuotas, e.VtrmvcCoflis, e.VtrmvcNrocta, e.VtrmvcNrosub, e.VtrmvcImptcn, e.VtrmvcFchvnc })
                    .HasName("W_VT_VTDBCR");

                entity.Property(e => e.VtrmvcCodemp)
                    .HasColumnName("VTRMVC_CODEMP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcModfor)
                    .HasColumnName("VTRMVC_MODFOR")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcCodfor)
                    .HasColumnName("VTRMVC_CODFOR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcNrofor).HasColumnName("VTRMVC_NROFOR");

                entity.Property(e => e.VtrmvcEmpapl)
                    .HasColumnName("VTRMVC_EMPAPL")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcModapl)
                    .HasColumnName("VTRMVC_MODAPL")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcCodapl)
                    .HasColumnName("VTRMVC_CODAPL")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcNroapl).HasColumnName("VTRMVC_NROAPL");

                entity.Property(e => e.VtrmvcCuotas).HasColumnName("VTRMVC_CUOTAS");

                entity.Property(e => e.VtrmvcClamov)
                    .HasColumnName("VTRMVC_CLAMOV")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvcEnviad)
                    .HasColumnName("USR_VTRMVC_ENVIAD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcCambio)
                    .HasColumnName("VTRMVC_CAMBIO")
                    .HasColumnType("numeric(20, 8)");

                entity.Property(e => e.VtrmvcCamuss)
                    .HasColumnName("VTRMVC_CAMUSS")
                    .HasColumnType("numeric(20, 8)");

                entity.Property(e => e.VtrmvcCmpver)
                    .HasColumnName("VTRMVC_CMPVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcCodbar)
                    .HasColumnName("VTRMVC_CODBAR")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcCodfcr)
                    .HasColumnName("VTRMVC_CODFCR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcCofdeu)
                    .HasColumnName("VTRMVC_COFDEU")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcCoffac)
                    .HasColumnName("VTRMVC_COFFAC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcCoflis)
                    .HasColumnName("VTRMVC_COFLIS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcDebaja)
                    .HasColumnName("VTRMVC_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcEmpfcr)
                    .HasColumnName("VTRMVC_EMPFCR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcFchint)
                    .HasColumnName("VTRMVC_FCHINT")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvcFchmov)
                    .HasColumnName("VTRMVC_FCHMOV")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvcFchvnc)
                    .HasColumnName("VTRMVC_FCHVNC")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvcFecalt)
                    .HasColumnName("VTRMVC_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvcFecmod)
                    .HasColumnName("VTRMVC_FECMOD")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvcHormov)
                    .HasColumnName("VTRMVC_HORMOV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcImpext)
                    .HasColumnName("VTRMVC_IMPEXT")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmvcImpnac)
                    .HasColumnName("VTRMVC_IMPNAC")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmvcImpsec)
                    .HasColumnName("VTRMVC_IMPSEC")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmvcImptcn)
                    .HasColumnName("VTRMVC_IMPTCN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcImpuss)
                    .HasColumnName("VTRMVC_IMPUSS")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmvcLotori)
                    .HasColumnName("VTRMVC_LOTORI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcLotrec)
                    .HasColumnName("VTRMVC_LOTREC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcLottra)
                    .HasColumnName("VTRMVC_LOTTRA")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcModfcr)
                    .HasColumnName("VTRMVC_MODFCR")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcModule)
                    .HasColumnName("VTRMVC_MODULE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcNrocta)
                    .HasColumnName("VTRMVC_NROCTA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcNrofcr).HasColumnName("VTRMVC_NROFCR");

                entity.Property(e => e.VtrmvcNrosub)
                    .HasColumnName("VTRMVC_NROSUB")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcOalias)
                    .HasColumnName("VTRMVC_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcObsimp)
                    .HasColumnName("VTRMVC_OBSIMP")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcSysver)
                    .HasColumnName("VTRMVC_SYSVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcTextos)
                    .HasColumnName("VTRMVC_TEXTOS")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmvcTstamp)
                    .HasColumnName("VTRMVC_TSTAMP")
                    .IsRowVersion();

                entity.Property(e => e.VtrmvcUltopr)
                    .HasColumnName("VTRMVC_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvcUserid)
                    .HasColumnName("VTRMVC_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });
        }
    }
}
