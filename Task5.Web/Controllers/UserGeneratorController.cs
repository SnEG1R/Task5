using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task5.Application.CQs.User.Queries.GetListPersonData;

namespace Task5.Web.Controllers;

public class UserGeneratorController : Controller
{
    private readonly IMediator _mediator;

    public UserGeneratorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string region, [FromBody] int seed)
    {
        var query = new GetListPersonDataQuery()
        {
            Region = region,
            Seed = seed
        };
        var getListPersonDataVm = await _mediator.Send(query);

        return Ok(getListPersonDataVm.PersonDataDtos);
    }
}