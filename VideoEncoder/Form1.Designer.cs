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
            this.has_image = new System.Windows.Forms.CheckBox();
            this.video_load = new System.Windows.Forms.Button();
            this.image_load = new System.Windows.Forms.Button();
            this.view_mode = new System.Windows.Forms.GroupBox();
            this.quad = new System.Windows.Forms.RadioButton();
            this.dual = new System.Windows.Forms.RadioButton();
            this.create_video = new System.Windows.Forms.Button();
            this.name_video = new System.Windows.Forms.TextBox();
            this.label_for_name = new System.Windows.Forms.Label();
            this.four = new System.Windows.Forms.CheckBox();
            this.third = new System.Windows.Forms.CheckBox();
            this.second = new System.Windows.Forms.CheckBox();
            this.first = new System.Windows.Forms.CheckBox();
            this.view_mode.SuspendLayout();
            this.SuspendLayout();
            // 
            // has_image
            // 
            this.has_image.AutoSize = true;
            this.has_image.Location = new System.Drawing.Point(239, 70);
            this.has_image.Name = "has_image";
            this.has_image.Size = new System.Drawing.Size(82, 17);
            this.has_image.TabIndex = 2;
            this.has_image.Text = "Add image?";
            this.has_image.UseVisualStyleBackColor = true;
            this.has_image.CheckedChanged += new System.EventHandler(this.has_image_CheckedChanged);
            // 
            // video_load
            // 
            this.video_load.Location = new System.Drawing.Point(23, 29);
            this.video_load.Name = "video_load";
            this.video_load.Size = new System.Drawing.Size(190, 23);
            this.video_load.TabIndex = 3;
            this.video_load.Text = "Load Video";
            this.video_load.UseVisualStyleBackColor = true;
            this.video_load.Click += new System.EventHandler(this.video_load_Click);
            // 
            // image_load
            // 
            this.image_load.Location = new System.Drawing.Point(23, 66);
            this.image_load.Name = "image_load";
            this.image_load.Size = new System.Drawing.Size(190, 23);
            this.image_load.TabIndex = 4;
            this.image_load.Text = "Load image";
            this.image_load.UseVisualStyleBackColor = true;
            this.image_load.Click += new System.EventHandler(this.image_load_Click);
            // 
            // view_mode
            // 
            this.view_mode.Controls.Add(this.quad);
            this.view_mode.Controls.Add(this.dual);
            this.view_mode.Location = new System.Drawing.Point(374, 66);
            this.view_mode.Name = "view_mode";
            this.view_mode.Size = new System.Drawing.Size(207, 125);
            this.view_mode.TabIndex = 5;
            this.view_mode.TabStop = false;
            this.view_mode.Text = "View mode";
            // 
            // quad
            // 
            this.quad.AutoSize = true;
            this.quad.Location = new System.Drawing.Point(124, 87);
            this.quad.Name = "quad";
            this.quad.Size = new System.Drawing.Size(51, 17);
            this.quad.TabIndex = 1;
            this.quad.Text = "Quad";
            this.quad.UseVisualStyleBackColor = true;
            this.quad.CheckedChanged += new System.EventHandler(this.quad_CheckedChanged);
            // 
            // dual
            // 
            this.dual.AutoSize = true;
            this.dual.Checked = true;
            this.dual.Location = new System.Drawing.Point(31, 87);
            this.dual.Name = "dual";
            this.dual.Size = new System.Drawing.Size(47, 17);
            this.dual.TabIndex = 0;
            this.dual.TabStop = true;
            this.dual.Text = "Dual";
            this.dual.UseVisualStyleBackColor = true;
            this.dual.CheckedChanged += new System.EventHandler(this.dual_CheckedChanged);
            // 
            // create_video
            // 
            this.create_video.Location = new System.Drawing.Point(23, 154);
            this.create_video.Name = "create_video";
            this.create_video.Size = new System.Drawing.Size(323, 37);
            this.create_video.TabIndex = 6;
            this.create_video.Text = "Create video";
            this.create_video.UseVisualStyleBackColor = true;
            this.create_video.Click += new System.EventHandler(this.create_video_Click);
            // 
            // name_video
            // 
            this.name_video.Location = new System.Drawing.Point(142, 116);
            this.name_video.Name = "name_video";
            this.name_video.Size = new System.Drawing.Size(204, 20);
            this.name_video.TabIndex = 7;
            this.name_video.TextChanged += new System.EventHandler(this.name_video_TextChanged);
            // 
            // label_for_name
            // 
            this.label_for_name.AutoSize = true;
            this.label_for_name.Location = new System.Drawing.Point(23, 119);
            this.label_for_name.Name = "label_for_name";
            this.label_for_name.Size = new System.Drawing.Size(99, 13);
            this.label_for_name.TabIndex = 8;
            this.label_for_name.Text = "New name of video";
            // 
            // four
            // 
            this.four.AutoSize = true;
            this.four.Location = new System.Drawing.Point(374, 33);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(39, 17);
            this.four.TabIndex = 16;
            this.four.Text = "V4";
            this.four.UseVisualStyleBackColor = true;
            this.four.CheckedChanged += new System.EventHandler(this.four_CheckedChanged);
            // 
            // third
            // 
            this.third.AutoSize = true;
            this.third.Location = new System.Drawing.Point(329, 33);
            this.third.Name = "third";
            this.third.Size = new System.Drawing.Size(39, 17);
            this.third.TabIndex = 15;
            this.third.Text = "V3";
            this.third.UseVisualStyleBackColor = true;
            this.third.CheckedChanged += new System.EventHandler(this.third_CheckedChanged);
            // 
            // second
            // 
            this.second.AutoSize = true;
            this.second.Location = new System.Drawing.Point(284, 33);
            this.second.Name = "second";
            this.second.Size = new System.Drawing.Size(39, 17);
            this.second.TabIndex = 14;
            this.second.Text = "V2";
            this.second.UseVisualStyleBackColor = true;
            this.second.CheckedChanged += new System.EventHandler(this.second_CheckedChanged);
            // 
            // first
            // 
            this.first.AutoSize = true;
            this.first.Location = new System.Drawing.Point(239, 33);
            this.first.Name = "first";
            this.first.Size = new System.Drawing.Size(39, 17);
            this.first.TabIndex = 13;
            this.first.Text = "V1";
            this.first.UseVisualStyleBackColor = true;
            this.first.CheckedChanged += new System.EventHandler(this.first_CheckedChanged);
            // 
            // Encoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 215);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Encoder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoEncoder";
            this.view_mode.ResumeLayout(false);
            this.view_mode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

