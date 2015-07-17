namespace Second_Class_Project
{
    partial class UI_Form
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
            this.Dice_Number_Box = new System.Windows.Forms.TextBox();
            this.Dice_Roll_Box = new System.Windows.Forms.TextBox();
            this.Seed_Value_Box = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Dice_Number_Box
            // 
            this.Dice_Number_Box.Location = new System.Drawing.Point(172, 36);
            this.Dice_Number_Box.Name = "Dice_Number_Box";
            this.Dice_Number_Box.Size = new System.Drawing.Size(100, 20);
            this.Dice_Number_Box.TabIndex = 0;
            // 
            // Dice_Roll_Box
            // 
            this.Dice_Roll_Box.Location = new System.Drawing.Point(172, 76);
            this.Dice_Roll_Box.Name = "Dice_Roll_Box";
            this.Dice_Roll_Box.Size = new System.Drawing.Size(100, 20);
            this.Dice_Roll_Box.TabIndex = 1;
            // 
            // Seed_Value_Box
            // 
            this.Seed_Value_Box.Location = new System.Drawing.Point(172, 114);
            this.Seed_Value_Box.Name = "Seed_Value_Box";
            this.Seed_Value_Box.Size = new System.Drawing.Size(100, 20);
            this.Seed_Value_Box.TabIndex = 2;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(152, 162);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 26);
            this.goButton.TabIndex = 3;
            this.goButton.Text = "GO!GO!GO!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Number of Dice";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter Number of Rolls Per Dice";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Enter the Seed Value";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Update_All_Charts);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.startForm1);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.startForm2);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(27, 168);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(51, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "LINQ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // UI_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 205);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.Seed_Value_Box);
            this.Controls.Add(this.Dice_Roll_Box);
            this.Controls.Add(this.Dice_Number_Box);
            this.Name = "UI_Form";
            this.Text = "Dice Statistics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Dice_Number_Box;
        private System.Windows.Forms.TextBox Dice_Roll_Box;
        private System.Windows.Forms.TextBox Seed_Value_Box;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

