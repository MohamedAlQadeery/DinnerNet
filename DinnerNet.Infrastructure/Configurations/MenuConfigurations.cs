using DinnerNet.Domain.HostAggregate.ValueObjects;
using DinnerNet.Domain.MenuAggregate;
using DinnerNet.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DinnerNet.Infrastructure.Configurations;
public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewsIdsTable(builder);

    }



    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {

        builder.ToTable("Menus");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => MenuId.Create(value));

        builder.Property(m => m.Name)
                .HasMaxLength(100);
        builder.Property(m => m.Description)
                .HasMaxLength(100);

        builder.OwnsOne(m => m.AverageRating);
        builder.Property(m => m.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value)
                );


    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, msb =>
        {
            msb.ToTable("MenuSections");
            msb.WithOwner().HasForeignKey("MenuId");
            msb.HasKey("Id", "MenuId");

            msb.Property(ms => ms.Id)
                .ValueGeneratedNever()
                .HasColumnName("MenuSectionId")
                .HasConversion(id => id.Value,
                 value => MenuSectionId.Create(value));


            msb.Property(ms => ms.Name)
             .HasMaxLength(100);
            msb.Property(ms => ms.Description)
                    .HasMaxLength(100);

            msb.OwnsMany(ms => ms.Items, mib =>
            {
                mib.ToTable("MenuItems");
                mib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
                mib.HasKey("Id", "MenuSectionId", "MenuId");
                mib.Property(ms => ms.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("MenuItemId")
                    .HasConversion(id => id.Value,
                     value => MenuItemId.Create(value));

                mib.Property(ms => ms.Name)
                   .HasMaxLength(100);
                mib.Property(ms => ms.Description)
                        .HasMaxLength(100);

            });

            msb.Navigation(s => s.Items).Metadata.SetField("_items");
            msb.Navigation(s => s.Items)
            .UsePropertyAccessMode(PropertyAccessMode.Field);




        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

    }


    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dib =>
        {
            dib.ToTable("MenuDinnerIds");
            dib.WithOwner().HasForeignKey("MenuId");
            dib.HasKey("Id");
            dib.Property(d => d.Value)
              .HasColumnName("DinnerId")
              .ValueGeneratedNever();



        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewsIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Reviews, mrb =>
        {
            mrb.ToTable("MenuReviewIds");
            mrb.WithOwner().HasForeignKey("MenuId");
            mrb.HasKey("Id");

            mrb.Property(d => d.Value)
              .HasColumnName("MenuReviewId")
              .ValueGeneratedNever();



        });
        builder.Metadata.FindNavigation(nameof(Menu.Reviews))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

}