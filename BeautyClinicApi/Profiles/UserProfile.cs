using AutoMapper;
using BeautyClinicApi.Models;
using BeautyClinicApi.DTOs;

namespace BeautyClinicApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Mapping from User to UserDTO
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.ProfilePhoto, opt => opt.MapFrom(src => src.ProfilePhoto))
                // Assuming you have mappings for Order to OrderDTO and Appointment to AppointmentDTO
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments));

            // Mapping from UserDTO to User
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore()) // Usually you don't want to map the ID from DTO to entity
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.ProfilePhoto, opt => opt.MapFrom(src => src.ProfilePhoto))
                // Do not map Orders and Appointments as they are likely managed separately
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ForMember(dest => dest.Appointments, opt => opt.Ignore());
        }
    }
}

