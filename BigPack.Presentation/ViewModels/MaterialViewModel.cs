using AutoMapper;
using BigPack.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigPack.Presentation.ViewModels
{
    internal class MaterialViewModel
    {
        public string MaterialName { get; set; }
        
        public string MaterialTypeName { get; set; }
        
        public string SuppliersNames { get; set; }
        
        public int CountInStock { get; set; }
        
        public int MinCount { get; set; }
    }

    internal class MaterialViewModelProfiler : Profile
    {
        public MaterialViewModelProfiler()
        {
            CreateMap<MaterialModel, MaterialViewModel>()
                .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.MaterialTypeName, opt => opt.MapFrom(src => src.MaterialType.Title))
                //.ForMember(dest => dest.SuppliersNames, opt => opt.MapFrom(src => string.Concat(src.Suppliers.Select(x => x.Title))))
                .ForMember(dest => dest.CountInStock, opt => opt.MapFrom(src => src.CountInStock))
                .ForMember(dest => dest.MinCount, opt => opt.MapFrom(src => src.MinCount))
                .ForMember(dest => dest.SuppliersNames, opt => opt.Ignore());
        }
    }
}
