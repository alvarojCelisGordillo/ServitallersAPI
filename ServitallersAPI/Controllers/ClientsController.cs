using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using ServitallersAPI.Models;
using ServitallersAPI.Models.Dtos;
using ServitallersAPI.Repository.IRepository;

namespace ServitallersAPI.Controllers
{
    [Route("api/Clients")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "ServitalleresAPISpecClients")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _imapper;

        public ClientsController(IClientRepository clientRepository, IMapper imapper)
        {
            _clientRepository = clientRepository;
            _imapper = imapper;
        }


        [HttpGet]
        public IActionResult GetClients()
        {
            var objList = _clientRepository.GetClients();

            var objDto = new List<ClientDto>();
            foreach (var obj in objList)
            {
                objDto.Add(_imapper.Map<ClientDto>(obj));
            }

            return Ok(objDto);
        }

        [HttpGet("{clientId:int}", Name = "GetClient")]
        [Authorize]
        public IActionResult GetClient(int clientId)
        {
            var obj = _clientRepository.GetClient(clientId);

            if (obj == null)
            {
                return NotFound();
            }

            var objDto = _imapper.Map<ClientDto>(obj);

            return Ok(objDto);
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientDto clientDto)
        {
            if (clientDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_clientRepository.ClientExists(clientDto.NumberOfIdentification))
            {
                ModelState.AddModelError("", "¡Este cliente ya existe!");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientObj = _imapper.Map<Client>(clientDto);
            if (!_clientRepository.CreateClient(clientObj))
            {
                ModelState.AddModelError("", $"¡No se ha podido guardar el Cliente {clientObj.FirstName} {clientObj.FirstLastName} con numero de cedula {clientObj.NumberOfIdentification}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetClient", new {clientId = clientObj.NumberOfIdentification}, clientObj);
        }

        [HttpPatch("{clientId:int}", Name = "UpdateClient")]
        public IActionResult UpdateClient(int clientId, [FromBody] ClientDto clientDto)
        {
            if (clientDto == null || clientId != clientDto.Id)
            {
                return BadRequest();
            }

            var clientObj = _imapper.Map<Client>(clientDto);
            if (!_clientRepository.UpdateClient(clientObj))
            {
                ModelState.AddModelError("", 
                    $"¡No se ha podido actualizar el Cliente {clientObj.FirstName} " + $"{clientObj.FirstLastName} con numero de cedula {clientObj.NumberOfIdentification}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{clientId:int}", Name = "DeleteClient")]
        public IActionResult DeleteClient(int clientId)
        {
            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            var clientObj = _clientRepository.GetClient(clientId);

            if (!_clientRepository.DeleteClient(clientObj))
            {
                ModelState.AddModelError("", $"¡No se ha podido eliminar el Cliente {clientObj.FirstName} {clientObj.FirstLastName} " + $"con numero de cedula {clientObj.NumberOfIdentification}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
