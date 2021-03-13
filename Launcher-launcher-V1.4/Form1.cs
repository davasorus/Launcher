using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;

/*
created 04/10 by Sean Davitt
Ideally for the memes but also to get all these launchers under control
Last modified: 08/20/19
Please pm me on reddit @ u/davasorus or dm me on twitter at davasorus if you have any questions or issues
~~~~~~~~~~~~Current Progress~~~~~~~~~~~~~~

V 1.0 - complete
    Initial creation - proof of concept

v 1.1 - complete
    Fleshing out of available launchers,
    fleshing out xml,
    users are now able to save configuration for xml

v 1.2 - complete
    Comments/Explanation on code

v 1.3 - complete
    Intelligent Launcher-xml functionality

v 1.4 - complete
    Intelligent Lack-of-Launcher functionality
    added final launcher

~~~~~~~~ FUTURE IMPLIMENTATION~~~~~~~~~~~~~~~~~~
V 1.5
    add support bot
    Process Kill buttons - Complete
    Kill all button - complete
    start all button - complete
    Add Help button

v 2.0
    Folder selector functionality
 */

namespace Launcher_launcher_1._4
{
    public partial class Form1 : Form
    {
        //initializes the xml document labeled: StartupSettings
        private XmlDocument StartupSettings = new XmlDocument();

        //creates strings that are pseudo-null
        private string SEL = @"";

        private string BEL = @"";
        private string OEL = @"";
        private string UEL = @"";
        private string DEL = @"";
        private string CYOEL = "";

        //what the base canvas/form does when it loads up every time
        private void Form1_Load(object sender, EventArgs e)
        {
            InitialLoadofXML();

            LauncherCheck();

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        public Form1()
        {
            InitializeComponent();
        }

        //actions the form takes when looking for the configuration xml
        private void InitialLoadofXML()
        {
            //Checking if the LauncherFiles.xml exists, and loading the data if it does.
            if (File.Exists("LauncherFiles.xml"))
            {
                StartupSettings.Load("LauncherFiles.xml");
                SteamExeLocation.Text = StartupSettings.GetElementsByTagName("SEL")[0].InnerText;
                BattleExeLocation.Text = StartupSettings.GetElementsByTagName("BEL")[0].InnerText;
                OriginExeLocation.Text = StartupSettings.GetElementsByTagName("OEL")[0].InnerText;
                UbiExeLocation.Text = StartupSettings.GetElementsByTagName("UEL")[0].InnerText;
                DiscExeLocation.Text = StartupSettings.GetElementsByTagName("DEL")[0].InnerText;
                CYOExeLocation.Text = StartupSettings.GetElementsByTagName("CYOL")[0].InnerText;
                CYOExeName.Text = StartupSettings.GetElementsByTagName("CYON")[0].InnerText;
            }

            //Creation of a new LauncherFiles.xml if one does not already exist.
            else
            {
                SEL = SteamExeLocation.Text;
                BEL = BattleExeLocation.Text;
                OEL = OriginExeLocation.Text;
                UEL = UbiExeLocation.Text;
                DEL = DiscExeLocation.Text;

                //root of the XML
                XmlNode root = StartupSettings.CreateElement("root");
                StartupSettings.AppendChild(root);

                //Steam path xml information
                XmlNode SELPathNode = StartupSettings.CreateElement("SEL");
                SELPathNode.InnerText = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Steam";
                root.AppendChild(SELPathNode);

                //Battle .Net path xml information
                XmlNode BELPathNode = StartupSettings.CreateElement("BEL");
                BELPathNode.InnerText = "PC User Account Name";
                root.AppendChild(BELPathNode);

                //Origin path xml information
                XmlNode OELPathNode = StartupSettings.CreateElement("OEL");
                OELPathNode.InnerText = "PC User Account Name";
                root.AppendChild(OELPathNode);

                //Ubisoft path xml information
                XmlNode UELPathNode = StartupSettings.CreateElement("UEL");
                UELPathNode.InnerText = "PC User Account Name";
                root.AppendChild(UELPathNode);

                //Discord path xml information
                XmlNode DELPathNode = StartupSettings.CreateElement("DEL");
                DELPathNode.InnerText = "PC User Account Name";
                root.AppendChild(DELPathNode);

                //Create Your Own Location xml information
                XmlNode CYOLPathNode = StartupSettings.CreateElement("CYOL");
                CYOLPathNode.InnerText = "PC User Account Name";
                root.AppendChild(CYOLPathNode);

                //Create your own Name xml information
                XmlNode CYONPathNode = StartupSettings.CreateElement("CYON");
                CYONPathNode.InnerText = "Program Short cut name";
                root.AppendChild(CYONPathNode);

                //Save the start up settings
                StartupSettings.Save("LauncherFiles.xml");
            }
        }

        //Actions done on button click for steam
        //the steam executable is activate as long as the correct root folder is selected
        private void Steam_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                string batdir = string.Format(SteamExeLocation.Text);
                proc = new Process();

                proc.StartInfo.WorkingDirectory = batdir;
                proc.StartInfo.FileName = "Steam.lnk";
                proc.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        //Actions done on button click for battle .net
        //the battle .net executable is activated as long as the correct root folder is selected
        private void Battle_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Users\" + BattleExeLocation.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Battle.net.lnk"))
            {
                BEL = @"C:\Users\" + BattleExeLocation.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\";
            }
            else
            {
                BEL = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Battle.net\";
            }

