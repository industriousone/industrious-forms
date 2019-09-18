<p align="center">
	<a href="https://opensource.org/licenses/MIT" target="_blank">
        <img src="https://img.shields.io/github/license/industriousone/industrious-forms" alt="MIT" />
    </a>
    <a href="https://twitter.com/industrious" target="_blank">
        <img src="https://img.shields.io/twitter/follow/industrious.svg?style=social&label=Follow">
    </a>
</p>

# Industrious.Forms

Make working with Xamarin.Forms just a little bit easier.

See [Industrious.ToDo](https://github.com/industrious/industrious-todo) for usage examples in something resembling a real application.

## Contents

- [AutoFocusBehavior](#autofocusbehavior)
- [BooleanBindingExtension](#booleanbindingextension)
- [BooleanConverter](#booleanconverter)
- [BooleanInverseConverter](#booleaninverseconverter)

### AutoFocusBehavior

Automatically set the input focus to a particular control when a condition becomes true.

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentView
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:forms="clr-namespace:Industrious.Forms;assembly=Industrious.Forms"
    x:Class="SampleClass">
    <StackLayout>
        <Entry
            Text="{Binding Title}"
            forms:AutoFocusBehavior.When="{Binding ShouldFocusTitle"} />
    </StackLayout>
</ContentView>
```

### BooleanBindingExtension

A shortcut for binding boolean properties on a Xamarin.Forms view to a non-boolean value on the view model. See [BooleanConverter](#booleanconverter) for info on how values are interpreted. Supports the use of "!" to negate the value.

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentView
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:forms="clr-namespace:Industrious.Forms;assembly=Industrious.Forms"
    x:Class="SampleClass">
    <StackLayout>
        <StackLayout
            x:Name="MainLayout"
            IsVisible="{forms:BooleanBinding ItemCount}">
            <!-- main content goes here -->
        </StackLayout>
        <StackLayout
            x:Name="EmptyCollectionLayout"
            IsVisible="{forms:BooleanBinding !ItemCount}">
            <!-- show this view when there are no items in the collection -->
        </StackLayout>
    </StackLayout>
</ContentView>
```

### BooleanConverter

Converts most types into a boolean value using C-style rules: null and zero values are interpreted as `false`; anything else evaluates as `true`. Convenient for those times you'd like to bind an object's visibility to the existence of an object.

```c#
public class MyViewModel
{
    public Object SomeObjectProperty { get; set; }
}
```

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentView
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:forms="clr-namespace:Industrious.Forms;assembly=Industrious.Forms"
    x:Class="SampleClass">
    <StackLayout>
        <Label
            Text="The object exists"
            IsVisible="{Binding SomeObjectProperty, Converter={forms:BooleanConverter}}" />
    </StackLayout>
</ContentView>
```

### BooleanInverseConverter

Converts most types into a boolean value following the same logic as [BooleanConverter](#booleanconverter), but inverts the results: null and zero values are interpreted as `true`, anything else evaluates as `false`.

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentView
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:forms="clr-namespace:Industrious.Forms;assembly=Industrious.Forms"
    x:Class="SampleClass">
    <StackLayout>
        <Label
            Text="The object does not exists"
            IsVisible="{Binding SomeObjectProperty, Converter={forms:BooleanInverseConverter}}" />
    </StackLayout>
</ContentView>
```

## Stay in touch

* Website - https://industriousone.com
* Twitter - [@industrious](https://twitter.com/industrious)

## License

[MIT](https://opensource.org/licenses/MIT)
