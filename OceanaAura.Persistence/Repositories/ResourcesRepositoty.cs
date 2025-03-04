using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Persistence;
using OceanaAura.Application.Persistence.LookUp;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Enums;
using OceanaAura.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Persistence.Repositories
{
    public class ResourcesRepositoty : GenericRepository<Resources>, IResourcesRepositoty
    {
        private readonly OeanaAuraDbContext _appDbContext;
        public ResourcesRepositoty(OeanaAuraDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
