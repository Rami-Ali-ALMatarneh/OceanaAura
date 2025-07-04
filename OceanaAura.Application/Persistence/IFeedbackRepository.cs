﻿using OceanaAura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Persistence
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
       Task<List<Feedback>> GetVisibilityFeedback();
    }
}
