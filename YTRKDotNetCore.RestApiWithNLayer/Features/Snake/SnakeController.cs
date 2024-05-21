using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace YTRKDotNetCore.RestApiWithNLayer.Features.Snake
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnakeController : ControllerBase
    {
        private async Task<SnakeData[]> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("Snakes.json");

            var model = JsonConvert.DeserializeObject<SnakeData[]>(jsonStr);
            return model!;
        }

        [HttpGet("snakeList")]
        public async Task<IActionResult> SnakeLists()
        {
            var model = await GetDataAsync();
            return Ok(model);
        }

        [HttpGet("snakeDetail/{id}")]
        public async Task<IActionResult> SnakeDetail(int id)
        {
            var model = await GetDataAsync();
            var result = model.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound("No data fount");
            }
            return Ok(result);
        }
    }
}


public class SnakeModelDTO
{
    public SnakeData[] data { get; set; }
}

public class SnakeData
{
    public int Id { get; set; }
    public string MMName { get; set; }
    public string EngName { get; set; }
    public string Detail { get; set; }
    public string IsPoison { get; set; }
    public string IsDanger { get; set; }
}
