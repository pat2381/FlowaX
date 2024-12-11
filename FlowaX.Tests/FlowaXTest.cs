using System.Threading.Tasks;
using FlowaX.Core;
using FlowaX.Extensions;
using Xunit;

namespace FlowaX.Tests
{
    public class FlowaXTest
    {
        [Fact]
        public void Should_Return_Success()
        {
            var result = Result<string>.Success("Hallo Welt");
            Assert.True(result.IsSuccess);
            Assert.Equal("Hallo Welt", result.Value);
        }

        [Fact]
        public void Should_Handle_Failure()
        {
            var result = Result<int>.Failure("Fehler aufgetreten");
            Assert.False(result.IsSuccess);
            Assert.Equal("Fehler aufgetreten", result.Error);
        }

        [Fact]
        public async Task Should_BindAsync_Successfully()
        {
            // Simulierte asynchrone Funktion
            async Task<Result<int>> DoubleAsync(int x)
            {
                await Task.Delay(100);  // Simulierte Verzögerung
                return Result<int>.Success(x * 2);
            }

            // Nutzung der Erweiterungsmethode
            var result = await Result<int>.Success(5).BindAsync(DoubleAsync);

            Assert.True(result.IsSuccess);
            Assert.Equal(10, result.Value); // Ergebnis sollte 10 sein
        }

        [Fact]
        public async Task Should_Handle_FromAsync_With_Exception()
        {
            async Task<int> FailingTask() => throw new InvalidOperationException("Fehler!");
            var result = await Result<int>.FromAsync(FailingTask);
        
            Assert.False(result.IsSuccess);
            Assert.Equal("Fehler!", result.Error);
        }
    }
}