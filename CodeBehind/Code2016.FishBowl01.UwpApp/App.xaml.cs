using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Code2016.FishBowl01.UwpApp
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	sealed partial class App : Application
	{
		/// <summary>
		/// Initializes the singleton application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App()
		{
			this.InitializeComponent();
			this.Suspending += OnSuspending;
		}

		/// <summary>
		/// Invoked when the application is launched normally by the end user.  Other entry points
		/// will be used such as when the application is launched to open a specific file.
		/// </summary>
		/// <param name="e">Details about the launch request and process.</param>
		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
#if DEBUG
			if (System.Diagnostics.Debugger.IsAttached)
			{
				this.DebugSettings.EnableFrameRateCounter = true;
			}
#endif

			// タイトルバー領域までアプリの表示を拡張する
			var coreTitleBar = Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar;
			coreTitleBar.ExtendViewIntoTitleBar = true;
			// タイトルバー領域のカラーリングを指定する
			var appTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
			appTitleBar.BackgroundColor = Color.FromArgb(0xFF, 0x76, 0xAC, 0x90);
			appTitleBar.ForegroundColor = Colors.White;
			appTitleBar.InactiveBackgroundColor = Color.FromArgb(0xFF, 0x76, 0xAC, 0x90);
			appTitleBar.InactiveForegroundColor = Color.FromArgb(0xff, 0x66, 0x66, 0x66);
			appTitleBar.ButtonBackgroundColor = Color.FromArgb(0xFF, 0x76, 0xAC, 0x90);
			appTitleBar.ButtonForegroundColor = Colors.White;
			appTitleBar.ButtonInactiveBackgroundColor = Color.FromArgb(0xFF, 0xCE, 0xE6, 0xA0);
			appTitleBar.ButtonInactiveForegroundColor = Color.FromArgb(0xff, 0x34, 0x34, 0x34);
			appTitleBar.ButtonHoverBackgroundColor = Color.FromArgb(0xff, 0x15, 0x4E, 0x60);
			appTitleBar.ButtonHoverForegroundColor = Colors.White;
			appTitleBar.ButtonPressedBackgroundColor = Color.FromArgb(0xff, 0x34, 0x34, 0x34);
			appTitleBar.ButtonPressedForegroundColor = Colors.White;

			Frame rootFrame = Window.Current.Content as Frame;

			// Do not repeat app initialization when the Window already has content,
			// just ensure that the window is active
			if (rootFrame == null)
			{
				// Create a Frame to act as the navigation context and navigate to the first page
				rootFrame = new Frame();

				rootFrame.NavigationFailed += OnNavigationFailed;

				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					//TODO: Load state from previously suspended application
				}

				// Place the frame in the current Window
				Window.Current.Content = rootFrame;
			}

			if (e.PrelaunchActivated == false)
			{
				if (rootFrame.Content == null)
				{
					// When the navigation stack isn't restored navigate to the first page,
					// configuring the new page by passing required information as a navigation
					// parameter
					rootFrame.Navigate(typeof(MainPage), e.Arguments);
				}
				// Ensure the current window is active
				Window.Current.Activate();
			}
		}

		/// <summary>
		/// Invoked when Navigation to a certain page fails
		/// </summary>
		/// <param name="sender">The Frame which failed navigation</param>
		/// <param name="e">Details about the navigation failure</param>
		void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}

		/// <summary>
		/// Invoked when application execution is being suspended.  Application state is saved
		/// without knowing whether the application will be terminated or resumed with the contents
		/// of memory still intact.
		/// </summary>
		/// <param name="sender">The source of the suspend request.</param>
		/// <param name="e">Details about the suspend request.</param>
		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: Save application state and stop any background activity
			deferral.Complete();
		}
	}
}
