using System;
using System.Globalization;
using Xamarin.Forms;

namespace Industrious.Forms
{
	/// <summary>
	///  Converts most types into a boolean value using C-style rules: null and zero
	///  values are interpreted as <c>false</c>; anything else evaluates as <c>true</c>.
	///  Convenient for those times you'd like to bind an objects visibility to the
	///  existence of an object.
	///  <example>
	///		<code>
	///			&lt;Label
	///				Text="Object exists"
	///				IsVisible="{Binding MyObject, Converter={forms:BooleanConverter}}" &gt;>
	///		</code>
	///  </example>
	/// </summary>
	public class BooleanConverter : IValueConverter
	{
		private readonly IValueConverter _innerConverter;


		public BooleanConverter()
		{ }


		public BooleanConverter(IValueConverter innerConverter)
		{
			_innerConverter = innerConverter;
		}


		public static Boolean Convert(Object value)
		{
			switch (value)
			{
			case Boolean b:
				return (b);

			case Byte n:
				return !(n == 0);

			case Decimal n:
				return !(n == 0);

			case Double n:
#pragma warning disable RECS0018 // Comparison of floating point numbers with equality operator
				return !(n == 0.0);
#pragma warning restore RECS0018 // Comparison of floating point numbers with equality operator

			case Int16 n:
				return !(n == 0);

			case Int32 n:
				return !(n == 0);

			case Int64 n:
				return !(n == 0);

			case SByte n:
				return !(n == 0);

			case Single n:
#pragma warning disable RECS0018 // Comparison of floating point numbers with equality operator
				return !(n == 0.0);
#pragma warning restore RECS0018 // Comparison of floating point numbers with equality operator

			case UInt16 n:
				return !(n == 0);

			case UInt32 n:
				return !(n == 0);

			case UInt64 n:
				return !(n == 0);

			default:
				return !(value is null);
			}
		}


		public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			if (_innerConverter != null)
				value = _innerConverter.Convert(value, targetType, parameter, culture);

			return Convert(value);
		}


		public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
