using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWE.MusicPlayer
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			List<string> mp3_files = FindAllMp3AudioFiles();

			foreach (var mp3_file in mp3_files)
			{
				mediaListBox.Items.Add(mp3_file);
			}
		}

		private List<string> FindAllMp3AudioFiles()
		{
			var mp3_files = new List<string>();

			string mp3_file_extension = ".mp3";
			string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
			foreach (string file in files)
			{
				if (file.EndsWith(mp3_file_extension))
				{
					mp3_files.Add(file);
				}
			}
			
			return mp3_files;
		}



		private WaveOutEvent outputDevice;
		private AudioFileReader audioFile;


		private void OnButtonPlayClick(object sender, EventArgs args)
		{
			if (outputDevice == null)
			{
				outputDevice = new WaveOutEvent();
				outputDevice.PlaybackStopped += OnPlaybackStopped;
			}
			if (audioFile == null)
			{
				audioFile = new AudioFileReader(mediaListBox.Text);
				outputDevice.Init(audioFile);
			}
			outputDevice.Play();
		}

		private void OnButtonStopClick(object sender, EventArgs args)
		{
			outputDevice.Stop();
		}

		private void OnPlaybackStopped(object sender, StoppedEventArgs args)
		{
			outputDevice.Dispose();
			outputDevice = null;
			audioFile.Dispose();
			audioFile = null;
		}

		private void mediaListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			mediaFileNameLabel.Text = mediaListBox.Text;
		}

		private void mediaPlayButton_Click(object sender, EventArgs e)
		{
			mediaPlayButton.Click += OnButtonPlayClick;
		}

		private void mediaStopButton_Click(object sender, EventArgs e)
		{
			mediaStopButton.Click += OnButtonStopClick;
		}
	}
}
