/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DTO;
using Common.Entities;
using Common.Services.Infrastructure;
using Common.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services
{
    public class PersonService<TPerson> : BaseService, IPersonService where TPerson : Person, new()
    {
        protected readonly IPersonRepository<TPerson> PersonRepository;

        public PersonService(ICurrentContextProvider contextProvider, IPersonRepository<TPerson> personRepository) : base(contextProvider)
        {
            this.PersonRepository = personRepository;
        }

        public async Task<bool> Delete(int id)
        {
            await PersonRepository.Delete(id, Session);
            return true;
        }

        public async Task<PersonDTO> Edit(PersonDTO dto)
        {
            var person = dto.MapTo<TPerson>();
            await PersonRepository.Edit(person, Session);
            return person.MapTo<PersonDTO>();
        }

        public async Task<IList<PersonDTO>> GetAll(bool includeDeleted = false)
        {
            IEnumerable<TPerson> list = await PersonRepository.GetList(Session, includeDeleted);

            IList<PersonDTO> listDTO = new List<PersonDTO>();
            foreach (Person person in list)
            {
                listDTO.Add(person.MapTo<PersonDTO>());
            }

            return listDTO;
        }

        public async Task<PersonDTO> GetById(int id, bool includeDeleted = false)
        {
            var Person = await PersonRepository.Get(id, Session, includeDeleted);
            return Person.MapTo<PersonDTO>();
        }

    }
}