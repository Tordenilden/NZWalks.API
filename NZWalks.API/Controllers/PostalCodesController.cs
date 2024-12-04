﻿using AutoMapper;
using DAL.Models.DTO;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostalCodesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPostalCodeRepository postalCodeRepository;

        public PostalCodesController(IMapper mapper, IPostalCodeRepository postalCodeRepository)
        {
            this.mapper = mapper;
            this.postalCodeRepository = postalCodeRepository;
        }

        // GET PostalCode
        // GET: /api/PostalCode

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postalCodesDomainModel = await postalCodeRepository.GetAllAsync();

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<PostalCodeDto>>(postalCodesDomainModel));
        }

        // Get PostalCode By Id
        // GET; /api/PostalCodes/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var postalCodeDomainModel = await postalCodeRepository.GetByIdAsync(id);

            if (postalCodeDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain Model to DTO
            return Ok(mapper.Map<PostalCodeDto>(postalCodeDomainModel));
        }
    }
}
