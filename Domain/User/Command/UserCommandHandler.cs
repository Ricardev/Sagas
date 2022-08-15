using MediatR;

namespace Domain.User.Command;

public class UserCommandHandler : IRequestHandler<CreateUserCommand>, IRequestHandler<DeleteUserCommand>
{
    public Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}