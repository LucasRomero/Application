
using Application.Exceptions;
using Application.Features.Ordenes.Create;
using Core.Entities;
using Core.Interfaces;
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
        public async Task Handle_should_returnFailureResult()
        {
            // Arrange
            var command = new CrearOrdenCommand
            {
                Cantidad = 1,
                Operacion = 'C',
                ActivoId = 0,
                MontoTotal = 0,
                EstadoId = 0,
                TipoActivoId = 1,
                CuentaId = 1,
            };

            var handler = new CrearOrdenCommandHandler(_unitOfWorkMock.Object);

            // Act
            Result<int> result = await handler.Handle(command, default);

            // Assert
            Assert.IsTrue(result.IsFailure);
            
        }
    }
}
