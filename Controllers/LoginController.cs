using BackendWebUMG.Contexts;
using BackendWebUMG.DataLayer;
using BackendWebUMG.Entities;
using BackendWebUMG.UtilityObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace BackendWebUMG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UMGDBContext _Context;
        private readonly JWTSettings _jwtSettings;

        public LoginController(UMGDBContext Context, IOptions<JWTSettings> jwtSettings)
        {
            _Context = Context;
            _jwtSettings = jwtSettings.Value;
        }

        public List<User> GetAll()
        {
            var users = _Context.User.ToList();
            return users; 
        }
       
        [HttpPost("Autentication")]
        public ActionResult<UserWithToken> Autentication([FromBody] User User)
        {
            DLLogin dlLogin = new DLLogin(_Context);
            DLTokenByUser dltoken = new DLTokenByUser(_Context); 
            DLJWT dlJWT = new DLJWT(_jwtSettings);
            UserWithToken userResponse = null;
            //FindUser
            User = dlLogin.FindUser(User);
            if (User != null)
            {
                //Generate Token
                TokenByUser TokenByUser = dlJWT.GenerateRefreshToken(User.UserId);
                //Add Token 
                dltoken.AddTokenByUser(TokenByUser); 

                userResponse = new UserWithToken(User);
                userResponse.RefreshToken = TokenByUser.Token;

            }
            //Not Generated TOken
            if (userResponse == null)
            {
                return BadRequest("El usuario no  existe.");
            }
            //sign your token here here..
            userResponse.AccessToken = dlJWT.GenerateAccessToken(User.UserId);

            return userResponse;

        }

    }
}
