using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniversalForm.Domain.Entities;
using UniversalForm.Domain.Entities.Manager;

namespace UniversalForm.EF
{
    /// <summary>
    /// 
    /// </summary>
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {

        }

        public DbSet<T_Form> T_Form { get; set; }

        public DbSet<T_Menu> T_Menu { get; set; }

        public DbSet<T_RolePermission> T_RolePermission { get; set; }

        public DbSet<T_Manager_Role> T_Manager_Role { get; set; }

        public DbSet<T_Manager> T_Manager { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //设置Id为主键
            builder.Entity<T_Form>()
                .HasKey(t => new { t.ID });
            builder.Entity<T_Menu>()
                .HasKey(t => new { t.ID });
            builder.Entity<T_RolePermission>()
                .HasKey(t => new { t.ID });
            builder.Entity<T_Manager_Role>()
                .HasKey(t => new { t.ID });
            builder.Entity<T_Manager>()
                .HasKey(t => new { t.ID });

            base.OnModelCreating(builder);
        }
    }
}
