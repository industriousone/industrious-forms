using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Industrious.Forms
{
	/// <summary>
	///  A shortcut for binding boolean properties to non-boolean values using the
	///  <see cref="BooleanConverter"/> and <see cref="BooleanInverseConverter"/> converters.
	/// </summary>
	/// <example>
	///	 Bind a non-boolean value to a boolean property.
	///	 <code>
	///   &lt;Label
	///       Text="Title"
	///       IsVisible="{forms:BooleanBinding CurrentObject}" &gt;>
	///  </code>
	/// </example>
	/// <example>
	///	 Bind non-boolean value to a boolean property, inverting the result.
	///	 <code>
	///   &lt;Label
	///       Text="Title"
	///       IsVisible="{forms:BooleanBinding !CurrentObject}" &gt;>
	///  </code>
	/// </example>
	[ContentProperty(nameof(Path))]
	public class BooleanBindingExtension : IMarkupExtension<BindingBase>
	{
		public String Path { get; set; }
		public BindingMode Mode { get; set; } = BindingMode.Default;
		public IValueConverter Converter { get; set; }
		public Object ConverterParameter { get; set; }
		public String StringFormat { get; set; }
		public Object Source { get; set; }
		public String UpdateSourceEventName { get; set; }
		public Object TargetNullValue { get; set; }
		public Object FallbackValue { get; set; }


		BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
		{
			return CreateBinding();
		}


		Object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
		{
			return (this as IMarkupExtension<BindingBase>).ProvideValue(serviceProvider);
		}


		public Binding CreateBinding()
		{
			if (Path.StartsWith("!", StringComparison.CurrentCulture))
			{
				Path = Path.TrimStart('!');
				Converter = new BooleanInverseConverter(Converter);
			}
			else
			{
				Converter = new BooleanConverter(Converter);
			}

			return new Binding(Path, Mode, Converter, ConverterParameter, StringFormat, Source)
			{
				UpdateSourceEventName = UpdateSourceEventName,
				FallbackValue = FallbackValue,
				TargetNullValue = TargetNullValue,
			};
		}
	}
}
