
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpinxTask.Core.Models;

namespace SpinxTask.Core.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(i => i.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(i => i.Description)
                .HasMaxLength(150)
                .IsRequired();


            builder
                .HasMany(i => i.Clients)
                .WithMany(i=>i.Products)
                .UsingEntity<ClientProduct>(
                    cp =>
                    {
                        cp
                        .HasKey(i => new { i.ProductId, i.ClientId });

                        cp
                        .HasOne(i => i.Product)
                        .WithMany(ii=>ii.ClientProducts)
                        .HasForeignKey(iii=>iii.ProductId)
                        .OnDelete(deleteBehavior:DeleteBehavior.Restrict);

                        cp
                        .HasOne(i => i.Client)
                        .WithMany(ii => ii.ClientProducts)
                        .HasForeignKey(iii => iii.ClientId);


                        cp
                        .Property(i => i.License)
                        .HasMaxLength(255);

                    }
                );

        }
    }
}
