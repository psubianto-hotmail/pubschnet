/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IPersonService
    {
        Task<IList<PersonDTO>> GetAll(bool includeDeleted = false);
        Task<PersonDTO> GetById(int id, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<PersonDTO> Edit(PersonDTO dto);
    }
}