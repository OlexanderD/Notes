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
            userbuilder.HasMany(x => x.Notes)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }

    }
}
