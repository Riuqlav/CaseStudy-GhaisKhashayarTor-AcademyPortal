using CaseStudy.Server.Repository;
using CaseStudy.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Server.Controllers
{
    public class BeersController : AbstractController<Beer>
    {
        public BeersController(IRepository<Beer> repo) : base(repo)
        {

        }
    }
}