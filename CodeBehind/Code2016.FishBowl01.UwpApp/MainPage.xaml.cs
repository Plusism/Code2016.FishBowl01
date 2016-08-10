using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Code2016.FishBowl01.UwpApp
{
	/// <summary>
	/// Code2016 きんぎょばち (1) BGMとSE鳴らすモバイルアプリ
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// BGM音量
		/// </summary>
		public double _volume = 0.5;

		/// <summary>
		/// BGMボリューム操作時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MusicVolume_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
		{
			if (this.MusicMediaElement == null)
				return;
			_volume = this.MusicVolume.Value / 100;
			this.MusicMediaElement.Volume = _volume;
		}

		/// <summary>
		/// BGMミュート操作時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MusicMute_Click(object sender, RoutedEventArgs e)
		{
			var flag = !(this.MusicMute.IsChecked ?? false);
			this.MusicVolume.IsEnabled = flag;
			this.MusicPlaybackRate.IsEnabled = flag;
			this.MusicButton1.IsEnabled = flag;
			this.MusicButton2.IsEnabled = flag;
			this.MusicButton3.IsEnabled = flag;
			this.MusicButton4.IsEnabled = flag;
			this.MusicMediaElement.Volume = (flag) ? _volume : 0;
		}

		/// <summary>
		/// BGM音量(最大)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MusicButton1_Click(object sender, RoutedEventArgs e)
		{
			_volume = 1;
			this.MusicVolume.Value = _volume * 100;
			this.MusicMediaElement.Volume = _volume;
		}

		/// <summary>
		/// BGM音量(標準)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MusicButton2_Click(object sender, RoutedEventArgs e)
		{
			_volume = 0.5;
			this.MusicVolume.Value = _volume * 100;
			this.MusicMediaElement.Volume = _volume;
		}

		/// <summary>
		/// BGMフェードアウト(速め)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void MusicButton3_Click(object sender, RoutedEventArgs e)
		{
			do
			{
				_volume -= 0.01;
				this.MusicVolume.Value = _volume * 100;
				this.MusicMediaElement.Volume = _volume;
				await Task.Delay(25);
			} while (_volume > 0);
		}

		/// <summary>
		/// BGMフェードアウト(遅め)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void MusicButton4_Click(object sender, RoutedEventArgs e)
		{
			do
			{
				_volume -= 0.01;
				this.MusicVolume.Value = _volume * 100;
				this.MusicMediaElement.Volume = _volume;
				await Task.Delay(50);
			} while (_volume > 0);
		}

		/// <summary>
		/// BGMを選択時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MusicListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.MusicListBox.SelectedIndex == -1)
				return;
			var tag = (this.MusicListBox.SelectedItem as ListBoxItem).Tag;
			this.MusicMediaElement.Source = new Uri($"ms-appx:///Assets/Music/{tag}.mp3");
			this.MusicMediaElement.Play();
		}

		/// <summary>
		/// BGMのメディアがオープンされた後(テンポの再設定)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MusicMediaElement_MediaOpened(object sender, RoutedEventArgs e)
		{
			var rate = double.Parse((string)(this.MusicPlaybackRate.SelectedItem as ComboBoxItem).Content);
			this.MusicMediaElement.PlaybackRate = rate;
		}

		/// <summary>
		/// BGMテンポを選択時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MusicPlaybackRate_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.MusicMediaElement == null)
				return;
			var rate = double.Parse((string)(this.MusicPlaybackRate.SelectedItem as ComboBoxItem).Content);
			this.MusicMediaElement.PlaybackRate = rate;
		}

		/// <summary>
		/// BGM停止ボタンをクリック時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MusicStop_Click(object sender, RoutedEventArgs e)
		{
			this.MusicMediaElement.Stop();
			this.MusicListBox.SelectedIndex = -1;
		}

		/// <summary>
		/// SE再生ボタンをクリック時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SoundButton_Click(object sender, RoutedEventArgs e)
		{
			var tag = (sender as Button).Tag;
			this.SoundMediaElement.Source = new Uri($"ms-appx:///Assets/Sound/{tag}.mp3");
			this.SoundMediaElement.Play();
		}
	}
}
