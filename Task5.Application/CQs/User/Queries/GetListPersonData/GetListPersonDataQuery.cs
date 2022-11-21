using MediatR;

namespace Task5.Application.CQs.User.Queries.GetListPersonData;

public class GetListPersonDataQuery : IRequest<GetListPersonDataVm>
{
    public string Region { get; set; }
    public int Seed { get; set; }
}