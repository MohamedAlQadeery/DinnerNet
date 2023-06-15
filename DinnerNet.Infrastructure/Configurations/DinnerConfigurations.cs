using DinnerNet.Domain.BillAggregate.ValueObjects;
using DinnerNet.Domain.DinnerAggregate;
using DinnerNet.Domain.DinnerAggregate.Enums;
using DinnerNet.Domain.DinnerAggregate.ValueObjects;
using DinnerNet.Domain.GuestAggregate.ValueObjects;
using DinnerNet.Domain.HostAggregate.ValueObjects;
using DinnerNet.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DinnerNet.Infrastructure.Configurations;

public class DinnerConfigurations : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigureDinnersTable(builder);
        ConfigureDinnerReservationsTable(builder);
    }



    private void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.ToTable("Dinners");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(d => d.Name)
                .HasMaxLength(100);

        builder.Property(d => d.Description)
                .HasMaxLength(100);


        builder.Property(d => d.HostId)
               .HasConversion(
                   id => id.Value,
                   value => HostId.Create(value));

        builder.Property(d => d.MenuId)
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value));

        builder.Property(d => d.Status)
                .HasConversion(status => status.Value,
                 value => DinnerStatus.FromValue(value));


        builder.OwnsOne(d => d.Price, pb =>
        {
            pb.Property(p => p.Value)
            .HasColumnType("decimal(10,4)");
        });
        builder.OwnsOne(d => d.Location);

    }

    private void ConfigureDinnerReservationsTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.OwnsMany(d => d.Reservations, drb =>
        {
            drb.ToTable("DinnerReservations");
            drb.WithOwner().HasForeignKey("DinnerId");

            drb.HasKey("DinnerId", "Id");
            drb.Property(r => r.Id)
                .ValueGeneratedNever()
                .HasColumnName("ReservationId")
                .HasConversion(id => id.Value,
                value => ReservationId.Create(value));


            drb.Property(r => r.GuestId)
                .HasConversion(
                    id => id.Value,
                    value => GuestId.Create(value));

            drb.Property(r => r.BillId)
               .HasConversion(
                   id => id.Value,
                   value => BillId.Create(value));


            drb.Property(r => r.Status)
                .HasConversion(status => status.Value,
                value => ReservationStatus.FromValue(value));



        });

        builder.Metadata.FindNavigation(nameof(Dinner.Reservations))!
                        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}