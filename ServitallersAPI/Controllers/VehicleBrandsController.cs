using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServitallersAPI.Models;
using ServitallersAPI.Models.Dtos;
using ServitallersAPI.Repository.IRepository;

namespace ServitallersAPI.Controllers
{
    [Route("api/VehicleBrands")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "ServitalleresAPISpecVB")]
    public class VehicleBrandsController : ControllerBase
    {
        private readonly IVehicleBrandRepository _vehicleBrandRepository;
        private readonly IMapper _mapper;

        public VehicleBrandsController(IVehicleBrandRepository vehicleBrandRepository, IMapper mapper)
        {
            _vehicleBrandRepository = vehicleBrandRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene el listado de todos los Vehículos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<VehicleBrandDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetVehicleBrands()
        {
            var objList = _vehicleBrandRepository.GetVehicleBrands();

            var objDto = new List<VehicleBrandDto>();
            foreach (var obj in objList)
            {
             objDto.Add(_mapper.Map<VehicleBrandDto>(obj));   
            }

            return Ok(objDto);
        }

        /// <summary>
        /// Obtiene Vehículo individual.
        /// </summary>
        /// <param name="vehicleBrandId">El ID del Vehículo.</param>
        /// <returns></returns>
        [HttpGet("{vehicleBrandId:int}", Name = "GetVehicleBrand")]
        [ProducesResponseType(200, Type = typeof(VehicleBrandDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetVehicleBrand(int vehicleBrandId)
        {
            var obj = _vehicleBrandRepository.GetVehicleBrand(vehicleBrandId);
            if (obj == null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<VehicleBrandDto>(obj);
            return Ok(objDto);
        }

        /// <summary>
        /// Crea un Nuevo registro de vehículo. 
        /// </summary>
        /// <param name="vehicleBrandDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(VehicleBrandDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateVehicleBrand([FromBody] VehicleBrandDto vehicleBrandDto)
        {
            if (vehicleBrandDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_vehicleBrandRepository.VehicleExists(vehicleBrandDto.Model))
            {
                ModelState.AddModelError("", "¡El vehiculo ya existe!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleBrandObj = _mapper.Map<VehicleBrand>(vehicleBrandDto);

            if (!_vehicleBrandRepository.CreateVehicleBrand(vehicleBrandObj))
            {
                ModelState.AddModelError("", $"¡No se ha podido guardar el vehiculo {vehicleBrandObj.Make} {vehicleBrandObj.Model}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetVehicleBrand", new {vehicleBrandId = vehicleBrandObj.Id}, vehicleBrandObj);
        }

        /// <summary>
        /// Actualiza un registro de vehículo ya guardado en BD.
        /// </summary>
        /// <param name="vehicleBrandId">El ID del Vehículo.</param>
        /// <param name="vehicleBrandDto">El objeto del Vehículo.</param>
        /// <returns></returns>
        [HttpPatch("{vehicleBrandId:int}", Name = "UpdateVehicle")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult UpdateVehicle(int vehicleBrandId, [FromBody] VehicleBrandDto vehicleBrandDto)
        {
            if (vehicleBrandDto == null || vehicleBrandId != vehicleBrandDto.Id)
            {
                return BadRequest();
            }

            var vehicleBrandObj = _mapper.Map<VehicleBrand>(vehicleBrandDto);
            if (!_vehicleBrandRepository.UpdateVehicleBrand(vehicleBrandObj))
            {
                ModelState.AddModelError("", $"¡No se ha podido actualizar el vehiculo {vehicleBrandObj.Make} {vehicleBrandObj.Model}");
                return StatusCode(500, ModelState);

            }

            return NoContent();
        }

        /// <summary>
        /// Elimina un registro de vehículo ya guardado en BD. 
        /// </summary>
        /// <param name="vehicleBrandId">El ID del Vehículo.</param>
        /// <returns></returns>
        [HttpDelete("{vehicleBrandId:int}", Name = "DeleteVehicle")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteVehicle(int vehicleBrandId)
        {
            if (!_vehicleBrandRepository.VehicleBrandExists(vehicleBrandId))
            {
                return NotFound();
            }

            var vehicleBrandObj = _vehicleBrandRepository.GetVehicleBrand(vehicleBrandId);
            if (!_vehicleBrandRepository.DeleteVehicleBrand(vehicleBrandObj))
            {
                ModelState.AddModelError("", $"¡No se ha podido eliminar el vehiculo {vehicleBrandObj.Make} {vehicleBrandObj.Model}");
                return StatusCode(500, ModelState);

            }

            return NoContent();
        }

    }
    
}
