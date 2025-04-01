namespace ASHome.Forms
{
    partial class PrintDownPaymentForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBoxCompany = new System.Windows.Forms.GroupBox();
            this.lblCompanyEmail = new System.Windows.Forms.Label();
            this.lblCompanyPhone = new System.Windows.Forms.Label();
            this.lblCompanyAddress = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.groupBoxCustomer = new System.Windows.Forms.GroupBox();
            this.lblCustomerEmail = new System.Windows.Forms.Label();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxProperty = new System.Windows.Forms.GroupBox();
            this.lblPropertyDetails = new System.Windows.Forms.Label();
            this.lblPropertyAddress = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxPayment = new System.Windows.Forms.GroupBox();
            this.lblDownPaymentNote = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblDownPaymentAmount = new System.Windows.Forms.Label();
            this.lblDownPaymentDate = new System.Windows.Forms.Label();
            this.lblDownPaymentId = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.groupBoxCompany.SuspendLayout();
            this.groupBoxCustomer.SuspendLayout();
            this.groupBoxProperty.SuspendLayout();
            this.groupBoxPayment.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblFormTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(784, 60);
            this.panelTop.TabIndex = 0;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(12, 9);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(760, 36);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Beh Qəbzi";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnPreview);
            this.panelButtons.Controls.Add(this.btnPrint);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 511);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(784, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(697, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Ləğv et";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnPreview.FlatAppearance.BorderSize = 0;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Location = new System.Drawing.Point(535, 9);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 32);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "Önizlə";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(616, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 32);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Çap et";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.groupBoxCompany);
            this.panelContent.Controls.Add(this.groupBoxCustomer);
            this.panelContent.Controls.Add(this.groupBoxProperty);
            this.panelContent.Controls.Add(this.groupBoxPayment);
            this.panelContent.Controls.Add(this.panelFooter);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(784, 451);
            this.panelContent.TabIndex = 2;
            // 
            // groupBoxCompany
            // 
            this.groupBoxCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCompany.Controls.Add(this.lblCompanyEmail);
            this.groupBoxCompany.Controls.Add(this.lblCompanyPhone);
            this.groupBoxCompany.Controls.Add(this.lblCompanyAddress);
            this.groupBoxCompany.Controls.Add(this.lblCompanyName);
            this.groupBoxCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCompany.Location = new System.Drawing.Point(12, 6);
            this.groupBoxCompany.Name = "groupBoxCompany";
            this.groupBoxCompany.Size = new System.Drawing.Size(760, 100);
            this.groupBoxCompany.TabIndex = 0;
            this.groupBoxCompany.TabStop = false;
            this.groupBoxCompany.Text = "Şirkət Məlumatları";
            // 
            // lblCompanyEmail
            // 
            this.lblCompanyEmail.AutoSize = true;
            this.lblCompanyEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyEmail.Location = new System.Drawing.Point(18, 77);
            this.lblCompanyEmail.Name = "lblCompanyEmail";
            this.lblCompanyEmail.Size = new System.Drawing.Size(100, 15);
            this.lblCompanyEmail.TabIndex = 3;
            this.lblCompanyEmail.Text = "info@ashome.az";
            // 
            // lblCompanyPhone
            // 
            this.lblCompanyPhone.AutoSize = true;
            this.lblCompanyPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyPhone.Location = new System.Drawing.Point(18, 59);
            this.lblCompanyPhone.Name = "lblCompanyPhone";
            this.lblCompanyPhone.Size = new System.Drawing.Size(101, 15);
            this.lblCompanyPhone.TabIndex = 2;
            this.lblCompanyPhone.Text = "+994 xx xxx xx xx";
            // 
            // lblCompanyAddress
            // 
            this.lblCompanyAddress.AutoSize = true;
            this.lblCompanyAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyAddress.Location = new System.Drawing.Point(18, 41);
            this.lblCompanyAddress.Name = "lblCompanyAddress";
            this.lblCompanyAddress.Size = new System.Drawing.Size(134, 15);
            this.lblCompanyAddress.TabIndex = 1;
            this.lblCompanyAddress.Text = "Bakı şəhəri, Nərimanov";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(18, 22);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(79, 18);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "AS Home";
            // 
            // groupBoxCustomer
            // 
            this.groupBoxCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCustomer.Controls.Add(this.lblCustomerEmail);
            this.groupBoxCustomer.Controls.Add(this.lblCustomerPhone);
            this.groupBoxCustomer.Controls.Add(this.lblCustomerName);
            this.groupBoxCustomer.Controls.Add(this.label3);
            this.groupBoxCustomer.Controls.Add(this.label2);
            this.groupBoxCustomer.Controls.Add(this.label1);
            this.groupBoxCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCustomer.Location = new System.Drawing.Point(12, 112);
            this.groupBoxCustomer.Name = "groupBoxCustomer";
            this.groupBoxCustomer.Size = new System.Drawing.Size(760, 85);
            this.groupBoxCustomer.TabIndex = 1;
            this.groupBoxCustomer.TabStop = false;
            this.groupBoxCustomer.Text = "Müştəri Məlumatları";
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.AutoSize = true;
            this.lblCustomerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerEmail.Location = new System.Drawing.Point(85, 63);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(128, 15);
            this.lblCustomerEmail.TabIndex = 5;
            this.lblCustomerEmail.Text = "customer@email.com";
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerPhone.Location = new System.Drawing.Point(85, 43);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(101, 15);
            this.lblCustomerPhone.TabIndex = 4;
            this.lblCustomerPhone.Text = "+994 xx xxx xx xx";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(85, 23);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(85, 15);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "Müştəri Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Telefon:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad:";
            // 
            // groupBoxProperty
            // 
            this.groupBoxProperty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProperty.Controls.Add(this.lblPropertyDetails);
            this.groupBoxProperty.Controls.Add(this.lblPropertyAddress);
            this.groupBoxProperty.Controls.Add(this.label7);
            this.groupBoxProperty.Controls.Add(this.label8);
            this.groupBoxProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProperty.Location = new System.Drawing.Point(12, 203);
            this.groupBoxProperty.Name = "groupBoxProperty";
            this.groupBoxProperty.Size = new System.Drawing.Size(760, 70);
            this.groupBoxProperty.TabIndex = 6;
            this.groupBoxProperty.TabStop = false;
            this.groupBoxProperty.Text = "Əmlak Məlumatları";
            this.groupBoxProperty.Enter += new System.EventHandler(this.groupBoxProperty_Enter);
            // 
            // lblPropertyDetails
            // 
            this.lblPropertyDetails.AutoSize = true;
            this.lblPropertyDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertyDetails.Location = new System.Drawing.Point(85, 43);
            this.lblPropertyDetails.Name = "lblPropertyDetails";
            this.lblPropertyDetails.Size = new System.Drawing.Size(92, 15);
            this.lblPropertyDetails.TabIndex = 4;
            this.lblPropertyDetails.Text = "3 otaqlı, 120 m²";
            // 
            // lblPropertyAddress
            // 
            this.lblPropertyAddress.AutoSize = true;
            this.lblPropertyAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertyAddress.Location = new System.Drawing.Point(85, 23);
            this.lblPropertyAddress.Name = "lblPropertyAddress";
            this.lblPropertyAddress.Size = new System.Drawing.Size(250, 15);
            this.lblPropertyAddress.TabIndex = 3;
            this.lblPropertyAddress.Text = "Bakı şəhəri, Nərimanov rayonu, Əhmədov 55";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Detalı:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ünvan:";
            // 
            // groupBoxPayment
            // 
            this.groupBoxPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPayment.Controls.Add(this.lblDownPaymentNote);
            this.groupBoxPayment.Controls.Add(this.lblPaymentMethod);
            this.groupBoxPayment.Controls.Add(this.lblDownPaymentAmount);
            this.groupBoxPayment.Controls.Add(this.lblDownPaymentDate);
            this.groupBoxPayment.Controls.Add(this.lblDownPaymentId);
            this.groupBoxPayment.Controls.Add(this.label9);
            this.groupBoxPayment.Controls.Add(this.label10);
            this.groupBoxPayment.Controls.Add(this.label11);
            this.groupBoxPayment.Controls.Add(this.label12);
            this.groupBoxPayment.Controls.Add(this.label13);
            this.groupBoxPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPayment.Location = new System.Drawing.Point(12, 279);
            this.groupBoxPayment.Name = "groupBoxPayment";
            this.groupBoxPayment.Size = new System.Drawing.Size(760, 120);
            this.groupBoxPayment.TabIndex = 7;
            this.groupBoxPayment.TabStop = false;
            this.groupBoxPayment.Text = "Ödəniş Məlumatları";
            // 
            // lblDownPaymentNote
            // 
            this.lblDownPaymentNote.AutoSize = true;
            this.lblDownPaymentNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownPaymentNote.Location = new System.Drawing.Point(85, 103);
            this.lblDownPaymentNote.Name = "lblDownPaymentNote";
            this.lblDownPaymentNote.Size = new System.Drawing.Size(249, 15);
            this.lblDownPaymentNote.TabIndex = 9;
            this.lblDownPaymentNote.Text = "Bu qəbz əmlakın beh ödənişi üçün təsdiqdir.";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.Location = new System.Drawing.Point(85, 83);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(37, 15);
            this.lblPaymentMethod.TabIndex = 8;
            this.lblPaymentMethod.Text = "Nağd";
            // 
            // lblDownPaymentAmount
            // 
            this.lblDownPaymentAmount.AutoSize = true;
            this.lblDownPaymentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownPaymentAmount.Location = new System.Drawing.Point(85, 63);
            this.lblDownPaymentAmount.Name = "lblDownPaymentAmount";
            this.lblDownPaymentAmount.Size = new System.Drawing.Size(71, 15);
            this.lblDownPaymentAmount.TabIndex = 7;
            this.lblDownPaymentAmount.Text = "10,000 AZN";
            // 
            // lblDownPaymentDate
            // 
            this.lblDownPaymentDate.AutoSize = true;
            this.lblDownPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownPaymentDate.Location = new System.Drawing.Point(85, 43);
            this.lblDownPaymentDate.Name = "lblDownPaymentDate";
            this.lblDownPaymentDate.Size = new System.Drawing.Size(69, 15);
            this.lblDownPaymentDate.TabIndex = 6;
            this.lblDownPaymentDate.Text = "01.04.2023";
            // 
            // lblDownPaymentId
            // 
            this.lblDownPaymentId.AutoSize = true;
            this.lblDownPaymentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownPaymentId.Location = new System.Drawing.Point(85, 23);
            this.lblDownPaymentId.Name = "lblDownPaymentId";
            this.lblDownPaymentId.Size = new System.Drawing.Size(49, 15);
            this.lblDownPaymentId.TabIndex = 5;
            this.lblDownPaymentId.Text = "BH-001";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Qeyd:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Ödəniş:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Məbləğ:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Tarix:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "İD:";
            // 
            // panelFooter
            // 
            this.panelFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFooter.Controls.Add(this.lblCreatedDate);
            this.panelFooter.Controls.Add(this.lblCreatedBy);
            this.panelFooter.Controls.Add(this.label15);
            this.panelFooter.Controls.Add(this.label14);
            this.panelFooter.Location = new System.Drawing.Point(12, 401);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(760, 50);
            this.panelFooter.TabIndex = 8;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedDate.Location = new System.Drawing.Point(662, 26);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(69, 15);
            this.lblCreatedDate.TabIndex = 7;
            this.lblCreatedDate.Text = "01.04.2023";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(662, 6);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(79, 15);
            this.lblCreatedBy.TabIndex = 6;
            this.lblCreatedBy.Text = "Administrator";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(612, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 15);
            this.label15.TabIndex = 5;
            this.label15.Text = "Tarix:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(594, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "Yaradan:";
            // 
            // PrintDownPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "PrintDownPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beh Qəbzi";
            this.panelTop.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.groupBoxCompany.ResumeLayout(false);
            this.groupBoxCompany.PerformLayout();
            this.groupBoxCustomer.ResumeLayout(false);
            this.groupBoxCustomer.PerformLayout();
            this.groupBoxProperty.ResumeLayout(false);
            this.groupBoxProperty.PerformLayout();
            this.groupBoxPayment.ResumeLayout(false);
            this.groupBoxPayment.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.GroupBox groupBoxCompany;
        private System.Windows.Forms.Label lblCompanyEmail;
        private System.Windows.Forms.Label lblCompanyPhone;
        private System.Windows.Forms.Label lblCompanyAddress;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.GroupBox groupBoxCustomer;
        private System.Windows.Forms.Label lblCustomerEmail;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxProperty;
        private System.Windows.Forms.Label lblPropertyDetails;
        private System.Windows.Forms.Label lblPropertyAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBoxPayment;
        private System.Windows.Forms.Label lblDownPaymentNote;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblDownPaymentAmount;
        private System.Windows.Forms.Label lblDownPaymentDate;
        private System.Windows.Forms.Label lblDownPaymentId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}