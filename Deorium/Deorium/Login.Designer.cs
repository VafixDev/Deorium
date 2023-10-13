namespace Deorium
{
    partial class Login
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
            txtboxUserID = new TextBox();
            txtboxBotToken = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnSubmit = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtboxUserID
            // 
            txtboxUserID.Location = new Point(180, 124);
            txtboxUserID.Name = "txtboxUserID";
            txtboxUserID.Size = new Size(455, 27);
            txtboxUserID.TabIndex = 0;
            // 
            // txtboxBotToken
            // 
            txtboxBotToken.Location = new Point(180, 257);
            txtboxBotToken.Name = "txtboxBotToken";
            txtboxBotToken.Size = new Size(455, 27);
            txtboxBotToken.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(233, 60);
            label1.Name = "label1";
            label1.Size = new Size(362, 41);
            label1.TabIndex = 2;
            label1.Text = "Enter a telegram user id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(207, 195);
            label2.Name = "label2";
            label2.Size = new Size(405, 41);
            label2.TabIndex = 3;
            label2.Text = "Enter a telegram bot token:";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.Black;
            btnSubmit.FlatStyle = FlatStyle.Popup;
            btnSubmit.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnSubmit.ForeColor = SystemColors.ButtonHighlight;
            btnSubmit.Location = new Point(317, 349);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(168, 59);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(602, 400);
            label3.Name = "label3";
            label3.Size = new Size(181, 41);
            label3.TabIndex = 5;
            label3.Text = "Deorium v1";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(btnSubmit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtboxBotToken);
            Controls.Add(txtboxUserID);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtboxUserID;
        private TextBox txtboxBotToken;
        private Label label1;
        private Label label2;
        private Button btnSubmit;
        private Label label3;
    }
}