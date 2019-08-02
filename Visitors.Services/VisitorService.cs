﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visitors.Data;
using Visitors.Domain;
using Visitors.Services.Contracts;
using Visitors.Services.DTO;

namespace Visitors.Services
{
    public class VisitorService: IVisitorService
    {
        private readonly IRepository<Visitor> repository;

        public VisitorService(IRepository<Visitor> repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<DeltaItem>> GetDelta()
        {
            return await repository.TableNoTracking
                .Select(v => new DeltaItem() { Id = v.Id, DeltaTime = Convert.ToInt32((v.LastEnterDate - v.CreateDate).TotalSeconds) })
                .ToListAsync();
        }
    }
}
