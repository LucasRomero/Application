
using Application.Exceptions;
using Application.Features.Ordenes.Create;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Moq;

namespace TestProject.Services
{
    [TestClass]
    public sealed class OrdenServiceTest
    {

        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public OrdenServiceTest()
        {
            _unitOfWorkMock = new();
        }

        [TestMethod]
        public async Task Handle_should_returnActivoNotFoundFailureResult()
        {
            // Arrange
            var command = new CreateOrdenCommand
            {
                Cantidad = 1,
                Operacion = "C",
                ActivoId = 0,
                CuentaId = 1,
            };

            var activoRepositoryMock = new Mock<IActivoRepository>();
            activoRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Activo)null);

            _unitOfWorkMock
                .Setup(uow => uow.ActivoRepository)
                .Returns(activoRepositoryMock.Object);

            var handler = new CreateOrdenCommandHandler(_unitOfWorkMock.Object);

            // Act
            Result<int> result = await handler.Handle(command, default);

            // Assert
            Assert.IsTrue(result.IsFailure);
        }

        [TestMethod]
        public async Task Handle_should_returnTipoActivoNotFoundFailureResult()
        {
            // Arrange
            var command = new CreateOrdenCommand
            {
                Cantidad = 1,
                Operacion = "C",
                ActivoId = 1,
                CuentaId = 1,
            };

            var activoRepositoryMock = new Mock<IActivoRepository>();
            activoRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Activo() { });

            _unitOfWorkMock
                .Setup(uow => uow.ActivoRepository)
                .Returns(activoRepositoryMock.Object);


            var tipoActivoRepositoryMock = new Mock<ITipoActivoRepository>();
            tipoActivoRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((TipoActivo)null);

            _unitOfWorkMock
                .Setup(uow => uow.TipoActivoRepository)
                .Returns(tipoActivoRepositoryMock.Object);

            var handler = new CreateOrdenCommandHandler(_unitOfWorkMock.Object);

            // Act
            Result<int> result = await handler.Handle(command, default);

            // Assert
            Assert.IsTrue(result.IsFailure);
        }

        [TestMethod]
        public async Task Handle_should_returnSuccedResult()
        {
            // Arrange
            var command = new CreateOrdenCommand
            {
                Cantidad = 1,
                Operacion = "C",
                ActivoId = 1,
                CuentaId = 1,
            };

            var activoRepositoryMock = new Mock<IActivoRepository>();
            activoRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Activo() { });

            _unitOfWorkMock
                .Setup(uow => uow.ActivoRepository)
                .Returns(activoRepositoryMock.Object);


            var tipoActivoRepositoryMock = new Mock<ITipoActivoRepository>();
            tipoActivoRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new TipoActivo() { });

            _unitOfWorkMock
                .Setup(uow => uow.TipoActivoRepository)
                .Returns(tipoActivoRepositoryMock.Object);


            var ordenRepositoryMock = new Mock<IOrdenRepository>();
            ordenRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Orden>()));

            _unitOfWorkMock
                .Setup(uow => uow.OrdenesRepository)
                .Returns(ordenRepositoryMock.Object);

            var unitRepositoryMock = new Mock<IUnitOfWork>();
            unitRepositoryMock
                .Setup(repo => repo.Commit())
                .Returns(It.IsAny<Task<int>>());


            var handler = new CreateOrdenCommandHandler(_unitOfWorkMock.Object);

            // Act
            Result<int> result = await handler.Handle(command, default);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(It.IsAny<int>(), result.Value);
        }

    }
}
