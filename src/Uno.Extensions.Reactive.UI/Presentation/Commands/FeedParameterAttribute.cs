﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Uno.Extensions.Reactive.UI.Config;

namespace Uno.Extensions.Reactive.UI.Presentation.Commands;

/// <summary>
/// Flags a parameter of a method this is being exposed as <see cref="ICommand"/> (cf. <see cref="CommandAttribute"/>),
/// to be automatically full-filled from a feed declared on the same class.
/// </summary>
/// <remarks>
/// This attribute is optional if you enabled <see cref="ImplicitFeedCommandParametersAttribute"/> in your project
/// and you have a public feed that matches type and name of the parameter.
/// </remarks>
[AttributeUsage(AttributeTargets.Parameter)]
public class FeedParameterAttribute : Attribute
{
	/// <summary>
	/// Flags a parameter of a method this is being exposed as <see cref="ICommand"/> (cf. <see cref="CommandAttribute"/>),
	/// to be automatically full-filled from a feed declared on the same class.
	/// </summary>
	/// <param name="property">The name of the property that should be used as input for the parameter.</param>
	public FeedParameterAttribute(string? property = null)
	{
	}
}
