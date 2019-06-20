using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Strengths.API.Data;
using Strengths.Shared.Models;

namespace Strengths.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrengthsController : ControllerBase {
        private StrengthsContext _strengthsContext;
        public StrengthsController(StrengthsContext strengthsContext)
        {
            _strengthsContext = strengthsContext;
        }
        
        // GET api/strengths
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _strengthsContext.Users
                    .Include(u => u.Theme1)
                        .ThenInclude(t1 => t1.Domain)
                    .Include(u => u.Theme2)
                        .ThenInclude(t2 => t2.Domain)
                    .Include(u => u.Theme3)
                        .ThenInclude(t3 => t3.Domain)
                    .Include(u => u.Theme4)
                        .ThenInclude(t4 => t4.Domain)
                    .Include(u => u.Theme5)
                        .ThenInclude(t5 => t5.Domain)
                    .ToArray();
        }
    }
}