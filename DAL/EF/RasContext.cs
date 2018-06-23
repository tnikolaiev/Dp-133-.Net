using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ras.DAL.Entity;

namespace Ras.DAL.EF
{
    public partial class RasContext : DbContext
    {
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupStage> AcademyStages { get; set; }
        public virtual DbSet<Characteristic> Characteristic { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<EnglishLevel> EnglishLevel { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<GroupInfo> GroupInfo { get; set; }
        public virtual DbSet<GroupInfoTeacher> GroupInfoTeachers { get; set; }
        public virtual DbSet<GroupInfoTest> GroupInfoTests { get; set; }
        public virtual DbSet<GroupPaymentStatus> GroupPaymentStatus { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<ItaGroup> ItaAcademy { get; set; }
        public virtual DbSet<ItaGroupStatus> ItaAcademyStatuses { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LanguageTranslations> LanguageTranslations { get; set; }
        public virtual DbSet<LoginUser> LoginUser { get; set; }
        public virtual DbSet<LoginuserEmployeeroles> LoginuserEmployeeroles { get; set; }
        public virtual DbSet<Mark> Mark { get; set; }
        public virtual DbSet<PersonalStatus> PersonalStatuses { get; set; }
        public virtual DbSet<ProfileInfo> ProfileInfo { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentStatus> StudentStatuses { get; set; }
        public virtual DbSet<TeacherType> TeacherTypes { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }
        public virtual DbSet<TestName> TestesNames { get; set; }
        public virtual DbSet<TestsNameTemplate> TestsNameTemplate { get; set; }
        public virtual DbSet<User> Users { get; set; }

        private string connectionString;

        public RasContext(string connectionString)
        {
            this.connectionString = connectionString;
            //Database.EnsureCreated();
        }

        //TODO: check this ctor
        //public RasContext()
        //{
            
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySQL(@"Server=localhost;user id=ras;database = ss_ps_db;Pwd=1111;persistsecurityinfo = True;");
                optionsBuilder.UseMySQL(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("academy", "ss_ps_db");

                entity.HasIndex(e => e.CityId)
                    .HasName("FKnqn157p7x9jwg395dof37f9d9");

                entity.HasIndex(e => e.DirectionId)
                    .HasName("FKjung41y4riao7o7vhd8kk7qtf");

                entity.HasIndex(e => e.StageId)
                    .HasName("FKqlhohwc4f6yf2mahy2caofg0n");

                entity.HasIndex(e => e.TechnologyId)
                    .HasName("FKh7cpmhg8whftf52sf3qk92e8i");

                entity.Property(e => e.Id).HasColumnName("academy_id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CrmGroup).HasColumnName("crm_group");

                entity.Property(e => e.DirectionId).HasColumnName("direction_id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Free).HasColumnName("free");

                entity.Property(e => e.HasEng).HasColumnName("has_eng");

                entity.Property(e => e.HasFirst).HasColumnName("has_first");

                entity.Property(e => e.HasTech).HasColumnName("has_tech");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.NotSynchronized).HasColumnName("not_synchronized");

                entity.Property(e => e.StageId).HasColumnName("stage_id");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TechnologyId).HasColumnName("technology_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Academy)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("academy$FKnqn157p7x9jwg395dof37f9d9");

                entity.HasOne(d => d.Direction)
                    .WithMany(p => p.Academy)
                    .HasForeignKey(d => d.DirectionId)
                    .HasConstraintName("academy$FKjung41y4riao7o7vhd8kk7qtf");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.Academy)
                    .HasForeignKey(d => d.StageId)
                    .HasConstraintName("academy$FKqlhohwc4f6yf2mahy2caofg0n");

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.Academy)
                    .HasForeignKey(d => d.TechnologyId)
                    .HasConstraintName("academy$FKh7cpmhg8whftf52sf3qk92e8i");
            });

            modelBuilder.Entity<GroupStage>(entity =>
            {
                entity.HasKey(e => e.StageId);

                entity.ToTable("academy_stages", "ss_ps_db");

                entity.Property(e => e.StageId).HasColumnName("stage_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Sort).HasColumnName("sort");
            });

            modelBuilder.Entity<Characteristic>(entity =>
            {
                entity.ToTable("characteristic", "ss_ps_db");

                entity.Property(e => e.CharacteristicId).HasColumnName("characteristic_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city", "ss_ps_db");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CrmId).HasColumnName("crm_id");

                entity.Property(e => e.Ita).HasColumnName("ita");
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.HasKey(e => e.DirectionId);

                entity.ToTable("directions", "ss_ps_db");

                entity.Property(e => e.DirectionId).HasColumnName("direction_id");

                entity.Property(e => e.Ita).HasColumnName("ita");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee", "ss_ps_db");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.FirstNameEng)
                    .IsRequired()
                    .HasColumnName("first_name_eng")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstNameUkr)
                    .HasColumnName("first_name_ukr")
                    .HasMaxLength(255);

                entity.Property(e => e.LastNameEng)
                    .IsRequired()
                    .HasColumnName("last_name_eng")
                    .HasMaxLength(255);

                entity.Property(e => e.LastNameUkr)
                    .HasColumnName("last_name_ukr")
                    .HasMaxLength(255);

                entity.Property(e => e.SecondNameUkr)
                    .HasColumnName("second_name_ukr")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.ToTable("employee_roles", "ss_ps_db");

                entity.Property(e => e.EmployeeroleId).HasColumnName("employeeroles_id");

                entity.Property(e => e.Authority)
                    .HasColumnName("authority")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EnglishLevel>(entity =>
            {
                entity.ToTable("english_level", "ss_ps_db");

                entity.Property(e => e.EnglishLevelId).HasColumnName("english_level_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback", "ss_ps_db");

                entity.HasIndex(e => e.ActiveCommunicatorId)
                    .HasName("FK24d69phv895w36amup5ln7mj9");

                entity.HasIndex(e => e.GettingThingsDoneId)
                    .HasName("FKop4fqdtd6kitwhhjv73xw1s92");

                entity.HasIndex(e => e.LearningAbilityId)
                    .HasName("FKabc7yjjg1b1mc5d4dv25vqvvw");

                entity.HasIndex(e => e.PassionalInitiativeId)
                    .HasName("FKd2qxv9cx9g0g0bt44u7f5v4ba");

                entity.HasIndex(e => e.TeamWorkId)
                    .HasName("FKbipci40s10odbiucjstll3n93");

                entity.HasIndex(e => e.TechnicalCompetenceId)
                    .HasName("FK425br58le4dv9xgmnvnu8jvkd");

                entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");

                entity.Property(e => e.ActiveCommunicatorId).HasColumnName("active_communicator");

                entity.Property(e => e.GettingThingsDoneId).HasColumnName("getting_things_done");

                entity.Property(e => e.LearningAbilityId).HasColumnName("learning_ability");

                entity.Property(e => e.PassionalInitiativeId).HasColumnName("passional_initiative");

                entity.Property(e => e.SummaryComment)
                    .HasColumnName("summary_comment")
                    .HasMaxLength(255);

                entity.Property(e => e.TeamWorkId).HasColumnName("team_work");

                entity.Property(e => e.TechnicalCompetenceId).HasColumnName("technical_competence");

                entity.HasOne(d => d.ActiveCommunicator)
                    .WithMany(p => p.FeedbackActiveCommunicatorNavigation)
                    .HasForeignKey(d => d.ActiveCommunicatorId)
                    .HasConstraintName("feedback$FK24d69phv895w36amup5ln7mj9");

                entity.HasOne(d => d.GettingThingsDone)
                    .WithMany(p => p.FeedbackGettingThingsDoneNavigation)
                    .HasForeignKey(d => d.GettingThingsDoneId)
                    .HasConstraintName("feedback$FKop4fqdtd6kitwhhjv73xw1s92");

                entity.HasOne(d => d.LearningAbility)
                    .WithMany(p => p.FeedbackLearningAbilityNavigation)
                    .HasForeignKey(d => d.LearningAbilityId)
                    .HasConstraintName("feedback$FKabc7yjjg1b1mc5d4dv25vqvvw");

                entity.HasOne(d => d.PassionalInitiative)
                    .WithMany(p => p.FeedbackPassionalInitiativeNavigation)
                    .HasForeignKey(d => d.PassionalInitiativeId)
                    .HasConstraintName("feedback$FKd2qxv9cx9g0g0bt44u7f5v4ba");

                entity.HasOne(d => d.TeamWork)
                    .WithMany(p => p.FeedbackTeamWorkNavigation)
                    .HasForeignKey(d => d.TeamWorkId)
                    .HasConstraintName("feedback$FKbipci40s10odbiucjstll3n93");

                entity.HasOne(d => d.TechnicalCompetence)
                    .WithMany(p => p.FeedbackTechnicalCompetenceNavigation)
                    .HasForeignKey(d => d.TechnicalCompetenceId)
                    .HasConstraintName("feedback$FK425br58le4dv9xgmnvnu8jvkd");
            });

            modelBuilder.Entity<GroupInfo>(entity =>
            {
                entity.ToTable("group_info", "ss_ps_db");

                entity.HasIndex(e => e.AcademyId)
                    .HasName("FKapr4vej8719lprb5fhrdbxj43");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("FK8kbtjrfh6mvfog3glapoetv4r");

                entity.Property(e => e.GroupInfoId).HasColumnName("group_info_id");

                entity.Property(e => e.AcademyId).HasColumnName("academy_id");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.StudentsPlannedToEnrollment).HasColumnName("students_planned_to_enrollment");

                entity.Property(e => e.StudentsPlannedToGraduate).HasColumnName("students_planned_to_graduate");

                entity.HasOne(d => d.Academy)
                    .WithMany(p => p.GroupInfo)
                    .HasForeignKey(d => d.AcademyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("group_info$FKapr4vej8719lprb5fhrdbxj43");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.GroupInfo)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("group_info$FK8kbtjrfh6mvfog3glapoetv4r");
            });

            modelBuilder.Entity<GroupInfoTeacher>(entity =>
            {
                entity.ToTable("group_info_teachers", "ss_ps_db");

                entity.HasIndex(e => e.AcademyId)
                    .HasName("FKhfxah780wlb898u08khbmchf5");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FKj574uhkhtui0xw08fyf1vgsid");

                entity.HasIndex(e => e.TeacherTypeId)
                    .HasName("FK2xy0dkq1ilv8fjldtvyo91vm4");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcademyId).HasColumnName("academy_id");

                entity.Property(e => e.ContributedHours).HasColumnName("contributed_hours");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Involved).HasColumnName("involved");

                entity.Property(e => e.TeacherTypeId).HasColumnName("teacher_type_id");

                entity.HasOne(d => d.Academy)
                    .WithMany(p => p.GroupInfoTeachers)
                    .HasForeignKey(d => d.AcademyId)
                    .HasConstraintName("group_info_teachers$FKhfxah780wlb898u08khbmchf5");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.GroupInfoTeachers)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("group_info_teachers$FKj574uhkhtui0xw08fyf1vgsid");

                entity.HasOne(d => d.TeacherType)
                    .WithMany(p => p.GroupInfoTeachers)
                    .HasForeignKey(d => d.TeacherTypeId)
                    .HasConstraintName("group_info_teachers$FK2xy0dkq1ilv8fjldtvyo91vm4");
            });

