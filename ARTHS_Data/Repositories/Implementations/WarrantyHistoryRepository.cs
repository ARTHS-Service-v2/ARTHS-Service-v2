﻿using ARTHS_Data.Entities;
using ARTHS_Data.Repositories.Interfaces;

namespace ARTHS_Data.Repositories.Implementations
{
    public class WarrantyHistoryRepository : Repository<WarrantyHistory>, IWarrantyHistoryRepository
    {
        public WarrantyHistoryRepository(ARTHS_DBContext context) : base(context)
        {
        }
    }
}
