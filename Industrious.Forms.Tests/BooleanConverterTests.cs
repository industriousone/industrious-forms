using System;
using Xunit;

namespace Industrious.Forms.Tests
{
	public class BooleanConverterTests
	{
		private Boolean Evaluate(Object value)
		{
			var sut = new BooleanConverter();
			var result = (Boolean)sut.Convert(value, typeof(Boolean), null, null);
			return (result);
		}


		[Fact]
		public void Convert_ReturnsFalse_OnBooleanFalse()
		{
			Assert.False(Evaluate(false));
		}


		[Fact]
		public void Convert_ReturnsTrue_OnBooleanTrue()
		{
			Assert.True(Evaluate(true));
		}


		[Fact]
		public void Convert_ReturnsFalse_OnDecimalZero()
		{
			Decimal value = 0;
			Assert.False(Evaluate(value));
		}


		[Fact]
		public void Convert_ReturnsTrue_OnDecimalNonZero()
		{
			Decimal value = 6;
			Assert.True(Evaluate(value));
		}


		[Fact]
		public void Convert_ReturnsFalse_OnDoubleZero()
		{
			Double value = 0.0;
			Assert.False(Evaluate(value));
		}


		[Fact]
		public void Convert_ReturnsTrue_OnDoubleNonZero()
		{
			Double value = 6.0;
			Assert.True(Evaluate(value));
		}


		[Fact]
		public void Convert_ReturnsFalse_OnInt32Zero()
		{
			Int32 value = 0;
			Assert.False(Evaluate(value));
		}


		[Fact]
		public void Convert_ReturnsTrue_OnInt32NonZero()
		{
			Int32 value = 6;
			Assert.True(Evaluate(value));
		}


		[Fact]
		public void Convert_ReturnsFalse_OnNullableInt32Null()
		{
			Int32? value = null;
			Assert.False(Evaluate(value));
		}


		[Fact]
		public void Convert_ReturnsFalse_OnNullableInt32Zero()
		{
			Int32? value = 0;
			Assert.False(Evaluate(value));
		}


		[Fact]
		public void Convert_ReturnsTrue_OnNullableInt32NotNull()
		{
			Int32? value = 6;
			Assert.True(Evaluate(value));
		}


		[Fact]
		public void Convert_ReturnsFalse_OnObjectNull()
		{
			Assert.False(Evaluate(null));
		}


		[Fact]
		public void Convert_ReturnsTrue_OnObjectNotNull()
		{
			Assert.True(Evaluate("Value"));
		}
	}
}
