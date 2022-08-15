using MediatR;

namespace Application.User;

public class UserApplication : IUserApplication
{
    private readonly IMediator _mediator;

    public UserApplication(IMediator mediator)
    {
        _mediator = mediator;  
    }
}