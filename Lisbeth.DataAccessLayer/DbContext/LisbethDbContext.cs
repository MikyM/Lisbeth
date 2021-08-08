using System;
using Lisbeth.Domain.Entities;
using Lisbeth.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
#nullable enable

namespace Lisbeth.DataAccessLayer.DbContext
{
    public sealed class LisbethDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public LisbethDbContext(DbContextOptions<LisbethDbContext> options) : base(options)
        {
            ChangeTracker.StateChanged += OnEntityStateChanged;
        }

        public DbSet<TestEntity> TestEntities { get; set; }

        private static void OnEntityStateChanged(object? sender, EntityStateChangedEventArgs e)
        {
            if (e.NewState == EntityState.Modified && e.Entry.Entity is Entity entity)
                e.Entry.CurrentValues["UpdatedAt"] = DateTime.UtcNow;
        }
    }
}
