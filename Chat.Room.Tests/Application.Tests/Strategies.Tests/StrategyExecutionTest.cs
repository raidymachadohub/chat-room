using System.Threading.Tasks;
using Autofac.Extras.FakeItEasy;
using Chat.Room.Application.Strategies;
using Chat.Room.Application.Strategies.Interfaces;
using Chat.Room.Shared.FlowControl.Model;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Chat.Room.Tests.Application.Tests.Strategies.Tests
{
    public class StrategyExecutionTest
    {
        [Fact]
        public async Task Should_return_success_when_send_common_message()
        {
            using var autoFake = new AutoFake();

            var expectedResult = Result.Ok();
            
            var commonStrategy = autoFake.Resolve<ICommonStrategy>();
            var strategy = autoFake.Resolve<CommonStrategy>();

            A.CallTo(() => commonStrategy.ExecuteAsync(A<string>.Ignored, A<string>.Ignored))
                .Returns(expectedResult);

            // Act
            const string user = "Test";
            const string message = "Unit Testing";
            var result = await strategy.ExecuteAsync(user, message);
            
            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
        
        [Fact]
        public async Task Should_return_success_when_send_stock_message()
        {
            using var autoFake = new AutoFake();

            var expectedResult = Result.Ok();
            
            var stockStrategy = autoFake.Resolve<IStockStrategy>();
            var strategy = autoFake.Resolve<StockStrategy>();

            A.CallTo(() => stockStrategy.ExecuteAsync(A<string>.Ignored, A<string>.Ignored))
                .Returns(expectedResult);

            // Act
            const string user = "Test";
            const string message = "/stock=UnitCode";
            var result = await strategy.ExecuteAsync(user, message);
            
            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}