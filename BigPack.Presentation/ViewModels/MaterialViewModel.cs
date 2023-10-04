using AutoMapper;
using BigPack.Db;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace BigPack.Presentation.ViewModels
{
    internal class MaterialViewModel
    {
        public string MaterialName { get; set; }

        public string MaterialTypeName { get; set; }

        public IEnumerable<string> SuppliersNamesArray { get; set; }

        private string suppliersNames;

        public string SuppliersNames
        {
            get => string.Join(", ", SuppliersNamesArray);  
       
            set =>this.SuppliersNames = value;
        }
        

        public int CountInStock { get; set; }

        public int MinCount { get; set; }

        public StickyNoteControl MyProperty { get; set; }
    }

    internal class MaterialViewModelProfiler : Profile
    {
        public MaterialViewModelProfiler()
        {
            CreateMap<MaterialModel, MaterialViewModel>()
                .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.MaterialTypeName, opt => opt.MapFrom(src => src.MaterialType.Title))
                .ForMember(dest => dest.SuppliersNamesArray, opt => opt.MapFrom(src => src.Suppliers.Select(x => x.Title)))
                .ForMember(dest => dest.CountInStock, opt => opt.MapFrom(src => src.CountInStock))
                .ForMember(dest => dest.SuppliersNames, opt => opt.Ignore())
                .ForMember(dest => dest.MinCount, opt => opt.MapFrom(src => src.MinCount));
        }
    }
}