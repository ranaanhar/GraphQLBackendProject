using GraphQLBackend.Data;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ILogger<HomeController> _logger;
        private Database _database;
        
        public HomeController(ILogger<HomeController>logger,Database database)
        {
            _logger = logger;
            _database = database;
        }

        [HttpGet]
        public IActionResult Get(){
            try
            {
                var query=_database.Books.Select(i=>i);
                if(query!=null){
                    _logger.LogInformation("count : {0}",query.Count());
                }else{
                    _logger.LogInformation("query is null");
                }
            }
            catch (System.Exception exp)
            {
                _logger.LogError("{0}",exp);                
            }
            return Ok("Home Controller");
        }
    }
}
