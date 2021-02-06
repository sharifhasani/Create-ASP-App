using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Create_Asp_App.Data.Context
{
    public class CreateAspAppDbContext : DbContext
    {
        CreateAspAppDbContext(DbContextOptions<CreateAspAppDbContext> options) : base(options)
        {

        }

        #region Tables DbSet



        #endregion


        #region Override Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Delete Cascade Delete for tables
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            #region Query Filter

            // Sample Query Filter
            //modelBuilder.Entity<TEntity>()
            //    .HasQueryFilter(t => !t.IsDelete);

            #endregion

            #region Fluent API

            // Sample Fluent Api
            //modelBuilder.Entity<TEntity>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Name).IsRequired();
            //    entity.HasOne(d => d.Username)
            //        .WithMany(p => p.Phone);
            //});

            #endregion

        }


        #endregion

    }
}
