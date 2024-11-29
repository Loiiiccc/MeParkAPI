using Mapster;
using MeParkAPI.Models;
using MeParkAPI.Models.DTOs.ParkingDTO;
using MeParkAPI.Models.DTOs.VehiculeDTO;
using Microsoft.AspNetCore.Identity;
using System;

namespace MeParkAPI.Mapper
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Vehicle, AllVehiclesDto>
                .NewConfig()
                .Map(dest => dest.Owner, src => src.Owner.UserName);

            TypeAdapterConfig<Vehicle, AddVehicleDto>
                .NewConfig();

            TypeAdapterConfig<Vehicle, UpdateVehicleDto>
                .NewConfig();

            TypeAdapterConfig<Parking, UpdateParkingDto>
                .NewConfig();
            //TypeAdapterConfig<Student, AllStudentsDTO>
            //    .NewConfig()
            //    .Map(dest => dest.Classes, src => src.Classes)
            //    .Map(dest => dest.Courses, src => src.Courses);

            //TypeAdapterConfig<Course, AllCoursesDTO>
            //    .NewConfig()
            //    .Map(dest => dest.TeachersForCourse, src => src.TeachersForCourse);

            //TypeAdapterConfig<UserForRegistrationDto, IdentityUser>
            //    .NewConfig()
            //    .Map(dest => dest.UserName, src => src.Email);
        }
    }
}
