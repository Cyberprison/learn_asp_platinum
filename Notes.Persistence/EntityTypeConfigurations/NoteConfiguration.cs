using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Notes.Persistence.EntityTypeConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            //айди задали
            builder.HasKey(note => note.Id);

            //уникальное название
            builder.HasIndex(note => note.Id).IsUnique();

            //макс длина
            builder.Property(note => note.Title).HasMaxLength(250);
        }
    }
}
