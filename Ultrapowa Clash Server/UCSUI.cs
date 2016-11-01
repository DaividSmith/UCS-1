using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using UCS.Core;
using UCS.Core.Network;
using UCS.PacketProcessing.Messages.Server;
using System.Timers;
using UCS.Logic.AvatarStreamEntry;

namespace UCS
{
    public partial class UCSUI : MaterialForm
    {
        public UCSUI()
        {
            InitializeComponent();
            var sm = MaterialSkinManager.Instance;
            sm.AddFormToManage(this);
            sm.Theme = MaterialSkinManager.Themes.DARK;
            sm.ColorScheme = new ColorScheme(Primary.Red800, Primary.Red900, Primary.Grey500, Accent.Red200, TextShade.WHITE);
        }

        private void UCSUI_Load(object sender, EventArgs e)
        {
            materialLabel5.Text = Convert.ToString(Dns.GetHostByName(Dns.GetHostName()).AddressList[0]);
            materialLabel6.Text = ConfigurationManager.AppSettings["ServerPort"];
            materialLabel7.Text = Convert.ToString(ResourcesManager.GetOnlinePlayers().Count);
            materialLabel8.Text = Convert.ToString(ResourcesManager.GetConnectedClients().Count);
            materialLabel13.Text = Convert.ToString(ResourcesManager.GetInMemoryLevels().Count);
            //materialLabel14.Text = Convert.ToString(ResourcesManager.GetAllPlayerIds()) + Convert.ToString(ResourcesManager.);
            //materialLabel16.Text = Convert.ToString(ResourcesManager.GetAllPlayersFromDB());

            /* SETTINGS */
            textBox1.Text = ConfigurationManager.AppSettings["startingGems"];
            textBox2.Text = ConfigurationManager.AppSettings["startingGold"];
            textBox3.Text = ConfigurationManager.AppSettings["startingElixir"];
            textBox4.Text = ConfigurationManager.AppSettings["startingDarkElixir"];
            textBox5.Text = ConfigurationManager.AppSettings["startingTrophies"];
            textBox6.Text = ConfigurationManager.AppSettings["startingLevel"];
            textBox7.Text = ConfigurationManager.AppSettings["UpdateUrl"];
            textBox10.Text = ConfigurationManager.AppSettings["useCustomPatch"];
            textBox8.Text = ConfigurationManager.AppSettings["patchingServer"];
            textBox9.Text = ConfigurationManager.AppSettings["maintenanceTimeleft"];
            textBox11.Text = ConfigurationManager.AppSettings["databaseConnectionName"];
            textBox13.Text = ConfigurationManager.AppSettings["ServerPort"];
            textBox12.Text = ConfigurationManager.AppSettings["AdminMessage"];
            textBox14.Text = ConfigurationManager.AppSettings["LogLevel"];
            /* SETTINGS */

            /* PLAYER EDITOR */
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            textBox17.Enabled = false;
            textBox18.Enabled = false;
            textBox19.Enabled = false;
            /* PLAYER EDITOR */

            listView1.Items.Clear();
            foreach (var acc in ResourcesManager.GetOnlinePlayers())
            {
                ListViewItem item = new ListViewItem(acc.GetPlayerAvatar().GetAvatarName());
                item.SubItems.Add(Convert.ToString(acc.GetPlayerAvatar().GetId()));
                item.SubItems.Add(Convert.ToString(acc.GetPlayerAvatar().GetAvatarLevel()));
                item.SubItems.Add(Convert.ToString(acc.GetPlayerAvatar().GetScore()));
                item.SubItems.Add(Convert.ToString(acc.GetAccountPrivileges()));
                listView1.Items.Add(item);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            Process.Start("restarter.bat");
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            materialLabel5.Text = Convert.ToString(Dns.GetHostByName(Dns.GetHostName()).AddressList[0]);
            materialLabel6.Text = ConfigurationManager.AppSettings["ServerPort"];
            materialLabel7.Text = Convert.ToString(ResourcesManager.GetOnlinePlayers().Count);
            materialLabel8.Text = Convert.ToString(ResourcesManager.GetConnectedClients().Count);
            materialLabel13.Text = Convert.ToString(ResourcesManager.GetInMemoryLevels().Count);
        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel7_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel8_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel13_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel14_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel15_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel16_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel23_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel26_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "999999999";
            textBox2.Text = "999999999";
            textBox3.Text = "999999999";
            textBox4.Text = "10000000";
            textBox5.Text = "random";
            textBox6.Text = "1";
            textBox7.Text = "http://ultrapowa.com";
            textBox10.Text = "false";
            textBox8.Text = "";
            textBox9.Text = "0";
            textBox11.Text = "sqlite";
            textBox13.Text = "9339";
            textBox12.Text = "Welcome to UCS Beta! Visit http://ultrapowa.com for more Infos.";
            textBox14.Text = "1";
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            var doc = new XmlDocument();
            var path = "config.ucs";
            doc.Load(path);
            var ie = doc.SelectNodes("appSettings/add").GetEnumerator();

            while (ie.MoveNext())
            {
                if ((ie.Current as XmlNode).Attributes["key"].Value == "startingGems")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox1.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "startingGold")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox2.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "startingElixir")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox3.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "startingDarkElixir")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox4.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "startingTrophies")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox5.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "startingLevel")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox6.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "UpdateUrl")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox7.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "useCustomPatch")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox10.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "patchingServer")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox8.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "maintenanceTimeleft")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox9.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "databaseConnectionName")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox11.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "ServerPort")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox13.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "AdminMessage")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox12.Text;
                }
                if ((ie.Current as XmlNode).Attributes["key"].Value == "LogLevel")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = textBox14.Text;
                }            
            }

            doc.Save(path);
            var title = "Ultrapowa Clash Server Manager";
            var message = "Changes has been saved!";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void materialCheckBox1_CheckedChanged(object sender2, EventArgs e2)
        {
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            textBox15.Enabled = true;
            textBox16.Enabled = true;
            textBox17.Enabled = true;
            textBox18.Enabled = true;
            textBox19.Enabled = true;

            /* LOAD PLAYER */
            try
            {
                textBox15.Text = Convert.ToString(ResourcesManager.GetPlayer(long.Parse(textBox20.Text)).GetPlayerAvatar().GetAvatarName());
                textBox16.Text = Convert.ToString(ResourcesManager.GetPlayer(long.Parse(textBox20.Text)).GetPlayerAvatar().GetScore());
                textBox17.Text = Convert.ToString(ResourcesManager.GetPlayer(long.Parse(textBox20.Text)).GetPlayerAvatar().GetDiamonds());
                textBox18.Text = Convert.ToString(ResourcesManager.GetPlayer(long.Parse(textBox20.Text)).GetPlayerAvatar().GetTownHallLevel());
                textBox19.Text = Convert.ToString(ResourcesManager.GetPlayer(long.Parse(textBox20.Text)).GetPlayerAvatar().GetAllianceId());
            }
            catch (NullReferenceException)
            {
                var title = "Error";
                MessageBox.Show("Player with ID " + textBox20.Text + " not found!", title,MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            }
            /* LOAD PLAYER */
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            /* CLEAR */
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            /* CLEAR */
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            /* SAVE PLAYER */
            ResourcesManager.GetPlayer(long.Parse(textBox20.Text)).GetPlayerAvatar().SetName(textBox15.Text);
            ResourcesManager.GetPlayer(long.Parse(textBox20.Text)).GetPlayerAvatar().SetScore(Convert.ToInt32(textBox16.Text));
            ResourcesManager.GetPlayer(long.Parse(textBox20.Text)).GetPlayerAvatar().SetDiamonds(Convert.ToInt32(textBox17.Text));
            ResourcesManager.GetPlayer(long.Parse(textBox20.Text)).GetPlayerAvatar().SetTownHallLevel(Convert.ToInt32(textBox18.Text));
            ResourcesManager.GetPlayer(long.Parse(textBox20.Text)).GetPlayerAvatar().SetAllianceId(Convert.ToInt32(textBox19.Text));

            var title = "Finished!";
            MessageBox.Show("Player has been saved!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            /* SAVE PLAYER */
        }

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            foreach (var onlinePlayer in ResourcesManager.GetOnlinePlayers())
            {
                var pm = new GlobalChatLineMessage(onlinePlayer.GetClient());
                pm.SetChatMessage(textBox21.Text);
                pm.SetPlayerId(0);
                pm.SetLeagueId(22);
                pm.SetPlayerName(textBox22.Text);
                PacketManager.ProcessOutgoingPacket(pm);
            }
        }

        private void materialRaisedButton10_Click(object sender, EventArgs e)
        {
            var mail = new AllianceMailStreamEntry();
            mail.SetId((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            mail.SetSenderId(0);
            mail.SetSenderAvatarId(0);
            mail.SetSenderName(textBox23.Text);
            mail.SetIsNew(2); // 0 = Seen, 2 = New
            mail.SetAllianceId(0);
            mail.SetAllianceBadgeData(1728059989);
            mail.SetAllianceName("Ultrapowa");
            mail.SetMessage(textBox24.Text);
            mail.SetSenderLevel(300);
            mail.SetSenderLeagueId(22);

            foreach (var onlinePlayer in ResourcesManager.GetOnlinePlayers())
            {
                var p = new AvatarStreamEntryMessage(onlinePlayer.GetClient());
                p.SetAvatarStreamEntry(mail);
                PacketManager.ProcessOutgoingPacket(p);
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton11_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (var acc in ResourcesManager.GetOnlinePlayers())
            {
                ListViewItem item = new ListViewItem(acc.GetPlayerAvatar().GetAvatarName());
                item.SubItems.Add(Convert.ToString(acc.GetPlayerAvatar().GetId()));
                item.SubItems.Add(Convert.ToString(acc.GetPlayerAvatar().GetAvatarLevel()));
                item.SubItems.Add(Convert.ToString(acc.GetPlayerAvatar().GetScore()));
                item.SubItems.Add(Convert.ToString(acc.GetAccountPrivileges()));
                listView1.Items.Add(item);
            }
        }
    }
}
