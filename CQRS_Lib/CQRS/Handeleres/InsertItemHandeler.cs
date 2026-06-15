using CQRS_Lib.CQRS.Commands;
using CQRS_Lib.DataAccess;
using CQRS_Lib.Models;
using CQRS_Lib.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Lib.CQRS.Handeleres
{
    public class InsertItemHandeler : IRequestHandler<InsertItemCommand, item>
    {
        private readonly ApplicationDbContext _db;

        public InsertItemHandeler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<item> Handle(InsertItemCommand request, CancellationToken cancellationToken)
        {
           await _db.AddAsync(request.item);
            _db.SaveChanges();
            return await Task.FromResult(request.item);
        }
    }
}
