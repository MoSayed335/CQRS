using CQRS_Lib.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Lib.CQRS.Queries
{
    public record GetAllitemsQuery : IRequest<List<item>>;

}
