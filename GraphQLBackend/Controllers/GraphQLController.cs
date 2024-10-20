using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using GraphQLBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private ILogger<GraphQLController> _logger;
        private ISchema _schema;
        private IDocumentExecuter _executer;
        private IGraphQLTextSerializer _serializer;
        public GraphQLController(ILogger<GraphQLController> logger, ISchema schema, IDocumentExecuter executer, IGraphQLTextSerializer serializer)
        {
            _logger = logger;
            _schema = schema;
            _executer = executer;
            _serializer = serializer;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var variables = _serializer.Deserialize<Inputs>(request.variables);
                    var executedResult = await _executer.ExecuteAsync(option =>
                    {
                        option.Schema = _schema;
                        option.Query = request.query;
                        option.OperationName = request.operationName;
                        option.Variables = variables;
                    });

                    if (executedResult.Errors != null && executedResult.Errors.Count > 0)
                    {
                        _logger.LogInformation("{0}", executedResult.Errors[0]);
                        return BadRequest("query error");
                    }

                    var result = _serializer.Serialize(executedResult);
                    return Ok(result);
                }
                catch (Exception exp)
                {
                    _logger.LogInformation(exp.Message, exp);
                }
            }
            return BadRequest("Inputs is Invalid");
        }
    }
}
