﻿using LM.Application.Persistence.Contracts;
using LM.Domain;

namespace LM.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveTypeRepository(LeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
