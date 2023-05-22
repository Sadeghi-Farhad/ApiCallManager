namespace WinFormsTester
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_call = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_token = new System.Windows.Forms.RichTextBox();
            this.richTextBox_request = new System.Windows.Forms.RichTextBox();
            this.richTextBox_response = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_method = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelUrl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Access Token:";
            // 
            // button_call
            // 
            this.button_call.Location = new System.Drawing.Point(351, 400);
            this.button_call.Name = "button_call";
            this.button_call.Size = new System.Drawing.Size(75, 23);
            this.button_call.TabIndex = 1;
            this.button_call.Text = "CALL";
            this.button_call.UseVisualStyleBackColor = true;
            this.button_call.Click += new System.EventHandler(this.button_call_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "REQUEST:";
            // 
            // richTextBox_token
            // 
            this.richTextBox_token.Location = new System.Drawing.Point(215, 40);
            this.richTextBox_token.Name = "richTextBox_token";
            this.richTextBox_token.Size = new System.Drawing.Size(685, 99);
            this.richTextBox_token.TabIndex = 5;
            this.richTextBox_token.Text = "";
            // 
            // richTextBox_request
            // 
            this.richTextBox_request.Location = new System.Drawing.Point(215, 200);
            this.richTextBox_request.Name = "richTextBox_request";
            this.richTextBox_request.Size = new System.Drawing.Size(343, 184);
            this.richTextBox_request.TabIndex = 6;
            this.richTextBox_request.Text = "";
            // 
            // richTextBox_response
            // 
            this.richTextBox_response.Location = new System.Drawing.Point(578, 200);
            this.richTextBox_response.Name = "richTextBox_response";
            this.richTextBox_response.Size = new System.Drawing.Size(322, 184);
            this.richTextBox_response.TabIndex = 8;
            this.richTextBox_response.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "RESPONSE:";
            // 
            // comboBox_method
            // 
            this.comboBox_method.FormattingEnabled = true;
            this.comboBox_method.Location = new System.Drawing.Point(23, 212);
            this.comboBox_method.Name = "comboBox_method";
            this.comboBox_method.Size = new System.Drawing.Size(177, 23);
            this.comboBox_method.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "METHOD:";
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(23, 255);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(47, 15);
            this.labelUrl.TabIndex = 11;
            this.labelUrl.Text = "labelUrl";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 450);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_method);
            this.Controls.Add(this.richTextBox_response);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox_request);
            this.Controls.Add(this.richTextBox_token);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_call);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button_call;
        private Label label2;
        private RichTextBox richTextBox_token;
        private RichTextBox richTextBox_request;
        private RichTextBox richTextBox_response;
        private Label label3;
        private ComboBox comboBox_method;
        private Label label4;
        private Label labelUrl;
    }
}