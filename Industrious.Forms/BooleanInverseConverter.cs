using System;
using System.Globalization;
using Xamarin.Forms;

namespace Industrious.Forms
{
	/// <summary>
	///  Converts most types into a boolean value using C-style rules, and inverts that
	///  value: null and zero values are interpreted as <c>true</c>; anything else evaluates
	///  as <c>false</c>. Convenient for those times you'd like to bind an objects visibility
	///  to the non-existence of an object.
	///  <example>
	///		<code>
	///			&lt;Label
	///				Text="Object exists"
	///				IsVisible="{Binding MyObject, Converter={forms:BooleanInverseConverter}}" &gt;>
	///		</code>
	///  </example>
	/// </summary>
	public class BooleanInverseConverter : IValueConverter
	{
		private readonly IValueConverter _innerConverter;


		public BooleanInverseConverter()
		{ }


		public BooleanInverseConverter(IValueConverter innerConverter)
		{
			_innerConverter = innerConverter;
		}


		public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			if (_innerConverter != null)
				value = _innerConverter.Convert(value, targetType, parameter, culture);

			return (!BooleanConverter.Convert(value));
		}


		public object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
