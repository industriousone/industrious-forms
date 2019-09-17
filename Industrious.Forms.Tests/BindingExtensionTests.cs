using System;
using Xunit;

namespace Industrious.Forms.Tests
{
	public class BindingExtensionTests
	{
		[Fact]
		public void ProvideValue_AttachesBooleanConverter()
		{
			var sut = new BooleanBindingExtension
			{
				Path = "Value"
			};

			var converter = sut.CreateBinding().Converter;
			Assert.True((Boolean)converter.Convert("1", typeof(Boolean), null, null));
		}


		[Fact]
		public void ProvideValue_CallsSpecifiedConverterFirst()
		{
			var sut = new BooleanBindingExtension
			{
				Path = "Value",
				Converter = new BooleanInverseConverter()
			};

			var converter = sut.CreateBinding().Converter;
			Assert.False((Boolean)converter.Convert("1", typeof(Boolean), null, null));
		}


		[Fact]
		public void ProvideValue_InvertsResult_OnLeadingBang()
		{
			var sut = new BooleanBindingExtension
			{
				Path = "!Value"
			};

			var converter = sut.CreateBinding().Converter;
			Assert.False((Boolean)converter.Convert("1", typeof(Boolean), null, null));
		}


		[Fact]
		public void ProvideValue_RemovesLeadingBang_OnLeadingBang()
		{
			var sut = new BooleanBindingExtension
			{
				Path = "!Value"
			};

			Assert.Equal("Value", sut.CreateBinding().Path);
		}
	}
}
