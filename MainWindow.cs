using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Net.Http;
using System.Globalization;
using SOR4VSChat;
using System.Threading;

namespace SOR4_Blender
{
    public partial class MainWindow : Form
    {
        // internal variables
        public Assembly imageAssembly = Assembly.GetExecutingAssembly();

        // class references
        public MainForm mainform;

        public bool updateAvailable = false;
        string updateurl = "https://raw.githubusercontent.com/honganqi/SOR4_Blender/main/latest.json";
        string downloadURL = "";

        CancellationTokenSource mainTokenSource;

        // window stuff
        public Point lastLocation;

        public MainWindow()
        {
            InitializeComponent();

            mainform = new MainForm(this) { TopLevel = false, TopMost = true };
            btnMinimize.BackColor = Color.FromArgb(33, 33, 33);
            btnClose.BackColor = Color.FromArgb(33, 33, 33);

            // set titlebar info
            string currentVerString = Application.ProductVersion;
            List<string> currentVersionSplit = currentVerString.Split('.').ToList();
            if (currentVersionSplit[3] == "0") currentVersionSplit.RemoveAt(3);
            if (currentVersionSplit[2] == "0") currentVersionSplit.RemoveAt(2);
            labelVerNum.Text = "v" + string.Join(".", currentVersionSplit) + " by honganqi";

            // place embedded images
            Stream thumbStream = imageAssembly.GetManifestResourceStream("SOR4_Blender.img.bmc.png");
            Bitmap thumbBitmap = new(thumbStream);
            imgBMCSupport.Image = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("SOR4_Blender.img.sflogo.png");
            thumbBitmap = new(thumbStream);
            imgSF.Image = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("SOR4_Blender.img.youtube.png");
            thumbBitmap = new(thumbStream);
            imgYoutube.Image = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("SOR4_Blender.img.twitch.png");
            thumbBitmap = new(thumbStream);
            imgTwitch.Image = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("SOR4_Blender.img.exit.png");
            thumbBitmap = new(thumbStream);
            btnClose.BackgroundImage = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("SOR4_Blender.img.min.png");
            thumbBitmap = new(thumbStream);
            btnMinimize.BackgroundImage = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("SOR4_Blender.img.save.png");
            thumbBitmap = new(thumbStream);
            mainform.btnSaveSettings.BackgroundImage = thumbBitmap;

            commandDict = new();
            GetSettings();

            activePanel.Controls.Add(mainform);
            mainform.commandListPanel.InitializeForm(this);
            mainform.Show();
            mainform.SwitchPanel("main");

            CheckUpdate(updateurl);
        }

        public async void CheckUpdate(string url)
        {
            List<string> onlineVer = new();
            List<string> currentVer = new();
            var client = new HttpClient();
            var request = client.GetAsync(url);

            Task timeout = Task.Delay(3000);
            await Task.WhenAny(timeout, request);

            try
            {
                HttpResponseMessage response = request.Result;
                if (response.IsSuccessStatusCode)
                {
                    var page = response.Content.ReadAsStringAsync();
                    var queryResult = Newtonsoft.Json.JsonConvert.DeserializeObject<SOR4Bot.VersionClass>(page.Result);

                    if ((queryResult != null) && (queryResult.ReleaseDate != null))
                    {
                        DateTime releaseDate = DateTime.Parse(queryResult.ReleaseDate).ToUniversalTime();
                        string onlineVerString = queryResult.Version;
                        string currentVerString = Application.ProductVersion;
                        downloadURL = queryResult.DownloadURL;
                        if (onlineVerString.CompareTo(currentVerString) > 0)
                        {
                            List<string> versionSplit = onlineVerString.Split('.').ToList();
                            if (versionSplit[3] == "0") versionSplit.RemoveAt(3);
                            if (versionSplit[2] == "0") versionSplit.RemoveAt(2);
                            onlineVer.Add(string.Join(".", versionSplit));
                            onlineVer.Add(releaseDate.ToLocalTime().ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern));
                            btnUpdateNotif.Text = "v" + onlineVer[0] + " is now available!\nGET IT NOW!";
                            if (queryResult.Description != "")
                            {
                                ToolTip updateTooltip = new();
                                updateTooltip.SetToolTip(btnUpdateNotif, "Download from: " + queryResult.DownloadURL + "\n\n" + queryResult.Description);
                            }

                            versionSplit = new(currentVerString.Split('.').ToList());
                            if (versionSplit[3] == "0") versionSplit.RemoveAt(3);
                            if (versionSplit[2] == "0") versionSplit.RemoveAt(2);
                            currentVer.Add(string.Join(".", versionSplit));
                            currentVer.Add(releaseDate.ToLocalTime().ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern));
                            btnUpdateNotif.Show();
                        }
                    }
                }
                else
                {
                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.NotFound:
                            throw new Exception("The update file was not found on the server.");
                        case System.Net.HttpStatusCode.BadRequest:
                            throw new Exception("");
                        case System.Net.HttpStatusCode.InternalServerError:
                            throw new Exception("");
                        case System.Net.HttpStatusCode.MethodNotAllowed:
                            throw new Exception("");
                        case System.Net.HttpStatusCode.Forbidden:
                            throw new Exception("");
                    }
                }
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        public void GetUpdate()
        {
            if (downloadURL != "") System.Diagnostics.Process.Start(downloadURL);
        }

