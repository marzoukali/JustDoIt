using System.Threading;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using TIS.Todo.Api.DTOs;
using TIS.Todo.Application.Interfaces.IRepositories;
using TIS.Todo.Application.UserTodos;
using TIS.Todo.Domain.Interfaces.IRepositories;
using TIS.Todo.Domain.Models;
using Xunit;

namespace TIS.Todo.Application.Tests.UserTodos
{
    public class CreateHandlerTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IAsyncRepository<TodoItem>> _todoRepoMock;
        private readonly Mock<IAppUserRepository> _userRepoMock;


        public CreateHandlerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();
            _userRepoMock = new Mock<IAppUserRepository>();
            _todoRepoMock = new Mock<IAsyncRepository<TodoItem>>();
        }

        [Fact]
        public async void CreateTodoItemShouldCallGetUserByIdToVerifyUser()
        {
            //Arrange
            var command = new Create.Command {TodoItem = new ToDoCreateRequest(), UserId = It.IsAny<string>()};
            var handler = new Create.Handler(_mapperMock.Object, _userRepoMock.Object, _todoRepoMock.Object);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            _userRepoMock.Verify(x => x.GetUserById(It.IsAny<string>()));
        }


        [Fact]
        public async void CreateTodoItemShouldFailIfUserIsNotExists()
        {
            //Arrange
            var command = new Create.Command {TodoItem = new ToDoCreateRequest(), UserId = It.IsAny<string>()};
            var handler = new Create.Handler(_mapperMock.Object, _userRepoMock.Object, _todoRepoMock.Object);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Couldn't get user info in order to create todo");
        }
    }
}