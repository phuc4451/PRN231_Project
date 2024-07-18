using AutoMapper;
using Project_PRN231_API.Models;
using Project_PRN231_API.ViewModel;
using System.Runtime.InteropServices;

namespace Project_PRN231_API.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Role, RoleVM>()
                .ForMember(dest => dest.RoleID, otp => otp.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.RoleName, otp => otp.MapFrom(src => src.RoleName)).ReverseMap(); ;

            CreateMap<User, UserVM>()
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
              .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
              .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
              .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId)).ReverseMap(); ;

            CreateMap<Crop, CropVM>()
                .ForMember(dest => dest.CropId, otp => otp.MapFrom(src => src.CropId))
                .ForMember(dest => dest.CropName, otp => otp.MapFrom(src => src.CropName))
                .ForMember(dest => dest.CropType, otp => otp.MapFrom(src => src.CropType))
                .ForMember(dest => dest.Status, otp => otp.MapFrom(src => src.Status)).ReverseMap(); ;

            CreateMap<CareProcess, CareProcessVM>()
                .ForMember(dest => dest.CareProcessId, otp => otp.MapFrom(src => src.CareProcessId))
                .ForMember(dest => dest.CropId, otp => otp.MapFrom(src => src.CropId))
                .ForMember(dest => dest.UserId, otp => otp.MapFrom(src => src.UserId))
                .ForMember(dest => dest.TaskDescription, otp => otp.MapFrom(src => src.TaskDescription))
                .ForMember(dest => dest.DueDate, otp => otp.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.CompletionStatus, otp => otp.MapFrom(src => src.CompletionStatus))
                .ForMember(dest => dest.CompletionDate, otp => otp.MapFrom(src => src.CompletionDate))
                .ForMember(dest => dest.MaterialsUsed, otp => otp.MapFrom(src => src.MaterialsUsed))
                .ReverseMap();

            CreateMap<PlantProcess, PlantProcessVM>()
            .ForMember(dest => dest.PlantProcessId, opt => opt.MapFrom(src => src.PlantProcessId))
            .ForMember(dest => dest.CropId, opt => opt.MapFrom(src => src.CropId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.PlantingDate, opt => opt.MapFrom(src => src.PlantingDate))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.ExpectedHarvestDate, opt => opt.MapFrom(src => src.ExpectedHarvestDate))
            .ReverseMap();

            CreateMap<HarvestProcess, HarvestProcessVM>()
                .ForMember(dest => dest.HarvestProcessId, opt => opt.MapFrom(src => src.HarvestProcessId))
                .ForMember(dest => dest.CropId, opt => opt.MapFrom(src => src.CropId))
                .ForMember(dest => dest.HarvestDate, opt => opt.MapFrom(src => src.HarvestDate))
                .ForMember(dest => dest.QuantityHarvested, opt => opt.MapFrom(src => src.QuantityHarvested))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)).ReverseMap();

            CreateMap<StorageAllocation, StorageAllocationVM>()
            .ForMember(dest => dest.StorageAllocationId, opt => opt.MapFrom(src => src.StorageAllocationId))
            .ForMember(dest => dest.HarvestProcessId, opt => opt.MapFrom(src => src.HarvestProcessId))
            .ForMember(dest => dest.StorageId, opt => opt.MapFrom(src => src.StorageId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ReverseMap();

            CreateMap<Storage, StorageVM>()
            .ForMember(dest => dest.StorageId, opt => opt.MapFrom(src => src.StorageId))
            .ForMember(dest => dest.StorageName, opt => opt.MapFrom(src => src.StorageName))
            .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
            .ReverseMap();

            CreateMap<SaleProcess, SaleProcessVM>()
            .ForMember(dest => dest.SaleProcessId, opt => opt.MapFrom(src => src.SaleProcessId))
            .ForMember(dest => dest.StorageId, opt => opt.MapFrom(src => src.StorageId))
            .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => src.SaleDate))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.Destination))
            .ReverseMap();

        }
    }
}
