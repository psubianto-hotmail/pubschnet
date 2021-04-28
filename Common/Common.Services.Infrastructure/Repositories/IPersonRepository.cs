/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IPersonRepository<TPerson> where TPerson : Person
    {
        Task Delete(int id, ContextSession session);
        Task<IEnumerable<TPerson>> GetList(ContextSession session, bool includeDeleted = false);
        Task<TPerson> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TPerson> Edit(TPerson person, ContextSession session);
    }
}
