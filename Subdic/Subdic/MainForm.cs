using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subdic
{
    public partial class MainForm : Form
    {
        //---------------------------------------------------------------------
        private (List<string>, List<string>) SerialList;
        private void SerialBoxInit()
        {
            SerialList
                = GetSerialList(@"http://www.tvsubtitles.net/tvshows.html");

            SerialComboBox.DataSource = SerialList.Item1;

            SerialComboBox
                .AutoCompleteCustomSource = new AutoCompleteStringCollection();
            SerialComboBox
                .AutoCompleteCustomSource
                .AddRange(SerialList.Item1.ToArray());
        }
        private static (List<string>, List<string>) GetSerialList(string url)
        {
            using WebClient client = new WebClient();
            string page = client.DownloadString(url);

            var matchName
                = Regex.Matches(page, @"ml.><b>.*?<.b>");
            int num = 2;
            string now, prev = "";
            var listName = new List<string>(matchName.Count);
            foreach (Match sn in matchName)
            {
                string s = sn.Value.Substring(7);
                now = s.Substring(0, s.IndexOf('<'));
                if (now != prev) listName.Add(now);
                else listName.Add(now + '(' + num++ + ')');
                prev = now;
            }

            var matchUrl
                = Regex.Matches(page, @"href=.tvshow-(\d)*-(\d)*.html");
            var listUrl = new List<string>(matchName.Count);
            foreach (Match su in matchUrl)
                listUrl.Add(su.Value.Substring(6));

            return (listName, listUrl);
        }
        //---------------------------------------------------------------------
        private (List<string>, List<string>) SeasonList;
        private static (List<string>, List<string>) GetSeasonList(string url)
        {
            using WebClient client = new WebClient();
            string page = client.DownloadString(url);

            var matchUrl
                = Regex.Matches(page, @"href=.tvshow-(\d)*-(\d)*.html");
            var listUrl = new List<string>(matchUrl.Count);
            foreach (Match su in matchUrl)
                listUrl.Add(su.Value.Substring(6));

            var listName = new List<string>(matchUrl.Count);
            for (int i = matchUrl.Count; i > 0; i--)
                listName.Add("Season " + i);

            return (listName, listUrl);
        }

        //---------------------------------------------------------------------
        public MainForm()
        {
            InitializeComponent();
            SerialBoxInit();
        }

        private void SerialComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int ind = SerialList.Item1.IndexOf(SerialComboBox.Text);
            if (ind != -1)
            {
                SeasonList
                    = GetSeasonList(@"http://www.tvsubtitles.net/"
                                    + SerialList.Item2[ind]);
                if (SeasonList.Item1.Count > 0 && SeasonList.Item2.Count > 0)
                {
                    SeasonComboBox.DataSource = SeasonList.Item1;
                    SeasonComboBox.Text = SeasonList.Item1[0];
                }
                else SeasonComboBox.Text = "Season 1";
            }
            else
            {
                SeasonComboBox.DataSource = null;
                SeasonComboBox.Text = "";
            }
        }
    }
}
