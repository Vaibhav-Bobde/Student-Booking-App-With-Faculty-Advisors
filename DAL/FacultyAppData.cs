namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FacultyAppData : DbContext
    {
        public FacultyAppData()
            : base("name=FacultyAppConnString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.DeptName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.CWID)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Fname)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Lname)
                .IsUnicode(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.Day)
                .IsUnicode(false);
        }
    }
}
