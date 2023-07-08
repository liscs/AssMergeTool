using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Core.SubtitleFormats;
using System;
using System.Collections;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace AssMergeTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void AddAss_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                FileName = "sub.ass",
                Filter = @"Ass files (*.ass)|*.ass",
                Title = @"Open text file",
                Multiselect = true
            };

            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            try
            {
                Button button = (Button)sender;
                if (button.Name == "AddAss1")
                {
                    foreach (var i in openFileDialog1.FileNames) AssList1.Items.Add(i);
                }
                else
                {
                    foreach (var i in openFileDialog1.FileNames) AssList2.Items.Add(i);
                }
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                                $"Details:\n\n{ex.StackTrace}");
            }
        }

        private void DelAss_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (AssList1.SelectedIndex != -1 && button.Name == "DelAss1")
                AssList1.Items.RemoveAt(AssList1.SelectedIndex);
            else if (AssList2.SelectedIndex != -1 && button.Name == "DelAss2")
                AssList2.Items.RemoveAt(AssList2.SelectedIndex);
        }


        //合并assList中的ass文件，保存到savename，info信息使用2文件
        private static void SaveAss(ArrayList assList, string savename)
        {
            var info = new ArrayList();
            var styles = new ArrayList();
            var Event = new ArrayList();
            assList.Reverse();
            foreach (var i in assList)
            {
                var file1 = new StreamReader(i.ToString());
                string line;
                if (assList.IndexOf(i) == 0)
                    while ((line = file1.ReadLine()) != "[V4+ Styles]")
                        info.Add(line);

                file1.ReadLine();
                while ((line = file1.ReadLine()) != "[Events]")
                {
                    if (line == "")
                        continue;
                    try
                    {
                        if (line != null) styles.Add(line.Insert(line.IndexOf(','), '-' + assList.IndexOf(i).ToString()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }

                file1.ReadLine();
                while ((line = file1.ReadLine()) != null)
                {
                    if (line == "") continue;
                    try
                    {
                        Event.Add(line.Insert(line.IndexOf(',', 34), '-' + assList.IndexOf(i).ToString()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
                file1.Close();
            }

            using (var file2 = new StreamWriter(savename, false, Encoding.UTF8))
            {
                foreach (var i in info) file2.WriteLine(i);
                file2.WriteLine("[V4+ Styles]");
                file2.WriteLine(
                    "Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding");
                foreach (var i in styles) file2.WriteLine(i);
                file2.WriteLine("");
                file2.WriteLine("[Events]");
                file2.WriteLine("Format: Layer, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text");
                foreach (var i in Event) file2.WriteLine(i);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var assList = new ArrayList();
            for (int i = 0; i < AssList1.Items.Count && i < AssList2.Items.Count; i++)
            {
                ResampleResolution((string)AssList1.Items[i], (string)AssList2.Items[i]);
                assList.Add(AssList1.Items[i]);
                assList.Add(AssList2.Items[i]);
                SaveAss(assList, (string)AssList2.Items[i]);
                assList.Clear();
            }
            MessageBox.Show(@"success!");
        }

        //重设leftPath对应路径字幕文件的分辨率为rightPath文件分辨率
        private void ResampleResolution(string leftPath, string rightPath)
        {
            Subtitle sub = Subtitle.Parse(leftPath);
            (int, int) tupleSourceResolution = getResolution(leftPath);
            (int, int) tupleTargetResolution = getResolution(rightPath);

            int sourceWidth = tupleSourceResolution.Item1, sourceHeight = tupleSourceResolution.Item2;
            int targetWidth = tupleTargetResolution.Item1, targetHeight = tupleTargetResolution.Item2;
            var fixMargins = true;
            var fixFonts = true;
            var fixPos = true;
            var fixDraw = true;
            var styles = AdvancedSubStationAlpha.GetSsaStylesFromHeader(sub.Header);
            foreach (var style in styles)
            {
                if (fixMargins)
                {
                    style.MarginLeft = AssaResampler.Resample(sourceWidth, targetWidth, style.MarginLeft);
                    style.MarginRight = AssaResampler.Resample(sourceWidth, targetWidth, style.MarginRight);
                    style.MarginVertical = AssaResampler.Resample(sourceHeight, targetHeight, style.MarginVertical);
                }

                if (fixFonts)
                {
                    style.FontSize = AssaResampler.Resample(sourceHeight, targetHeight, style.FontSize);
                }

                if (fixFonts || fixDraw)
                {
                    style.OutlineWidth = (decimal)AssaResampler.Resample(sourceHeight, targetHeight, (float)style.OutlineWidth);
                    style.ShadowWidth = (decimal)AssaResampler.Resample(sourceHeight, targetHeight, (float)style.ShadowWidth);
                    style.Spacing = (decimal)AssaResampler.Resample(sourceWidth, targetWidth, (float)style.Spacing);
                }
            }

            sub.Header = AdvancedSubStationAlpha.GetHeaderAndStylesFromAdvancedSubStationAlpha(sub.Header, styles);

            sub.Header = AdvancedSubStationAlpha.AddTagToHeader("PlayResX", "PlayResX: " + targetWidth.ToString(CultureInfo.InvariantCulture), "[Script Info]", sub.Header);
            sub.Header = AdvancedSubStationAlpha.AddTagToHeader("PlayResY", "PlayResY: " + targetHeight.ToString(CultureInfo.InvariantCulture), "[Script Info]", sub.Header);

            foreach (var p in sub.Paragraphs)
            {
                if (fixFonts)
                {
                    p.Text = AssaResampler.ResampleOverrideTagsFont(sourceWidth, targetWidth, sourceHeight, targetHeight, p.Text);
                }

                if (fixPos)
                {
                    p.Text = AssaResampler.ResampleOverrideTagsPosition(sourceWidth, targetWidth, sourceHeight, targetHeight, p.Text);
                }

                if (fixDraw)
                {
                    p.Text = AssaResampler.ResampleOverrideTagsDrawing(sourceWidth, targetWidth, sourceHeight, targetHeight, p.Text, null);
                }
            }
            SaveSub(sub, leftPath);
        }

        private void SaveSub(Subtitle sub, string leftPath)
        {
            using (var file = new StreamWriter(leftPath, false, Encoding.UTF8))
            {
                file.Write(sub.Header);
                file.WriteLine("Format: Layer,Start,End,Style,Actor,MarginL,MarginR,MarginV,Effect,Text");
                foreach (var p in sub.Paragraphs)
                {
                    var line = "Dialogue: " + p.Layer.ToString() + "," + p.StartTime.ToHHMMSSFF() + "," + p.EndTime.ToHHMMSSFF() + "," +
                        p.Extra + "," + p.Actor + "," + p.MarginL + "," + p.MarginR + "," +
                        p.MarginV + "," + p.Effect + "," + p.Text;
                    file.WriteLine(line);
                }
            }

        }

        private (int, int) getResolution(string path)
        {
            int width = 0, height = 0;
            using (var file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    int index;
                    if ((index = line.LastIndexOf("PlayResX:")) != -1)
                    {
                        width = int.Parse(line.Substring(index + 9).Trim());
                    }
                    if ((index = line.LastIndexOf("PlayResY:")) != -1)
                    {
                        height = int.Parse(line.Substring(index + 9).Trim());
                        break;
                    }
                }
            }
            return (width, height);
        }

        private void AssList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }


        private void AssList1_DragDrop(object sender, DragEventArgs e)
        {
            var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var t in fileNames)
                AssList1.Items.Add(t);
        }
        private void AssList2_DragDrop(object sender, DragEventArgs e)
        {
            var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var t in fileNames)
                AssList2.Items.Add(t);
        }

        private void AssList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AssList1.Items.Count == 1)
                return;
            if (AssList1.SelectedIndex == 0)
            {
                Up1.Enabled = false;
                Down1.Enabled = true;
            }
            else if (AssList1.SelectedIndex == AssList1.Items.Count - 1)
            {
                Down1.Enabled = false;
                Up1.Enabled = true;
            }
            else
            {
                Down1.Enabled = true;
                Up1.Enabled = true;
            }
        }
        private void AssList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AssList2.Items.Count == 1)
                return;
            if (AssList2.SelectedIndex == 0)
            {
                Up2.Enabled = false;
                Down2.Enabled = true;
            }
            else if (AssList2.SelectedIndex == AssList2.Items.Count - 1)
            {
                Down2.Enabled = false;
                Up2.Enabled = true;
            }
            else
            {
                Down2.Enabled = true;
                Up2.Enabled = true;
            }
        }

        private void Up_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "Up1")
            {
                var tem = AssList1.SelectedItem;
                AssList1.Items[AssList1.SelectedIndex] = AssList1.Items[AssList1.SelectedIndex - 1];
                AssList1.Items[AssList1.SelectedIndex - 1] = tem;
                AssList1.SelectedIndex--;
            }
            else
            {
                var tem = AssList2.SelectedItem;
                AssList2.Items[AssList2.SelectedIndex] = AssList2.Items[AssList2.SelectedIndex - 1];
                AssList2.Items[AssList2.SelectedIndex - 1] = tem;
                AssList2.SelectedIndex--;
            }
        }

        private void Down_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "Down1")
            {
                var tem = AssList1.SelectedItem;
                AssList1.Items[AssList1.SelectedIndex] = AssList1.Items[AssList1.SelectedIndex + 1];
                AssList1.Items[AssList1.SelectedIndex + 1] = tem;
                AssList1.SelectedIndex++;
            }
            else
            {
                var tem = AssList2.SelectedItem;
                AssList2.Items[AssList2.SelectedIndex] = AssList2.Items[AssList2.SelectedIndex + 1];
                AssList2.Items[AssList2.SelectedIndex + 1] = tem;
                AssList2.SelectedIndex++;
            }
        }
    }
}