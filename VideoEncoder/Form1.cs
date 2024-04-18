using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoEncoder.Properties;

namespace VideoEncoder
{
    public partial class Form1 : Form
    {
        struct Settings
        {
            public string video_url { get; set; }
            public string image_url { get; set; }
            public string new_name { get; set; }
            public int materials { get; set; }
            public bool quad_mode { get; set; }
            public bool use_image { get; set; }

            public Settings(
                string videoUrl = null,
                string imageUrl = null,
                string newName = "output.mp4",
                int Materials = 0,
                bool quadMode = true,
                bool useImage = false)
            {
                video_url = videoUrl;
                image_url = imageUrl;
                new_name = newName;
                materials = Materials;
                quad_mode = quadMode;
                use_image = useImage;
            }
        }

        Settings Setting = new Settings();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void video_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Video files|*.mov;*.mp4;*.m4a;*.3gp;*.3g2;*.mj2;";
            openDialog.FilterIndex = 1;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openDialog.FileName;
                Setting.video_url = selectedFile;

                video_load.Text = "Loaded " + System.IO.Path.GetFileName(selectedFile);
            }
        }

        private void image_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp;*.jpg;*.jpeg;*.png";
            openDialog.FilterIndex = 1;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openDialog.FileName;
                Setting.image_url = selectedFile;

                image_load.Text = "Loaded " + System.IO.Path.GetFileName(selectedFile);

                try
                {
                    Image image = Image.FromFile(selectedFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }


        // -------------------------- NAME OF VIDEO --------------------------
        private void name_video_TextChanged(object sender, EventArgs e)
        {
            if (ContainsForbiddenSymbols(name_video.Text))
            {
                MessageBox.Show("The name contains forbidden symbols for a file name in Windows.");

                if (name_video.Text.Length > 0)
                {
                    name_video.Text = name_video.Text.Substring(0, name_video.Text.Length - 1);
                    name_video.SelectionStart = name_video.Text.Length;
                }
            }
        }
        private bool ContainsForbiddenSymbols(string text)
        {
            char[] forbiddenSymbols = Path.GetInvalidFileNameChars();
            return text.Any(c => forbiddenSymbols.Contains(c));
        }
        // -------------------------- END --------------------------


        // -------------------------- VIEW MODES --------------------------
        private void dual_CheckedChanged(object sender, EventArgs e)
        {
            if (dual.Checked && Setting.materials > 2)
            {
                quad.Checked = true;
                MessageBox.Show("You have a lot of checked video tracks or images. Unchecked it first.");
            }
            else if (dual.Checked) Setting.quad_mode = false;
        }

        private void quad_CheckedChanged(object sender, EventArgs e)
        {
            if (quad.Checked) Setting.quad_mode = true;
        }
        // -------------------------- END --------------------------


        // -------------------------- MATERIALS ADD --------------------------
        private void first_CheckedChanged(object sender, EventArgs e)
        {
            if (first.Checked == false) Setting.materials -= 1;
            else if (IsALotOf() == true && first.Checked)
            {
                first.Checked = false;
                Setting.materials += 1;

                MessageBox.Show("Your view mode isn't support amount of choosed materials");
                return;
            }
            else if (first.Checked) Setting.materials += 1;
        }

        private void second_CheckedChanged(object sender, EventArgs e)
        {
            if (second.Checked == false) Setting.materials -= 1;
            else if (IsALotOf() == true && second.Checked)
            {
                second.Checked = false;
                Setting.materials += 1;

                MessageBox.Show("Your view mode isn't support amount of choosed materials");
                return;
            }
            else if (second.Checked) Setting.materials += 1;
        }

        private void third_CheckedChanged(object sender, EventArgs e)
        {
            if (third.Checked == false) Setting.materials -= 1;
            else if (IsALotOf() == true && third.Checked)
            {
                third.Checked = false;
                Setting.materials += 1;

                MessageBox.Show("Your view mode isn't support amount of choosed materials");
                return;
            }
            else if (third.Checked) Setting.materials += 1;
        }

        private void four_CheckedChanged(object sender, EventArgs e)
        {
            if (four.Checked == false) Setting.materials -= 1;
            else if (IsALotOf() == true && four.Checked)
            {
                four.Checked = false;
                Setting.materials += 1;

                MessageBox.Show("Your view mode isn't support amount of choosed materials");
                return;
            }
            else if (four.Checked) Setting.materials += 1;
        }

        private bool IsALotOf()
        {
            int limit = Setting.quad_mode ? 4 : 2;
            return (limit < Setting.materials + 1) ? true : false;
        }

        // IMAGE
        private void has_image_CheckedChanged(object sender, EventArgs e)
        {
            if (has_image.Checked == false)
            {
                Setting.materials--;
            }
            else if (IsALotOf() == true && has_image.Checked)
            {
                has_image.Checked = false;
                Setting.materials++;

                MessageBox.Show("Your view mode isn't support amount of choosed materials");
                return;
            }
            else if (has_image.Checked)
            {
                Setting.materials++;
                Setting.use_image = true;
            }
        }

        // -------------------------- END --------------------------


        // -------------------------- RENDER --------------------------
        private void create_video_Click(object sender, EventArgs e)
        {
            if (Setting.video_url == null)
            {
                MessageBox.Show("Video is not loaded");
                return;
            }
            else if (Setting.image_url == null && Setting.use_image)
            {
                MessageBox.Show("You check 'Use image', but image is not loaded");
                return;
            }

            Setting.new_name = name_video.Text;
            string directoryPath = Path.GetDirectoryName(Setting.video_url);
            string new_name = directoryPath + "\\" + Setting.new_name + ".mp4";

            string map = "mosaic";
            string filter = "";

            if (Setting.materials == 1)
            {
                MessageBox.Show("You only have 1 selected material.");
                return;
            }


            int size = Setting.materials;
            if (Setting.use_image) size--;
            int[] tracks = new int[size];

            int entered = 0;
            if (first.Checked)
            {
                tracks[entered] = 0;
                entered++;
            }
            if (second.Checked)
            {
                tracks[entered] = 1;
                entered++;
            }
            if (third.Checked)
            {
                tracks[entered] = 2;
                entered++;
            }
            if (four.Checked)
            {
                tracks[entered] = 3;
                entered++;
            }

            if (Setting.materials == 2 && Setting.use_image == false) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[0:v:{tracks[1]}]scale=iw/2:-1[top2];[top1][top2]hstack[mosaic]";
            else if (Setting.materials == 2 && Setting.use_image) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[1:v]scale=iw/2:-1[top2];[top1][top2]hstack[mosaic]";

            else if (Setting.materials == 3 && Setting.use_image == false) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[0:v:{tracks[1]}]scale=iw/2:-1[top2];[0:v:{tracks[2]}]scale=iw/2:-1[bottom1];[0:v:{tracks[2]}]scale=iw/2:-1[bottom2];[top1][top2]hstack[top];[bottom1][bottom2]hstack[bottom];[top][bottom]vstack[mosaic]";
            else if (Setting.materials == 3 && Setting.use_image) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[0:v:{tracks[1]}]scale=iw/2:-1[top2];[1:v]scale=iw/2:-1[bottom1];[1:v]scale=iw/2:-1[bottom2];[top1][top2]hstack[top];[bottom1][bottom2]hstack[bottom];[top][bottom]vstack[mosaic]";

            else if (Setting.materials == 4 && Setting.use_image == false) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[0:v:{tracks[1]}]scale=iw/2:-1[top2];[0:v:{tracks[2]}]scale=iw/2:-1[bottom1];[0:v:{tracks[3]}]scale=iw/2:-1[bottom2];[top1][top2]hstack[top];[bottom1][bottom2]hstack[bottom];[top][bottom]vstack[mosaic]";
            else if (Setting.materials == 4 && Setting.use_image) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[0:v:{tracks[1]}]scale=iw/2:-1[top2];[0:v:{tracks[2]}]scale=iw/2:-1[bottom1];[1:v]scale=iw/2:-1[bottom2];[top1][top2]hstack[top];[bottom1][bottom2]hstack[bottom];[top][bottom]vstack[mosaic]";

            string materials = $"-i \"{Setting.video_url}\"";
            if (Setting.use_image == true) materials += $" -i \"{Setting.image_url}\"";

            //filter = "[0:v:0]scale=iw/2:-1[top1];[0:v:1]scale=iw/2:-1[top2];[top1][top2]hstack[mosaic]";
            string ffmpegCommand = $"ffmpeg {materials} -filter_complex \"{filter}\" -map \"[{map}]\" -c:v libx264 -c:a ac3 -crf 20 \"{new_name}\"";

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(ffmpegCommand);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            /*
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {ffmpegCommand}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false, 
                UseShellExecute = false
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.WaitForExit();
            }
            */

            MessageBox.Show("Video is saved in the folder of loaded video!");
        }
        
        // -------------------------- END --------------------------
    }
}
