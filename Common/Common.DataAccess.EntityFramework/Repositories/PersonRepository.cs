/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the �docs� folder for license information on type of purchased license.
*/

using Common.Entities;
using Common.Services.Infrastructure;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Common.DataAccess.EntityFramework
{
    public class PersonRepository : BaseDeletableRepository<Person, DataContext>, IPersonRepository<Person>
    {
        public override async Task<Person> Edit(Person obj, ContextSession session)
        {
            var objectExists = await Exists(obj, session, true);
            using (var context = GetContext(session))
            {
                context.Entry(obj).State = objectExists ? EntityState.Modified : EntityState.Added;

                await context.SaveChangesAsync();
                return obj;
            }
        }

        public override async Task<Person> Get(int id, ContextSession session, bool includeDeleted = false)
        {
            using (var context = GetContext(session))
            {
                return await GetEntities(context, includeDeleted)
                    .Where(obj => obj.Id == id)
                    .FirstOrDefaultAsync();
            }
        }

        public override async Task<IEnumerable<Person>> GetList(ContextSession session, bool includeDeleted)
        {
            using (var context = GetContext(session))
            {
                return await GetEntities(context, includeDeleted).ToListAsync();
            }
        }

    }
}
