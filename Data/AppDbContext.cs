
using Microsoft.EntityFrameworkCore;
using petrgAPI.Models;


namespace petrgAPI.Data{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base (opt){

        }
        protected override void OnModelCreating(ModelBuilder builder){
            
            //A Pet has one PetGuardian and PetGuardian has many Pets
            builder.Entity<Pet>()
            .HasOne(pet => pet.PetGuardian)
            .WithMany(pet => pet.Pets)
            .HasForeignKey(pet => pet.PetGuardianId);


            //One address has one petGuardian and PetGuardian has one address
            builder.Entity<Address>()
            .HasOne(addres => addres.PetGuardian)
            .WithOne(petGuardian => petGuardian.Address)
            .HasForeignKey<PetGuardian>(petGuardian => petGuardian.AddresId);

        }


        
        public DbSet<Pet> Pets {get; set;}
        public DbSet<PetGuardian> PetGuardians {get; set;}
        public DbSet<Address> Addresses {get; set;}



    }

}