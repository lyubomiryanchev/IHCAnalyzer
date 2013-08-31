namespace ImmunohistochemistryAnalyzer
{
	partial class MainForm
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
			this.pictureBoxResultImage = new System.Windows.Forms.PictureBox();
			this.buttonLoadImage = new System.Windows.Forms.Button();
			this.buttonAnalyzeImage = new System.Windows.Forms.Button();
			this.labelAnalysis = new System.Windows.Forms.Label();
			this.buttonSaveImage = new System.Windows.Forms.Button();
			this.tabControlImages = new System.Windows.Forms.TabControl();
			this.tabFirstImage = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultImage)).BeginInit();
			this.tabControlImages.SuspendLayout();
			this.tabFirstImage.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxResultImage
			// 
			this.pictureBoxResultImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxResultImage.Location = new System.Drawing.Point(6, 3);
			this.pictureBoxResultImage.Name = "pictureBoxResultImage";
			this.pictureBoxResultImage.Size = new System.Drawing.Size(781, 449);
			this.pictureBoxResultImage.TabIndex = 0;
			this.pictureBoxResultImage.TabStop = false;
			// 
			// buttonLoadImage
			// 
			this.buttonLoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLoadImage.Location = new System.Drawing.Point(735, 512);
			this.buttonLoadImage.Name = "buttonLoadImage";
			this.buttonLoadImage.Size = new System.Drawing.Size(75, 23);
			this.buttonLoadImage.TabIndex = 1;
			this.buttonLoadImage.Text = "Load image";
			this.buttonLoadImage.UseVisualStyleBackColor = true;
			this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
			// 
			// buttonAnalyzeImage
			// 
			this.buttonAnalyzeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAnalyzeImage.Location = new System.Drawing.Point(654, 512);
			this.buttonAnalyzeImage.Name = "buttonAnalyzeImage";
			this.buttonAnalyzeImage.Size = new System.Drawing.Size(75, 23);
			this.buttonAnalyzeImage.TabIndex = 2;
			this.buttonAnalyzeImage.Text = "Analyze";
			this.buttonAnalyzeImage.UseVisualStyleBackColor = true;
			this.buttonAnalyzeImage.Click += new System.EventHandler(this.buttonAnalyzeImage_Click);
			// 
			// labelAnalysis
			// 
			this.labelAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelAnalysis.AutoSize = true;
			this.labelAnalysis.Location = new System.Drawing.Point(12, 517);
			this.labelAnalysis.Name = "labelAnalysis";
			this.labelAnalysis.Size = new System.Drawing.Size(51, 13);
			this.labelAnalysis.TabIndex = 3;
			this.labelAnalysis.Text = "Analisys: ";
			// 
			// buttonSaveImage
			// 
			this.buttonSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveImage.Location = new System.Drawing.Point(573, 512);
			this.buttonSaveImage.Name = "buttonSaveImage";
			this.buttonSaveImage.Size = new System.Drawing.Size(75, 23);
			this.buttonSaveImage.TabIndex = 4;
			this.buttonSaveImage.Text = "Save";
			this.buttonSaveImage.UseVisualStyleBackColor = true;
			this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
			// 
			// tabControlImages
			// 
			this.tabControlImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlImages.Controls.Add(this.tabFirstImage);
			this.tabControlImages.Location = new System.Drawing.Point(12, 12);
			this.tabControlImages.Name = "tabControlImages";
			this.tabControlImages.SelectedIndex = 0;
			this.tabControlImages.Size = new System.Drawing.Size(798, 484);
			this.tabControlImages.TabIndex = 5;
			// 
			// tabFirstImage
			// 
			this.tabFirstImage.Controls.Add(this.pictureBoxResultImage);
			this.tabFirstImage.Location = new System.Drawing.Point(4, 22);
			this.tabFirstImage.Name = "tabFirstImage";
			this.tabFirstImage.Padding = new System.Windows.Forms.Padding(3);
			this.tabFirstImage.Size = new System.Drawing.Size(790, 458);
			this.tabFirstImage.TabIndex = 0;
			this.tabFirstImage.Text = "first-image";
			this.tabFirstImage.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(822, 545);
			this.Controls.Add(this.tabControlImages);
			this.Controls.Add(this.buttonSaveImage);
			this.Controls.Add(this.labelAnalysis);
			this.Controls.Add(this.buttonAnalyzeImage);
			this.Controls.Add(this.buttonLoadImage);
			this.Name = "MainForm";
			this.Text = "Immunohistochemistry analyzer";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultImage)).EndInit();
			this.tabControlImages.ResumeLayout(false);
			this.tabFirstImage.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxResultImage;
		private System.Windows.Forms.Button buttonLoadImage;
		private System.Windows.Forms.Button buttonAnalyzeImage;
		private System.Windows.Forms.Label labelAnalysis;
		private System.Windows.Forms.Button buttonSaveImage;
		private System.Windows.Forms.TabControl tabControlImages;
		private System.Windows.Forms.TabPage tabFirstImage;
	}
}

