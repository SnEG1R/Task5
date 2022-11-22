using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task5.Application.CQs.User.Queries.GetListPersonData;
using Task5.Web.Models;

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
    public async Task<IActionResult> Index(string region, [FromBody] InformationData data)
    {
        var query = new GetListPersonDataQuery()
        {
            Region = region,
            Seed = data.Seed,
            ErrorValue = data.ErrorValue,
            CountLoadRecord = data.CountLoadRecord
        };
        var getListPersonDataVm = await _mediator.Send(query);

        return Ok(getListPersonDataVm.PersonDataDtos);
    }
}