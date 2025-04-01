namespace ASHome.Forms
{
    partial class SettingsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabCompany = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveCompanyInfo = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnSelectLogo = new System.Windows.Forms.Button();
            this.txtLogoPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBankDetails = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTaxId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdateProfile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCurrentPhone = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCurrentEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCurrentFullName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCurrentUsername = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPasswordNote = new System.Windows.Forms.Label();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.chkIsAdmin = new System.Windows.Forms.CheckBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtUserPhone = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtUserFullName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabBackup = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.btnRestoreBackup = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.btnCreateBackup = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabCompany.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.tabProfile.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tabBackup.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabCompany);
            this.tabMain.Controls.Add(this.tabProfile);
            this.tabMain.Controls.Add(this.tabUsers);
            this.tabMain.Controls.Add(this.tabBackup);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(884, 561);
            this.tabMain.TabIndex = 0;
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this.panel1);
            this.tabCompany.Location = new System.Drawing.Point(4, 22);
            this.tabCompany.Name = "tabCompany";
            this.tabCompany.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompany.Size = new System.Drawing.Size(876, 535);
            this.tabCompany.TabIndex = 0;
            this.tabCompany.Text = "Şirkət məlumatları";
            this.tabCompany.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSaveCompanyInfo);
            this.panel1.Controls.Add(this.pbLogo);
            this.panel1.Controls.Add(this.btnSelectLogo);
            this.panel1.Controls.Add(this.txtLogoPath);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtBankDetails);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtTaxId);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtWebsite);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCompanyName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 529);
            this.panel1.TabIndex = 0;
            // 
            // btnSaveCompanyInfo
            // 
            this.btnSaveCompanyInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCompanyInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveCompanyInfo.FlatAppearance.BorderSize = 0;
            this.btnSaveCompanyInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCompanyInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCompanyInfo.ForeColor = System.Drawing.Color.White;
            this.btnSaveCompanyInfo.Location = new System.Drawing.Point(730, 480);
            this.btnSaveCompanyInfo.Name = "btnSaveCompanyInfo";
            this.btnSaveCompanyInfo.Size = new System.Drawing.Size(128, 35);
            this.btnSaveCompanyInfo.TabIndex = 19;
            this.btnSaveCompanyInfo.Text = "Yadda saxla";
            this.btnSaveCompanyInfo.UseVisualStyleBackColor = false;
            this.btnSaveCompanyInfo.Click += new System.EventHandler(this.btnSaveCompanyInfo_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogo.Location = new System.Drawing.Point(541, 37);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(200, 200);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 18;
            this.pbLogo.TabStop = false;
            // 
            // btnSelectLogo
            // 
            this.btnSelectLogo.Location = new System.Drawing.Point(384, 379);
            this.btnSelectLogo.Name = "btnSelectLogo";
            this.btnSelectLogo.Size = new System.Drawing.Size(32, 23);
            this.btnSelectLogo.TabIndex = 17;
            this.btnSelectLogo.Text = "...";
            this.btnSelectLogo.UseVisualStyleBackColor = true;
            this.btnSelectLogo.Click += new System.EventHandler(this.btnSelectLogo_Click);
            // 
            // txtLogoPath
            // 
            this.txtLogoPath.Location = new System.Drawing.Point(29, 379);
            this.txtLogoPath.Name = "txtLogoPath";
            this.txtLogoPath.ReadOnly = true;
            this.txtLogoPath.Size = new System.Drawing.Size(349, 20);
            this.txtLogoPath.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Şirkət loqo:";
            // 
            // txtBankDetails
            // 
            this.txtBankDetails.Location = new System.Drawing.Point(29, 317);
            this.txtBankDetails.Multiline = true;
            this.txtBankDetails.Name = "txtBankDetails";
            this.txtBankDetails.Size = new System.Drawing.Size(387, 42);
            this.txtBankDetails.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Bank hesabı:";
            // 
            // txtTaxId
            // 
            this.txtTaxId.Location = new System.Drawing.Point(29, 260);
            this.txtTaxId.Name = "txtTaxId";
            this.txtTaxId.Size = new System.Drawing.Size(387, 20);
            this.txtTaxId.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "VÖEN nömrəsi:";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(29, 204);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(387, 20);
            this.txtWebsite.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Web:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(29, 149);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(387, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(29, 96);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(387, 20);
            this.txtPhone.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Telefon:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(227, 37);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(290, 40);
            this.txtAddress.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ünvan:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(29, 37);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(178, 20);
            this.txtCompanyName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Şirkət adı:";
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.panel2);
            this.tabProfile.Location = new System.Drawing.Point(4, 22);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(876, 535);
            this.tabProfile.TabIndex = 1;
            this.tabProfile.Text = "Profil";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnUpdateProfile);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.txtCurrentPhone);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtCurrentEmail);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtCurrentFullName);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtCurrentUsername);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 529);
            this.panel2.TabIndex = 0;
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnUpdateProfile.FlatAppearance.BorderSize = 0;
            this.btnUpdateProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProfile.ForeColor = System.Drawing.Color.White;
            this.btnUpdateProfile.Location = new System.Drawing.Point(730, 480);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(128, 35);
            this.btnUpdateProfile.TabIndex = 19;
            this.btnUpdateProfile.Text = "Yenilə";
            this.btnUpdateProfile.UseVisualStyleBackColor = false;
            this.btnUpdateProfile.Click += new System.EventHandler(this.btnUpdateProfile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConfirmPassword);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtNewPassword);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtCurrentPassword);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(29, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 187);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Şifrə dəyişikliklər (boş buraxıla bilər)";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(133, 127);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '•';
            this.txtConfirmPassword.Size = new System.Drawing.Size(216, 20);
            this.txtConfirmPassword.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Şifrəni təsdiq et:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(133, 87);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.Size = new System.Drawing.Size(216, 20);
            this.txtNewPassword.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Yeni şifrə:";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(133, 47);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '•';
            this.txtCurrentPassword.Size = new System.Drawing.Size(216, 20);
            this.txtCurrentPassword.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Cari şifrə:";
            // 
            // txtCurrentPhone
            // 
            this.txtCurrentPhone.Location = new System.Drawing.Point(178, 149);
            this.txtCurrentPhone.Name = "txtCurrentPhone";
            this.txtCurrentPhone.Size = new System.Drawing.Size(238, 20);
            this.txtCurrentPhone.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Telefon:";
            // 
            // txtCurrentEmail
            // 
            this.txtCurrentEmail.Location = new System.Drawing.Point(178, 109);
            this.txtCurrentEmail.Name = "txtCurrentEmail";
            this.txtCurrentEmail.Size = new System.Drawing.Size(238, 20);
            this.txtCurrentEmail.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Email:";
            // 
            // txtCurrentFullName
            // 
            this.txtCurrentFullName.Location = new System.Drawing.Point(178, 69);
            this.txtCurrentFullName.Name = "txtCurrentFullName";
            this.txtCurrentFullName.Size = new System.Drawing.Size(238, 20);
            this.txtCurrentFullName.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Ad və soyadı:";
            // 
            // txtCurrentUsername
            // 
            this.txtCurrentUsername.Location = new System.Drawing.Point(178, 29);
            this.txtCurrentUsername.Name = "txtCurrentUsername";
            this.txtCurrentUsername.ReadOnly = true;
            this.txtCurrentUsername.Size = new System.Drawing.Size(238, 20);
            this.txtCurrentUsername.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "İstifadəçi adı:";
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.splitContainer1);
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Size = new System.Drawing.Size(876, 535);
            this.tabUsers.TabIndex = 2;
            this.tabUsers.Text = "İstifadəçilər";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(876, 535);
            this.splitContainer1.SplitterDistance = 292;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblPasswordNote);
            this.panel3.Controls.Add(this.btnCancelEdit);
            this.panel3.Controls.Add(this.btnAddUser);
            this.panel3.Controls.Add(this.chkIsActive);
            this.panel3.Controls.Add(this.chkIsAdmin);
            this.panel3.Controls.Add(this.txtUserPassword);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.txtUserPhone);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.txtUserEmail);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.txtUserFullName);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.txtUsername);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(292, 535);
            this.panel3.TabIndex = 0;
            // 
            // lblPasswordNote
            // 
            this.lblPasswordNote.AutoSize = true;
            this.lblPasswordNote.ForeColor = System.Drawing.Color.Gray;
            this.lblPasswordNote.Location = new System.Drawing.Point(14, 203);
            this.lblPasswordNote.Name = "lblPasswordNote";
            this.lblPasswordNote.Size = new System.Drawing.Size(262, 13);
            this.lblPasswordNote.TabIndex = 26;
            this.lblPasswordNote.Text = "* Şifrəni dəyişmək istəmirsinizsə, bu sahəni boş buraxın";
            this.lblPasswordNote.Visible = false;
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.BackColor = System.Drawing.Color.Gray;
            this.btnCancelEdit.FlatAppearance.BorderSize = 0;
            this.btnCancelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEdit.ForeColor = System.Drawing.Color.White;
            this.btnCancelEdit.Location = new System.Drawing.Point(145, 300);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(125, 30);
            this.btnCancelEdit.TabIndex = 25;
            this.btnCancelEdit.Text = "Ləğv et";
            this.btnCancelEdit.UseVisualStyleBackColor = false;
            this.btnCancelEdit.Visible = false;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(14, 300);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(125, 30);
            this.btnAddUser.TabIndex = 24;
            this.btnAddUser.Text = "Əlavə et";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(14, 260);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(51, 17);
            this.chkIsActive.TabIndex = 23;
            this.chkIsActive.Text = "Aktiv";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // chkIsAdmin
            // 
            this.chkIsAdmin.AutoSize = true;
            this.chkIsAdmin.Location = new System.Drawing.Point(14, 237);
            this.chkIsAdmin.Name = "chkIsAdmin";
            this.chkIsAdmin.Size = new System.Drawing.Size(56, 17);
            this.chkIsAdmin.TabIndex = 22;
            this.chkIsAdmin.Text = "Admin";
            this.chkIsAdmin.UseVisualStyleBackColor = true;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(14, 180);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '•';
            this.txtUserPassword.Size = new System.Drawing.Size(262, 20);
            this.txtUserPassword.TabIndex = 21;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 164);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "Şifrə:";
            // 
            // txtUserPhone
            // 
            this.txtUserPhone.Location = new System.Drawing.Point(14, 141);
            this.txtUserPhone.Name = "txtUserPhone";
            this.txtUserPhone.Size = new System.Drawing.Size(262, 20);
            this.txtUserPhone.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 125);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Telefon:";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.Location = new System.Drawing.Point(14, 102);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(262, 20);
            this.txtUserEmail.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 86);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Email:";
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.Location = new System.Drawing.Point(14, 63);
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.Size = new System.Drawing.Size(262, 20);
            this.txtUserFullName.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Ad və soyadı:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(14, 24);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(262, 20);
            this.txtUsername.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "İstifadəçi adı:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.btnDeleteUser);
            this.panel4.Controls.Add(this.btnEditUser);
            this.panel4.Controls.Add(this.lblUserCount);
            this.panel4.Controls.Add(this.dgvUsers);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10);
            this.panel4.Size = new System.Drawing.Size(580, 535);
            this.panel4.TabIndex = 0;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(62)))), ((int)(((byte)(55)))));
            this.btnDeleteUser.FlatAppearance.BorderSize = 0;
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Location = new System.Drawing.Point(495, 494);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Sil";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditUser.BackColor = System.Drawing.Color.Orange;
            this.btnEditUser.FlatAppearance.BorderSize = 0;
            this.btnEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditUser.ForeColor = System.Drawing.Color.White;
            this.btnEditUser.Location = new System.Drawing.Point(414, 494);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(75, 23);
            this.btnEditUser.TabIndex = 2;
            this.btnEditUser.Text = "Redaktə et";
            this.btnEditUser.UseVisualStyleBackColor = false;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // lblUserCount
            // 
            this.lblUserCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUserCount.AutoSize = true;
            this.lblUserCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblUserCount.Location = new System.Drawing.Point(13, 498);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(130, 15);
            this.lblUserCount.TabIndex = 1;
            this.lblUserCount.Text = "Cəmi: 0 istifadəçi";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colUsername,
            this.colFullName,
            this.colEmail,
            this.colPhone,
            this.colRole,
            this.colStatus,
            this.colLastLogin});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvUsers.Location = new System.Drawing.Point(13, 13);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(557, 475);
            this.dgvUsers.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colUsername
            // 
            this.colUsername.FillWeight = 80F;
            this.colUsername.HeaderText = "İstifadəçi adı";
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.FillWeight = 120F;
            this.colFullName.HeaderText = "Ad və soyad";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.FillWeight = 110F;
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.FillWeight = 80F;
            this.colPhone.HeaderText = "Telefon";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colRole
            // 
            this.colRole.FillWeight = 60F;
            this.colRole.HeaderText = "Rol";
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 60F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colLastLogin
            // 
            this.colLastLogin.FillWeight = 100F;
            this.colLastLogin.HeaderText = "Son giriş";
            this.colLastLogin.Name = "colLastLogin";
            this.colLastLogin.ReadOnly = true;
            // 
            // tabBackup
            // 
            this.tabBackup.Controls.Add(this.panel5);
            this.tabBackup.Location = new System.Drawing.Point(4, 22);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Size = new System.Drawing.Size(876, 535);
            this.tabBackup.TabIndex = 3;
            this.tabBackup.Text = "Yedəkləmə";
            this.tabBackup.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label22);
            this.panel5.Controls.Add(this.btnRestoreBackup);
            this.panel5.Controls.Add(this.label21);
            this.panel5.Controls.Add(this.btnCreateBackup);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(876, 535);
            this.panel5.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(53, 172);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(570, 48);
            this.label22.TabIndex = 3;
            this.label22.Text = "Diqqət! Yedək faylı bərpa edildiyi zaman bütün mövcud verilənlər silinib, yedəkdək" +
    "i verilənlərlə əvəz ediləcək. Bu əməliyyatı yerinə yetirməzdən əvvəl əmin olun k" +
    "i, bütün vacib məlumatlar saxlanılıb.";
            // 
            // btnRestoreBackup
            // 
            this.btnRestoreBackup.BackColor = System.Drawing.Color.Orange;
            this.btnRestoreBackup.FlatAppearance.BorderSize = 0;
            this.btnRestoreBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoreBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestoreBackup.ForeColor = System.Drawing.Color.White;
            this.btnRestoreBackup.Location = new System.Drawing.Point(53, 134);
            this.btnRestoreBackup.Name = "btnRestoreBackup";
            this.btnRestoreBackup.Size = new System.Drawing.Size(248, 35);
            this.btnRestoreBackup.TabIndex = 2;
            this.btnRestoreBackup.Text = "Yedək faylından bərpa et";
            this.btnRestoreBackup.UseVisualStyleBackColor = false;
            this.btnRestoreBackup.Click += new System.EventHandler(this.btnRestoreBackup_Click);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(53, 72);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(570, 32);
            this.label21.TabIndex = 1;
            this.label21.Text = "Verilənlər bazasının ehtiyat nüsxəsini yaratmaq üçün aşağıdakı düyməni basın. Bu " +
    "əməliyyat bazanın tam surətini çıxarıb təhlükəsiz yerdə saxlamağa imkan verir.";
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCreateBackup.FlatAppearance.BorderSize = 0;
            this.btnCreateBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBackup.ForeColor = System.Drawing.Color.White;
            this.btnCreateBackup.Location = new System.Drawing.Point(53, 34);
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(248, 35);
            this.btnCreateBackup.TabIndex = 0;
            this.btnCreateBackup.Text = "Yedək yarat";
            this.btnCreateBackup.UseVisualStyleBackColor = false;
            this.btnCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tabMain);
            this.Name = "SettingsForm";
            this.Text = "Parametrlər";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabMain.ResumeLayout(false);
            this.tabCompany.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.tabProfile.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabUsers.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tabBackup.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabCompany;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabBackup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveCompanyInfo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSelectLogo;
        private System.Windows.Forms.TextBox txtLogoPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBankDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTaxId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdateProfile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCurrentPhone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCurrentEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCurrentFullName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCurrentUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPasswordNote;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.CheckBox chkIsAdmin;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtUserPhone;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtUserEmail;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtUserFullName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Label lblUserCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastLogin;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnRestoreBackup;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnCreateBackup;
    }
}
