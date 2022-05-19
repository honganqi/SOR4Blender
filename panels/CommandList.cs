using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SOR4_Blender.panels
{
    public partial class CommandList : Form
    {
        MainWindow _mainwindow;
        bool speedRevPos;
        bool healthDeathPos;
        bool charsCustomizePos;

        public CommandList(MainWindow mainwindow)
        {
            InitializeComponent();
            _mainwindow = mainwindow;
        }

        public Dictionary<string, MainWindow.CommandClass> GetCommandSettings()
        {
            Dictionary<string, MainWindow.CommandClass> commands = new();

            commands.Add("speed", _mainwindow.commandDict["speed"]);
            commands["speed"].Enabled = chkSpeed.Checked;
            commands["speed"].Interval = int.Parse(txtSpeed.Text);
            commands["speed"].IntervalType = cmbSpeed.SelectedItem.ToString();
            commands["speed"].IntervalEnd = int.Parse(txtSpeed2.Text);

            commands.Add("size", _mainwindow.commandDict["size"]);
            commands["size"].Enabled = chkSize.Checked;
            commands["size"].Interval = int.Parse(txtSize.Text);
            commands["size"].IntervalType = cmbSize.SelectedItem.ToString();
            commands["size"].IntervalEnd = int.Parse(txtSize2.Text);

            commands.Add("health", _mainwindow.commandDict["health"]);
            commands["health"].Enabled = chkHealth.Checked;
            commands["health"].Interval = int.Parse(txtHealth.Text);
            commands["health"].IntervalType = cmbHealth.SelectedItem.ToString();
            commands["health"].IntervalEnd = int.Parse(txtHealth2.Text);

            commands.Add("gravity", _mainwindow.commandDict["gravity"]);
            commands["gravity"].Enabled = chkGravity.Checked;
            commands["gravity"].Interval = int.Parse(txtGravity.Text);
            commands["gravity"].IntervalType = cmbGravity.SelectedItem.ToString();
            commands["gravity"].IntervalEnd = int.Parse(txtGravity2.Text);

            commands.Add("lives", _mainwindow.commandDict["lives"]);
            commands["lives"].Enabled = chkLives.Checked;
            commands["lives"].Interval = int.Parse(txtLives.Text);
            commands["lives"].IntervalType = cmbLives.SelectedItem.ToString();
            commands["lives"].IntervalEnd = int.Parse(txtLives2.Text);

            commands.Add("stars", _mainwindow.commandDict["stars"]);
            commands["stars"].Enabled = chkStars.Checked;
            commands["stars"].Interval = int.Parse(txtStars.Text);
            commands["stars"].IntervalType = cmbStars.SelectedItem.ToString();
            commands["stars"].IntervalEnd = int.Parse(txtStars2.Text);

            //commands.Add("characters", _mainwindow.commandDict["characters"]);
            //commands["characters"].Enabled = chkChars.Checked;
            //commands["characters"].Interval = int.Parse(txtChars.Text);
            //commands["characters"].IntervalType = cmbChars.SelectedItem.ToString();
            //commands["characters"].IntervalEnd = int.Parse(txtChars2.Text);

            commands.Add("moves", _mainwindow.commandDict["moves"]);
            commands["moves"].Enabled = chkMoves.Checked;
            commands["moves"].Interval = int.Parse(txtMoves.Text);
            commands["moves"].IntervalType = cmbMoves.SelectedItem.ToString();
            commands["moves"].IntervalEnd = int.Parse(txtMoves2.Text);

            return commands;
        }

        public void InitializeForm(MainWindow mainwindow)
        {
            // speed
            chkSpeed.Checked = mainwindow.commandDict["speed"].Enabled;
            cmbSpeed.SelectedIndex = cmbSpeed.FindString(mainwindow.commandDict["speed"].IntervalType);
            txtSpeed.Text = mainwindow.commandDict["speed"].Interval.ToString();
            txtSpeed2.Text = mainwindow.commandDict["speed"].IntervalEnd.ToString();
            // size
            chkSize.Checked = mainwindow.commandDict["size"].Enabled;
            cmbSize.SelectedIndex = cmbSize.FindString(mainwindow.commandDict["size"].IntervalType);
            txtSize.Text = mainwindow.commandDict["size"].Interval.ToString();
            txtSize2.Text = mainwindow.commandDict["size"].IntervalEnd.ToString();
            // health
            chkHealth.Checked = mainwindow.commandDict["health"].Enabled;
            cmbHealth.SelectedIndex = cmbHealth.FindString(mainwindow.commandDict["health"].IntervalType);
            txtHealth.Text = mainwindow.commandDict["health"].Interval.ToString();
            txtHealth2.Text = mainwindow.commandDict["health"].IntervalEnd.ToString();
            // gravity
            chkGravity.Checked = mainwindow.commandDict["gravity"].Enabled;
            cmbGravity.SelectedIndex = cmbGravity.FindString(mainwindow.commandDict["gravity"].IntervalType);
            txtGravity.Text = mainwindow.commandDict["gravity"].Interval.ToString();
            txtGravity2.Text = mainwindow.commandDict["gravity"].IntervalEnd.ToString();
            // lives
            chkLives.Checked = mainwindow.commandDict["lives"].Enabled;
            cmbLives.SelectedIndex = cmbLives.FindString(mainwindow.commandDict["lives"].IntervalType);
            txtLives.Text = mainwindow.commandDict["lives"].Interval.ToString();
            txtLives2.Text = mainwindow.commandDict["lives"].IntervalEnd.ToString();
            // stars
            chkStars.Checked = mainwindow.commandDict["stars"].Enabled;
            cmbStars.SelectedIndex = cmbStars.FindString(mainwindow.commandDict["stars"].IntervalType);
            txtStars.Text = mainwindow.commandDict["stars"].Interval.ToString();
            txtStars2.Text = mainwindow.commandDict["stars"].IntervalEnd.ToString();
            // characters
            //chkChars.Checked = mainwindow.commandDict["characters"].Enabled;
            //cmbChars.SelectedIndex = cmbChars.FindString(mainwindow.commandDict["characters"].IntervalType);
            //txtChars.Text = mainwindow.commandDict["characters"].Interval.ToString();
            //txtChars2.Text = mainwindow.commandDict["characters"].IntervalEnd.ToString();
            // moves
            chkMoves.Checked = mainwindow.commandDict["moves"].Enabled;
            cmbMoves.SelectedIndex = cmbMoves.FindString(mainwindow.commandDict["moves"].IntervalType);
            txtMoves.Text = mainwindow.commandDict["moves"].Interval.ToString();
            txtMoves2.Text = mainwindow.commandDict["moves"].IntervalEnd.ToString();
        }

        private void CommandList_MouseDown(object sender, MouseEventArgs e)
        {
            _mainwindow.lastLocation = e.Location;
        }

        private void CommandList_MouseMove(object sender, MouseEventArgs e)
        {
            _mainwindow.MoveWindow(e);
        }

        private void btnCharsCustomize_Click(object sender, EventArgs e)
        {
            _mainwindow.mainform.SwitchPanel("character");
        }

        private void cmbSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpeed.SelectedIndex == 1)
            {
                labelSpeedRange.Visible = true;
                txtSpeed2.Visible = true;
                if (speedRevPos)
                {
                    chkSpeedReverse.Left += 60;
                    speedRevPos = false;
                }   
            }
            else
            {
                labelSpeedRange.Visible = false;
                txtSpeed2.Visible = false;
                if (!speedRevPos)
                {
                    chkSpeedReverse.Left -= 60;
                    speedRevPos = true;
                }
            }
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSize.SelectedIndex == 1)
            {
                labelSizeRange.Visible = true;
                txtSize2.Visible = true;
            }
            else
            {
                labelSizeRange.Visible = false;
                txtSize2.Visible = false;
            }
        }

        private void cmbHealth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHealth.SelectedIndex == 1)
            {
                labelHealthRange.Visible = true;
                txtHealth2.Visible = true;
                if (healthDeathPos)
                {
                    chkHealthDeath.Left += 60;
                    healthDeathPos = false;
                }
            }
            else
            {
                labelHealthRange.Visible = false;
                txtHealth2.Visible = false;
                if (!healthDeathPos)
                {
                    chkHealthDeath.Left -= 60;
                    healthDeathPos = true;
                }
            }
        }

        private void cmbGravity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGravity.SelectedIndex == 1)
            {
                labelGravityRange.Visible = true;
                txtGravity2.Visible = true;
            }
            else
            {
                labelGravityRange.Visible = false;
                txtGravity2.Visible = false;
            }
        }

        private void cmbLives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLives.SelectedIndex == 1)
            {
                labelLivesRange.Visible = true;
                txtLives2.Visible = true;
            }
            else
            {
                labelLivesRange.Visible = false;
                txtLives2.Visible = false;
            }
        }

        private void cmbStars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStars.SelectedIndex == 1)
            {
                labelStarsRange.Visible = true;
                txtStars2.Visible = true;
            }
            else
            {
                labelStarsRange.Visible = false;
                txtStars2.Visible = false;
            }
        }

        private void cmbChars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChars.SelectedIndex == 1)
            {
                labelCharsRange.Visible = true;
                txtChars2.Visible = true;
                if (charsCustomizePos)
                {
                    btnCharsCustomize.Left += 60;
                    charsCustomizePos = false;
                }
            }
            else
            {
                labelCharsRange.Visible = false;
                txtChars2.Visible = false;
                if (!charsCustomizePos)
                {
                    btnCharsCustomize.Left -= 60;
                    charsCustomizePos = true;
                }
            }
        }

        private void cmbMoves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMoves.SelectedIndex == 1)
            {
                labelMovesRange.Visible = true;
                txtMoves2.Visible = true;
            }
            else
            {
                labelMovesRange.Visible = false;
                txtMoves2.Visible = false;
            }
        }
    }
}
