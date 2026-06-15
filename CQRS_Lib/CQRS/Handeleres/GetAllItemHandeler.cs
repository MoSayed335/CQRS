using CQRS_Lib.CQRS.Queries;
using CQRS_Lib.DataAccess;
using CQRS_Lib.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Lib.CQRS.Handeleres
{
    public class GetAllItemHandeler : IRequestHandler<GetAllitemsQuery, List<item>>
    {
       private readonly ApplicationDbContext _db;
        public GetAllItemHandeler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<item>> Handle(GetAllitemsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_db.Items.ToList());
        }
    }
}
