/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the �docs� folder for license information on type of purchased license.
*/

using Common.DTO;
using Common.Services.Infrastructure;
using Common.WebApi.Identity;
using System.Threading.Tasks;
using System.Web.Http;

namespace Common.WebApi.Controllers
{
    [RoutePrefix("persons")]
    [Authorize(Roles = Roles.Admin)]
    public class PersonsController : BaseApiController
    {
        protected readonly IPersonService PersonService;

        public PersonsController(IPersonService personService)
        {
            this.PersonService = personService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var result = await PersonService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var person = await PersonService.GetById(id);
            return Ok(person);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create(PersonDTO PersonDto)
        {
            if (PersonDto.Id != 0)
            {
                return BadRequest();
            }

            var result = await PersonService.Edit(PersonDto);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Edit(int id, PersonDTO PersonDto)
        {
            if (id != PersonDto.Id)
                return BadRequest();

            var result = await PersonService.Edit(PersonDto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await PersonService.Delete(id);
            return Ok(result);
        }

    }
}