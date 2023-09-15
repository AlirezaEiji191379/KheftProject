using FluentValidation;
using KheftProject.Core.Contexts;
using KheftProject.Core.DataAccess.Repository.Abstraction;
using KheftProject.User.Business.Contracts.Commands;
using KheftProject.User.DataAccess.Entities;
using KheftProject.User.DataAccess.Repositories.Abstraction;
using MediatR;

namespace KheftProject.User.Business.Handlers;

internal class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, ResponseDto>
{
    private readonly IValidator<UserRegistrationCommand> _validator;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;


    public UserRegistrationCommandHandler(IValidator<UserRegistrationCommand> validator,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDto> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var userEntity = new UserEntity()
            {
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                TelegramUsername = request.TelegramUsername,
                UserId = request.UserId
            };
            await _userRepository.Create(userEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new ResponseDto()
            {
                StatusCode = 201,
                Message = "User Created Successfully!"
            };
        }
        catch (Exception exception)
        {
            return new ResponseDto()
            {
                Message = exception.Message,
                StatusCode = 400
            };
        }
    }
}