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
            this.button_getList = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listView_users = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_gender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_adduser = new System.Windows.Forms.Button();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_SelectMultiPartFile = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_PostMultiPart = new System.Windows.Forms.Button();
            this.txtBox_MultiPartFile = new System.Windows.Forms.TextBox();
            this.txtBox_MultiPartStringParam = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBox_MultiPartIntParam = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName:";
            // 
            // button_getList
            // 
            this.button_getList.Location = new System.Drawing.Point(657, 112);
            this.button_getList.Name = "button_getList";
            this.button_getList.Size = new System.Drawing.Size(109, 23);
            this.button_getList.TabIndex = 1;
            this.button_getList.Text = "Get List";
            this.button_getList.UseVisualStyleBackColor = true;
            this.button_getList.Click += new System.EventHandler(this.button_getlist_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Users List:";
            // 
            // listView_users
            // 
            this.listView_users.Location = new System.Drawing.Point(542, 30);
            this.listView_users.Name = "listView_users";
            this.listView_users.Size = new System.Drawing.Size(348, 80);
            this.listView_users.TabIndex = 12;
            this.listView_users.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_login);
            this.groupBox1.Controls.Add(this.textBox_password);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_username);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 121);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LOGIN";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(333, 75);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 23);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(94, 73);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(194, 23);
            this.textBox_password.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password:";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(94, 35);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(194, 23);
            this.textBox_username.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_gender);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button_adduser);
            this.groupBox2.Controls.Add(this.textBox_email);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_name);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(23, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 226);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADD USER";
            // 
            // comboBox_gender
            // 
            this.comboBox_gender.FormattingEnabled = true;
            this.comboBox_gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboBox_gender.Location = new System.Drawing.Point(94, 121);
            this.comboBox_gender.Name = "comboBox_gender";
            this.comboBox_gender.Size = new System.Drawing.Size(194, 23);
            this.comboBox_gender.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Gender:";
            // 
            // button_adduser
            // 
            this.button_adduser.Location = new System.Drawing.Point(181, 180);
            this.button_adduser.Name = "button_adduser";
            this.button_adduser.Size = new System.Drawing.Size(75, 23);
            this.button_adduser.TabIndex = 9;
            this.button_adduser.Text = "ADD";
            this.button_adduser.UseVisualStyleBackColor = true;
            this.button_adduser.Click += new System.EventHandler(this.button_adduser_Click);
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(94, 85);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(194, 23);
            this.textBox_email.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Email:";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(94, 48);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(194, 23);
            this.textBox_name.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_SelectMultiPartFile);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btn_PostMultiPart);
            this.groupBox3.Controls.Add(this.txtBox_MultiPartFile);
            this.groupBox3.Controls.Add(this.txtBox_MultiPartStringParam);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtBox_MultiPartIntParam);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(542, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 175);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MultiPartFormData";
            // 
            // btn_SelectMultiPartFile
            // 
            this.btn_SelectMultiPartFile.Location = new System.Drawing.Point(313, 99);
            this.btn_SelectMultiPartFile.Name = "btn_SelectMultiPartFile";
            this.btn_SelectMultiPartFile.Size = new System.Drawing.Size(25, 26);
            this.btn_SelectMultiPartFile.TabIndex = 16;
            this.btn_SelectMultiPartFile.Text = "...";
            this.btn_SelectMultiPartFile.UseVisualStyleBackColor = true;
            this.btn_SelectMultiPartFile.Click += new System.EventHandler(this.btn_SelectMultiPartFile_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "FileParam:";
            // 
            // btn_PostMultiPart
            // 
            this.btn_PostMultiPart.Location = new System.Drawing.Point(129, 137);
            this.btn_PostMultiPart.Name = "btn_PostMultiPart";
            this.btn_PostMultiPart.Size = new System.Drawing.Size(75, 23);
            this.btn_PostMultiPart.TabIndex = 14;
            this.btn_PostMultiPart.Text = "Post";
            this.btn_PostMultiPart.UseVisualStyleBackColor = true;
            this.btn_PostMultiPart.Click += new System.EventHandler(this.btn_PostMultiPart_Click);
            // 
            // txtBox_MultiPartFile
            // 
            this.txtBox_MultiPartFile.Location = new System.Drawing.Point(79, 99);
            this.txtBox_MultiPartFile.Name = "txtBox_MultiPartFile";
            this.txtBox_MultiPartFile.Size = new System.Drawing.Size(228, 23);
            this.txtBox_MultiPartFile.TabIndex = 13;
            // 
            // txtBox_MultiPartStringParam
            // 
            this.txtBox_MultiPartStringParam.Location = new System.Drawing.Point(79, 64);
            this.txtBox_MultiPartStringParam.Name = "txtBox_MultiPartStringParam";
            this.txtBox_MultiPartStringParam.Size = new System.Drawing.Size(194, 23);
            this.txtBox_MultiPartStringParam.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "StringParam:";
            // 
            // txtBox_MultiPartIntParam
            // 
            this.txtBox_MultiPartIntParam.Location = new System.Drawing.Point(79, 27);
            this.txtBox_MultiPartIntParam.Name = "txtBox_MultiPartIntParam";
            this.txtBox_MultiPartIntParam.Size = new System.Drawing.Size(194, 23);
            this.txtBox_MultiPartIntParam.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "IntParam:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView_users);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_getList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button_getList;
        private Label label3;
        private ListView listView_users;
        private GroupBox groupBox1;
        private Button button_login;
        private TextBox textBox_password;
        private Label label5;
        private TextBox textBox_username;
        private GroupBox groupBox2;
        private Button button_adduser;
        private TextBox textBox_email;
        private Label label2;
        private TextBox textBox_name;
        private Label label4;
        private ComboBox comboBox_gender;
        private Label label6;
        private GroupBox groupBox3;
        private TextBox txtBox_MultiPartStringParam;
        private Label label7;
        private TextBox txtBox_MultiPartIntParam;
        private Label label8;
        private OpenFileDialog openFileDialog1;
        private Button btn_PostMultiPart;
        private TextBox txtBox_MultiPartFile;
        private Button btn_SelectMultiPartFile;
        private Label label9;
    }
}