using CQRS_Lib.Models;
using CQRS_Lib.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CQRS.DTOs;
using CQRS.DTOs.Requests;
using CQRS.DTOs.Responce;
using MediatR;
using CQRS_Lib.CQRS.Queries;
using CQRS_Lib.CQRS.Commands;
namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<item> _itemRepository;
        private readonly IMediator _mediator;
        public ItemsController(IRepository<item> itemRepository, IMediator mediator)
        {
            _itemRepository = itemRepository;
            _mediator = mediator;
        }
        [HttpGet("index")]
        public async Task<IActionResult> index(string? name , int Page = 1)
        {
            //var items = await _itemRepository.GetAllasync(Tracke:false);
            var items = await _mediator.Send(new GetAllitemsQuery());

            if(name is not null)
                //items = await _itemRepository.GetAllasync(i=>i.name.Contains(name));
            if (Page <= 0)
                Page = 1;
            int CurruntPage = Page;
            double TotalPage = Math.Ceiling(CurruntPage / 5.0);
            //items = items.Skip((Page - 1)).Take(5);
                
            return Ok(new ItemDTO
            {
                items = items,
                CurruntPage = CurruntPage,
                TotalPages = TotalPage
            });
        }
        [HttpGet("Getone")]
        public async Task<IActionResult> Getone(int id)
        {
            if(id == null &&  id < 0)
                return NotFound();

            var item = await _itemRepository.GetoneAsync(i=>i.id == id);
            if(item is null)
                return NotFound();

            return Ok(new SuccessMassage
            {
                item = item,
                Massege = "Success"
            });
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateItem(item item)
        {
            //if (item is null || item.id == 0)
            //    return BadRequest();
            //await _itemRepository.CreateAsync(item);
            //await _itemRepository.SaveChanges();
          var resulte =  await _mediator.Send(new InsertItemCommand(item));

            return Ok(resulte);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Updateitem(int id ,itemResponse itemresponse)
        {
            //if(itemresponse is null || id == null || id < 0)
            //    return BadRequest("Error");
            var item = await _itemRepository.GetoneAsync(item=>item.id == id);
            if(item is null)
                return BadRequest("this item Out of Stok");
            item = new item
            {
                name = itemresponse.name,
                description = itemresponse.description,
                price = itemresponse.price
            };
            _itemRepository.ubdate(item);
            await _itemRepository.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Deleteitem(int id)
        {
            var item = await _itemRepository.GetoneAsync(i=>i.id == id);
            if(item is null)
                return BadRequest();
            _itemRepository.Delete(item);
            await _itemRepository.SaveChanges();
            return Ok();
        }
    }
}
