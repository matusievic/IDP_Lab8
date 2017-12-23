﻿using System;
using System.Windows.Forms;

namespace GlobalHooks
{
    public partial class MainWindow : Form
    {
        private readonly Settings _tempConfig = new Settings();
        private readonly GlobalHooks _globalHooks;
        private Settings _config;

        public MainWindow()
        {
            InitializeComponent();
            ConfigInit();
            _globalHooks = new GlobalHooks(_config, MainWindowShow);
        }

        private void ConfigInit()
        {
            _config = _tempConfig.UpdateProgram();
            hooksMode.Checked = _config.isHooks;
            Email.Text = _config.Email;
            fileSize.Value = _config.FileSize > 5000 ? _config.FileSize : 5000;
            hideMode.Checked = _config.HideCheck;
        }

        private void SaveSettingsButtonClick(object sender, EventArgs e)
        {
            _config.Email = Email.Text;
            _config.isHooks = hooksMode.Checked;
            _config.FileSize = (long) fileSize.Value;
            _config.HideCheck = hideMode.Checked;

            _tempConfig.SaveConfig(_config);
        }

        private void HideProgramButtonClick(object sender, EventArgs e)
        {
            Hide();
        }

        private void MainWindowShown(object sender, EventArgs e)
        {
            if (_config.HideCheck)
            {
                Hide();
            }
        }

        private void MainWindowShow()
        {
            Show();
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}