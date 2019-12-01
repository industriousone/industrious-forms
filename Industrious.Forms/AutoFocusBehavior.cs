using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Industrious.Forms
{
	/// <summary>
	///  An <see cref="https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/behaviors/attached">
	///  attached behavior</see> which automatically set the input focus to a view when the provided condition
	///  becomes true.
	/// </summary>
	/// <example>
	///  Sets the focus to attached <see cref="Entry"/> when the binding condition resolves to <c>true</c>.
	///  <code>
	///   &lt;Entry
	///       Text="{Binding Title}"
	///       forms:AutoFocusBehavior.FocusWhen="{Binding ShouldFocusTitle}" /&gt;
	///  </code>
	/// </example>
	/// <example>
	///  To set the focus automatically when the form is loaded, set <c>When</c> to <c>true</c>.
	///  <code>
	///   &lt;Entry
	///       Text="{Binding Title}"
	///       forms:AutoFocusBehavior.FocusWhen="True" /&gt;
	///  </code>
	/// </example>
	public static class AutoFocusBehavior
	{
		public static readonly BindableProperty FocusWhenProperty = BindableProperty.CreateAttached(
			"FocusWhen",
			typeof(Boolean),
			typeof(AutoFocusBehavior),
			false,
			propertyChanged: OnFocusWhenChanged);


		public static Boolean GetFocusWhen(BindableObject bindable)
		{
			var value = (Boolean)bindable.GetValue(FocusWhenProperty);
			return (value);
		}


		public static void SetFocusWhen(BindableObject bindable, Boolean value)
		{
			bindable.SetValue(FocusWhenProperty, value);
		}


		private static void OnFocusWhenChanged(BindableObject bindable, Object oldValue, Object newValue)
		{
			if ((Boolean)newValue)
			{
				// if view is visible, set focus, else wait until it is
				var view = (View)bindable;
				if (view.Width >= 0)
					view.Focus();
				else
					view.PropertyChanged += OnViewPropertyChanged;
			}
		}


		private static void OnViewPropertyChanged(Object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Renderer")
			{
				// view is now visible enough, go ahead and set focus
				var view = (View)sender;
				view.PropertyChanged -= OnViewPropertyChanged;
				view.Focus();
			}
		}
	}
}