            Process proc = null;
            try
            {
                string batdir = string.Format(BEL);
                proc = new Process();
                proc.StartInfo.WorkingDirectory = batdir;
                proc.StartInfo.FileName = "Battle.net.lnk";
                proc.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        //Actions done on button click for Battle Origin
        //the origin executable is activated as long as the correct root folder is selected
        private void Origin_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Users\" + OriginExeLocation.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Origin.lnk"))
            {
                OEL = @"C:\Users\" + OriginExeLocation.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\";
            }
            else
            {
                OEL = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Origin";
            }

            ;
            Process proc = null;
            try
            {
                string batdir = string.Format(OEL);
                proc = new Process();
                proc.StartInfo.WorkingDirectory = batdir;
                proc.StartInfo.FileName = "Origin.lnk";
                proc.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        //Actions done on button click for Ubisoft
        //the Ubisoft executable is activated as long as the correct root folder is selected
        private void Ubi_Click(object sender, EventArgs e)
        {
            UEL = @"C:\Users\" + UbiExeLocation.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Ubisoft\Uplay";

            Process proc = null;
            try
            {
                string batdir = string.Format(UEL);
                proc = new Process();
                proc.StartInfo.WorkingDirectory = batdir;
                proc.StartInfo.FileName = "Uplay.lnk";
                proc.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        //Actions done on button click for discord
        //the discord executable is activated as long as the correct root folder is selected
        private void Discord_Click(object sender, EventArgs e)
        {
            DEL = @"C:\Users\" + DiscExeLocation.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Discord Inc\";

            Process proc = null;
            try
            {
                string batdir = string.Format(DEL);
                proc = new Process();
                proc.StartInfo.WorkingDirectory = batdir;
                proc.StartInfo.FileName = "Discord.lnk";
                proc.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        //Actions done when adding in a user generated shortcut
        private void CreateYourOwn_Click(object sender, EventArgs e)
        {
            CYOEL = CYOExeLocation.Text;
            Process proc = null;
            try
            {
                string batdir = string.Format(CYOEL);
                proc = new Process();
                proc.StartInfo.WorkingDirectory = batdir;
                proc.StartInfo.FileName = CYOExeName.Text + ".lnk";
                proc.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        private void StartAll_Click(object sender, EventArgs e)
        {
            Steam_Click(sender, e);

            Battle_Click(sender, e);

            Origin_Click(sender, e);

            Ubi_Click(sender, e);

            Discord_Click(sender, e);

            CreateYourOwn_Click(sender, e);

            StartAllCheck();

            KillAllCheck();
        }

        //code to check and see if launchers can be found at file path found in configuration panel
        private void LauncherCheck()
        {
            //steam information
            if (!File.Exists(SteamExeLocation.Text + @"\Steam.lnk"))
            {
                SteamStatusBox.Visible = true;
                SteamStatusBox.Text = "Steam was not found. The search box is either empty, file path is wrong, or Steam is not installed.";
            }
            else
            {
                SteamStatusBox.Visible = false;
                SteamStatusBox.Text = "";
            }

            if (SteamStatusBox.Text != "")
            {
                SteamDownload.Visible = true;
            }
            else
            {
                SteamDownload.Visible = false;
            }

            //Battle Net Information
            if (File.Exists(@"C:\Users\" + BattleExeLocation.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Battle.net.lnk"))
            {
                BattleStatusBox.Visible = false;
                BattleStatusBox.Text = "";
            }
            else if (File.Exists(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Battle.net\Battle.net.lnk"))
            {
                BattleStatusBox.Visible = false;
                BattleStatusBox.Text = "";
            }
            else
            {
                BattleStatusBox.Visible = true;
                BattleStatusBox.Text = "Battle Net was not found. This box is either empty, file path is wrong, or Battle Net is not installed.";
            }

            if (BattleStatusBox.Text != "")
            {
                BattleDownload.Visible = true;
            }
            else
            {
                BattleDownload.Visible = false;
            }

            //Origin Information
            if (File.Exists(@"C:\Users\" + OriginExeLocation.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Origin.lnk"))
            {
                OriginStatusBox.Visible = false;
                OriginStatusBox.Text = "";
            }
            else if (File.Exists(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Origin\Origin.lnk"))
            {
                OriginStatusBox.Visible = false;
                OriginStatusBox.Text = "";
            }
            else
            {
                OriginStatusBox.Visible = true;
                OriginStatusBox.Text = "Origin was not found. The search box is either empty, file path is wrong, or Origin is not installed.";
            }

            if (OriginStatusBox.Text != "")
            {
                OriginDownload.Visible = true;
            }
            else
            {
                OriginDownload.Visible = false;
            }

            //Uplay Information
            if (!File.Exists(@"C:\Users\" + UbiExeLocation.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Ubisoft\Uplay\Uplay.lnk"))
            {
                UbiStatusBox.Visible = true;
                UbiStatusBox.Text = "Uplay was not found. The search box is either empty, file path is wrong, or Uplay is not installed.";
            }
            else
            {
                UbiStatusBox.Visible = false;
                UbiStatusBox.Text = "";
            }

            if (UbiStatusBox.Text != "")
            {
                UbiDownload.Visible = true;
            }
            else
            {
                UbiDownload.Visible = false;
            }

            //Discord Information
            if (!File.Exists(@"C:\Users\" + DiscExeLocation.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Discord Inc\Discord.lnk"))
            {
                DiscStatusBox.Visible = true;
                DiscStatusBox.Text = "Discord was not found. The search box is either empty, file path is wrong, or Discord is not installed.";
            }
            else
            {
                DiscStatusBox.Visible = false;
                DiscStatusBox.Text = "";
            }

            if (DiscStatusBox.Text != "")
            {
                DiscDownload.Visible = true;
            }
            else
            {
                DiscDownload.Visible = false;
            }

            //Create Your Own Information
            if (!File.Exists(CYOExeLocation.Text + CYOExeName.Text + ".lnk"))
            {
                CYOStatusBox.Visible = true;
                CYOStatusBox.Text = "The Start Menu item you wanted to add cannot be found. Either your PC username is missing/wrong or the name of the program is wrong/the box is empty.";
            }
            else
            {
                CYOStatusBox.Visible = false;
                CYOStatusBox.Text = "";
            }
        }

        //code to check to see if processes are started
        //will only display if a launcher process is started
        private void KillAllCheck()
        {
            //steam specific
            try
            {
                Process[] sname = Process.GetProcessesByName("Steam");
                if (sname.Length == 0)
                    KillAll.Visible = false;
                else
                    KillAll.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            //Battle .net specific
            try
            {
                Process[] bname = Process.GetProcessesByName("Battle.net Launcher");
                if (bname.Length == 0)
                    KillAll.Visible = false;
                else
                    KillAll.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            try
            {
                Process[] bname1 = Process.GetProcessesByName("Agent");
                if (bname1.Length == 0)
                    KillAll.Visible = false;
                else
                    KillAll.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            //origin specific
            try
            {
                Process[] oname = Process.GetProcessesByName("Origin");
                if (oname.Length == 0)
                    KillAll.Visible = false;
                else
                    KillAll.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            //uplay specific
            try
            {
                Process[] uname = Process.GetProcessesByName("upc");
                if (uname.Length == 0)
                    KillAll.Visible = false;
                else
                    KillAll.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

        //code to check to see if process are started
        //will only show if launcher processes are not started
        private void StartAllCheck()
        {
            //steam specific
            try
            {
                Process[] sname = Process.GetProcessesByName("Steam");
                if (sname.Length == 0)
                    StartAll.Visible = true;
                else
                    StartAll.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            //Battle .net specific
            try
            {
                Process[] bname = Process.GetProcessesByName("Battle.net Launcher");
                if (bname.Length == 0)
                    StartAll.Visible = true;
                else
                    StartAll.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            try
            {
                Process[] bname1 = Process.GetProcessesByName("Agent");
                if (bname1.Length == 0)
                    StartAll.Visible = true;
                else
                    StartAll.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            //origin specific
            try
            {
                Process[] oname = Process.GetProcessesByName("Origin");
                if (oname.Length == 0)
                    StartAll.Visible = true;
                else
                    StartAll.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            //uplay specific
            try
            {
                Process[] uname = Process.GetProcessesByName("upc");
                if (uname.Length == 0)
                    StartAll.Visible = true;
                else
                    StartAll.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

        //this checks for processes by name and displays the kill button
        //if the respective process can be found by name
        private void ProcessCheck()
        {
            //steam specific
            try
            {
                Process[] sname = Process.GetProcessesByName("Steam");
                if (sname.Length == 0)
                    SteamKill.Visible = false;
                else
                    SteamKill.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            //Battle .net specific
            try
            {
                Process[] bname = Process.GetProcessesByName("Battle.net Launcher");
                if (bname.Length == 0)
                    BattleKill.Visible = false;
                else
                    BattleKill.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            try
            {
                Process[] bname1 = Process.GetProcessesByName("Agent");
                if (bname1.Length == 0)
                    BattleKill.Visible = false;
                else
                    BattleKill.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            //origin specific
            try
            {
                Process[] oname = Process.GetProcessesByName("Origin");
                if (oname.Length == 0)
                    OriginKill.Visible = false;
                else
                    OriginKill.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            //uplay specific
            try
            {
                Process[] uname = Process.GetProcessesByName("upc");
                if (uname.Length == 0)
                    UplayKill.Visible = false;
                else
                    UplayKill.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            //discord specific
            try
            {
                Process[] dname = Process.GetProcessesByName("discord");
                if (dname.Length == 0)
                    DiscordKill.Visible = false;
                else
                    DiscordKill.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

        //The placeholder text is modified inso that the XML maintains the modification for the subsiquint uses.
        private void SaveStartupSettings()
        {
            StartupSettings.GetElementsByTagName("SEL")[0].InnerText = SteamExeLocation.Text;
            StartupSettings.GetElementsByTagName("BEL")[0].InnerText = BattleExeLocation.Text;
            StartupSettings.GetElementsByTagName("OEL")[0].InnerText = OriginExeLocation.Text;
            StartupSettings.GetElementsByTagName("UEL")[0].InnerText = UbiExeLocation.Text;
            StartupSettings.GetElementsByTagName("DEL")[0].InnerText = DiscExeLocation.Text;
            StartupSettings.GetElementsByTagName("CYOL")[0].InnerText = CYOExeLocation.Text;
            StartupSettings.GetElementsByTagName("CYON")[0].InnerText = CYOExeName.Text;

            StartupSettings.Save("LauncherFiles.xml");
        }

        //Actions done when the save button is presses
        //this will modify the xml with whatever text is in whichever text box
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveStartupSettings();
            LauncherCheck();
            ProcessCheck();
            StartAllCheck();
            KillAllCheck();
        }

        //on button click this will kill the Steam Launcher once it is fully started
        private void SteamKill_Click_1(object sender, EventArgs e)
        {
            ProcessKill("Steam");

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        //on button click this will kill the Battle.net Launcher once it is fully started
        private void BattleKill_Click(object sender, EventArgs e)
        {
            ProcessKill("Agent");
            ProcessKill("Battle.net");

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        ////on button click this will kill the Origin Launcher once it is fully started
        private void OriginKill_Click(object sender, EventArgs e)
        {
            ProcessKill("Origin");

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        //on button click this will kill the Uplay Launcher once it is fully started
        private void UplayKill_Click(object sender, EventArgs e)
        {
            ProcessKill("upc");

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        //on button click this will kill discord once it is fully started
        private void DiscordKill_Click(object sender, EventArgs e)
        {
            ProcessKill("discord");

            ProcessCheck();

            StartAllCheck();

            KillAllCheck();
        }

        //this will kill all process en mass just like the individual kill buttons
        private void KillAll_Click(object sender, EventArgs e)
        {
            //steam specific
            ProcessKill("Steam");

            //Battle.Net Specific
            ProcessKill("Agent");
            ProcessKill("Battle.net");

            //Origin Specific
            ProcessKill("Origin");

            //Uplay Specific
            ProcessKill("upc");

            ProcessKill("discord");

            StartAllCheck();

            KillAllCheck();
        }

        //actions done when steam download button is clicked
        private void SteamDownload_Click(object sender, EventArgs e)
        {
            string title = "Steam Download Box";
            string message = "would you like to download Steam?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Process.Start("https://store.steampowered.com/about/");
            }
            else
            {
            }
        }

        //actions done when Battle Net download button is clicked
        private void BattleDownload_Click(object sender, EventArgs e)
        {
            string title = "Battle Net Download Box";
            string message = "would you like to download Battle Net?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Process.Start("https://www.blizzard.com/en-us/apps/battle.net/desktop");
            }
            else
            {
            }
        }

        //actions done when Origin download button is clicked
        private void OriginDownload_Click(object sender, EventArgs e)
        {
            string title = "Origin Download Box";
            string message = "would you like to download Origin";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Process.Start("https://www.origin.com/usa/en-us/store/download");
            }
            else
            {
            }
        }

        //actions done when Uplay download button is clicked
        private void UbiDownload_Click(object sender, EventArgs e)
        {
            string title = "Uplay Download Box";
            string message = "would you like to download Uplay?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Process.Start("https://uplay.ubisoft.com/en-GB");
            }
            else
            {
            }
        }

        //actions done when Discord download button is clicked
        private void DiscDownload_Click(object sender, EventArgs e)
        {
            string title = "Battle Net Download Box";
            string message = "would you like to download Uplay?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Process.Start("https://discordapp.com/download");
            }
            else
            {
            }
        }

        //this will kill any process that matches the name (exactly how it is typed)
        //that is passed through the function
        private void ProcessKill(string Kill)
        {
            foreach (var process in Process.GetProcessesByName(Kill))
            {
                process.Kill();
            }
        }

        //Python Silliness
        private void Button1_Click(object sender, EventArgs e)
        {
            Support("PythonTest1.py");
        }

        //Code that calls python script
        private void Support(string args)
        {
            string PythonPath1 = @"C:\Users\";
            string PythonPath2 = @"\AppData\Local\Programs\Python\";
            string PythonPath3 = @"Python" + '*' + @"\";
            try
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = PythonPath1 + '*' + PythonPath2 + PythonPath3 + "Python.exe";
                start.Arguments = string.Format("{0}", args);
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        Console.WriteLine(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }
    }
}