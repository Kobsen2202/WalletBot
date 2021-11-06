using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WalletBot;
using WalletBot.Entities;

namespace WalletBot.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController: ControllerBase
    {
        private readonly DataContext _context;

        public AdminController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            var result = await _context.Categories.AddAsync(category);
            return Ok(result.Entity.Id);
        }
    }
}