            modelBuilder.Entity<GroupInfoTest>(entity =>
            {
                entity.ToTable("group_info_tests", "ss_ps_db");

                entity.HasIndex(e => e.AcademyId)
                    .HasName("FK6wh4jolfqywtlskykcu5avhsm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcademyId).HasColumnName("academy_id");

                entity.Property(e => e.Test10MaxVal)
                    .HasColumnName("test_10_max_val")
                    .HasMaxLength(255);

                entity.Property(e => e.Test10Name)
                    .HasColumnName("test_10_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Test1MaxVal)
                    .HasColumnName("test_1_max_val")
                    .HasMaxLength(255);

                entity.Property(e => e.Test1Name)
                    .HasColumnName("test_1_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Test2MaxVal)
                    .HasColumnName("test_2_max_val")
                    .HasMaxLength(255);

                entity.Property(e => e.Test2Name)
                    .HasColumnName("test_2_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Test3MaxVal)
                    .HasColumnName("test_3_max_val")
                    .HasMaxLength(255);

                entity.Property(e => e.Test3Name)
                    .HasColumnName("test_3_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Test4MaxVal)
                    .HasColumnName("test_4_max_val")
                    .HasMaxLength(255);

                entity.Property(e => e.Test4Name)
                    .HasColumnName("test_4_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Test5MaxVal)
                    .HasColumnName("test_5_max_val")
                    .HasMaxLength(255);

                entity.Property(e => e.Test5Name)
                    .HasColumnName("test_5_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Test6MaxVal)
                    .HasColumnName("test_6_max_val")
                    .HasMaxLength(255);

                entity.Property(e => e.Test6Name)
                    .HasColumnName("test_6_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Test7MaxVal)
                    .HasColumnName("test_7_max_val")
                    .HasMaxLength(255);

                entity.Property(e => e.Test7Name)
                    .HasColumnName("test_7_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Test8MaxVal)
                    .HasColumnName("test_8_max_val")
                    .HasMaxLength(255);

                entity.Property(e => e.Test8Name)
                    .HasColumnName("test_8_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Test9MaxVal)
                    .HasColumnName("test_9_max_val")
                    .HasMaxLength(255);

                entity.Property(e => e.Test9Name)
                    .HasColumnName("test_9_name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Academy)
                    .WithMany(p => p.GroupInfoTests)
                    .HasForeignKey(d => d.AcademyId)
                    .HasConstraintName("group_info_tests$FK6wh4jolfqywtlskykcu5avhsm");
            });

            modelBuilder.Entity<GroupPaymentStatus>(entity =>
            {
                entity.ToTable("group_payment_status", "ss_ps_db");

                entity.Property(e => e.GroupPaymentStatusId).HasColumnName("group_payment_status_id");

                entity.Property(e => e.GroupPaymentStatus1).HasColumnName("group_payment_status");

                entity.Property(e => e.GroupPaymentStatusName)
                    .IsRequired()
                    .HasColumnName("group_payment_status_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history", "ss_ps_db");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcademyId).HasColumnName("academy_id");

                entity.Property(e => e.AcademyName)
                    .HasColumnName("academy_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CrmGroup).HasColumnName("crm_group");

                entity.Property(e => e.Direction)
                    .HasColumnName("direction")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.NameForSite)
                    .HasColumnName("name_for_site")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Stage)
                    .HasColumnName("stage")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<ItaGroup>(entity =>
            {
                entity.HasKey(e => e.ItAcademyId);

                entity.ToTable("ita_academy", "ss_ps_db");

                entity.HasIndex(e => e.AcademyId)
                    .HasName("IDX_7C83998B6D55ACAB");

                entity.HasIndex(e => e.ItAcademyStatusId)
                    .HasName("IDX_7C83998B444B38AA");

                entity.HasIndex(e => e.UserId)
                    .HasName("IDX_7C83998BA76ED395");

                entity.Property(e => e.ItAcademyId).HasColumnName("it_academy_id");

                entity.Property(e => e.AcademyId).HasColumnName("academy_id");

                entity.Property(e => e.Canceled).HasColumnName("canceled");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.EngSlotId).HasColumnName("eng_slot_id");

                entity.Property(e => e.HrComment).HasColumnName("hr_comment");

                entity.Property(e => e.HrEndDate)
                    .HasColumnName("hr_end_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.HrStartDate)
                    .HasColumnName("hr_start_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IsSync).HasColumnName("is_sync");

                entity.Property(e => e.IsSyncRegGroup).HasColumnName("is_sync_reg_group");

                entity.Property(e => e.ItAcademyStatusId).HasColumnName("it_academy_status_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TechSlotId).HasColumnName("tech_slot_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Academy)
                    .WithMany(p => p.ItaAcademy)
                    .HasForeignKey(d => d.AcademyId)
                    .HasConstraintName("ita_academy$FK_7C83998B6D55ACAB");

                entity.HasOne(d => d.ItAcademyStatus)
                    .WithMany(p => p.ItaAcademy)
                    .HasForeignKey(d => d.ItAcademyStatusId)
                    .HasConstraintName("ita_academy$FK_7C83998B444B38AA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ItaAcademy)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("ita_academy$FK_7C83998BA76ED395");
            });

            modelBuilder.Entity<ItaGroupStatus>(entity =>
            {
                entity.HasKey(e => e.ItAcademyStatusId);

                entity.ToTable("ita_academy_statuses", "ss_ps_db");

                entity.Property(e => e.ItAcademyStatusId).HasColumnName("it_academy_status_id");

                entity.Property(e => e.CrmStatus)
                    .IsRequired()
                    .HasColumnName("crm_status")
                    .HasMaxLength(255);

                entity.Property(e => e.CrmStatusCode).HasColumnName("crm_status_code");

                entity.Property(e => e.CsStatus).HasColumnName("cs_status");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.ToTable("languages", "ss_ps_db");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.Local)
                    .IsRequired()
                    .HasColumnName("local")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<LanguageTranslations>(entity =>
            {
                entity.HasKey(e => e.TranslationId);

                entity.ToTable("language_translations", "ss_ps_db");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("FK1lsjfmypo7wbviku2scaxw103");

                entity.Property(e => e.TranslationId).HasColumnName("translation_id");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasColumnName("field")
                    .HasMaxLength(255);

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.Local)
                    .HasColumnName("local")
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasColumnName("tag")
                    .HasMaxLength(255);

                entity.Property(e => e.Trasnlation)
                    .IsRequired()
                    .HasColumnName("trasnlation")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.LanguageTranslations)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("language_translations$FK1lsjfmypo7wbviku2scaxw103");
            });

            modelBuilder.Entity<LoginUser>(entity =>
            {
                entity.ToTable("login_user", "ss_ps_db");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FKctad27fryj7tnantkhbqggr1v");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountNonExpired)
                    .IsRequired()
                    .HasColumnName("account_non_expired")
                    .HasColumnType("binary(1)");

                entity.Property(e => e.AccountNonLocked)
                    .IsRequired()
                    .HasColumnName("account_non_locked")
                    .HasColumnType("binary(1)");

                entity.Property(e => e.CredentialsNonExpired)
                    .IsRequired()
                    .HasColumnName("credentials_non_expired")
                    .HasColumnType("binary(1)");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasColumnName("enabled")
                    .HasColumnType("binary(1)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LoginUser)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("login_user$FKctad27fryj7tnantkhbqggr1v");
            });

            modelBuilder.Entity<LoginuserEmployeeroles>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.EmployeerolesId });

                entity.ToTable("loginuser_employeeroles", "ss_ps_db");

                entity.HasIndex(e => e.EmployeerolesId)
                    .HasName("FKgvekcnf1ydg5qtikcho8shaae");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeerolesId).HasColumnName("employeeroles_id");

                entity.HasOne(d => d.Employeeroles)
                    .WithMany(p => p.LoginuserEmployeeroles)
                    .HasForeignKey(d => d.EmployeerolesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("loginuser_employeeroles$FKgvekcnf1ydg5qtikcho8shaae");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.LoginuserEmployeeroles)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("loginuser_employeeroles$FKkl3g1t81y0pbexjofd0xn4ct7");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("mark", "ss_ps_db");

                entity.HasIndex(e => e.CharacteristicId)
                    .HasName("FKfn0905rt554w4qc4k01vjwtln");

                entity.Property(e => e.MarkId).HasColumnName("mark_id");

                entity.Property(e => e.CharacteristicId).HasColumnName("characteristic_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Characteristic)
                    .WithMany(p => p.Mark)
                    .HasForeignKey(d => d.CharacteristicId)
                    .HasConstraintName("mark$FKfn0905rt554w4qc4k01vjwtln");
            });

            modelBuilder.Entity<PersonalStatus>(entity =>
            {
                entity.ToTable("personal_statuses", "ss_ps_db");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ProfileInfo>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.ToTable("profile_info", "ss_ps_db");

                entity.HasIndex(e => e.TechnologyId)
                    .HasName("FKktsttf6y6cxwf15wwchokucva");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.ProfileName)
                    .IsRequired()
                    .HasColumnName("profile_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TechnologyId).HasColumnName("technology_id");

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.ProfileInfo)
                    .HasForeignKey(d => d.TechnologyId)
                    .HasConstraintName("profile_info$FKktsttf6y6cxwf15wwchokucva");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students", "ss_ps_db");

                entity.HasIndex(e => e.GroupId)
                    .HasName("FKhkcgw9sjsfsune68tsywawccr");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FKsuj0vgku9kyds0olm5d6cyl4v");

                entity.HasIndex(e => e.EnglishLevelId)
                    .HasName("FK96x3gmk0e10exuvymubnqciig");

                entity.HasIndex(e => e.ExpertStudentFeedbackId)
                    .HasName("FKet4nwem3tnoy3tn9e2sqlv3nt");

                entity.HasIndex(e => e.StudentStatusId)
                    .HasName("FKe82lbwdq8io7qeqondi0mvbnu");

                entity.HasIndex(e => e.TeacherStudentFeedbackId)
                    .HasName("FKk124ctna91gc2sv1achdv8spx");

                entity.HasIndex(e => e.UserId)
                    .HasName("FKdt1cjx5ve5bdabmuuf3ibrwaq");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("academy_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EngGram).HasColumnName("eng_gram");

                entity.Property(e => e.EnglishLevelId).HasColumnName("english_level_id");

                entity.Property(e => e.EntryScore).HasColumnName("entry_score");

                entity.Property(e => e.ExpertScore).HasColumnName("expert_score");

                entity.Property(e => e.ExpertStudentFeedbackId).HasColumnName("expert_student_feedback_id");

                entity.Property(e => e.FinalBase).HasColumnName("final_base");

                entity.Property(e => e.FinalLang).HasColumnName("final_lang");

                entity.Property(e => e.IncomingTest).HasColumnName("incoming_test");

                entity.Property(e => e.IntermTestBase).HasColumnName("interm_test_base");

                entity.Property(e => e.IntermTestLang).HasColumnName("interm_test_lang");

                entity.Property(e => e.InterviewerComment)
                    .HasColumnName("interviewer_comment")
                    .HasMaxLength(255);

                entity.Property(e => e.InterviewerScore).HasColumnName("interviewer_score");

                entity.Property(e => e.Removed).HasColumnName("removed");

                entity.Property(e => e.StudentStatusId).HasColumnName("student_status_id");

                entity.Property(e => e.TeacherScore).HasColumnName("teacher_score");

                entity.Property(e => e.TeacherStudentFeedbackId).HasColumnName("teacher_student_feedback_id");

                entity.Property(e => e.Test1).HasColumnName("test_1");

                entity.Property(e => e.Test10).HasColumnName("test_10");

                entity.Property(e => e.Test2).HasColumnName("test_2");

                entity.Property(e => e.Test3).HasColumnName("test_3");

                entity.Property(e => e.Test4).HasColumnName("test_4");

                entity.Property(e => e.Test5).HasColumnName("test_5");

                entity.Property(e => e.Test6).HasColumnName("test_6");

                entity.Property(e => e.Test7).HasColumnName("test_7");

                entity.Property(e => e.Test8).HasColumnName("test_8");

                entity.Property(e => e.Test9).HasColumnName("test_9");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("students$FKhkcgw9sjsfsune68tsywawccr");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("students$FKsuj0vgku9kyds0olm5d6cyl4v");

                entity.HasOne(d => d.EnglishLevel)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.EnglishLevelId)
                    .HasConstraintName("students$FK96x3gmk0e10exuvymubnqciig");

                entity.HasOne(d => d.ExpertStudentFeedback)
                    .WithMany(p => p.StudentsExpertStudentFeedback)
                    .HasForeignKey(d => d.ExpertStudentFeedbackId)
                    .HasConstraintName("students$FKet4nwem3tnoy3tn9e2sqlv3nt");

                entity.HasOne(d => d.StudentStatus)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StudentStatusId)
                    .HasConstraintName("students$FKe82lbwdq8io7qeqondi0mvbnu");

                entity.HasOne(d => d.TeacherStudentFeedback)
                    .WithMany(p => p.StudentsTeacherStudentFeedback)
                    .HasForeignKey(d => d.TeacherStudentFeedbackId)
                    .HasConstraintName("students$FKk124ctna91gc2sv1achdv8spx");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("students$FKdt1cjx5ve5bdabmuuf3ibrwaq");
            });

            modelBuilder.Entity<StudentStatus>(entity =>
            {
                entity.ToTable("student_statuses", "ss_ps_db");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TeacherType>(entity =>
            {
                entity.HasKey(e => e.TeacherTypeId);

                entity.ToTable("teacher_types", "ss_ps_db");

                entity.Property(e => e.TeacherTypeId).HasColumnName("teacher_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.HasKey(e => e.TechnologyId);

                entity.ToTable("technologies", "ss_ps_db");

                entity.Property(e => e.TechnologyId).HasColumnName("technology_id");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasColumnName("alias")
                    .HasMaxLength(255);

                entity.Property(e => e.DirectiondId).HasColumnName("directiond_id");

                entity.Property(e => e.Free).HasColumnName("free");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasMaxLength(255);

                entity.Property(e => e.Image2)
                    .IsRequired()
                    .HasColumnName("image2")
                    .HasMaxLength(255);

                entity.Property(e => e.Ita).HasColumnName("ita");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TestName>(entity =>
            {
                entity.ToTable("testes_names", "ss_ps_db");

                entity.HasIndex(e => e.AcademyId)
                    .HasName("FKdfx1cqnsxkiv9hsv5augmolsb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcademyId).HasColumnName("academy_id");

                entity.Property(e => e.TestMaxScore).HasColumnName("test_max_score");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("test_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TestSequence).HasColumnName("test_sequence");

                entity.HasOne(d => d.Academy)
                    .WithMany(p => p.TestesNames)
                    .HasForeignKey(d => d.AcademyId)
                    .HasConstraintName("testes_names$FKdfx1cqnsxkiv9hsv5augmolsb");
            });

            modelBuilder.Entity<TestsNameTemplate>(entity =>
            {
                entity.ToTable("tests_name_template", "ss_ps_db");

                entity.HasIndex(e => e.TemplateDirectionId)
                    .HasName("FK2rgwvy7duk5kwlusmtu1lbfom");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TemplateDirectionId).HasColumnName("template_direction_id");

                entity.Property(e => e.TestMaxScore).HasColumnName("test_max_score");

                entity.Property(e => e.TestName)
                    .HasColumnName("test_name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.TemplateDirection)
                    .WithMany(p => p.TestsNameTemplate)
                    .HasForeignKey(d => d.TemplateDirectionId)
                    .HasConstraintName("tests_name_template$FK2rgwvy7duk5kwlusmtu1lbfom");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "ss_ps_db");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.EngLevel).HasColumnName("eng_level");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(255);

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasMaxLength(255);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(255);
            });
        }
    }
}
