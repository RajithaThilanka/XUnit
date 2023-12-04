// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Graph;
// using Microsoft.Identity.Web;
// using Microsoft.Identity.Web.MicrosoftGraph;
// using System.Net.Http;
// using System.Threading.Tasks;
//
// namespace MovieManagementAPI.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class UserController : ControllerBase
//     {
//         private readonly ITokenAcquisition _tokenAcquisition;
//         private readonly IGraphServiceClient _graphServiceClient;
//
//         public UserController(ITokenAcquisition tokenAcquisition, IGraphServiceClient graphServiceClient)
//         {
//             _tokenAcquisition = tokenAcquisition;
//             _graphServiceClient = graphServiceClient;
//         }
//
//         [HttpGet("userinfo")]
//         [AuthorizeForScopes(Scopes = new[] { "user.read" })]
//         public async Task<IActionResult> GetUserInformation()
//         {
//             try
//             {
//                 var token = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { "user.read" });
//
//                 var user = await _graphServiceClient.Me.Request()
//                     .WithHeaders(new[] { new HeaderOption("Authorization", "Bearer " + token) })
//                     .GetAsync();
//
//                 return Ok(user.DisplayName);
//             }
//             catch (ServiceException ex)
//             {
//                 return BadRequest($"Error: {ex.Message}");
//             }
//         }
//     }
// }