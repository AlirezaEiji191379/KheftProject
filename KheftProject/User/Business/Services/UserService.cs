using KheftProject.Core.DataAccess.Repository.Abstraction;
using KheftProject.User.Business.Abstractions;
using KheftProject.User.Business.Contracts.Dtos;
using KheftProject.User.DataAccess.Entities;
using KheftProject.User.DataAccess.Repositories.Abstraction;

namespace KheftProject.User.Business.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<bool> HasUserWithTelegramId(long telegramSerialId)
    {
        return _userRepository.HasUserWithTelegramSerialId(telegramSerialId);
    }

    public async Task<Guid> GetOrCreateUser(UserDto userDto)
    {
        var registeredUser = await _userRepository.FindUserByTelegramSerialId(userDto.TelegramSerialId);
        if (registeredUser != null)
        {
            return registeredUser.UserId;
        }

        var userEntity = new UserEntity()
        {
            UserId = Guid.NewGuid(),
            TelegramSerialId = userDto.TelegramSerialId,
            FullName = userDto.FullName
        };
        await _userRepository.Create(userEntity);
        await _unitOfWork.SaveChangesAsync();
        return userEntity.UserId;
    }
}