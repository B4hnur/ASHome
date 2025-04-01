namespace ASHome.Forms
{
    partial class PropertyDetailsForm
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpUpdatedAt = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpCreatedAt = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSourceUrl = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numBuiltYear = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numTotalFloors = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numFloor = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numBathrooms = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numRooms = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numArea = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtListingCode = new System.Windows.Forms.TextBox();
            this.lblListingCode = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelImages = new System.Windows.Forms.Panel();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnNextImage = new System.Windows.Forms.Button();
            this.btnPrevImage = new System.Windows.Forms.Button();
            this.lblImageCount = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBuiltYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBathrooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.groupBox3);
            this.panelLeft.Controls.Add(this.groupBox2);
            this.panelLeft.Controls.Add(this.groupBox1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft.Size = new System.Drawing.Size(400, 661);
            this.panelLeft.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpUpdatedAt);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.dtpCreatedAt);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtSourceUrl);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.cmbEmployee);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cmbStatus);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(10, 416);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 235);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Digər məlumatlar";
            // 
            // dtpUpdatedAt
            // 
            this.dtpUpdatedAt.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpUpdatedAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUpdatedAt.Location = new System.Drawing.Point(159, 182);
            this.dtpUpdatedAt.Name = "dtpUpdatedAt";
            this.dtpUpdatedAt.Size = new System.Drawing.Size(200, 20);
            this.dtpUpdatedAt.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 186);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Yenilənmə tarixi:";
            // 
            // dtpCreatedAt
            // 
            this.dtpCreatedAt.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpCreatedAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreatedAt.Location = new System.Drawing.Point(159, 150);
            this.dtpCreatedAt.Name = "dtpCreatedAt";
            this.dtpCreatedAt.Size = new System.Drawing.Size(200, 20);
            this.dtpCreatedAt.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Yaranma tarixi:";
            // 
            // txtSourceUrl
            // 
            this.txtSourceUrl.Location = new System.Drawing.Point(18, 112);
            this.txtSourceUrl.Name = "txtSourceUrl";
            this.txtSourceUrl.Size = new System.Drawing.Size(342, 20);
            this.txtSourceUrl.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Mənbə linki:";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(159, 56);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(201, 21);
            this.cmbEmployee.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(159, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Məsul əməkdaş:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(18, 56);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Status:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numBuiltYear);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.numTotalFloors);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.numFloor);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.numBathrooms);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numRooms);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.numPrice);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numArea);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(10, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 183);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametrlər";
            // 
            // numBuiltYear
            // 
            this.numBuiltYear.Location = new System.Drawing.Point(274, 140);
            this.numBuiltYear.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numBuiltYear.Name = "numBuiltYear";
            this.numBuiltYear.Size = new System.Drawing.Size(86, 20);
            this.numBuiltYear.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(274, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Tikilmə ili:";
            // 
            // numTotalFloors
            // 
            this.numTotalFloors.Location = new System.Drawing.Point(159, 140);
            this.numTotalFloors.Name = "numTotalFloors";
            this.numTotalFloors.Size = new System.Drawing.Size(86, 20);
            this.numTotalFloors.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(159, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Ümumi mərtəbə:";
            // 
            // numFloor
            // 
            this.numFloor.Location = new System.Drawing.Point(21, 140);
            this.numFloor.Name = "numFloor";
            this.numFloor.Size = new System.Drawing.Size(86, 20);
            this.numFloor.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Mərtəbə:";
            // 
            // numBathrooms
            // 
            this.numBathrooms.Location = new System.Drawing.Point(274, 91);
            this.numBathrooms.Name = "numBathrooms";
            this.numBathrooms.Size = new System.Drawing.Size(86, 20);
            this.numBathrooms.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Hamam otağı:";
            // 
            // numRooms
            // 
            this.numRooms.Location = new System.Drawing.Point(159, 91);
            this.numRooms.Name = "numRooms";
            this.numRooms.Size = new System.Drawing.Size(86, 20);
            this.numRooms.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(159, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Otaq sayı:";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(21, 91);
            this.numPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(111, 20);
            this.numPrice.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Qiymət (₼):";
            // 
            // numArea
            // 
            this.numArea.DecimalPlaces = 2;
            this.numArea.Location = new System.Drawing.Point(21, 43);
            this.numArea.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numArea.Name = "numArea";
            this.numArea.Size = new System.Drawing.Size(111, 20);
            this.numArea.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Sahə (m²):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.lblTitle);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtListingCode);
            this.groupBox1.Controls.Add(this.lblListingCode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ümumi məlumatlar";
            // 
            // cmbCity
            // 
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(205, 46);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(155, 21);
            this.cmbCity.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Şəhər:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(18, 189);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(342, 20);
            this.txtAddress.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ünvan:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(18, 130);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(342, 40);
            this.txtDescription.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Təsvir:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(18, 91);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(342, 20);
            this.txtTitle.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(18, 75);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(44, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Başlıq:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(116, 46);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(83, 21);
            this.cmbType.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Növ:";
            // 
            // txtListingCode
            // 
            this.txtListingCode.Location = new System.Drawing.Point(18, 46);
            this.txtListingCode.Name = "txtListingCode";
            this.txtListingCode.ReadOnly = true;
            this.txtListingCode.Size = new System.Drawing.Size(83, 20);
            this.txtListingCode.TabIndex = 1;
            // 
            // lblListingCode
            // 
            this.lblListingCode.AutoSize = true;
            this.lblListingCode.Location = new System.Drawing.Point(18, 30);
            this.lblListingCode.Name = "lblListingCode";
            this.lblListingCode.Size = new System.Drawing.Size(56, 13);
            this.lblListingCode.TabIndex = 0;
            this.lblListingCode.Text = "Elan kodu:";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelBottom);
            this.panelRight.Controls.Add(this.panelImages);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(400, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(484, 661);
            this.panelRight.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 611);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(484, 50);
            this.panelBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(62)))), ((int)(((byte)(55)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(262, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Ləğv et";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(364, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Yadda Saxla";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelImages
            // 
            this.panelImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImages.BackColor = System.Drawing.Color.White;
            this.panelImages.Controls.Add(this.btnDeleteImage);
            this.panelImages.Controls.Add(this.btnAddImage);
            this.panelImages.Controls.Add(this.btnNextImage);
            this.panelImages.Controls.Add(this.btnPrevImage);
            this.panelImages.Controls.Add(this.lblImageCount);
            this.panelImages.Controls.Add(this.pictureBox);
            this.panelImages.Location = new System.Drawing.Point(19, 19);
            this.panelImages.Name = "panelImages";
            this.panelImages.Size = new System.Drawing.Size(453, 586);
            this.panelImages.TabIndex = 0;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(62)))), ((int)(((byte)(55)))));
            this.btnDeleteImage.FlatAppearance.BorderSize = 0;
            this.btnDeleteImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteImage.ForeColor = System.Drawing.Color.White;
            this.btnDeleteImage.Location = new System.Drawing.Point(208, 551);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(93, 23);
            this.btnDeleteImage.TabIndex = 6;
            this.btnDeleteImage.Text = "Şəkli sil";
            this.btnDeleteImage.UseVisualStyleBackColor = false;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddImage.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddImage.FlatAppearance.BorderSize = 0;
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImage.ForeColor = System.Drawing.Color.White;
            this.btnAddImage.Location = new System.Drawing.Point(109, 551);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(93, 23);
            this.btnAddImage.TabIndex = 5;
            this.btnAddImage.Text = "Şəkil əlavə et";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnNextImage
            // 
            this.btnNextImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnNextImage.FlatAppearance.BorderSize = 0;
            this.btnNextImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextImage.ForeColor = System.Drawing.Color.White;
            this.btnNextImage.Location = new System.Drawing.Point(357, 551);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(75, 23);
            this.btnNextImage.TabIndex = 4;
            this.btnNextImage.Text = "İrəli >";
            this.btnNextImage.UseVisualStyleBackColor = false;
            this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
            // 
            // btnPrevImage
            // 
            this.btnPrevImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrevImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnPrevImage.FlatAppearance.BorderSize = 0;
            this.btnPrevImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevImage.ForeColor = System.Drawing.Color.White;
            this.btnPrevImage.Location = new System.Drawing.Point(16, 551);
            this.btnPrevImage.Name = "btnPrevImage";
            this.btnPrevImage.Size = new System.Drawing.Size(75, 23);
            this.btnPrevImage.TabIndex = 3;
            this.btnPrevImage.Text = "< Geri";
            this.btnPrevImage.UseVisualStyleBackColor = false;
            this.btnPrevImage.Click += new System.EventHandler(this.btnPrevImage_Click);
            // 
            // lblImageCount
            // 
            this.lblImageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageCount.AutoSize = true;
            this.lblImageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageCount.Location = new System.Drawing.Point(357, 13);
            this.lblImageCount.Name = "lblImageCount";
            this.lblImageCount.Size = new System.Drawing.Size(67, 15);
            this.lblImageCount.TabIndex = 1;
            this.lblImageCount.Text = "Şəkil: 0/0";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(16, 31);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(416, 506);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // PropertyDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "PropertyDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Əmlak Detalları";
            this.Load += new System.EventHandler(this.PropertyDetailsForm_Load);
            this.panelLeft.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBuiltYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBathrooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelImages.ResumeLayout(false);
            this.panelImages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtListingCode;
        private System.Windows.Forms.Label lblListingCode;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numBuiltYear;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numTotalFloors;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numFloor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numBathrooms;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numRooms;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSourceUrl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpUpdatedAt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpCreatedAt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panelImages;
        private System.Windows.Forms.Label lblImageCount;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnNextImage;
        private System.Windows.Forms.Button btnPrevImage;
    }
}
