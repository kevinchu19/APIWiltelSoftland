using System;
using System.Threading;
using System.Threading.Tasks;
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

        public virtual DbSet<SarVtrrcc01> SarVtrrcc01 { get; set; }
        public virtual DbSet<SarVtrrcc04> SarVtrrcc04 { get; set; }
        public virtual DbSet<SarVtrrcc05> SarVtrrcc05 { get; set; }
        public virtual DbSet<SarVtrrch> SarVtrrch { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SarVtrrcc01>(entity =>
            {
                entity.HasKey(e => new { e.SarVtrrcc01Identi, e.SarVtrrcc01Nroitm });

                entity.ToTable("SAR_VTRRCC01");

                entity.Property(e => e.SarVtrrcc01Identi)
                    .HasColumnName("SAR_VTRRCC01_IDENTI")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc01Nroitm).HasColumnName("SAR_VTRRCC01_NROITM");

                entity.Property(e => e.SarVtCmpver)
                    .HasColumnName("SAR_VT_CMPVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtDebaja)
                    .HasColumnName("SAR_VT_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtFecalt)
                    .HasColumnName("SAR_VT_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.SarVtFecmod)
                    .HasColumnName("SAR_VT_FECMOD")
                    .HasColumnType("datetime");

                entity.Property(e => e.SarVtHormov)
                    .HasColumnName("SAR_VT_HORMOV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLotori)
                    .HasColumnName("SAR_VT_LOTORI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLotrec)
                    .HasColumnName("SAR_VT_LOTREC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLottra)
                    .HasColumnName("SAR_VT_LOTTRA")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtModule)
                    .HasColumnName("SAR_VT_MODULE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtOalias)
                    .HasColumnName("SAR_VT_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtSysver)
                    .HasColumnName("SAR_VT_SYSVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtTstamp)
                    .HasColumnName("SAR_VT_TSTAMP")
                    .IsRowVersion();

                entity.Property(e => e.SarVtUltopr)
                    .HasColumnName("SAR_VT_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtUserid)
                    .HasColumnName("SAR_VT_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc01Cannac)
                    .HasColumnName("SAR_VTRRCC01_CANNAC")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.SarVtrrcc01Codapl)
                    .HasColumnName("SAR_VTRRCC01_CODAPL")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc01Cuotas).HasColumnName("SAR_VTRRCC01_CUOTAS");

                entity.Property(e => e.SarVtrrcc01Impext)
                    .HasColumnName("SAR_VTRRCC01_IMPEXT")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.SarVtrrcc01Impnac)
                    .HasColumnName("SAR_VTRRCC01_IMPNAC")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.SarVtrrcc01Modapl)
                    .HasColumnName("SAR_VTRRCC01_MODAPL")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc01Nroapl).HasColumnName("SAR_VTRRCC01_NROAPL");

                entity.Property(e => e.SarVtrrcc01Canext)
                    .HasColumnName("SAR_VTRRCC01_CANEXT");

            });

            modelBuilder.Entity<SarVtrrcc04>(entity =>
            {
                entity.HasKey(e => new { e.SarVtrrcc04Identi, e.SarVtrrcc04Nroitm });

                entity.ToTable("SAR_VTRRCC04");

                entity.Property(e => e.SarVtrrcc04Identi)
                    .HasColumnName("SAR_VTRRCC04_IDENTI")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Nroitm).HasColumnName("SAR_VTRRCC04_NROITM");

                entity.Property(e => e.SarVtCmpver)
                    .HasColumnName("SAR_VT_CMPVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtDebaja)
                    .HasColumnName("SAR_VT_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtFecalt)
                    .HasColumnName("SAR_VT_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.SarVtFecmod)
                    .HasColumnName("SAR_VT_FECMOD")
                    .HasColumnType("datetime");

                entity.Property(e => e.SarVtHormov)
                    .HasColumnName("SAR_VT_HORMOV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLotori)
                    .HasColumnName("SAR_VT_LOTORI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLotrec)
                    .HasColumnName("SAR_VT_LOTREC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLottra)
                    .HasColumnName("SAR_VT_LOTTRA")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtModule)
                    .HasColumnName("SAR_VT_MODULE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtOalias)
                    .HasColumnName("SAR_VT_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtSysver)
                    .HasColumnName("SAR_VT_SYSVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtTstamp)
                    .HasColumnName("SAR_VT_TSTAMP")
                    .IsRowVersion();

                entity.Property(e => e.SarVtUltopr)
                    .HasColumnName("SAR_VT_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtUserid)
                    .HasColumnName("SAR_VT_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Cheque).HasColumnName("SAR_VTRRCC04_CHEQUE");

                entity.Property(e => e.SarVtrrcc04Codcpt)
                    .HasColumnName("SAR_VTRRCC04_CODCPT")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Fchaux)
                    .HasColumnName("SAR_VTRRCC04_FCHAUX")
                    .HasColumnType("datetime");

                entity.Property(e => e.SarVtrrcc04Import)
                    .HasColumnName("SAR_VTRRCC04_IMPORT")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.SarVtrrcc04Impuss)
                    .HasColumnName("SAR_VTRRCC04_IMPUSS")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.SarVtrrcc04Modcpt)
                    .HasColumnName("SAR_VTRRCC04_MODCPT")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Nroint).HasColumnName("SAR_VTRRCC04_NROINT");

                entity.Property(e => e.SarVtrrcc04Tipcpt)
                    .HasColumnName("SAR_VTRRCC04_TIPCPT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrrcc04Codori)
                    .HasColumnName("USR_VTRRCC04_CODORI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Codbco)
                    .HasColumnName("SAR_VTRRCC04_CODBCO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Chesuc)
                    .HasColumnName("SAR_VTRRCC04_CHESUC");

                entity.Property(e => e.SarVtrrcc04Catego)
                    .HasColumnName("SAR_VTRRCC04_CATEGO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Docfir)
                    .HasColumnName("SAR_VTRRCC04_DOCFIR")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Tipdoc)
                    .HasColumnName("SAR_VTRRCC04_TIPDOC")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Nrodoc)
                    .HasColumnName("SAR_VTRRCC04_NRODOC")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SarVtrrcc05>(entity =>
            {
                entity.HasKey(e => new { e.SarVtrrcc05Identi, e.SarVtrrcc05Nroitm });

                entity.ToTable("SAR_VTRRCC05");

                entity.Property(e => e.SarVtrrcc05Identi)
                    .HasColumnName("SAR_VTRRCC05_IDENTI")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc05Nroitm).HasColumnName("SAR_VTRRCC05_NROITM");

                entity.Property(e => e.SarVtCmpver)
                    .HasColumnName("SAR_VT_CMPVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtDebaja)
                    .HasColumnName("SAR_VT_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtFecalt)
                    .HasColumnName("SAR_VT_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.SarVtFecmod)
                    .HasColumnName("SAR_VT_FECMOD")
                    .HasColumnType("datetime");

                entity.Property(e => e.SarVtHormov)
                    .HasColumnName("SAR_VT_HORMOV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLotori)
                    .HasColumnName("SAR_VT_LOTORI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLotrec)
                    .HasColumnName("SAR_VT_LOTREC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLottra)
                    .HasColumnName("SAR_VT_LOTTRA")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtModule)
                    .HasColumnName("SAR_VT_MODULE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtOalias)
                    .HasColumnName("SAR_VT_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtSysver)
                    .HasColumnName("SAR_VT_SYSVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtTstamp)
                    .HasColumnName("SAR_VT_TSTAMP")
                    .IsRowVersion();

                entity.Property(e => e.SarVtUltopr)
                    .HasColumnName("SAR_VT_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtUserid)
                    .HasColumnName("SAR_VT_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc05Codcpt)
                    .HasColumnName("SAR_VTRRCC05_CODCPT")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc05Import)
                    .HasColumnName("SAR_VTRRCC05_IMPORT")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.SarVtrrcc05Impuss)
                    .HasColumnName("SAR_VTRRCC05_IMPUSS")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.SarVtrrcc05Modcpt)
                    .HasColumnName("SAR_VTRRCC05_MODCPT")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc05Tipcpt)
                    .HasColumnName("SAR_VTRRCC05_TIPCPT")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SarVtrrch>(entity =>
            {
                entity.HasKey(e => e.SarVtrrchIdenti);

                entity.ToTable("SAR_VTRRCH");

                entity.Property(e => e.SarVtrrchIdenti)
                    .HasColumnName("SAR_VTRRCH_IDENTI")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SarVtCmpver)
                    .HasColumnName("SAR_VT_CMPVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtDebaja)
                    .HasColumnName("SAR_VT_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrchFchmov)
                    .HasColumnName("SAR_VTRRCH_FCHMOV")
                    .HasColumnType("datetime");

                entity.Property(e => e.SarVtFecalt)
                    .HasColumnName("SAR_VT_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.SarVtFecmod)
                    .HasColumnName("SAR_VT_FECMOD")
                    .HasColumnType("datetime");

                entity.Property(e => e.SarVtHormov)
                    .HasColumnName("SAR_VT_HORMOV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLotori)
                    .HasColumnName("SAR_VT_LOTORI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLotrec)
                    .HasColumnName("SAR_VT_LOTREC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtLottra)
                    .HasColumnName("SAR_VT_LOTTRA")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtModule)
                    .HasColumnName("SAR_VT_MODULE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtOalias)
                    .HasColumnName("SAR_VT_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtSysver)
                    .HasColumnName("SAR_VT_SYSVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                //entity.Property(e => e.SarVtTstamp)
                //    .HasColumnName("SAR_VT_TSTAMP")
                //    .IsRowVersion();

                entity.Property(e => e.SarVtUltopr)
                    .HasColumnName("SAR_VT_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtUserid)
                    .HasColumnName("SAR_VT_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrchCobrad)
                    .HasColumnName("SAR_VTRRCH_COBRAD")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrchCodcom)
                    .HasColumnName("SAR_VTRRCH_CODCOM")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrchCodemp)
                    .HasColumnName("SAR_VTRRCH_CODEMP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrchCodfor)
                    .HasColumnName("SAR_VTRRCH_CODFOR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrchCodori).HasColumnName("SAR_VTRRCH_CODORI");

                entity.Property(e => e.SarVtrrchErrmsg)
                    .HasColumnName("SAR_VTRRCH_ERRMSG")
                    .HasColumnType("text");

                entity.Property(e => e.SarVtrrchModfor)
                    .HasColumnName("SAR_VTRRCH_MODFOR")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrchNrocta)
                    .HasColumnName("SAR_VTRRCH_NROCTA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrchNrofor).HasColumnName("SAR_VTRRCH_NROFOR");

                entity.Property(e => e.SarVtrrchStatus)
                    .HasColumnName("SAR_VTRRCH_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrrchArch)
                    .HasColumnName("USR_VTRRCH_ARCH")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrrchWsestad).HasColumnName("USR_VTRRCH_WSESTAD");
            });
        }
          
    }
}
