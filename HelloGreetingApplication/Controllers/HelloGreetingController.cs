using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using NLog;

namespace HelloGreetingApplication.Controllers
{

    /// <summary>
    /// Class Providing API for HelloGreeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        ResponseModel<string> responseModel;

        private readonly IGreetingBL _greetingBL;

        public HelloGreetingController(IGreetingBL greetingBL)
        {
            _greetingBL = greetingBL;
        }

        /// <summary>
        /// This method call the method of BusinessLayer
        /// </summary>
        /// <return>"_greetingBl.GreetMessage()" </return>
        [HttpGet]
        public IActionResult GetMessage(String? FirstName, String? LastName)
        {

            logger.Info($"Get request, greet message first: {FirstName}, last: {LastName}");
            string message = _greetingBL.GreetMessage(FirstName, LastName);
            responseModel = new ResponseModel<string>();
            {
                responseModel.Success = true;
                responseModel.Message = "Successfully";
                responseModel.Data = message;
            }
            return Ok(responseModel);
        }


        private static readonly Logger logger = LogManager .GetCurrentClassLogger();


        /// <summary>
        /// This method calls the method of BusinessLayer to fetch the greeting message by its Id
        /// </summary>
        /// <param name="id">Greeting message Id</param>
        /// <returns>Greeting message for the specified Id</returns>
        [HttpGet]
        [Route("GreetingById")]
        public IActionResult GetGreetingById(int id)
        {
            logger.Info($"Get request for greeting with Id: {id}");

            var greetingMessage = _greetingBL.FindGreetingById(id);

            if (greetingMessage == null)
            {
                responseModel = new ResponseModel<string>
                {
                    Success = false,
                    Message = "Greeting not found",
                    Data = null
                };
                return NotFound(responseModel);
            }

            responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting found",
                Data = greetingMessage.Message
            };

            return Ok(responseModel);
        }


        /// <summary>
        /// This is Get Method
        /// </summary>
        /// <return>"Hello, World" </return>

        [HttpGet]
        [Route("Get Method")]
        public IActionResult Get()
        {
            logger.Info("Get request recieve");
            responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Hello to Greeting App API Endpoint Hit";
            responseModel.Data = "Hello, World";
            return Ok(responseModel);
        }

        /// <summary>
        /// This is Post Method
        /// </summary>
        /// <return>"Add Successfully or Exception Raised" </return>
        
        [HttpPost]
        [Route("Post Method")] 
        public IActionResult Post(RequestModel requestModel) 
        {
            logger.Info($"Post request| key: {requestModel.key}, value: {requestModel.value}");
            responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Hello this is post";
            responseModel.Data = $"key: {requestModel.key}, value: {requestModel.value}";
            return Ok(responseModel);
        }

        /// <summary>
        /// This is Put Method
        /// </summary>
        /// <return>"Data updated" </return>
        
        [HttpPut]
        [Route("Put Method")]
        public IActionResult Put(RequestModel requestModel) 
        {
            logger.Info($"Put request recieved, update: {requestModel.value}");
            responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Hello I am put";
            responseModel.Data = requestModel.value;
            return Ok(responseModel);
        }

        /// <summary>
        /// This is Patch Method
        /// </summary>
        /// <return>"Data updated" </return>

        [HttpPatch]
        [Route("Patch Method")]
        public IActionResult Patch(RequestModel requestModel) 
        {
            logger.Info($"Patch request recieved, modifying: {requestModel.value}");
            responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Hello I am patch";
            responseModel.Data = requestModel.value;
            return Ok(responseModel);
        }

        /// <summary>
        /// This is Delete Method
        /// </summary>
        /// <return>"Deleted Successfully" </return>
        
        [HttpDelete]
        [Route("Delete Method")]
        public IActionResult Delete(RequestModel requestModel) 
        {
            logger.Info($"delete request recieved, delete: {requestModel.key}");
            responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Hello I am Delete";
            responseModel.Data = null;
            return Ok(responseModel);
        }

        /// <summary>
        /// Method to list all the greeting messages
        /// </summary>
        /// <returns>List of messages</returns>
        [HttpGet]
        [Route("list of greeting")]
        public IActionResult GetAllGreetings()
        {
            var greetings = _greetingBL.GetAllGreetings();
            return Ok(greetings);
        }

    }
}
