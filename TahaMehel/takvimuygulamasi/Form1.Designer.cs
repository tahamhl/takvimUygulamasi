namespace gorseltakvim
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
            dataGridView1 = new DataGridView();
            oncekibuton = new Button();
            sonrakibuton = new Button();
            silbuton = new Button();
            Bul = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 138);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(930, 776);
            dataGridView1.TabIndex = 0;
            // 
            // oncekibuton
            // 
            oncekibuton.BackColor = Color.Thistle;
            oncekibuton.FlatAppearance.BorderColor = Color.Black;
            oncekibuton.FlatAppearance.BorderSize = 2;
            oncekibuton.FlatStyle = FlatStyle.Flat;
            oncekibuton.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            oncekibuton.Location = new Point(11, 66);
            oncekibuton.Name = "oncekibuton";
            oncekibuton.Size = new Size(129, 40);
            oncekibuton.TabIndex = 1;
            oncekibuton.Text = "Önceki";
            oncekibuton.UseVisualStyleBackColor = false;
            oncekibuton.Click += oncekibuton_Click;
            // 
            // sonrakibuton
            // 
            sonrakibuton.BackColor = Color.PaleGreen;
            sonrakibuton.FlatAppearance.BorderColor = Color.Black;
            sonrakibuton.FlatAppearance.BorderSize = 2;
            sonrakibuton.FlatStyle = FlatStyle.Flat;
            sonrakibuton.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            sonrakibuton.Location = new Point(146, 66);
            sonrakibuton.Name = "sonrakibuton";
            sonrakibuton.Size = new Size(132, 40);
            sonrakibuton.TabIndex = 2;
            sonrakibuton.Text = "Sonraki";
            sonrakibuton.UseVisualStyleBackColor = false;
            sonrakibuton.Click += sonrakibuton_Click;
            // 
            // silbuton
            // 
            silbuton.BackColor = Color.RosyBrown;
            silbuton.FlatAppearance.BorderColor = SystemColors.ActiveCaptionText;
            silbuton.FlatAppearance.BorderSize = 2;
            silbuton.FlatStyle = FlatStyle.Flat;
            silbuton.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            silbuton.Location = new Point(577, 67);
            silbuton.Name = "silbuton";
            silbuton.Size = new Size(112, 39);
            silbuton.TabIndex = 3;
            silbuton.Text = "Sil";
            silbuton.UseVisualStyleBackColor = false;
            silbuton.Click += silbuton_Click;
            // 
            // Bul
            // 
            Bul.BackColor = SystemColors.GradientActiveCaption;
            Bul.BorderStyle = BorderStyle.FixedSingle;
            Bul.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            Bul.ForeColor = Color.Black;
            Bul.Location = new Point(711, 67);
            Bul.Multiline = true;
            Bul.Name = "Bul";
            Bul.Size = new Size(230, 39);
            Bul.TabIndex = 5;
            Bul.KeyDown += Bul_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(890, 42);
            label1.Name = "label1";
            label1.Size = new Size(51, 22);
            label1.TabIndex = 6;
            label1.Text = "Bulma";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 926);
            Controls.Add(label1);
            Controls.Add(Bul);
            Controls.Add(silbuton);
            Controls.Add(sonrakibuton);
            Controls.Add(oncekibuton);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Takvim";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button oncekibuton;
        private Button sonrakibuton;
        private Button silbuton;
        private TextBox Bul;
        private Label label1;
    }
}