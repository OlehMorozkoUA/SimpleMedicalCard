using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
    }

    public class DiagnossisCardiovascular : IDiagnossisReception
    {
        [Key]
        public int Id { get; set; }
        public string Quest1 { get; set; }
        public string Quest2 { get; set; }
        public string Quest3 { get; set; }
        public string Quest4 { get; set; }
        public DateTime Date { get; set; }
        public string Conclusion { get; set; }
        public string Reception { get; set; }
        public int StudentId { get; set; }
    }

    public class DiagnossisRespiratory : IDiagnossisReception
    {
        [Key]
        public int Id { get; set; }
        public string Quest1 { get; set; }
        public string Quest2 { get; set; }
        public string Quest3 { get; set; }
        public DateTime Date { get; set; }
        public string Conclusion { get; set; }
        public string Reception { get; set; }
        public int StudentId { get; set; }
    }

    public class DiagnossisDigestive : IDiagnossisReception
    {
        [Key]
        public int Id { get; set; }
        public string Quest1 { get; set; }
        public string Quest2 { get; set; }
        public string Quest3 { get; set; }
        public string Quest4 { get; set; }
        public DateTime Date { get; set; }
        public string Conclusion { get; set; }
        public string Reception { get; set; }
        public int StudentId { get; set; }
    }

    public class DiagnossisEndocrine : IDiagnossisReception
    {
        [Key]
        public int Id { get; set; }
        public string Quest1 { get; set; }
        public string Quest2 { get; set; }
        public string Quest3 { get; set; }
        public string Quest4 { get; set; }
        public DateTime Date { get; set; }
        public string Conclusion { get; set; }
        public string Reception { get; set; }
        public int StudentId { get; set; }
    }

    public class StudentDataBase : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<DiagnossisCardiovascular> DiagnossisCardiovasculars { get; set; }
        public DbSet<DiagnossisDigestive> DiagnossisDigestives { get; set; }
        public DbSet<DiagnossisEndocrine> DiagnossisEndocrines { get; set; }
        public DbSet<DiagnossisRespiratory> DiagnossisRespiratories { get; set; }
        public StudentDataBase() : base("StudentDataBase") { }
    }
}
