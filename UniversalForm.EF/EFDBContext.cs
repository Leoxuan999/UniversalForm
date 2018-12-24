using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniversalForm.Domain.Entities;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //设置Id为主键
            //builder.Entity<Activity>()
            //    .HasKey(t => new { t.Id });

            base.OnModelCreating(builder);
        }
    }
}
