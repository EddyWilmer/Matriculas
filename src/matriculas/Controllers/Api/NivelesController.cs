﻿using AutoMapper;
using Matriculas.Models;
using Matriculas.Queries.Core.Repositories;
using Matriculas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriculas.Controllers.Api
{
    [Route("api/v2/[controller]")]
    public class NivelesController : Controller
    {
        private ILogger<NivelesController> _logger;
        private IAppRepository _repository;

        public NivelesController(IAppRepository repository, ILogger<NivelesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Recuperando la lista de niveles.");
                var results = _repository.Niveles.GetAll();
                return Ok(Mapper.Map<IEnumerable<NivelViewModel>>(results));
            }
            catch (Exception ex)
            {
                _logger.LogError($"No se pudo recuperar los niveles: {ex}");
                return BadRequest("No se pudo recuperar la información.");
            }
            
        }
    }
}
