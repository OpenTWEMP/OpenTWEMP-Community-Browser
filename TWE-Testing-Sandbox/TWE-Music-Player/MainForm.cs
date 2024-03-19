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

            outputDevice.Volume = volumeTrackBar.Value / 100f;
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

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            volumeTrackBar.Scroll += (s, a) => outputDevice.Volume = volumeTrackBar.Value / 100f;
            volumeLabel.Text = volumeTrackBar.Value.ToString();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            outputDevice.Pause();
        }

        private void rewindButton_Click(object sender, EventArgs e)
        {
            audioFile.Position = 0;
            outputDevice.Play();
        }

        private void muteButton_Click(object sender, EventArgs e)
        {
            volumeTrackBar.Value = volumeTrackBar.Minimum;
            outputDevice.Volume = volumeTrackBar.Minimum / 100f;
            volumeLabel.Text = volumeTrackBar.Minimum.ToString();
        }
    }
}
