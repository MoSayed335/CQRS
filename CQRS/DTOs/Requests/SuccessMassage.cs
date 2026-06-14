using CQRS_Lib.Models;

namespace CQRS.DTOs.Requests
{
    public class SuccessMassage
    {
        public item item { get; set; }
        public string Massege { get; set; }
    }
}
