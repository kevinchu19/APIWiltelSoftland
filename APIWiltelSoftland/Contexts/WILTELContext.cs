using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using APIWiltelSoftland.Entities;

namespace APIWiltelSoftland.Contexts
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
        public virtual DbSet<UsrWstush> UsrWstush { get; set; }
        public virtual DbSet<Cvmcth> Cvmcth { get; set; }
        public virtual DbSet<Cvmcti> Cvmcti { get; set; }
        public virtual DbSet<Vtrmvh> Vtrmvh { get; set; }
        public virtual DbSet<Vtrmvi> Vtrmvi { get; set; }

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

                entity.Property(e => e.SarVtrrcc01Canext)
                    .HasColumnName("SAR_VTRRCC01_CANEXT")
                    .HasColumnType("numeric(18, 2)");

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

                entity.Property(e => e.SarVtrrcc04Catego)
                    .HasColumnName("SAR_VTRRCC04_CATEGO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Cheque).HasColumnName("SAR_VTRRCC04_CHEQUE");

                entity.Property(e => e.SarVtrrcc04Chesuc).HasColumnName("SAR_VTRRCC04_CHESUC");

                entity.Property(e => e.SarVtrrcc04Codbco)
                    .HasColumnName("SAR_VTRRCC04_CODBCO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Codcpt)
                    .HasColumnName("SAR_VTRRCC04_CODCPT")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Docfir)
                    .HasColumnName("SAR_VTRRCC04_DOCFIR")
                    .HasMaxLength(120)
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

                entity.Property(e => e.SarVtrrcc04Nrodoc)
                    .HasColumnName("SAR_VTRRCC04_NRODOC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Nroint).HasColumnName("SAR_VTRRCC04_NROINT");

                entity.Property(e => e.SarVtrrcc04Tipcpt)
                    .HasColumnName("SAR_VTRRCC04_TIPCPT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrcc04Tipdoc)
                    .HasColumnName("SAR_VTRRCC04_TIPDOC")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrrcc04Codori)
                    .HasColumnName("USR_VTRRCC04_CODORI")
                    .HasMaxLength(20)
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

                entity.Property(e => e.SarVtrrchCodjob)
                    .HasColumnName("SAR_VTRRCH_CODJOB")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrchCodori)
                    .HasColumnName("SAR_VTRRCH_CODORI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrchEjeaut)
                    .HasColumnName("SAR_VTRRCH_EJEAUT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SarVtrrchErrmsg)
                    .HasColumnName("SAR_VTRRCH_ERRMSG")
                    .HasColumnType("text");

                entity.Property(e => e.SarVtrrchFchmov)
                    .HasColumnName("SAR_VTRRCH_FCHMOV")
                    .HasColumnType("datetime");

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

                entity.Property(e => e.UsrVtrrchCodboc)
                    .HasColumnName("USR_VTRRCH_CODBOC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrrchCodter)
                    .HasColumnName("USR_VTRRCH_CODTER")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrrchCodent).HasColumnName("USR_VTRRCH_CODENT");
            });

            modelBuilder.Entity<UsrWstush>(entity =>
            {
                entity.HasKey(e => new {e.UsrWstushUserid });

                entity.ToTable("USR_WSTUSH");
                
                entity.Property(e => e.UsrWstushUserid)
                    .HasColumnName("USR_WSTUSH_USERID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.UsrWsCmpver)
                    .HasColumnName("USR_WS_CMPVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UsrWsDebaja)
                    .HasColumnName("USR_WS_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrWsFecalt)
                    .HasColumnName("USR_WS_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsrWsFecmod)
                    .HasColumnName("USR_WS_FECMOD")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsrWsHormov)
                    .HasColumnName("USR_WS_HORMOV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UsrWsLotori)
                    .HasColumnName("USR_WS_LOTORI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrWsLotrec)
                    .HasColumnName("USR_WS_LOTREC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrWsLottra)
                    .HasColumnName("USR_WS_LOTTRA")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrWsModule)
                    .HasColumnName("USR_WS_MODULE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UsrWsOalias)
                    .HasColumnName("USR_WS_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UsrWsSysver)
                    .HasColumnName("USR_WS_SYSVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                //entity.Property(e => e.UsrWsTstamp)
                //    .HasColumnName("USR_WS_TSTAMP")
                //    .IsRowVersion();

                entity.Property(e => e.UsrWsUltopr)
                    .HasColumnName("USR_WS_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrWsUserid)
                    .HasColumnName("USR_WS_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UsrWstushUsrpwd)
                    .IsRequired()
                    .HasColumnName("USR_WSTUSH_USRPWD")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cvmcth>(entity =>
            {
                entity.HasKey(e => new { e.CvmcthCodemp, e.CvmcthCodcon, e.CvmcthNrocon, e.CvmcthNroext });

                entity.ToTable("CVMCTH");

                entity.HasIndex(e => e.CvmcthNroext)
                    .HasName("W_CV_VTRMVH");

                entity.HasIndex(e => new { e.CvmcthNroext, e.CvmcthDescrp })
                    .HasName("CVMCTH_SuperFind");

                entity.Property(e => e.CvmcthCodemp)
                    .HasColumnName("CVMCTH_CODEMP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCodcon)
                    .HasColumnName("CVMCTH_CODCON")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthNrocon)
                    .HasColumnName("CVMCTH_NROCON")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthNroext).HasColumnName("CVMCTH_NROEXT");

                entity.Property(e => e.CvmcthActcof)
                    .HasColumnName("CVMCTH_ACTCOF")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthActlis)
                    .HasColumnName("CVMCTH_ACTLIS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthModifi)
                    .HasColumnName("USR_CVMCTH_MODIFI")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            

                entity.Property(e => e.CvmcthAuxaju)
                    .HasColumnName("CVMCTH_AUXAJU")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthAuxfba)
                    .HasColumnName("CVMCTH_AUXFBA")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthAuxrte)
                    .HasColumnName("CVMCTH_AUXRTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthCerdec)
                    .HasColumnName("CVMCTH_CERDEC")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCndcom)
                    .HasColumnName("CVMCTH_CNDCOM")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCndpag)
                    .HasColumnName("CVMCTH_CNDPAG")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCodcst)
                    .HasColumnName("CVMCTH_CODCST")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCodctr)
                    .HasColumnName("CVMCTH_CODCTR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCodcvt)
                    .HasColumnName("CVMCTH_CODCVT")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCodlis)
                    .IsRequired()
                    .HasColumnName("CVMCTH_CODLIS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCodopr)
                    .HasColumnName("CVMCTH_CODOPR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCoef01)
                    .HasColumnName("CVMCTH_COEF01")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCoef02)
                    .HasColumnName("CVMCTH_COEF02")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCoef03)
                    .HasColumnName("CVMCTH_COEF03")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCoef04)
                    .HasColumnName("CVMCTH_COEF04")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCoef05)
                    .HasColumnName("CVMCTH_COEF05")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCoefic)
                    .HasColumnName("CVMCTH_COEFIC")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.CvmcthCofdev)
                    .HasColumnName("CVMCTH_COFDEV")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCoffac)
                    .HasColumnName("CVMCTH_COFFAC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthCoflis)
                    .HasColumnName("CVMCTH_COFLIS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthDebaja)
                    .HasColumnName("CVMCTH_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthDeposi)
                    .HasColumnName("CVMCTH_DEPOSI")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthDescrp)
                    .HasColumnName("CVMCTH_DESCRP")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthDimobl)
                    .HasColumnName("CVMCTH_DIMOBL")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthDimori)
                    .HasColumnName("CVMCTH_DIMORI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthEstact)
                    .HasColumnName("CVMCTH_ESTACT")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthEstcon)
                    .HasColumnName("CVMCTH_ESTCON")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthFacdes)
                    .HasColumnName("CVMCTH_FACDES")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFachas)
                    .HasColumnName("CVMCTH_FACHAS")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsrCvmcthFcfinot)
                    .HasColumnName("USR_CVMCTH_FCFINOT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFchaju)
                    .HasColumnName("CVMCTH_FCHAJU")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFchbas)
                    .HasColumnName("CVMCTH_FCHBAS")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFchinb)
                    .HasColumnName("CVMCTH_FCHINB")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFchmov)
                    .HasColumnName("CVMCTH_FCHMOV")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFchpeb)
                    .HasColumnName("CVMCTH_FCHPEB")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFchper)
                    .HasColumnName("CVMCTH_FCHPER")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFchrte)
                    .HasColumnName("CVMCTH_FCHRTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFchteb)
                    .HasColumnName("CVMCTH_FCHTEB")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFchter)
                    .HasColumnName("CVMCTH_FCHTER")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFchula)
                    .HasColumnName("CVMCTH_FCHULA")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFecalt)
                    .HasColumnName("CVMCTH_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFeclis)
                    .HasColumnName("CVMCTH_FECLIS")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFecmod)
                    .HasColumnName("CVMCTH_FECMOD")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthFreact).HasColumnName("CVMCTH_FREACT");

                entity.Property(e => e.CvmcthFrefac).HasColumnName("CVMCTH_FREFAC");

                entity.Property(e => e.CvmcthGrubon)
                    .HasColumnName("CVMCTH_GRUBON")
                    .HasMaxLength(6)
                    .IsUnicode(false);


                entity.Property(e => e.CvmcthModcst)
                    .HasColumnName("CVMCTH_MODCST")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthModcvt)
                    .HasColumnName("CVMCTH_MODCVT")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthNrocta)
                    .HasColumnName("CVMCTH_NROCTA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthNrosub)
                    .HasColumnName("CVMCTH_NROSUB")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthOalias)
                    .HasColumnName("CVMCTH_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthObshis)
                    .HasColumnName("CVMCTH_OBSHIS")
                    .HasColumnType("text");

                entity.Property(e => e.CvmcthOleole)
                    .HasColumnName("CVMCTH_OLEOLE")
                    .HasColumnType("text");

                entity.Property(e => e.CvmcthPctc01)
                    .HasColumnName("CVMCTH_PCTC01")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.CvmcthPctc02)
                    .HasColumnName("CVMCTH_PCTC02")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.CvmcthPctc03)
                    .HasColumnName("CVMCTH_PCTC03")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.CvmcthPctc04)
                    .HasColumnName("CVMCTH_PCTC04")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.CvmcthPctc05)
                    .HasColumnName("CVMCTH_PCTC05")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.CvmcthPercan)
                    .HasColumnName("CVMCTH_PERCAN")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthPriact)
                    .HasColumnName("CVMCTH_PRIACT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthPriaju)
                    .HasColumnName("CVMCTH_PRIAJU")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthPrifac)
                    .HasColumnName("CVMCTH_PRIFAC")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthRecnov)
                    .HasColumnName("CVMCTH_RECNOV")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthRubr01)
                    .HasColumnName("CVMCTH_RUBR01")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthRubr02)
                    .HasColumnName("CVMCTH_RUBR02")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthRubr03)
                    .HasColumnName("CVMCTH_RUBR03")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthRubr04)
                    .HasColumnName("CVMCTH_RUBR04")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthRubr05)
                    .HasColumnName("CVMCTH_RUBR05")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthRubr06)
                    .HasColumnName("CVMCTH_RUBR06")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthRubr07)
                    .HasColumnName("CVMCTH_RUBR07")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthRubr08)
                    .HasColumnName("CVMCTH_RUBR08")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthRubr09)
                    .HasColumnName("CVMCTH_RUBR09")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthRubr10)
                    .HasColumnName("CVMCTH_RUBR10")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthSector)
                    .HasColumnName("CVMCTH_SECTOR")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthSubcue)
                    .HasColumnName("CVMCTH_SUBCUE")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthSubori)
                    .HasColumnName("CVMCTH_SUBORI")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthTextos)
                    .HasColumnName("CVMCTH_TEXTOS")
                    .HasColumnType("text");

                entity.Property(e => e.CvmcthTipexp)
                    .HasColumnName("CVMCTH_TIPEXP")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthTipopr)
                    .HasColumnName("CVMCTH_TIPOPR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthUfaaux)
                    .HasColumnName("CVMCTH_UFAAUX")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthUltaju)
                    .HasColumnName("CVMCTH_ULTAJU")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthUltbas)
                    .HasColumnName("CVMCTH_ULTBAS")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthUltfac)
                    .HasColumnName("CVMCTH_ULTFAC")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthUltfba)
                    .HasColumnName("CVMCTH_ULTFBA")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmcthUltopr)
                    .HasColumnName("CVMCTH_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthUnific)
                    .HasColumnName("CVMCTH_UNIFIC")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthUserid)
                    .HasColumnName("CVMCTH_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthVnddor)
                    .HasColumnName("CVMCTH_VNDDOR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmcthVtcero)
                    .HasColumnName("CVMCTH_VTCERO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthCodenl).HasColumnName("USR_CVMCTH_CODENL");

                entity.Property(e => e.UsrCvmcthCodext)
                    .HasColumnName("USR_CVMCTH_CODEXT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthCodpai)
                    .HasColumnName("USR_CVMCTH_CODPAI")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthCodpos)
                    .HasColumnName("USR_CVMCTH_CODPOS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthCodpro)
                    .HasColumnName("USR_CVMCTH_CODPRO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthCodtec)
                    .HasColumnName("USR_CVMCTH_CODTEC")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthDeptos)
                    .HasColumnName("USR_CVMCTH_DEPTOS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthDirecc)
                    .HasColumnName("USR_CVMCTH_DIRECC")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthDppiso)
                    .HasColumnName("USR_CVMCTH_DPPISO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthMascar)
                    .HasColumnName("USR_CVMCTH_MASCAR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthNcarte).HasColumnName("USR_CVMCTH_NCARTE");

                entity.Property(e => e.UsrCvmcthNombre)
                    .HasColumnName("USR_CVMCTH_NOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthNrotar)
                    .HasColumnName("USR_CVMCTH_NROTAR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthNumero)
                    .HasColumnName("USR_CVMCTH_NUMERO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmcthUnific)
                    .HasColumnName("USR_CVMCTH_UNIFIC")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cvmcti>(entity =>
            {
                entity.HasKey(e => new { e.CvmctiCodemp, e.CvmctiCodcon, e.CvmctiNrocon, e.CvmctiNroext, e.CvmctiNroitm, e.CvmctiDebhab });

                entity.ToTable("CVMCTI");

                entity.Property(e => e.CvmctiCodemp)
                    .HasColumnName("CVMCTI_CODEMP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiCodcon)
                    .HasColumnName("CVMCTI_CODCON")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiNrocon)
                    .HasColumnName("CVMCTI_NROCON")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiNroext).HasColumnName("CVMCTI_NROEXT");

                entity.Property(e => e.CvmctiNroitm).HasColumnName("CVMCTI_NROITM");

                entity.Property(e => e.CvmctiDebhab)
                    .HasColumnName("CVMCTI_DEBHAB")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiActlis)
                    .HasColumnName("CVMCTI_ACTLIS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiArtcod)
                    .HasColumnName("CVMCTI_ARTCOD")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiAuxaju)
                    .HasColumnName("CVMCTI_AUXAJU")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.CvmctiCantid)
                    .HasColumnName("CVMCTI_CANTID")
                    .HasColumnType("numeric(18, 4)");
                
                entity.Property(e => e.CvmctiCntsec)
                    .HasColumnName("CVMCTI_CNTSEC")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.CvmctiCodano)
                    .HasColumnName("CVMCTI_CODANO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiCodcpt)
                    .HasColumnName("CVMCTI_CODCPT")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiCodniv)
                    .HasColumnName("CVMCTI_CODNIV")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiCodopr)
                    .HasColumnName("CVMCTI_CODOPR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiCuenta)
                    .HasColumnName("CVMCTI_CUENTA")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiDebaja)
                    .HasColumnName("CVMCTI_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiFacsec)
                    .HasColumnName("CVMCTI_FACSEC")
                    .HasColumnType("numeric(12, 6)");

                entity.Property(e => e.CvmctiFecalt)
                    .HasColumnName("CVMCTI_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmctiFecmod)
                    .HasColumnName("CVMCTI_FECMOD")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmctiModcpt)
                    .HasColumnName("CVMCTI_MODCPT")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiNorden).HasColumnName("CVMCTI_NORDEN");

                entity.Property(e => e.CvmctiOalias)
                    .HasColumnName("CVMCTI_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiPreaju)
                    .HasColumnName("CVMCTI_PREAJU")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.CvmctiPrecio)
                    .HasColumnName("CVMCTI_PRECIO")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.CvmctiRecnov)
                    .HasColumnName("CVMCTI_RECNOV")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiStocks)
                    .HasColumnName("CVMCTI_STOCKS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiTexadi)
                    .HasColumnName("CVMCTI_TEXADI")
                    .HasColumnType("text");

                entity.Property(e => e.CvmctiTipcpt)
                    .HasColumnName("CVMCTI_TIPCPT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiTipopr)
                    .HasColumnName("CVMCTI_TIPOPR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiTippro)
                    .HasColumnName("CVMCTI_TIPPRO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiTravig)
                    .HasColumnName("CVMCTI_TRAVIG")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiUltopr)
                    .HasColumnName("CVMCTI_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiUnimed)
                    .HasColumnName("CVMCTI_UNIMED")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiUnisec)
                    .HasColumnName("CVMCTI_UNISEC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiUserid)
                    .HasColumnName("CVMCTI_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.CvmctiVigdde)
                    .HasColumnName("CVMCTI_VIGDDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CvmctiVighta)
                    .HasColumnName("CVMCTI_VIGHTA")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsrCvmctiAplpro)
                    .HasColumnName("USR_CVMCTI_APLPRO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmctiCalpro)
                    .HasColumnName("USR_CVMCTI_CALPRO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmctiCodext)
                    .HasColumnName("USR_CVMCTI_CODEXT")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmctiCombos)
                    .HasColumnName("USR_CVMCTI_COMBOS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCvmctiItmbon).HasColumnName("USR_CVMCTI_ITMBON");

                entity.Property(e => e.UsrCvmctiPorcen)
                    .HasColumnName("USR_CVMCTI_PORCEN")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.UsrCvmctiVigdde)
                    .HasColumnName("USR_CVMCTI_VIGDDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsrCvmctiVighta)
                    .HasColumnName("USR_CVMCTI_VIGHTA")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Vtrmvi>(entity =>
            {
                entity.HasKey(e => new { e.VtrmviCodemp, e.VtrmviModfor, e.VtrmviCodfor, e.VtrmviNrofor, e.VtrmviNroitm, e.VtrmviDebhab });

                entity.ToTable("VTRMVI");

                entity.HasIndex(e => e.VtrmviNrofor)
                    .HasName("T_VT_VTRRCH");

                entity.HasIndex(e => new { e.VtrmviCuenta, e.VtrmviDebhab })
                    .HasName("W_GR_IGRMVHWIZ");

                entity.HasIndex(e => new { e.VtrmviTippro, e.VtrmviArtcod })
                    .HasName("T_FC_VTRMVI");

                entity.HasIndex(e => new { e.VtrmviModapl, e.VtrmviCodapl, e.VtrmviNroapl })
                    .HasName("W_VT_VTDBCR");

                entity.HasIndex(e => new { e.VtrmviModfor, e.VtrmviCodfor, e.VtrmviNrofor, e.VtrmviDebhab, e.VtrmviCuenta, e.VtrmviImpnac, e.VtrmviImpsec })
                    .HasName("P_IG_PRFMNCE1");

                entity.HasIndex(e => new { e.VtrmviModfor, e.VtrmviCodfor, e.VtrmviNrofor, e.VtrmviModcpt, e.VtrmviTipcpt, e.VtrmviCodcpt, e.VtrmviNroitm, e.VtrmviDebhab })
                    .HasName("R_VT_DESGIMP_1");

                entity.HasIndex(e => new { e.VtrmviNrofor, e.VtrmviModfor, e.VtrmviCodfor, e.VtrmviModcpt, e.VtrmviTipcpt, e.VtrmviCodcpt, e.VtrmviNroitm, e.VtrmviDebhab })
                    .HasName("R_VT_DESGIMP_2");

                entity.HasIndex(e => new { e.VtrmviModapl, e.VtrmviCodapl, e.VtrmviNroapl, e.VtrmviModfor, e.VtrmviCodfor, e.VtrmviNrofor, e.VtrmviDebhab, e.VtrmviModcpt, e.VtrmviTipcpt, e.VtrmviCodcpt, e.VtrmviCuenta, e.VtrmviCuoapl })
                    .HasName("T_VT_VTRRCH2");

                entity.Property(e => e.VtrmviCodemp)
                    .HasColumnName("VTRMVI_CODEMP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviModfor)
                    .HasColumnName("VTRMVI_MODFOR")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCodfor)
                    .HasColumnName("VTRMVI_CODFOR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviNrofor).HasColumnName("VTRMVI_NROFOR");

                entity.Property(e => e.VtrmviNroitm).HasColumnName("VTRMVI_NROITM");

                entity.Property(e => e.VtrmviDebhab)
                    .HasColumnName("VTRMVI_DEBHAB")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviAnovig).HasColumnName("VTRMVI_ANOVIG");

                entity.Property(e => e.VtrmviArtcod)
                    .HasColumnName("VTRMVI_ARTCOD")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviArtdes)
                    .HasColumnName("VTRMVI_ARTDES")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCantid)
                    .HasColumnName("VTRMVI_CANTID")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.VtrmviClamov)
                    .HasColumnName("VTRMVI_CLAMOV")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCntalt)
                    .HasColumnName("VTRMVI_CNTALT")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.VtrmviCntcon)
                    .HasColumnName("VTRMVI_CNTCON")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.VtrmviCntfac)
                    .HasColumnName("VTRMVI_CNTFAC")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.VtrmviCodano)
                    .HasColumnName("VTRMVI_CODANO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCodapl)
                    .HasColumnName("VTRMVI_CODAPL")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCodcon)
                    .HasColumnName("VTRMVI_CODCON")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCodcpt)
                    .IsRequired()
                    .HasColumnName("VTRMVI_CODCPT")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCodcur)
                    .HasColumnName("VTRMVI_CODCUR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCodniv)
                    .HasColumnName("VTRMVI_CODNIV")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCodopr)
                    .HasColumnName("VTRMVI_CODOPR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCodori)
                    .HasColumnName("VTRMVI_CODORI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCodpro)
                    .HasColumnName("VTRMVI_CODPRO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCuenta)
                    .IsRequired()
                    .HasColumnName("VTRMVI_CUENTA")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviCuoapl).HasColumnName("VTRMVI_CUOAPL");

                entity.Property(e => e.VtrmviDebaja)
                    .HasColumnName("VTRMVI_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviDeposi)
                    .HasColumnName("VTRMVI_DEPOSI")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviDespro)
                    .HasColumnName("VTRMVI_DESPRO")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmviEmpapl)
                    .HasColumnName("VTRMVI_EMPAPL")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviEmpcon)
                    .HasColumnName("VTRMVI_EMPCON")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviEmpori)
                    .HasColumnName("VTRMVI_EMPORI")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviEnvase)
                    .HasColumnName("VTRMVI_ENVASE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviExpori)
                    .HasColumnName("VTRMVI_EXPORI")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviExtdeb)
                    .HasColumnName("VTRMVI_EXTDEB")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviExthab)
                    .HasColumnName("VTRMVI_EXTHAB")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviFacalt)
                    .HasColumnName("VTRMVI_FACALT")
                    .HasColumnType("numeric(12, 6)");

                entity.Property(e => e.VtrmviFaccon)
                    .HasColumnName("VTRMVI_FACCON")
                    .HasColumnType("numeric(12, 6)");

                entity.Property(e => e.VtrmviFacfac)
                    .HasColumnName("VTRMVI_FACFAC")
                    .HasColumnType("numeric(12, 6)");

                entity.Property(e => e.VtrmviFactor)
                    .HasColumnName("VTRMVI_FACTOR")
                    .HasColumnType("numeric(12, 6)");

                entity.Property(e => e.VtrmviFecalt)
                    .HasColumnName("VTRMVI_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmviFecmod)
                    .HasColumnName("VTRMVI_FECMOD")
                    .HasColumnType("datetime");

              
                entity.Property(e => e.VtrmviIciext)
                    .HasColumnName("VTRMVI_ICIEXT")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviIcinac)
                    .HasColumnName("VTRMVI_ICINAC")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviIciuss)
                    .HasColumnName("VTRMVI_ICIUSS")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviImpdeb)
                    .HasColumnName("VTRMVI_IMPDEB")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviImpext)
                    .HasColumnName("VTRMVI_IMPEXT")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviImphab)
                    .HasColumnName("VTRMVI_IMPHAB")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviImpnac)
                    .HasColumnName("VTRMVI_IMPNAC")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviImpori)
                    .HasColumnName("VTRMVI_IMPORI")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviImpsec)
                    .HasColumnName("VTRMVI_IMPSEC")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviImpu01)
                    .HasColumnName("VTRMVI_IMPU01")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviImpu02)
                    .HasColumnName("VTRMVI_IMPU02")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviImpu03)
                    .HasColumnName("VTRMVI_IMPU03")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviImpu04)
                    .HasColumnName("VTRMVI_IMPU04")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviImpu05)
                    .HasColumnName("VTRMVI_IMPU05")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviImpu06)
                    .HasColumnName("VTRMVI_IMPU06")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviImpuss)
                    .HasColumnName("VTRMVI_IMPUSS")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviIntnoi)
                    .HasColumnName("VTRMVI_INTNOI")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviItmcon).HasColumnName("VTRMVI_ITMCON");

                entity.Property(e => e.VtrmviItmori).HasColumnName("VTRMVI_ITMORI");

                entity.Property(e => e.VtrmviModapl)
                    .HasColumnName("VTRMVI_MODAPL")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviModcpt)
                    .IsRequired()
                    .HasColumnName("VTRMVI_MODCPT")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviModori)
                    .HasColumnName("VTRMVI_MODORI")
                    .HasMaxLength(2)
                    .IsUnicode(false);


                entity.Property(e => e.VtrmviNatrib)
                    .HasColumnName("VTRMVI_NATRIB")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviNdespa)
                    .HasColumnName("VTRMVI_NDESPA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviNestan)
                    .HasColumnName("VTRMVI_NESTAN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviNewpre)
                    .HasColumnName("VTRMVI_NEWPRE")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.VtrmviNfecha)
                    .HasColumnName("VTRMVI_NFECHA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviNotros)
                    .HasColumnName("VTRMVI_NOTROS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviNroapl).HasColumnName("VTRMVI_NROAPL");

                entity.Property(e => e.VtrmviNrocon)
                    .HasColumnName("VTRMVI_NROCON")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviNroext).HasColumnName("VTRMVI_NROEXT");

                entity.Property(e => e.VtrmviNroori).HasColumnName("VTRMVI_NROORI");

                entity.Property(e => e.VtrmviNserie)
                    .HasColumnName("VTRMVI_NSERIE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviNubica)
                    .HasColumnName("VTRMVI_NUBICA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviOalias)
                    .HasColumnName("VTRMVI_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviOldpre)
                    .HasColumnName("VTRMVI_OLDPRE")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.VtrmviPciext)
                    .HasColumnName("VTRMVI_PCIEXT")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.VtrmviPcinac)
                    .HasColumnName("VTRMVI_PCINAC")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.VtrmviPciuss)
                    .HasColumnName("VTRMVI_PCIUSS")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.VtrmviPctbf1)
                    .HasColumnName("VTRMVI_PCTBF1")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.VtrmviPctbf2)
                    .HasColumnName("VTRMVI_PCTBF2")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.VtrmviPctbf3)
                    .HasColumnName("VTRMVI_PCTBF3")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.VtrmviPctbf4)
                    .HasColumnName("VTRMVI_PCTBF4")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.VtrmviPctbf5)
                    .HasColumnName("VTRMVI_PCTBF5")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.VtrmviPctbf6)
                    .HasColumnName("VTRMVI_PCTBF6")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.VtrmviPctbf7)
                    .HasColumnName("VTRMVI_PCTBF7")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.VtrmviPctbf8)
                    .HasColumnName("VTRMVI_PCTBF8")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.VtrmviPctbf9)
                    .HasColumnName("VTRMVI_PCTBF9")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.VtrmviPctbfn)
                    .HasColumnName("VTRMVI_PCTBFN")
                    .HasColumnType("numeric(15, 7)");

                entity.Property(e => e.VtrmviPreext)
                    .HasColumnName("VTRMVI_PREEXT")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.VtrmviPrenac)
                    .HasColumnName("VTRMVI_PRENAC")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.VtrmviPreuss)
                    .HasColumnName("VTRMVI_PREUSS")
                    .HasColumnType("numeric(20, 6)");

                entity.Property(e => e.VtrmviSecdeb)
                    .HasColumnName("VTRMVI_SECDEB")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviSechab)
                    .HasColumnName("VTRMVI_SECHAB")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviSector)
                    .HasColumnName("VTRMVI_SECTOR")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviTasa01)
                    .HasColumnName("VTRMVI_TASA01")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviTasa02)
                    .HasColumnName("VTRMVI_TASA02")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviTasa03)
                    .HasColumnName("VTRMVI_TASA03")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviTasa04)
                    .HasColumnName("VTRMVI_TASA04")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviTasa05)
                    .HasColumnName("VTRMVI_TASA05")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviTasa06)
                    .HasColumnName("VTRMVI_TASA06")
                    .HasColumnType("numeric(15, 4)");

                entity.Property(e => e.VtrmviTatrib)
                    .HasColumnName("VTRMVI_TATRIB")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmviTdespa)
                    .HasColumnName("VTRMVI_TDESPA")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmviTenvas)
                    .HasColumnName("VTRMVI_TENVAS")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmviTestan)
                    .HasColumnName("VTRMVI_TESTAN")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmviTextos)
                    .HasColumnName("VTRMVI_TEXTOS")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmviTfecha)
                    .HasColumnName("VTRMVI_TFECHA")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmviTipcpt)
                    .IsRequired()
                    .HasColumnName("VTRMVI_TIPCPT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviTipdes)
                    .HasColumnName("VTRMVI_TIPDES")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviTipopr)
                    .HasColumnName("VTRMVI_TIPOPR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviTippro)
                    .HasColumnName("VTRMVI_TIPPRO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviTipuni)
                    .HasColumnName("VTRMVI_TIPUNI")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviTotros)
                    .HasColumnName("VTRMVI_TOTROS")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmviTserie)
                    .HasColumnName("VTRMVI_TSERIE")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmviTubica)
                    .HasColumnName("VTRMVI_TUBICA")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmviUltopr)
                    .HasColumnName("VTRMVI_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviUnialt)
                    .HasColumnName("VTRMVI_UNIALT")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviUnicon)
                    .HasColumnName("VTRMVI_UNICON")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviUnifac)
                    .HasColumnName("VTRMVI_UNIFAC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviUnimed)
                    .HasColumnName("VTRMVI_UNIMED")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviUserid)
                    .HasColumnName("VTRMVI_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmviUssdeb)
                    .HasColumnName("VTRMVI_USSDEB")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VtrmviUsshab)
                    .HasColumnName("VTRMVI_USSHAB")
                    .HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<Vtrmvh>(entity =>
            {
                entity.HasKey(e => new { e.VtrmvhCodemp, e.VtrmvhModfor, e.VtrmvhCodfor, e.VtrmvhNrofor });

                entity.ToTable("VTRMVH");

                entity.HasIndex(e => e.VtrmvhNrofor)
                    .HasName("GR_NUMERATION");

                entity.HasIndex(e => new { e.VtrmvhModdcr, e.VtrmvhCoddcr, e.VtrmvhNrodcr })
                    .HasName("R_VT_DEBCRE");

                entity.HasIndex(e => new { e.VtrmvhModfor, e.VtrmvhCodfor, e.VtrmvhNrofor, e.VtrmvhCodrev })
                    .HasName("W_VT_FCRMVUPD");

                entity.HasIndex(e => new { e.VtrmvhModfor, e.VtrmvhCodfor, e.VtrmvhNrofor, e.VtrmvhModcom, e.VtrmvhCodcom })
                    .HasName("P_EO_MODFORMODCOM");

                entity.HasIndex(e => new { e.VtrmvhFchmov, e.VtrmvhModfor, e.VtrmvhCodfor, e.VtrmvhNrofor, e.VtrmvhModcom, e.VtrmvhCodcom })
                    .HasName("W_GR_IGRMVHWIZ");

                entity.HasIndex(e => new { e.VtrmvhModasi, e.VtrmvhCodasi, e.VtrmvhNroasi, e.VtrmvhModfor, e.VtrmvhCodfor, e.VtrmvhNrofor })
                    .HasName("W_GR_IGRMVHWIZ_2");

                entity.HasIndex(e => new { e.VtrmvhModrev, e.VtrmvhCodrev, e.VtrmvhNrorev, e.VtrmvhModasi, e.VtrmvhCodasi, e.VtrmvhNroasi })
                    .HasName("W_CG_CGTRANWIZ");

                entity.HasIndex(e => new { e.VtrmvhCodasi, e.VtrmvhNroasi, e.VtrmvhModasi, e.VtrmvhFchmov, e.VtrmvhModfor, e.VtrmvhCodfor, e.VtrmvhNrofor, e.VtrmvhModcom, e.VtrmvhCodcom, e.VtrmvhCoflis })
                    .HasName("P_IG_PRFMNCE1");

                entity.HasIndex(e => new { e.VtrmvhNroasi, e.VtrmvhModasi, e.VtrmvhCodasi, e.VtrmvhFchmov, e.VtrmvhModcom, e.VtrmvhCodcom, e.VtrmvhModfor, e.VtrmvhCodfor, e.VtrmvhNrofor, e.VtrmvhCoflis })
                    .HasName("CP_WW_CPRMVHWIZ");

                entity.Property(e => e.VtrmvhCodemp)
                    .HasColumnName("VTRMVH_CODEMP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhModfor)
                    .HasColumnName("VTRMVH_MODFOR")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCodfor)
                    .HasColumnName("VTRMVH_CODFOR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhNrofor).HasColumnName("VTRMVH_NROFOR");

                entity.Property(e => e.UsrVtrmvhArcbas)
                    .HasColumnName("USR_VTRMVH_ARCBAS")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhArcbnl)
                    .HasColumnName("USR_VTRMVH_ARCBNL")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhArccob)
                    .HasColumnName("USR_VTRMVH_ARCCOB")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhArclnk)
                    .HasColumnName("USR_VTRMVH_ARCLNK")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhBanco)
                    .HasColumnName("USR_VTRMVH_BANCO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhBrfile)
                    .HasColumnName("USR_VTRMVH_BRFILE")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhCodbar)
                    .HasColumnName("USR_VTRMVH_CODBAR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhCodboc)
                    .HasColumnName("USR_VTRMVH_CODBOC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhCodent).HasColumnName("USR_VTRMVH_CODENT");

                entity.Property(e => e.UsrVtrmvhCodlnk)
                    .HasColumnName("USR_VTRMVH_CODLNK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhCodter)
                    .HasColumnName("USR_VTRMVH_CODTER")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhComisi)
                    .HasColumnName("USR_VTRMVH_COMISI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhEntdeb)
                    .HasColumnName("USR_VTRMVH_ENTDEB")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhEnviogl)
                    .HasColumnName("USR_VTRMVH_ENVIOGL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhEnvmai)
                    .HasColumnName("USR_VTRMVH_ENVMAI")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhFhsftp)
                    .HasColumnName("USR_VTRMVH_FHSFTP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsrVtrmvhGencor)
                    .HasColumnName("USR_VTRMVH_GENCOR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhGennov)
                    .HasColumnName("USR_VTRMVH_GENNOV")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhIdc).HasColumnName("USR_VTRMVH_IDC");

                entity.Property(e => e.UsrVtrmvhIdfact)
                    .HasColumnName("USR_VTRMVH_IDFACT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhImagen)
                    .HasColumnName("USR_VTRMVH_IMAGEN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhMarcaea)
                    .HasColumnName("USR_VTRMVH_MARCAEA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhMedpag)
                    .HasColumnName("USR_VTRMVH_MEDPAG")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhMunicp)
                    .HasColumnName("USR_VTRMVH_MUNICP")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhNrocbu)
                    .HasColumnName("USR_VTRMVH_NROCBU")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhNrotar)
                    .HasColumnName("USR_VTRMVH_NROTAR")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhPagows)
                    .HasColumnName("USR_VTRMVH_PAGOWS")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsrVtrmvhSocio)
                    .HasColumnName("USR_VTRMVH_SOCIO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UsrVtrmvhSubftp).HasColumnName("USR_VTRMVH_SUBFTP");

                entity.Property(e => e.UsrVtrmvhTarjet)
                    .HasColumnName("USR_VTRMVH_TARJET")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCambio)
                    .HasColumnName("VTRMVH_CAMBIO")
                    .HasColumnType("numeric(20, 8)");

                entity.Property(e => e.VtrmvhCamsec)
                    .HasColumnName("VTRMVH_CAMSEC")
                    .HasColumnType("numeric(20, 8)");

                entity.Property(e => e.VtrmvhCamuss)
                    .HasColumnName("VTRMVH_CAMUSS")
                    .HasColumnType("numeric(20, 8)");

                entity.Property(e => e.VtrmvhClaaut).HasColumnName("VTRMVH_CLAAUT");

                entity.Property(e => e.VtrmvhClamov)
                    .HasColumnName("VTRMVH_CLAMOV")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCndcom)
                    .HasColumnName("VTRMVH_CNDCOM")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCndiva)
                    .HasColumnName("VTRMVH_CNDIVA")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCndpag)
                    .HasColumnName("VTRMVH_CNDPAG")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCobrad)
                    .HasColumnName("VTRMVH_COBRAD")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCodasi)
                    .HasColumnName("VTRMVH_CODASI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCodcom)
                    .IsRequired()
                    .HasColumnName("VTRMVH_CODCOM")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCoddcr)
                    .HasColumnName("VTRMVH_CODDCR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCodfcr)
                    .HasColumnName("VTRMVH_CODFCR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCodlis)
                    .HasColumnName("VTRMVH_CODLIS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCodope)
                    .HasColumnName("VTRMVH_CODOPE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCodopr)
                    .HasColumnName("VTRMVH_CODOPR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCodori).HasColumnName("VTRMVH_CODORI");

                entity.Property(e => e.VtrmvhCodrev)
                    .HasColumnName("VTRMVH_CODREV")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCodrim)
                    .HasColumnName("VTRMVH_CODRIM")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCodsce)
                    .HasColumnName("VTRMVH_CODSCE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCodzon)
                    .HasColumnName("VTRMVH_CODZON")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCofdeu)
                    .HasColumnName("VTRMVH_COFDEU")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCoffac)
                    .HasColumnName("VTRMVH_COFFAC")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhCoflis)
                    .HasColumnName("VTRMVH_COFLIS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhDebaja)
                    .HasColumnName("VTRMVH_DEBAJA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhDesmov)
                    .HasColumnName("VTRMVH_DESMOV")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhDimobl)
                    .HasColumnName("VTRMVH_DIMOBL")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhDimori)
                    .HasColumnName("VTRMVH_DIMORI")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhDimuni)
                    .HasColumnName("VTRMVH_DIMUNI")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhDocfis)
                    .HasColumnName("VTRMVH_DOCFIS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhEmpasi)
                    .HasColumnName("VTRMVH_EMPASI")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhEmpdcr)
                    .HasColumnName("VTRMVH_EMPDCR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhEmpfcr)
                    .HasColumnName("VTRMVH_EMPFCR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhEmprev)
                    .HasColumnName("VTRMVH_EMPREV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhEmprim)
                    .HasColumnName("VTRMVH_EMPRIM")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhEstaut).HasColumnName("VTRMVH_ESTAUT");

                entity.Property(e => e.VtrmvhFchaut)
                    .HasColumnName("VTRMVH_FCHAUT")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvhFchfce)
                    .HasColumnName("VTRMVH_FCHFCE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvhFchmov)
                    .HasColumnName("VTRMVH_FCHMOV")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvhFchpar)
                    .HasColumnName("VTRMVH_FCHPAR")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvhFchven)
                    .HasColumnName("VTRMVH_FCHVEN")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvhFecalt)
                    .HasColumnName("VTRMVH_FECALT")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvhFecfcr)
                    .HasColumnName("VTRMVH_FECFCR")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvhFecmod)
                    .HasColumnName("VTRMVH_FECMOD")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvhGrubon)
                    .HasColumnName("VTRMVH_GRUBON")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhHstfor).HasColumnName("VTRMVH_HSTFOR");

                entity.Property(e => e.VtrmvhIdtfex).HasColumnName("VTRMVH_IDTFEX");

                entity.Property(e => e.VtrmvhImpres).HasColumnName("VTRMVH_IMPRES");

                entity.Property(e => e.VtrmvhImptcn)
                    .IsRequired()
                    .HasColumnName("VTRMVH_IMPTCN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhJurisd)
                    .IsRequired()
                    .HasColumnName("VTRMVH_JURISD")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhLetfis)
                    .HasColumnName("VTRMVH_LETFIS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhLotein).HasColumnName("VTRMVH_LOTEIN");

                entity.Property(e => e.VtrmvhModasi)
                    .HasColumnName("VTRMVH_MODASI")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhModcom)
                    .HasColumnName("VTRMVH_MODCOM")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhModdcr)
                    .HasColumnName("VTRMVH_MODDCR")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhModfcr)
                    .HasColumnName("VTRMVH_MODFCR")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhModrev)
                    .HasColumnName("VTRMVH_MODREV")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhModrim)
                    .HasColumnName("VTRMVH_MODRIM")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhNidcae).HasColumnName("VTRMVH_NIDCAE");

                entity.Property(e => e.VtrmvhNidfex).HasColumnName("VTRMVH_NIDFEX");

                entity.Property(e => e.VtrmvhNroasi).HasColumnName("VTRMVH_NROASI");

                entity.Property(e => e.VtrmvhNrocae)
                    .HasColumnName("VTRMVH_NROCAE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhNrocta)
                    .IsRequired()
                    .HasColumnName("VTRMVH_NROCTA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhNrodcr).HasColumnName("VTRMVH_NRODCR");

                entity.Property(e => e.VtrmvhNrofcr).HasColumnName("VTRMVH_NROFCR");

                entity.Property(e => e.VtrmvhNrofis).HasColumnName("VTRMVH_NROFIS");

                entity.Property(e => e.VtrmvhNrorev).HasColumnName("VTRMVH_NROREV");

                entity.Property(e => e.VtrmvhNrorim).HasColumnName("VTRMVH_NRORIM");

                entity.Property(e => e.VtrmvhNrosub)
                    .HasColumnName("VTRMVH_NROSUB")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhOalias)
                    .HasColumnName("VTRMVH_OALIAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhOricod)
                    .HasColumnName("VTRMVH_ORICOD")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhOricom)
                    .HasColumnName("VTRMVH_ORICOM")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhStafcr).HasColumnName("VTRMVH_STAFCR");

                entity.Property(e => e.VtrmvhSubcue)
                    .HasColumnName("VTRMVH_SUBCUE")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhSubori)
                    .HasColumnName("VTRMVH_SUBORI")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhSucfis)
                    .HasColumnName("VTRMVH_SUCFIS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhSucurs)
                    .HasColumnName("VTRMVH_SUCURS")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhTextos)
                    .HasColumnName("VTRMVH_TEXTOS")
                    .HasColumnType("text");

                entity.Property(e => e.VtrmvhTipexp)
                    .HasColumnName("VTRMVH_TIPEXP")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhTipopr)
                    .HasColumnName("VTRMVH_TIPOPR")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhUltopr)
                    .HasColumnName("VTRMVH_ULTOPR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhUserid)
                    .HasColumnName("VTRMVH_USERID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhUsraut)
                    .HasColumnName("VTRMVH_USRAUT")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhUtpaor)
                    .HasColumnName("VTRMVH_UTPAOR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VtrmvhVencae)
                    .HasColumnName("VTRMVH_VENCAE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtrmvhVnddor)
                    .HasColumnName("VTRMVH_VNDDOR")
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

        }
    }
}
