using CQRS_Lib.Models;

namespace CQRS.DTOs
{
    public class ItemDTO
    {
        public IEnumerable<item> items { get; set; }
        public int CurruntPage { get; set; }
        public double TotalPages { get; set; }
    }
}
