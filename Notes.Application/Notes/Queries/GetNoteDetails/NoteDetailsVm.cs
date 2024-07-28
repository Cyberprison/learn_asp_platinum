using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsVm : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap(typeof(Note), GetType());

            profile.CreateMap<Note, NoteDetailsVm>()
                .ForMember(noteVm => noteVm.Title,
                opt => opt.MapFrom(Note => Note.Title))
                .ForMember(noteVm => noteVm.Details,
                opt => opt.MapFrom(Note => Note.Details))
                .ForMember(noteVm => noteVm.Id,
                opt => opt.MapFrom(Note => Note.Id))
                .ForMember(noteVm => noteVm.CreationDate,
                opt => opt.MapFrom(Note => Note.CreationDate))
                .ForMember(noteVm => noteVm.EditDate,
                opt => opt.MapFrom(Note => Note.EditDate)); 
        }
    }
}
