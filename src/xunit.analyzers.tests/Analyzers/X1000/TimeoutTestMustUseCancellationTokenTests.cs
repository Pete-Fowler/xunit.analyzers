using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;
using Verify = CSharpVerifier<Xunit.Analyzers.UseCancellationToken>;

public class TimeoutTestMustUseCancellationTokenTests
{
  	[Fact]
	public async Task NoCancellationToken_DoesNotTrigger()
	{
		var source = /* lang=c#-test */
			"""
			using System.Threading;
			using Xunit;

			class TestClass {
				[Fact]
				public void TestMethod() {
					Thread.Sleep(1);
				}
			}
			""";

		await Verify.VerifyAnalyzerV3(source);
	}
}