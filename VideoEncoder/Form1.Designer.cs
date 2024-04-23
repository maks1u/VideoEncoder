using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VideoEncoder
{
    partial class Encoder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encoder));
            this.has_image = new System.Windows.Forms.CheckBox();
            this.video_load = new System.Windows.Forms.Button();
            this.image_load = new System.Windows.Forms.Button();
            this.view_mode = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.quad = new System.Windows.Forms.RadioButton();
            this.dual = new System.Windows.Forms.RadioButton();
            this.create_video = new System.Windows.Forms.Button();
            this.name_video = new System.Windows.Forms.TextBox();
            this.label_for_name = new System.Windows.Forms.Label();
            this.four = new System.Windows.Forms.CheckBox();
            this.third = new System.Windows.Forms.CheckBox();
            this.second = new System.Windows.Forms.CheckBox();
            this.first = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.view_mode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // has_image
            // 
            resources.ApplyResources(this.has_image, "has_image");
            this.has_image.Name = "has_image";
            this.has_image.UseVisualStyleBackColor = true;
            this.has_image.CheckedChanged += new System.EventHandler(this.has_image_CheckedChanged);
            // 
            // video_load
            // 
            this.video_load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.video_load.Cursor = System.Windows.Forms.Cursors.Default;
            this.video_load.FlatAppearance.BorderSize = 0;
            this.video_load.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            resources.ApplyResources(this.video_load, "video_load");
            this.video_load.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.video_load.Name = "video_load";
            this.video_load.UseVisualStyleBackColor = false;
            this.video_load.Click += new System.EventHandler(this.video_load_Click);
            // 
            // image_load
            // 
            this.image_load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.image_load.Cursor = System.Windows.Forms.Cursors.Default;
            this.image_load.FlatAppearance.BorderSize = 0;
            this.image_load.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            resources.ApplyResources(this.image_load, "image_load");
            this.image_load.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.image_load.Name = "image_load";
            this.image_load.UseVisualStyleBackColor = false;
            this.image_load.Click += new System.EventHandler(this.image_load_Click);
            // 
            // view_mode
            // 
            this.view_mode.Controls.Add(this.pictureBox1);
            this.view_mode.Controls.Add(this.pictureBox2);
            this.view_mode.Controls.Add(this.quad);
            this.view_mode.Controls.Add(this.dual);
            resources.ApplyResources(this.view_mode, "view_mode");
            this.view_mode.Name = "view_mode";
            this.view_mode.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // quad
            // 
            resources.ApplyResources(this.quad, "quad");
            this.quad.Name = "quad";
            this.quad.UseVisualStyleBackColor = true;
            this.quad.CheckedChanged += new System.EventHandler(this.quad_CheckedChanged);
            // 
            // dual
            // 
            resources.ApplyResources(this.dual, "dual");
            this.dual.Checked = true;
            this.dual.Name = "dual";
            this.dual.TabStop = true;
            this.dual.UseVisualStyleBackColor = true;
            this.dual.CheckedChanged += new System.EventHandler(this.dual_CheckedChanged);
            // 
            // create_video
            //
            // Create rounded create video button
            this.create_video = new RoundedButton();
            this.create_video.BackColor = Color.FromArgb(0, 114, 222);
            this.create_video.FlatAppearance.BorderSize = 0;
            this.create_video.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 95, 184);
            this.create_video.ForeColor = Color.WhiteSmoke;
            this.create_video.Size = new Size(377, 46);
            this.create_video.Location = new Point(31, 189);
            this.create_video.Text = "Create Video";
            this.create_video.Click += new EventHandler(this.create_video_Click);
            this.Controls.Add(this.create_video);
            /*
            this.create_video.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(222)))));
            this.create_video.Cursor = System.Windows.Forms.Cursors.Default;
            this.create_video.FlatAppearance.BorderSize = 0;
            this.create_video.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(184)))));
            resources.ApplyResources(this.create_video, "create_video");
            this.create_video.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.create_video.Name = "create_video";
            this.create_video.UseVisualStyleBackColor = false;
            this.create_video.Click += new System.EventHandler(this.create_video_Click);
            */
            // 
            // name_video
            // 
            this.name_video.BackColor = System.Drawing.Color.White;
            this.name_video.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.name_video, "name_video");
            this.name_video.Name = "name_video";
            this.name_video.TextChanged += new System.EventHandler(this.name_video_TextChanged);
            // 
            // label_for_name
            // 
            resources.ApplyResources(this.label_for_name, "label_for_name");
            this.label_for_name.Name = "label_for_name";
            // 
            // four
            // 
            resources.ApplyResources(this.four, "four");
            this.four.Name = "four";
            this.four.UseVisualStyleBackColor = true;
            this.four.CheckedChanged += new System.EventHandler(this.four_CheckedChanged);
            // 
            // third
            // 
            resources.ApplyResources(this.third, "third");
            this.third.Name = "third";
            this.third.UseVisualStyleBackColor = true;
            this.third.CheckedChanged += new System.EventHandler(this.third_CheckedChanged);
            // 
            // second
            // 
            resources.ApplyResources(this.second, "second");
            this.second.Name = "second";
            this.second.UseVisualStyleBackColor = true;
            this.second.CheckedChanged += new System.EventHandler(this.second_CheckedChanged);
            // 
            // first
            // 
            resources.ApplyResources(this.first, "first");
            this.first.Name = "first";
            this.first.UseVisualStyleBackColor = true;
            this.first.CheckedChanged += new System.EventHandler(this.first_CheckedChanged);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Encoder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.four);
            this.Controls.Add(this.third);
            this.Controls.Add(this.label_for_name);
            this.Controls.Add(this.second);
            this.Controls.Add(this.name_video);
            this.Controls.Add(this.first);
            this.Controls.Add(this.create_video);
            this.Controls.Add(this.view_mode);
            this.Controls.Add(this.image_load);
            this.Controls.Add(this.video_load);
            this.Controls.Add(this.has_image);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Encoder";
            this.view_mode.ResumeLayout(false);
            this.view_mode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public class RoundedButton : Button
        {
            public int CornerRadius { get; set; } = 5;

            public RoundedButton()
            {
                this.FlatStyle = FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.BackColor = Color.FromArgb(229, 229, 229);
                this.ForeColor = Color.FromArgb(74, 74, 74);
                this.Cursor = Cursors.Hand;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                GraphicsPath path = new GraphicsPath();
                int radius = CornerRadius;
                int diameter = radius * 2;
                Rectangle bounds = new Rectangle(0, 0, Width, Height);

                path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
                path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
                path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);

                using (Pen pen = new Pen(Color.Transparent))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }


        #endregion
        private System.Windows.Forms.CheckBox has_image;
        private System.Windows.Forms.Button video_load;
        private System.Windows.Forms.Button image_load;
        private System.Windows.Forms.GroupBox view_mode;
        private System.Windows.Forms.RadioButton quad;
        private System.Windows.Forms.RadioButton dual;
        private System.Windows.Forms.Button create_video;
        private System.Windows.Forms.TextBox name_video;
        private System.Windows.Forms.Label label_for_name;
        private System.Windows.Forms.CheckBox four;
        private System.Windows.Forms.CheckBox third;
        private System.Windows.Forms.CheckBox second;
        private System.Windows.Forms.CheckBox first;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}