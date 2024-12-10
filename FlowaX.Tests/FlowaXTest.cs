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

        //[Fact]
        //public async Task Should_BindAsync_Successfully()
        //{
        //    //async Task<Result<int>> DoubleAsync(int x) => await Task.FromResult(Result<int>.Success(x * 2));

        //    //// Test: Verwende BindAsync korrekt
        //    ////var result = await Result<int>.Success(5).BindAsync(DoubleAsync);

        //    //Assert.True(result.IsSuccess);
        //    //Assert.Equal(10, result.Value);
        //}

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