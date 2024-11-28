using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730ebirriot.API.Inventory.Domain.Model.Aggregates;
using si730ebirriot.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace si730ebirriot.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
/// Application database context for the Learning Center Platform 
/// </summary>
/// <param name="options">
/// The options for the database context
/// </param>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   /// <summary>
   /// On configuring the database context 
   /// </summary>
   /// <remarks>
   /// This method is used to configure the database context.
   /// It also adds the created and updated date interceptor to the database context.
   /// </remarks>
   /// <param name="builder">
   /// The options builder for the database context
   /// </param>
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
   {
      builder.AddCreatedUpdatedInterceptor();
      base.OnConfiguring(builder);
   }

   /// <summary>
   /// On creating the database model 
   /// </summary>
   /// <remarks>
   /// This method is used to create the database model for the application.
   /// </remarks>
   /// <param name="builder">
   /// The model builder for the database context
   /// </param>
   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      
      // Bounded Contexts
      
      // Inventory Bounded Context
      builder.Entity<Thing>().HasKey(i => i.Id);
      builder.Entity<Thing>().Property(i => i.Id).ValueGeneratedOnAdd();
      
      builder.Entity<Thing>().OwnsOne(i => i.SerialNumber, n =>
      {
         n.WithOwner().HasForeignKey("Id");
         n.Property(i => i.Identifier).HasColumnName("SerialNumber");
      });

      builder.Entity<Thing>().Property(i => i.Model).IsRequired();
      
      builder.Entity<Thing>().Ignore(i => i.OperationModeString);
      builder.Entity<Thing>().Property(i => i.OperationMode).HasConversion<string>().IsRequired();
      
      builder.Entity<Thing>().Property(i => i.MaximumTemperatureThreshold).IsRequired();
      builder.Entity<Thing>().Property(i => i.MinimumTemperatureThreshold).IsRequired();
      
      // Apply snake case naming convention
      builder.UseSnakeCaseNamingConvention();
   }
}