﻿using DDD.Infrastructure.Base.Sagas;
using DDD.Sagas.Commands;
using DDD.Sagas.Events;
using Moq;
using NUnit.Framework;

namespace DDD.Sagas
{
  [TestFixture]
  public class OrderSagaManagerTests
  {
    private InMemorySagaRepository<OrderSagaData> _repository;
    private Mock<ICommandSender> _commandSender;
    private OrderSagaManager _manager;

    [SetUp]
    public void Setup()
    {
      _repository = new InMemorySagaRepository<OrderSagaData>();
      _commandSender = new Mock<ICommandSender>();
      _manager = new OrderSagaManager(_repository, _commandSender.Object);
    }

    [Test]
    public void RaiseEvent_Should_write_to_db_saga_contents()
    {
      // Arrange
      const string orderId = "1";
      var orderConfirmedEvent = new DocumentCreatedEvent(orderId);

      // Act
      _manager.ProcessMessage(orderConfirmedEvent);

      // Assert
      Assert.IsTrue(_repository.Values.ContainsKey(orderConfirmedEvent.DocumentId));
      Assert.IsTrue(orderId == _repository.Values[orderId].DocumentId);
    }

    [Test]
    public void DocumentAcceptedEvent_Should_send_PrintDocumentCommand()
    {
      // Arrange
      const string documentId = "12";
      var documentAcceptedEvent = new DocumentAcceptedEvent(documentId);

      _repository.Values[documentId] = new OrderSagaData()
      {
        DocumentId = documentId,
        CurrentState = _manager.SagaMachine.DocumentCreated
      };

      // Act
      _manager.ProcessMessage(documentAcceptedEvent);

      // Assert
      _commandSender.Verify(f => f.Send(It.Is<PrintDocumentCommand>(d => d.DocumentId == documentId)));
    }
  }
}