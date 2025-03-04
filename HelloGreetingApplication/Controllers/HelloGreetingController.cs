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
        private readonly IGreetingBL _greetingBl;

        public HelloGreetingController(IGreetingBL greetingBL)
        {
            _greetingBl = greetingBL;
        }

        /// <summary>
        /// This method call the method of BusinessLayer
        /// </summary>
        /// <return>"_greetingBl.GreetMessage()" </return>
        [HttpGet]
        public IActionResult Message()
        {

            return Ok(_greetingBl.GreetMessage());
        }


        private static readonly Logger logger = LogManager .GetCurrentClassLogger();
        ResponseModel<string> responseModel;


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
    }
}
