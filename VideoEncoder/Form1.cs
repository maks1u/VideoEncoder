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
    public partial class Encoder : Form
    {
        struct Settings
        {
            public string VideUrl { get; set; }
            public string ImageUrl { get; set; }
            public string NewName { get; set; }
            public int Materials { get; set; }
            public bool QuadMode { get; set; }
            public bool UseImage { get; set; }

            public Settings(
                string videoUrl = null,
                string imageUrl = null,
                string newName = "output.mp4",
                int materials = 0,
                bool quadMode = true,
                bool useImage = false)
            {
                VideUrl = videoUrl;
                ImageUrl = imageUrl;
                NewName = newName;
                Materials = materials;
                QuadMode = quadMode;
                UseImage = useImage;
            }
        }

        const MessageBoxIcon ErrorIcon = MessageBoxIcon.Error;
        const MessageBoxIcon InfoIcon = MessageBoxIcon.Information;
        const MessageBoxIcon QuestionIcon = MessageBoxIcon.Question;
        const MessageBoxIcon WarningIcon = MessageBoxIcon.Warning;

        Settings Setting = new Settings();

        public Encoder()
        {
            InitializeComponent();
        }

        private void video_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Video files|*.mov;*.mp4;*.m4a;*.3gp;*.3g2;*.mj2;";
            openDialog.FilterIndex = 1;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openDialog.FileName;
                Setting.VideUrl = selectedFile;

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
                Setting.ImageUrl = selectedFile;

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
                MessageBox.Show("The name contains forbidden symbols for a file name in Windows.", "Error name", MessageBoxButtons.OK, ErrorIcon);

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
            if (dual.Checked && Setting.Materials > 2)
            {
                quad.Checked = true;
                MessageBox.Show("You have a lot of checked video tracks or images. Unchecked it first.", "Error", MessageBoxButtons.OK, ErrorIcon);
            }
            else if (dual.Checked) Setting.QuadMode = false;
        }

        private void quad_CheckedChanged(object sender, EventArgs e)
        {
            if (quad.Checked) Setting.QuadMode = true;
        }
        // -------------------------- END --------------------------


        // -------------------------- Materials ADD --------------------------
        private void first_CheckedChanged(object sender, EventArgs e)
        {
            if (first.Checked == false) Setting.Materials -= 1;
            else if (IsALotOf() == true && first.Checked)
            {
                first.Checked = false;
                Setting.Materials += 1;

                MessageBox.Show("Your view mode isn't support amount of choosed Materials", "ViewMode Error", MessageBoxButtons.OK, ErrorIcon);
                return;
            }
            else if (first.Checked) Setting.Materials += 1;
        }

        private void second_CheckedChanged(object sender, EventArgs e)
        {
            if (second.Checked == false) Setting.Materials -= 1;
            else if (IsALotOf() == true && second.Checked)
            {
                second.Checked = false;
                Setting.Materials += 1;

                MessageBox.Show("Your view mode isn't support amount of choosed Materials", "ViewMode Error", MessageBoxButtons.OK, ErrorIcon);
                return;
            }
            else if (second.Checked) Setting.Materials += 1;
        }

        private void third_CheckedChanged(object sender, EventArgs e)
        {
            if (third.Checked == false) Setting.Materials -= 1;
            else if (IsALotOf() == true && third.Checked)
            {
                third.Checked = false;
                Setting.Materials += 1;

                MessageBox.Show("Your view mode isn't support amount of choosed Materials", "ViewMode Error", MessageBoxButtons.OK, ErrorIcon);
                return;
            }
            else if (third.Checked) Setting.Materials += 1;
        }

        private void four_CheckedChanged(object sender, EventArgs e)
        {
            if (four.Checked == false) Setting.Materials -= 1;
            else if (IsALotOf() == true && four.Checked)
            {
                four.Checked = false;
                Setting.Materials += 1;

                MessageBox.Show("Your view mode isn't support amount of choosed Materials", "ViewMode Error", MessageBoxButtons.OK, ErrorIcon);
                return;
            }
            else if (four.Checked) Setting.Materials += 1;
        }

        private bool IsALotOf()
        {
            int limit = Setting.QuadMode ? 4 : 2;
            return (limit < Setting.Materials + 1) ? true : false;
        }

        // IMAGE
        private void has_image_CheckedChanged(object sender, EventArgs e)
        {
            if (has_image.Checked == false)
            {
                Setting.Materials--;
                Setting.UseImage = false;
            }
            else if (IsALotOf() == true && has_image.Checked)
            {
                has_image.Checked = false;
                Setting.Materials++;

                MessageBox.Show("Your view mode isn't support amount of choosed Materials", "ViewMode Error", MessageBoxButtons.OK, ErrorIcon);
                return;
            }
            else if (has_image.Checked)
            {
                Setting.Materials++;
                Setting.UseImage = true;
            }
        }

        // -------------------------- END --------------------------


        // -------------------------- RENDER --------------------------
        private void create_video_Click(object sender, EventArgs e)
        {
            if (Setting.VideUrl == null)
            {
                MessageBox.Show("Video is not loaded", "Creating warning", MessageBoxButtons.OK, WarningIcon);
                return;
            }
            else if (Setting.ImageUrl == null && Setting.UseImage)
            {
                MessageBox.Show("You check 'Use image', but image is not loaded", "Creating warning", MessageBoxButtons.OK, WarningIcon);
                return;
            }
            else if (Setting.Materials <= 0)
            {
                MessageBox.Show("Not enough materials (video tracks, image).", "Creating warning", MessageBoxButtons.OK, WarningIcon);
                return;
            }

            string paramert = "";
            if (name_video.Text == null || name_video.Text == "")
            {
                paramert = "_dual";
                if (Setting.QuadMode) paramert = "_quad";

                Setting.NewName = System.IO.Path.GetFileNameWithoutExtension(Setting.VideUrl) + paramert;
            }
            else Setting.NewName = name_video.Text;

            string directoryPath = Path.GetDirectoryName(Setting.VideUrl);

            string NewName = directoryPath + "\\" + Setting.NewName + ".mp4";

            string outputFilePath = Path.Combine(directoryPath, $"{Setting.NewName}.mp4");
            bool isYes = true;
            if (File.Exists(outputFilePath))
            {
                DialogResult dialogResult = MessageBox.Show($"File '{Setting.NewName}.mp4' exists in the video source folder. Overwrite file?", "The file exists", MessageBoxButtons.YesNo, QuestionIcon);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Delete(outputFilePath);
                }
                else if (dialogResult == DialogResult.No)
                {
                    isYes = false;
                    MessageBox.Show("Enter a new file name.", "Information", MessageBoxButtons.OK, InfoIcon);
                }
            }

            if (isYes == false) return;

            string map = "mosaic";
            string filter = "";

            int size = Setting.Materials;
            if (Setting.UseImage) size--;
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

            if (Setting.Materials == 2 && Setting.UseImage == false) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[0:v:{tracks[1]}]scale=iw/2:-1[top2];[top1][top2]hstack[mosaic]";
            else if (Setting.Materials == 2 && Setting.UseImage) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[1:v]scale=iw/2:-1[top2];[top1][top2]hstack[mosaic]";

            else if (Setting.Materials == 3 && Setting.UseImage == false) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[0:v:{tracks[1]}]scale=iw/2:-1[top2];[0:v:{tracks[2]}]scale=iw/2:-1[bottom1];[0:v:{tracks[2]}]scale=iw/2:-1[bottom2];[top1][top2]hstack[top];[bottom1][bottom2]hstack[bottom];[top][bottom]vstack[mosaic]";
            else if (Setting.Materials == 3 && Setting.UseImage) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[0:v:{tracks[1]}]scale=iw/2:-1[top2];[1:v]scale=iw/2:-1[bottom1];[1:v]scale=iw/2:-1[bottom2];[top1][top2]hstack[top];[bottom1][bottom2]hstack[bottom];[top][bottom]vstack[mosaic]";

            else if (Setting.Materials == 4 && Setting.UseImage == false) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[0:v:{tracks[1]}]scale=iw/2:-1[top2];[0:v:{tracks[2]}]scale=iw/2:-1[bottom1];[0:v:{tracks[3]}]scale=iw/2:-1[bottom2];[top1][top2]hstack[top];[bottom1][bottom2]hstack[bottom];[top][bottom]vstack[mosaic]";
            else if (Setting.Materials == 4 && Setting.UseImage) filter = $"[0:v:{tracks[0]}]scale=iw/2:-1[top1];[0:v:{tracks[1]}]scale=iw/2:-1[top2];[0:v:{tracks[2]}]scale=iw/2:-1[bottom1];[1:v]scale=iw/2:-1[bottom2];[top1][top2]hstack[top];[bottom1][bottom2]hstack[bottom];[top][bottom]vstack[mosaic]";

            string materials = $"-i \"{Setting.VideUrl}\"";
            if (Setting.UseImage == true) materials += $" -i \"{Setting.ImageUrl}\"";

            string ffmpegCommand = $"ffmpeg {materials} -filter_complex \"{filter}\" -map \"[{map}]\" -c:v libx264 -c:a ac3 -crf 20 \"{NewName}\"";

            string batchFilePath = Path.Combine(Application.StartupPath, "command.bat");
            using (StreamWriter writer = new StreamWriter(batchFilePath))
            {
                writer.WriteLine(ffmpegCommand);
            }
            
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

            if (File.Exists(outputFilePath))
            {
                // Get the file size
                FileInfo fileInfo = new FileInfo(outputFilePath);
                long fileSizeInBytes = fileInfo.Length;

                // Convert to KB
                double fileSizeInKB = fileSizeInBytes / 1024; // Divide by 1024 to convert bytes to kilobytes

                if (fileSizeInKB < 1)
                {
                    MessageBox.Show($"Error. You have selected the wrong video tracks.", "Video tracks error", MessageBoxButtons.OK, ErrorIcon);
                }
                else
                {
                    MessageBox.Show("Video is saved in the folder of loaded video!", "Rendered", MessageBoxButtons.OK, InfoIcon);
                }
            }
            else
            {
                MessageBox.Show("The video was not saved. You may have selected the wrong video tracks!", "Video error", MessageBoxButtons.OK, WarningIcon);
            }
        }
        // -------------------------- END --------------------------
    }
}
