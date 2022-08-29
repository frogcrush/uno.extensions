﻿namespace TestHarness.UITest;

public class Given_ContentDialog : NavigationTestBase
{
	[TestCase("SimpleDialogNavRequestButton",0, false)]
	[TestCase("SimpleDialogCodebehindButton", 0, false)]
	[TestCase("SimpleDialogCodebehindWithCancelButton", 0, false)]
	[TestCase("SimpleDialogCodebehindWithCancelButton", 3, true)]
	public async Task When_SimpleContentDialog(string dialogButton,int delayInSeconds, bool dialogCancelled)
	{
		InitTestSection(TestSections.Dialogs);

		App.WaitThenTap("ContentDialogsButton");
		
		App.WaitElement("DialogsContentDialogsPage");
		var screenBefore=TakeScreenshot("When_Dialog_Before");
		App.Tap(dialogButton);
		var screenAfter = TakeScreenshot("When_Dialog_After");
		ImageAssert.AreNotEqual(screenBefore, screenAfter);

		if (delayInSeconds > 0)
		{
			await Task.Delay(delayInSeconds*1000);
			var screenAfterDelay = TakeScreenshot("When_Dialog_After_Delay");
			if (dialogCancelled)
			{
				ImageAssert.AreNotEqual(screenAfter, screenAfterDelay);
			}
			else
			{
				ImageAssert.AreEqual(screenAfter, screenAfterDelay);

			}
		}

		if (!dialogCancelled) { 
			App.WaitThenTap("DialogsSimpleDialogCloseButton");
		}

		await Task.Delay(AppExtensions.UIWaitTimeInMilliseconds);

		var screenClosed = TakeScreenshot("When_Dialog_Closed");
		ImageAssert.AreEqual(screenBefore, screenClosed,tolerance: PixelTolerance.Exclusive(Constants.DefaultPixelTolerance));
	}

}