using MakeAWish.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MakeAWish.DataConfig
{
    public class ToDoConfig : EntityTypeConfiguration<ToDoModel>
    {
        public ToDoConfig()
        {
            ToTable("ToDoList");
            Property(p => p.id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.label).IsRequired();
            Property(p => p.state).IsRequired();
            Property(p => p.resourceId).IsRequired();
            Property(p => p.hex).IsOptional();
            Property(p => p.tags).IsOptional();
        }
    }
}