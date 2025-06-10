using Kolokwium_ORM.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_ORM.Data;

public class DatabaseContext:DbContext
{
    public DbSet<Race> Races { get; set; }
     public DbSet<RaceParticipation> RaceParticipations { get; set; }
    public DbSet<Racer> Racers { get; set; }
     public DbSet<Track> Tracks { get; set; }
     public DbSet<TrackRace> TrackRaces { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
    // {
    //     new Doctor() { IdDoctor = 1, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@gmail.com" },
    //     new Doctor() { IdDoctor = 2, FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com" },
    //     new Doctor() { IdDoctor = 3, FirstName = "Anna", LastName = "Nowak", Email = "anna.nowak@clinic.com" },
    //     new Doctor() { IdDoctor = 4, FirstName = "Tomasz", LastName = "Kowalski", Email = "t.kowalski@hospital.org" }
    // });
    //
    // modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
    // {
    //     new Medicament() { IdMedicament = 1, Name = "Medicament1", Description = "description1", Type = "Type1" },
    //     new Medicament() { IdMedicament = 2, Name = "Paracetamol", Description = "Painkiller", Type = "Tablet" },
    //     new Medicament() { IdMedicament = 3, Name = "Ibuprofen", Description = "Anti-inflammatory", Type = "Capsule" }
    // });
    //
    // modelBuilder.Entity<Patient>().HasData(new List<Patient>()
    // {
    //     new Patient() { IdPatient = 1, FirstName = "Wojciech", LastName = "Kozlowski", BirthDate = new DateTime(2001, 7, 11) },
    //     new Patient() { IdPatient = 2, FirstName = "Alicja", LastName = "Wiśniewska", BirthDate = new DateTime(1995, 3, 22) },
    //     new Patient() { IdPatient = 3, FirstName = "Marcin", LastName = "Nowak", BirthDate = new DateTime(1988, 12, 5) }
    // });
    //
    // modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
    // {
    //     new Prescription() { IdPrescription = 1, Date = new DateTime(2025, 5, 23), IdDoctor = 1, IdPatient = 1 },
    //     new Prescription() { IdPrescription = 2, Date = new DateTime(2025, 5, 24), IdDoctor = 2, IdPatient = 2 },
    //     new Prescription() { IdPrescription = 3, Date = new DateTime(2025, 5, 25), IdDoctor = 3, IdPatient = 3 }
    // });
    //
    // modelBuilder.Entity<Prescription_Medicament>().HasData(new List<Prescription_Medicament>()
    // {
    //     new Prescription_Medicament() { IdPrescription = 1, IdMedicament = 1, Dose = 5, Details = "details1" },
    //     new Prescription_Medicament() { IdPrescription = 2, IdMedicament = 2, Dose = 2, Details = "take after meal" },
    //     new Prescription_Medicament() { IdPrescription = 3, IdMedicament = 3, Dose = 1, Details = "twice daily" }
    // });
}
    
}