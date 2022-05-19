using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SOR4_Blender
{
    public partial class MainForm : Form
    {
        private MainWindow _mainwindow;
        bool botRunning = false;
        public panels.PanelCharacters panelCharacters;
        public panels.CommandList commandListPanel;


        public MainForm(MainWindow mainwindow)
        {
            InitializeComponent();
            _mainwindow = mainwindow;

            btnStartBot.Text = "\u25B6 START";
            panelCharacters = new panels.PanelCharacters(mainwindow) { TopLevel = false, TopMost = true };
            commandListPanel = new panels.CommandList(mainwindow) { TopLevel = false, TopMost = true };
        }

        public void SwitchPanel(string panelname)
        {
            chatPanel.Visible = false;
            chatPanel.Controls.Clear();
            switch (panelname)
            {
                case "main":
                    chatPanel.Controls.Add(commandListPanel);
                    commandListPanel.Show();
                    break;
                case "character":
                    chatPanel.Controls.Add(panelCharacters);
                    panelCharacters.Show();
                    break;
            }
            chatPanel.Visible = true;
        }

        private void btnStartBot_Click(object sender, EventArgs e)
        {
            if (botRunning)
            {
                btnStartBot.Text = "\u25B6 START";
                botRunning = false;
                _mainwindow.StopBot();
            }
            else
            {
                btnStartBot.Text = "\u25A0 STOP";
                botRunning = true;
                _mainwindow.StartBot();
            }

        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            _mainwindow.SaveSettings();
        }
    }
}
