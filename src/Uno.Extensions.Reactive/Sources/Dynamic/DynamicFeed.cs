﻿#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Uno.Extensions.Reactive.Core;
using Uno.Extensions.Reactive.Utils;

namespace Uno.Extensions.Reactive.Sources;

internal sealed class DynamicFeed<T> : IFeed<T>
{
	private readonly AsyncFunc<Option<T>> _dataProvider;

	public DynamicFeed(AsyncFunc<T?> dataProvider)
	{
		_dataProvider = async ct => Option.SomeOrNone(await dataProvider(ct));
	}

	public DynamicFeed(AsyncFunc<Option<T>> dataProvider)
	{
		_dataProvider = dataProvider;
	}

	/// <inheritdoc />
	public IAsyncEnumerable<Message<T>> GetSource(SourceContext context, CancellationToken ct = default)
		=> new FeedSession<T>(this, context, _dataProvider, ct);
}
