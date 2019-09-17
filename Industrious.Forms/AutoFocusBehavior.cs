using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Industrious.Forms
{
	/// <summary>
	///  Automatically set the input focus when a condition becomes true.
	/// </summary>
	/// <example>
	///  Sets the focus to attached <see cref="Entry"/> when the binding condition
	///  resolves to <c>true</c>.
	///  <code>
	///   &lt;Entry
	///       Text="{Binding Title}"
	///       local:AutoFocusBehavior.When="{Binding ShouldFocusTitle}" /&gt;
	///  </code>
	/// </example>
	/// <example>
	///  To set the focus automatically when the form is loaded, set <c>When</c>
	///  to <c>true</c>.
	///  <code>
	///   &lt;Entry
	///       Text="{Binding Title}"
	///       local:AutoFocusBehavior.When="true" /&gt;
	///  </code>
	/// </example>
	public class AutoFocusBehavior : Behavior<InputView>
	{
		public static readonly BindableProperty WhenProperty = BindableProperty.CreateAttached(
			"When",
			typeof(bool),
			typeof(AutoFocusBehavior),
			false,
			propertyChanged: OnWhenChanged);


		public static Boolean GetFocusWhen(BindableObject bindable)
		{
			var value = (Boolean)bindable.GetValue(WhenProperty);
			return (value);
		}

		public static void SetFocusWhen(BindableObject bindable, Boolean value)
		{
			bindable.SetValue(WhenProperty, value);
		}


		private static void OnWhenChanged(BindableObject bindable, Object oldValue, Object newValue)
		{
			if ((Boolean)newValue)
				_ = SetFocus((InputView)bindable);
		}


		private static async Task SetFocus(InputView bindable)
		{
			await Task.Delay(1);  // control isn't ready to receive focus when first attached
			bindable.Focus();
		}
	}
}
