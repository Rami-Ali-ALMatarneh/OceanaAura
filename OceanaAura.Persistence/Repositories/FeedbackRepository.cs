using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Persistence;
using OceanaAura.Application.Persistence.LookUp;
using OceanaAura.Domain.Entities;
using OceanaAura.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Persistence.Repositories
{
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        private readonly OeanaAuraDbContext _appDbContext;
        public FeedbackRepository(OeanaAuraDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Feedback>> GetVisibilityFeedback()
        {
           return await _appDbContext.feedbacks.Where(x=>x.IsShow == true).AsNoTracking().ToListAsync();
        }
    }
}
