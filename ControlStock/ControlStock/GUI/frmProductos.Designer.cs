namespace ControlStock.GUI
{
    partial class frmProductos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bORRARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bUSCARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.iMPRIMIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.dgProductos = new MetroFramework.Controls.MetroGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmnCodigoBarra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.eDITARToolStripMenuItem,
            this.bORRARToolStripMenuItem,
            this.bUSCARToolStripMenuItem,
            this.toolStripMenuItem4,
            this.toolStripMenuItem3,
            this.iMPRIMIRToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(924, 38);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(87, 34);
            this.toolStripMenuItem1.Text = "NUEVO";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // eDITARToolStripMenuItem
            // 
            this.eDITARToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.eDITARToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eDITARToolStripMenuItem.Image")));
            this.eDITARToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.eDITARToolStripMenuItem.Name = "eDITARToolStripMenuItem";
            this.eDITARToolStripMenuItem.Size = new System.Drawing.Size(84, 34);
            this.eDITARToolStripMenuItem.Text = "EDITAR";
            this.eDITARToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.eDITARToolStripMenuItem.Click += new System.EventHandler(this.eDITARToolStripMenuItem_Click);
            // 
            // bORRARToolStripMenuItem
            // 
            this.bORRARToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bORRARToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bORRARToolStripMenuItem.Image")));
            this.bORRARToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bORRARToolStripMenuItem.Name = "bORRARToolStripMenuItem";
            this.bORRARToolStripMenuItem.Size = new System.Drawing.Size(93, 34);
            this.bORRARToolStripMenuItem.Text = "BORRAR";
            this.bORRARToolStripMenuItem.Click += new System.EventHandler(this.bORRARToolStripMenuItem_Click);
            // 
            // bUSCARToolStripMenuItem
            // 
            this.bUSCARToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bUSCARToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bUSCARToolStripMenuItem.Image")));
            this.bUSCARToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bUSCARToolStripMenuItem.Name = "bUSCARToolStripMenuItem";
            this.bUSCARToolStripMenuItem.Size = new System.Drawing.Size(91, 34);
            this.bUSCARToolStripMenuItem.Text = "BUSCAR";
            this.bUSCARToolStripMenuItem.Click += new System.EventHandler(this.bUSCARToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(190, 34);
            this.toolStripMenuItem4.Text = "CARGAR TODOS LOS DATOS";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(111, 34);
            this.toolStripMenuItem3.Text = "ACTUALIZAR";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // iMPRIMIRToolStripMenuItem
            // 
            this.iMPRIMIRToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.iMPRIMIRToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("iMPRIMIRToolStripMenuItem.Image")));
            this.iMPRIMIRToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iMPRIMIRToolStripMenuItem.Name = "iMPRIMIRToolStripMenuItem";
            this.iMPRIMIRToolStripMenuItem.Size = new System.Drawing.Size(98, 34);
            this.iMPRIMIRToolStripMenuItem.Text = "IMPRIMIR";
            this.iMPRIMIRToolStripMenuItem.Click += new System.EventHandler(this.iMPRIMIRToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(90, 34);
            this.toolStripMenuItem2.Text = "CERRAR";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFiltro);
            this.panel1.Controls.Add(this.dgProductos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 474);
            this.panel1.TabIndex = 28;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(0, 2);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFiltro.Multiline = true;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(923, 36);
            this.txtFiltro.TabIndex = 2;
            this.txtFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // dgProductos
            // 
            this.dgProductos.AllowUserToAddRows = false;
            this.dgProductos.AllowUserToResizeRows = false;
            this.dgProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnCodigoBarra,
            this.cmnCategoria,
            this.cmnMarca,
            this.cmnDescripcion,
            this.cmnPrecio,
            this.cmnStock,
            this.cmnEstado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgProductos.EnableHeadersVisualStyles = false;
            this.dgProductos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgProductos.Location = new System.Drawing.Point(-8, 37);
            this.dgProductos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgProductos.MultiSelect = false;
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.ReadOnly = true;
            this.dgProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGoldenrod;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgProductos.RowTemplate.Height = 28;
            this.dgProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductos.Size = new System.Drawing.Size(933, 490);
            this.dgProductos.TabIndex = 1;
            this.dgProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgProductos_CellFormatting);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmnCodigoBarra
            // 
            this.cmnCodigoBarra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnCodigoBarra.HeaderText = "Codigo";
            this.cmnCodigoBarra.Name = "cmnCodigoBarra";
            this.cmnCodigoBarra.ReadOnly = true;
            // 
            // cmnCategoria
            // 
            this.cmnCategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnCategoria.HeaderText = "Categoria";
            this.cmnCategoria.Name = "cmnCategoria";
            this.cmnCategoria.ReadOnly = true;
            // 
            // cmnMarca
            // 
            this.cmnMarca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnMarca.HeaderText = "Marca";
            this.cmnMarca.Name = "cmnMarca";
            this.cmnMarca.ReadOnly = true;
            // 
            // cmnDescripcion
            // 
            this.cmnDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnDescripcion.HeaderText = "Descripcion";
            this.cmnDescripcion.Name = "cmnDescripcion";
            this.cmnDescripcion.ReadOnly = true;
            // 
            // cmnPrecio
            // 
            this.cmnPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cmnPrecio.HeaderText = "Precio";
            this.cmnPrecio.Name = "cmnPrecio";
            this.cmnPrecio.ReadOnly = true;
            this.cmnPrecio.Width = 75;
            // 
            // cmnStock
            // 
            this.cmnStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cmnStock.HeaderText = "Stock";
            this.cmnStock.Name = "cmnStock";
            this.cmnStock.ReadOnly = true;
            this.cmnStock.Width = 69;
            // 
            // cmnEstado
            // 
            this.cmnEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cmnEstado.HeaderText = "Estado";
            this.cmnEstado.Name = "cmnEstado";
            this.cmnEstado.ReadOnly = true;
            this.cmnEstado.Width = 77;
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmProductos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "[PRODUCTOS]";
            this.Load += new System.EventHandler(this.frmProductos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eDITARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bORRARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bUSCARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iMPRIMIRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private MetroFramework.Controls.MetroGrid dgProductos;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCodigoBarra;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnEstado;
    }
}