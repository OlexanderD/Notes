using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Data.Data.Models.Configurations
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userbuilder)
        {
            userbuilder.HasKey(x => x.Id);

            userbuilder.Property(x=>x.UserName).IsRequired();

            userbuilder.Property(x=> x.Password).IsRequired();

            userbuilder.HasMany(x => x.notes);
        }

    }
}
