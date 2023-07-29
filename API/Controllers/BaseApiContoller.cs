using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{//DRY rule: do not repeat urself, so we use a parent class to store all debugging features

    //square bracket here specifies the attribute of this class, sort of like @ in java  
    [ApiController]
    [Route("api/[controller]")]//controller here is a placeholder means any class derived from BaseApiController

    public class BaseApiController : ControllerBase
    {
        
    }
}