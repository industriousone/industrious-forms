using System;
using Xunit;

namespace Industrious.Forms.Tests
{
	public class BooleanInverseConverterTests
	{
		private Boolean Evaluate(Object value)
		{
			var sut = new BooleanInverseConverter();
			var result = (Boolean)sut.Convert(value, typeof(Boolean), null, null);
			return (result);
		}


		[Fact]
		public void Convert_ReturnsFalse_OnBooleanTrue()
		{
			Assert.False(Evaluate(true));
		}


		[Fact]
		public void Convert_ReturnsTrue_OnBooleanFalse()
		{
			Assert.True(Evaluate(false));
		}
	}
}
