
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
                Operacion = 'C',
                ActivoId = 0,
                MontoTotal = 0,
                EstadoId = 0,
                TipoActivoId = 1,
                CuentaId = 1,
            };

            var activoRepositoryMock = new Mock<IActivoRepository>();
            activoRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Activo)null);

            _unitOfWorkMock
                .Setup(uow => uow.ActivoRepository)
                .Returns(activoRepositoryMock.Object);

            var handler = new CrearOrdenCommandHandler(_unitOfWorkMock.Object);

            // Act
            Result<int> result = await handler.Handle(command, default);

            // Assert
            Assert.IsTrue(result.IsFailure);
            Assert.AreEqual("Activo con ID 0 no encontrado.", result.Error);
        }

        [TestMethod]
        public async Task Handle_should_returnTipoActivoNotFoundFailureResult()
        {
            // Arrange
            var command = new CreateOrdenCommand
            {
                Cantidad = 1,
                Operacion = 'C',
                ActivoId = 1,
                MontoTotal = 0,
                EstadoId = 0,
                TipoActivoId = 0,
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

            var handler = new CrearOrdenCommandHandler(_unitOfWorkMock.Object);

            // Act
            Result<int> result = await handler.Handle(command, default);

            // Assert
            Assert.IsTrue(result.IsFailure);
            Assert.AreEqual("Tipo de activo con ID 0 no encontrado.", result.Error);
        }


        [TestMethod]
        public async Task Handle_should_returnEstadoNotFoundFailureResult()
        {
            // Arrange
            var command = new CreateOrdenCommand
            {
                Cantidad = 1,
                Operacion = 'C',
                ActivoId = 1,
                MontoTotal = 0,
                EstadoId = 4,
                TipoActivoId = 1,
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

            var estadoRepositoryMock = new Mock<IEstadoOrdenRepository>();
            estadoRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((EstadoOrden)null);

            _unitOfWorkMock
                .Setup(uow => uow.EstadoOrdenRepository)
                .Returns(estadoRepositoryMock.Object);

            var handler = new CrearOrdenCommandHandler(_unitOfWorkMock.Object);

            // Act
            Result<int> result = await handler.Handle(command, default);

            // Assert
            Assert.IsTrue(result.IsFailure);
            Assert.AreEqual("Estado con ID 4 no encontrado.", result.Error);
        }


        [TestMethod]
        public async Task Handle_should_returnSuccedResult()
        {
            // Arrange
            var command = new CreateOrdenCommand
            {
                Cantidad = 1,
                Operacion = 'C',
                ActivoId = 1,
                MontoTotal = 0,
                EstadoId = 0,
                TipoActivoId = 1,
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

            var estadoRepositoryMock = new Mock<IEstadoOrdenRepository>();
            estadoRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new EstadoOrden() { });

            _unitOfWorkMock
                .Setup(uow => uow.EstadoOrdenRepository)
                .Returns(estadoRepositoryMock.Object);


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


            var handler = new CrearOrdenCommandHandler(_unitOfWorkMock.Object);

            // Act
            Result<int> result = await handler.Handle(command, default);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(It.IsAny<int>(), result.Value);
        }

    }
}
