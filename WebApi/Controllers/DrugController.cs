using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Repositories;
using WebApi.Repository;

namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DrugController : ControllerBase
    {
        private readonly ILogger<Drug> logger;
        private readonly IDrugRepository repository;

        public DrugController(ILogger<Drug> logger, IDrugRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            try
            {
                var drugs = repository.GetAll();
                return Ok(drugs.ToArray());
            }
            catch (Exception e)
            {
                logger.LogError(e,"BadRequest");
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetByCode")]
        public IActionResult GetByCode(string code)
        {
            var drugs =  repository.GetByCode(code);
            return Ok(drugs.ToArray());
        }

        [HttpGet]
        [Route("GetByLabel")]
        public IActionResult GetByLabel(string label)
        {
            var drugs =  repository.GetByLabel(label);
            return Ok(drugs.ToArray());
        }

        /// <summary>
        /// Deletes an item by code
        /// </summary>
        /// <param name="drug"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromBody] Drug drug)
        {
            try
            {
                repository.Delete(drug);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Update an existing item 
        /// </summary>
        /// <param name="drug"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] Drug drug)
        {
            try
            {
                repository.Update(drug);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Adds mew item
        /// </summary>
        /// <param name="drug"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] Drug drug)
        {
            try
            {
                repository.Insert(drug);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
        }
    }
}
