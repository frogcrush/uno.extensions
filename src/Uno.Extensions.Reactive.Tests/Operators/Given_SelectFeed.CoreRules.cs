﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.Extensions.Reactive.Operators;
using Uno.Extensions.Reactive.Testing;

namespace Uno.Extensions.Reactive.Tests.Operators;

[TestClass]
public partial class Given_SelectFeed : FeedTests
{
	[TestMethod]
	public async Task When_SelectFeed_Then_CompilesToCoreRules()
		=> await FeedCoreRules
			.Using(Feed.Async(async _ => 42))
			.WhenFeed(src => new SelectFeed<int, MyRecord>(src, i => new MyRecord(i)))
			.Then_CompilesToCoreRules(CT);

	private record MyRecord(int Value);
}
