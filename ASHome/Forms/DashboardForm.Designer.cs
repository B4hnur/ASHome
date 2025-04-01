namespace ASHome.Forms
{
    partial class DashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.lblMonthlyProfit = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lblMonthlyExpenses = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lblTotalExpenses = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblMonthlyRevenue = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblNewCustomers = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblRecentContracts = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTotalContracts = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblAvailableProperties = new System.Windows.Forms.Label();
            this.lblAvailablePropertiesText = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotalProperties = new System.Windows.Forms.Label();
            this.lblTotalPropertiesText = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.chartPropertyStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel17 = new System.Windows.Forms.Panel();
            this.listRecentActivities = new System.Windows.Forms.ListView();
            this.label23 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPropertyStatus)).BeginInit();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.panel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 60);
            this.panel1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRefresh.Location = new System.Drawing.Point(1157, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Yenilə";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(16, 19);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(278, 24);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Xoş gəlmisiniz, İstifadəçi adı!";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1264, 111);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.panel15, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel14, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel13, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel12, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1244, 91);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.panel15.Controls.Add(this.lblMonthlyProfit);
            this.panel15.Controls.Add(this.label19);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(1038, 48);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(203, 40);
            this.panel15.TabIndex = 11;
            // 
            // lblMonthlyProfit
            // 
            this.lblMonthlyProfit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonthlyProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlyProfit.ForeColor = System.Drawing.Color.Green;
            this.lblMonthlyProfit.Location = new System.Drawing.Point(103, 13);
            this.lblMonthlyProfit.Name = "lblMonthlyProfit";
            this.lblMonthlyProfit.Size = new System.Drawing.Size(97, 15);
            this.lblMonthlyProfit.TabIndex = 1;
            this.lblMonthlyProfit.Text = "0.00 AZN";
            this.lblMonthlyProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Aylıq mənfəət:";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.panel14.Controls.Add(this.lblTotalProfit);
            this.panel14.Controls.Add(this.label17);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(831, 48);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(201, 40);
            this.panel14.TabIndex = 10;
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProfit.ForeColor = System.Drawing.Color.Green;
            this.lblTotalProfit.Location = new System.Drawing.Point(101, 13);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(97, 15);
            this.lblTotalProfit.TabIndex = 1;
            this.lblTotalProfit.Text = "0.00 AZN";
            this.lblTotalProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Ümumi mənfəət:";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel13.Controls.Add(this.lblMonthlyExpenses);
            this.panel13.Controls.Add(this.label15);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(624, 48);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(201, 40);
            this.panel13.TabIndex = 9;
            // 
            // lblMonthlyExpenses
            // 
            this.lblMonthlyExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonthlyExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlyExpenses.ForeColor = System.Drawing.Color.Red;
            this.lblMonthlyExpenses.Location = new System.Drawing.Point(101, 13);
            this.lblMonthlyExpenses.Name = "lblMonthlyExpenses";
            this.lblMonthlyExpenses.Size = new System.Drawing.Size(97, 15);
            this.lblMonthlyExpenses.TabIndex = 1;
            this.lblMonthlyExpenses.Text = "0.00 AZN";
            this.lblMonthlyExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Aylıq xərclər:";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel12.Controls.Add(this.lblTotalExpenses);
            this.panel12.Controls.Add(this.label13);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(417, 48);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(201, 40);
            this.panel12.TabIndex = 8;
            // 
            // lblTotalExpenses
            // 
            this.lblTotalExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpenses.ForeColor = System.Drawing.Color.Red;
            this.lblTotalExpenses.Location = new System.Drawing.Point(101, 13);
            this.lblTotalExpenses.Name = "lblTotalExpenses";
            this.lblTotalExpenses.Size = new System.Drawing.Size(97, 15);
            this.lblTotalExpenses.TabIndex = 1;
            this.lblTotalExpenses.Text = "0.00 AZN";
            this.lblTotalExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Ümumi xərclər:";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(255)))), ((int)(((byte)(242)))));
            this.panel11.Controls.Add(this.lblMonthlyRevenue);
            this.panel11.Controls.Add(this.label11);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(210, 48);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(201, 40);
            this.panel11.TabIndex = 7;
            // 
            // lblMonthlyRevenue
            // 
            this.lblMonthlyRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonthlyRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlyRevenue.ForeColor = System.Drawing.Color.Green;
            this.lblMonthlyRevenue.Location = new System.Drawing.Point(101, 13);
            this.lblMonthlyRevenue.Name = "lblMonthlyRevenue";
            this.lblMonthlyRevenue.Size = new System.Drawing.Size(97, 15);
            this.lblMonthlyRevenue.TabIndex = 1;
            this.lblMonthlyRevenue.Text = "0.00 AZN";
            this.lblMonthlyRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Aylıq gəlir:";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(255)))), ((int)(((byte)(242)))));
            this.panel10.Controls.Add(this.lblTotalRevenue);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(3, 48);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(201, 40);
            this.panel10.TabIndex = 6;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.Green;
            this.lblTotalRevenue.Location = new System.Drawing.Point(101, 13);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(97, 15);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "0.00 AZN";
            this.lblTotalRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Ümumi gəlir:";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.panel9.Controls.Add(this.lblNewCustomers);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(1038, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(203, 39);
            this.panel9.TabIndex = 5;
            // 
            // lblNewCustomers
            // 
            this.lblNewCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNewCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblNewCustomers.Location = new System.Drawing.Point(103, 13);
            this.lblNewCustomers.Name = "lblNewCustomers";
            this.lblNewCustomers.Size = new System.Drawing.Size(97, 15);
            this.lblNewCustomers.TabIndex = 1;
            this.lblNewCustomers.Text = "0";
            this.lblNewCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Yeni müştərilər:";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.panel8.Controls.Add(this.lblTotalCustomers);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(831, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(201, 39);
            this.panel8.TabIndex = 4;
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotalCustomers.Location = new System.Drawing.Point(101, 13);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(97, 15);
            this.lblTotalCustomers.TabIndex = 1;
            this.lblTotalCustomers.Text = "0";
            this.lblTotalCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ümumi müştərilər:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.panel7.Controls.Add(this.lblRecentContracts);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(624, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(201, 39);
            this.panel7.TabIndex = 3;
            // 
            // lblRecentContracts
            // 
            this.lblRecentContracts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecentContracts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentContracts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblRecentContracts.Location = new System.Drawing.Point(101, 13);
            this.lblRecentContracts.Name = "lblRecentContracts";
            this.lblRecentContracts.Size = new System.Drawing.Size(97, 15);
            this.lblRecentContracts.TabIndex = 1;
            this.lblRecentContracts.Text = "0";
            this.lblRecentContracts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Yeni müqavilələr:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.panel6.Controls.Add(this.lblTotalContracts);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(417, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(201, 39);
            this.panel6.TabIndex = 2;
            // 
            // lblTotalContracts
            // 
            this.lblTotalContracts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalContracts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalContracts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotalContracts.Location = new System.Drawing.Point(101, 13);
            this.lblTotalContracts.Name = "lblTotalContracts";
            this.lblTotalContracts.Size = new System.Drawing.Size(97, 15);
            this.lblTotalContracts.TabIndex = 1;
            this.lblTotalContracts.Text = "0";
            this.lblTotalContracts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ümumi müqavilələr:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(242)))));
            this.panel5.Controls.Add(this.lblAvailableProperties);
            this.panel5.Controls.Add(this.lblAvailablePropertiesText);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(210, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(201, 39);
            this.panel5.TabIndex = 1;
            // 
            // lblAvailableProperties
            // 
            this.lblAvailableProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailableProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableProperties.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblAvailableProperties.Location = new System.Drawing.Point(101, 13);
            this.lblAvailableProperties.Name = "lblAvailableProperties";
            this.lblAvailableProperties.Size = new System.Drawing.Size(97, 15);
            this.lblAvailableProperties.TabIndex = 1;
            this.lblAvailableProperties.Text = "0";
            this.lblAvailableProperties.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAvailablePropertiesText
            // 
            this.lblAvailablePropertiesText.AutoSize = true;
            this.lblAvailablePropertiesText.Location = new System.Drawing.Point(3, 13);
            this.lblAvailablePropertiesText.Name = "lblAvailablePropertiesText";
            this.lblAvailablePropertiesText.Size = new System.Drawing.Size(86, 13);
            this.lblAvailablePropertiesText.TabIndex = 0;
            this.lblAvailablePropertiesText.Text = "Mövcud əmlak:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(242)))));
            this.panel4.Controls.Add(this.lblTotalProperties);
            this.panel4.Controls.Add(this.lblTotalPropertiesText);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(201, 39);
            this.panel4.TabIndex = 0;
            // 
            // lblTotalProperties
            // 
            this.lblTotalProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProperties.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotalProperties.Location = new System.Drawing.Point(101, 13);
            this.lblTotalProperties.Name = "lblTotalProperties";
            this.lblTotalProperties.Size = new System.Drawing.Size(97, 15);
            this.lblTotalProperties.TabIndex = 1;
            this.lblTotalProperties.Text = "0";
            this.lblTotalProperties.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalPropertiesText
            // 
            this.lblTotalPropertiesText.AutoSize = true;
            this.lblTotalPropertiesText.Location = new System.Drawing.Point(3, 13);
            this.lblTotalPropertiesText.Name = "lblTotalPropertiesText";
            this.lblTotalPropertiesText.Size = new System.Drawing.Size(81, 13);
            this.lblTotalPropertiesText.TabIndex = 0;
            this.lblTotalPropertiesText.Text = "Ümumi əmlak:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.chartPropertyStatus);
            this.panel3.Location = new System.Drawing.Point(12, 177);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 325);
            this.panel3.TabIndex = 2;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label22.Location = new System.Drawing.Point(8, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(111, 16);
            this.label22.TabIndex = 1;
            this.label22.Text = "Əmlak Statusu";
            // 
            // chartPropertyStatus
            // 
            this.chartPropertyStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartPropertyStatus.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPropertyStatus.Legends.Add(legend1);
            this.chartPropertyStatus.Location = new System.Drawing.Point(11, 29);
            this.chartPropertyStatus.Name = "chartPropertyStatus";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Status";
            this.chartPropertyStatus.Series.Add(series1);
            this.chartPropertyStatus.Size = new System.Drawing.Size(366, 284);
            this.chartPropertyStatus.TabIndex = 0;
            this.chartPropertyStatus.Text = "chart1";
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.Controls.Add(this.label21);
            this.panel16.Controls.Add(this.chartRevenue);
            this.panel16.Location = new System.Drawing.Point(408, 177);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(844, 325);
            this.panel16.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label21.Location = new System.Drawing.Point(13, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(142, 16);
            this.label21.TabIndex = 1;
            this.label21.Text = "Gəlirlər və Xərclər";
            // 
            // chartRevenue
            // 
            this.chartRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend2);
            this.chartRevenue.Location = new System.Drawing.Point(16, 29);
            this.chartRevenue.Name = "chartRevenue";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Gəlirlər";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Xərclər";
            this.chartRevenue.Series.Add(series2);
            this.chartRevenue.Series.Add(series3);
            this.chartRevenue.Size = new System.Drawing.Size(812, 284);
            this.chartRevenue.TabIndex = 0;
            this.chartRevenue.Text = "chart1";
            // 
            // panel17
            // 
            this.panel17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel17.Controls.Add(this.listRecentActivities);
            this.panel17.Controls.Add(this.label23);
            this.panel17.Location = new System.Drawing.Point(12, 508);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1240, 141);
            this.panel17.TabIndex = 4;
            // 
            // listRecentActivities
            // 
            this.listRecentActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listRecentActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listRecentActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listRecentActivities.HideSelection = false;
            this.listRecentActivities.Location = new System.Drawing.Point(11, 29);
            this.listRecentActivities.Name = "listRecentActivities";
            this.listRecentActivities.Size = new System.Drawing.Size(1217, 109);
            this.listRecentActivities.TabIndex = 2;
            this.listRecentActivities.UseCompatibleStateImageBehavior = false;
            this.listRecentActivities.View = System.Windows.Forms.View.List;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label23.Location = new System.Drawing.Point(8, 10);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(146, 16);
            this.label23.TabIndex = 1;
            this.label23.Text = "Son Fəaliyyətlər";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 661);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPropertyStatus)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label lblMonthlyProfit;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lblMonthlyExpenses;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblMonthlyRevenue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblNewCustomers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblRecentContracts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblTotalContracts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblAvailableProperties;
        private System.Windows.Forms.Label lblAvailablePropertiesText;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTotalProperties;
        private System.Windows.Forms.Label lblTotalPropertiesText;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPropertyStatus;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.ListView listRecentActivities;
        private System.Windows.Forms.Label label23;
    }
}
