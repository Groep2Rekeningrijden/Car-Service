﻿using CarMicroService.DTOs.CarType;

namespace CarMicroService.DTOs.Car
{
    public class GetCarDTO
    {
        public Guid Id { get; set; } 

        public string Name { get; set; }    

        public string Description { get; set; }     

        public GetCarTypeDTO CarType { get; set; }   

    }
}
