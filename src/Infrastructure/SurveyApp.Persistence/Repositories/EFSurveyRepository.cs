﻿using SurveyApp.Application.Interfaces;
using SurveyApp.Domain.Entities;
using SurveyApp.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.Repositories
{
    public class EFSurveyRepository : EFGenericRepository<Survey>, ISurveyRepository
    {
        public EFSurveyRepository(AppDbContext context) : base(context)
        {
        }
    }
}