        public void StartBot()
        {
            commandDict = mainform.commandListPanel.GetCommandSettings();
            mainTokenSource = new();

            var runAll = Task.Factory.StartNew(() => Parallel.ForEach(commandDict, commandpair =>
            {
                CommandClass command = commandpair.Value;
                if (CheckCommandIfExistAndEnabled(command))
                {
                    int interval = command.Interval * 1000;
                    if (command.IntervalType == "Range")
                    {
                        Random rng = new();
                        interval = rng.Next(command.Interval * 1000, command.IntervalEnd * 1000);
                    }
                    command.CancelTokenSource = new();
                    List<int> allowedParams = CheckParams(command.Command);
                    ChangeEvent(command.Command, interval, command.CancelTokenSource.Token, allowedParams);
                }
            }
            ), mainTokenSource.Token);
        }

        public void StopBot()
        {
            mainTokenSource.Cancel();

            foreach (KeyValuePair<string, CommandClass> commandpair in commandDict)
            {
                if (commandpair.Value.CancelTokenSource != null)
                    commandpair.Value.CancelTokenSource.Cancel();
            }
        }

        private static Task ChangeEvent(string command, int interval, CancellationToken cancelToken, List<int> allowedParams)
        {
            return Task.Run(async () =>
            {
                SOR4Bot sor4bot = new();
                string[] commandpair = new string[] { command };
                try
                {
                    while (true)
                    {
                        if (cancelToken.IsCancellationRequested)
                            break;
                        Dictionary<string, Dictionary<int, int>> gameValues = sor4bot.CheckValues();
                        string response = sor4bot.RunCommand(commandpair, "", allowedParams);
                        await Task.Delay(interval);
                    }
                }
                catch (OperationCanceledException)
                {

                }
            }, cancelToken);

        }

        private void GetSettings()
        {
            Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

            Dictionary<string, string> commandstrings = new()
            {
                ["speed"] = "speed",
                ["size"] = "resize",
                ["health"] = "health",
                ["gravity"] = "gravity",
                ["lives"] = "life",
                ["stars"] = "star",
                //["characters"] = "randomchar",
                ["moves"] = "mixitup",
            };

            foreach (KeyValuePair<string, string> cmdpair in commandstrings)
            {
                CommandClass cmd = new();
                cmd.Command = cmdpair.Value;

                if (settings[cmdpair.Key + "_enabled"] != null)
                {
                    cmd.Enabled = Convert.ToBoolean(settings[cmdpair.Key + "_enabled"].Value);
                    cmd.Interval = Convert.ToInt32(settings[cmdpair.Key + "_interval"].Value);
                    cmd.IntervalType = Convert.ToString(settings[cmdpair.Key + "_type"].Value);
                    cmd.IntervalEnd = Convert.ToInt32(settings[cmdpair.Key + "_end"].Value);
                }
                else
                {
                    cmd.Enabled = true;
                    cmd.Interval = 300;
                    cmd.IntervalType = "Fixed";
                    cmd.IntervalEnd = 500; ;
                }

                commandDict.Add(cmdpair.Key, cmd);
            }
        }

