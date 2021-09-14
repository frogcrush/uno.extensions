﻿using System;
#if WINDOWS_UWP || UNO_UWP_COMPATIBILITY
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#else
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
#endif

namespace Uno.Extensions.Navigation.Controls;

public class ContentWrapper : BaseWrapper<ContentControl>, ISimpleNavigation<ContentControl>
{
    public void Navigate(NavigationContext context, bool isBackNavigation, object viewModel)
    {
        var content = Activator.CreateInstance(context.Mapping.View);
        Control.Content = content;

        InitialiseView(content, context, viewModel);
    }
}
