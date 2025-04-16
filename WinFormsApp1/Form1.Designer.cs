namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxGray;
        private System.Windows.Forms.PictureBox pictureBoxNegative;
        private System.Windows.Forms.PictureBox pictureBoxMirror;
        private System.Windows.Forms.PictureBox pictureBoxThreshold;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLoadImage = new Button();
            openFileDialog1 = new OpenFileDialog();
            pictureBoxOriginal = new PictureBox();
            pictureBoxGray = new PictureBox();
            pictureBoxNegative = new PictureBox();
            pictureBoxMirror = new PictureBox();
            pictureBoxThreshold = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGray).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNegative).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMirror).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThreshold).BeginInit();
            SuspendLayout();
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(460, 12);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(120, 30);
            btnLoadImage.TabIndex = 0;
            btnLoadImage.Text = "Wczytaj obraz";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Location = new Point(12, 60);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(200, 200);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOriginal.TabIndex = 1;
            pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxGray
            // 
            pictureBoxGray.Location = new Point(220, 60);
            pictureBoxGray.Name = "pictureBoxGray";
            pictureBoxGray.Size = new Size(200, 200);
            pictureBoxGray.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxGray.TabIndex = 2;
            pictureBoxGray.TabStop = false;
            // 
            // pictureBoxNegative
            // 
            pictureBoxNegative.Location = new Point(430, 60);
            pictureBoxNegative.Name = "pictureBoxNegative";
            pictureBoxNegative.Size = new Size(200, 200);
            pictureBoxNegative.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxNegative.TabIndex = 3;
            pictureBoxNegative.TabStop = false;
            // 
            // pictureBoxMirror
            // 
            pictureBoxMirror.Location = new Point(640, 60);
            pictureBoxMirror.Name = "pictureBoxMirror";
            pictureBoxMirror.Size = new Size(200, 200);
            pictureBoxMirror.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMirror.TabIndex = 4;
            pictureBoxMirror.TabStop = false;
            // 
            // pictureBoxThreshold
            // 
            pictureBoxThreshold.Location = new Point(850, 60);
            pictureBoxThreshold.Name = "pictureBoxThreshold";
            pictureBoxThreshold.Size = new Size(200, 200);
            pictureBoxThreshold.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxThreshold.TabIndex = 5;
            pictureBoxThreshold.TabStop = false;
            // 
            // Form1
            // 
            ClientSize = new Size(1065, 280);
            Controls.Add(btnLoadImage);
            Controls.Add(pictureBoxOriginal);
            Controls.Add(pictureBoxGray);
            Controls.Add(pictureBoxNegative);
            Controls.Add(pictureBoxMirror);
            Controls.Add(pictureBoxThreshold);
            Name = "Form1";
            Text = "Przetwarzanie obrazów – wątki";
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGray).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNegative).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMirror).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThreshold).EndInit();
            ResumeLayout(false);
        }
    }
}