        public void SaveSettings()
        {
            commandDict = mainform.commandListPanel.GetCommandSettings();
            string[] settingStrings = new string[]
            {
                "enabled",
                "interval",
                "type",
                "end"
            };
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

                foreach (KeyValuePair<string, CommandClass> commandpair in commandDict)
                {
                    CommandClass cmd = commandpair.Value;
                    foreach(string settingstr in settingStrings)
                    {
                        if (settings[commandpair.Key + "_" + settingstr] == null)
                            settings.Add(commandpair.Key + "_" + settingstr, ""); 
                    }
                    settings[commandpair.Key + "_enabled"].Value = cmd.Enabled.ToString();
                    settings[commandpair.Key + "_interval"].Value = cmd.Interval.ToString();
                    settings[commandpair.Key + "_type"].Value = cmd.IntervalType.ToString();
                    settings[commandpair.Key + "_end"].Value = cmd.IntervalEnd.ToString();
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                MessageBox.Show("Settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private bool CheckCommandIfExistAndEnabled(CommandClass commandclass)
        {
            string command = commandclass.Command;
            if (SOR4Bot.botCommandsList.ContainsKey(command) && commandclass.Enabled)
                return true;
            return false;
        }

        private List<int> CheckParams(string command)
        {
            List<int> allowedParams = new();
            switch (command)
            {
                case "speed":
                    allowedParams.Add(0);
                    allowedParams.Add(1);
                    allowedParams.Add(2);
                    allowedParams.Add(3);
                    allowedParams.Add(4);
                    if (mainform.commandListPanel.chkSpeedReverse.Checked)
                        allowedParams.Add(5);
                    break;
                case "randomchar":
                    foreach (KeyValuePair<string, int> charpair in SOR4Bot.characterIDs)
                    {
                        Control[] paramControls = mainform.panelCharacters.Controls.Find("chk_character" + charpair.Key, true);
                        {
                            if ((paramControls[0] as CheckBox)?.Checked == true)
                                allowedParams.Add(charpair.Value);
                        }
                    }
                    break;
            }
            return allowedParams;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // window movement stuff
        public void MoveWindow(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - lastLocation.X;
                int dy = e.Location.Y - lastLocation.Y;
                Location = new Point(Location.X + dx, Location.Y + dy);
            }
        }

        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            //lastLocation = e.Location;
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            //MoveWindow(e);
        }

        private void panelLeft_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void panelLeft_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            //lastLocation = e.Location;
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            //MoveWindow(e);
        }

        private void labelAuthor_MouseDown(object sender, MouseEventArgs e)
        {
            // lastLocation = e.Location;
        }

        private void labelAuthor_MouseMove(object sender, MouseEventArgs e)
        {
            //MoveWindow(e);
        }

        private void activePanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void activePanel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btnHealthPanel_Click(object sender, EventArgs e)
        {
            mainform.SwitchPanel("health");
        }

        private void btnCharPanel_Click(object sender, EventArgs e)
        {
            mainform.SwitchPanel("character");
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exitAsk = MessageBox.Show("You sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (exitAsk == DialogResult.No);
        }

        private void imgSF_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/projects/sor4-vs-chat/");
        }

        public class CommandClass
        {
            public string Command { get; set; }
            public bool Enabled { get; set; }
            public int Interval { get; set; }
            public string IntervalType { get; set; }
            public int IntervalEnd { get; set; }
            public CancellationTokenSource CancelTokenSource { get; set; }
        }

        public Dictionary<string, CommandClass> commandDict;
    }
}
