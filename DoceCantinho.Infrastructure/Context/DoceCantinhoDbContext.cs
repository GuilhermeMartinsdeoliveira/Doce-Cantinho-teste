
using DoceCantinho.Domain.Entities;
using DoceCantinho.Domain.Interfaces;

using DoceCantinho.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoceCantinho.Infrastructure.Context
{
    public class DoceCantinhoDbContext : IdentityDbContext
    {
        public DoceCantinhoDbContext(DbContextOptions<DoceCantinhoDbContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// DbSet que representa a tabela de Doces no banco de dados.
        /// </summary>
        public DbSet<Doce> Doces { get; set; }

        /// <summary>
        /// DbSet que representa a tabela de Categories no banco de dados.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoceConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

    }
}
