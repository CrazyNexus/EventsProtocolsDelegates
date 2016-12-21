//
// ViewController.cs
//
// Created by Thomas Dubiel on 21.12.2016
// Copyright 2016 Thomas Dubiel. All rights reserved.
//
using System;

using UIKit;
using Foundation;

namespace EventsProtocolsDelegates
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			button1.AddTarget(Button2_TouchUpInside, UIControlEvent.TouchUpInside | UIControlEvent.TouchCancel);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		void Button2_TouchUpInside(object sender, EventArgs e)
		{
			if (sender == button1)
				Console.WriteLine("Button 1 fired");
			else
			{
				ImyFace gring = new myclass();
				gring.printName();
			}


			MyAlertDelegate alertDelegate = new MyAlertDelegate();
			UIAlertView alertView = new UIAlertView("What's up?", "What do You want from me?", alertDelegate, "Cancel", new string[] { "Yes", "No", "Maybe" });
			alertView.Show();
		}
	}

	interface ImyFace
	{
		void printName();
	}

	public class myclass : ImyFace
	{
		public void printName()
		{
			Console.WriteLine("Thomas");
		}
	}

	public class MyAlertDelegate : UIAlertViewDelegate
	{
		public override void Clicked(UIAlertView alertview, nint buttonIndex)
		{
			Console.WriteLine(buttonIndex.ToString() + " clicked");
		}
	}
}
