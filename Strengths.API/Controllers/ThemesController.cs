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
    public class ThemesController : ControllerBase {
        private StrengthsContext _strengthsContext;
        public ThemesController(StrengthsContext strengthsContext)
        {
            _strengthsContext = strengthsContext;
        }
        
        // GET api/themes
        [HttpGet]
        public ActionResult<IEnumerable<Theme>> Get()
        {
            return _strengthsContext.Themes
                    .Include(t => t.Domain)
                    .OrderBy(t => t.Domain.Id)
                        .ThenBy(t => t.Title)
                    .ToArray();
        }
    }
}