namespace Judahs_Mine_Sweeper_Final_Exam
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components=new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1=new Panel();
            label1=new Label();
            lblScore=new Label();
            imageList1=new ImageList(components);
            JeffBox=new TextBox();
            label2=new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle=BorderStyle.FixedSingle;
            panel1.Location=new Point(12, 12);
            panel1.MaximumSize=new Size(400, 400);
            panel1.MinimumSize=new Size(400, 400);
            panel1.Name="panel1";
            panel1.Size=new Size(400, 400);
            panel1.TabIndex=0;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Font=new Font("Trajan Pro 3", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location=new Point(267, 451);
            label1.Name="label1";
            label1.Size=new Size(54, 19);
            label1.TabIndex=1;
            label1.Text="Score";
            // 
            // lblScore
            // 
            lblScore.BackColor=Color.Black;
            lblScore.Font=new Font("Trajan Pro 3", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            lblScore.ForeColor=Color.Lime;
            lblScore.Location=new Point(342, 448);
            lblScore.MaximumSize=new Size(70, 22);
            lblScore.Name="lblScore";
            lblScore.Size=new Size(70, 22);
            lblScore.TabIndex=2;
            lblScore.Text="0";
            lblScore.Click+=lblScore_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth=ColorDepth.Depth8Bit;
            imageList1.ImageStream=(ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor=Color.Transparent;
            imageList1.Images.SetKeyName(0, "Links Bomb png.png");
            imageList1.Images.SetKeyName(1, "Dollar sign.png");
            imageList1.Images.SetKeyName(2, "Minesweeper tiles png.png");
            // 
            // JeffBox
            // 
            JeffBox.BackColor=Color.Black;
            JeffBox.Font=new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            JeffBox.ForeColor=Color.Red;
            JeffBox.Location=new Point(12, 443);
            JeffBox.Multiline=true;
            JeffBox.Name="JeffBox";
            JeffBox.ReadOnly=true;
            JeffBox.Size=new Size(225, 136);
            JeffBox.TabIndex=3;
            JeffBox.TextChanged+=JeffBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.BackColor=Color.Cyan;
            label2.BorderStyle=BorderStyle.Fixed3D;
            label2.Font=new Font("Verdana", 12F, FontStyle.Bold|FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor=Color.Red;
            label2.Location=new Point(12, 420);
            label2.Name="label2";
            label2.Size=new Size(82, 20);
            label2.TabIndex=4;
            label2.Text="JeffBOT";
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(424, 591);
            Controls.Add(label2);
            Controls.Add(JeffBox);
            Controls.Add(lblScore);
            Controls.Add(label1);
            Controls.Add(panel1);
            MaximumSize=new Size(440, 630);
            MinimumSize=new Size(440, 530);
            Name="Form1";
            Text="Judah's Mine Sweeper";
            Load+=Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label lblScore;
        private ImageList imageList1;
        private TextBox JeffBox;
        private Label label2;
    }
}