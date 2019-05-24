namespace ControlStock.GUI
{
    partial class frmVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentas));
            this.dgVentas = new MetroFramework.Controls.MetroGrid();
            this.cmnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPrecioU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bORRARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBuscarVtaFecha = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.iMPRIMIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tspActualizar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgVentas
            // 
            this.dgVentas.AllowUserToAddRows = false;
            this.dgVentas.AllowUserToResizeRows = false;
            this.dgVentas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGoldenrod;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnFecha,
            this.cmnCliente,
            this.cmnProducto,
            this.cmnCantidad,
            this.cmnPrecioU,
            this.cmnImporte,
            this.cmnPago,
            this.cmnDebe});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVentas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVentas.EnableHeadersVisualStyles = false;
            this.dgVentas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgVentas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgVentas.Location = new System.Drawing.Point(0, 40);
            this.dgVentas.MultiSelect = false;
            this.dgVentas.Name = "dgVentas";
            this.dgVentas.ReadOnly = true;
            this.dgVentas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGoldenrod;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgVentas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgVentas.RowTemplate.Height = 28;
            this.dgVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVentas.Size = new System.Drawing.Size(1012, 365);
            this.dgVentas.TabIndex = 31;
            // 
            // cmnFecha
            // 
            this.cmnFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cmnFecha.HeaderText = "Fecha de venta";
            this.cmnFecha.Name = "cmnFecha";
            this.cmnFecha.ReadOnly = true;
            this.cmnFecha.Width = 135;
            // 
            // cmnCliente
            // 
            this.cmnCliente.HeaderText = "Cliente";
            this.cmnCliente.Name = "cmnCliente";
            this.cmnCliente.ReadOnly = true;
            // 
            // cmnProducto
            // 
            this.cmnProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnProducto.HeaderText = "Producto";
            this.cmnProducto.Name = "cmnProducto";
            this.cmnProducto.ReadOnly = true;
            // 
            // cmnCantidad
            // 
            this.cmnCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cmnCantidad.HeaderText = "Cantidad";
            this.cmnCantidad.Name = "cmnCantidad";
            this.cmnCantidad.ReadOnly = true;
            this.cmnCantidad.Width = 93;
            // 
            // cmnPrecioU
            // 
            this.cmnPrecioU.HeaderText = "Precio Un.";
            this.cmnPrecioU.Name = "cmnPrecioU";
            this.cmnPrecioU.ReadOnly = true;
            // 
            // cmnImporte
            // 
            this.cmnImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cmnImporte.HeaderText = "Importe";
            this.cmnImporte.Name = "cmnImporte";
            this.cmnImporte.ReadOnly = true;
            this.cmnImporte.Width = 86;
            // 
            // cmnPago
            // 
            this.cmnPago.HeaderText = "Pagó";
            this.cmnPago.Name = "cmnPago";
            this.cmnPago.ReadOnly = true;
            // 
            // cmnDebe
            // 
            this.cmnDebe.HeaderText = "Debe";
            this.cmnDebe.Name = "cmnDebe";
            this.cmnDebe.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.bORRARToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolBuscarVtaFecha,
            this.tspActualizar,
            this.toolStripMenuItem4,
            this.iMPRIMIRToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1012, 40);
            this.menuStrip1.TabIndex = 30;
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
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(75, 34);
            this.toolStripMenuItem3.Text = "CAJA";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolBuscarVtaFecha
            // 
            this.toolBuscarVtaFecha.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolBuscarVtaFecha.Image = ((System.Drawing.Image)(resources.GetObject("toolBuscarVtaFecha.Image")));
            this.toolBuscarVtaFecha.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBuscarVtaFecha.Name = "toolBuscarVtaFecha";
            this.toolBuscarVtaFecha.Size = new System.Drawing.Size(122, 34);
            this.toolBuscarVtaFecha.Text = "VTAS. X FECHA";
            this.toolBuscarVtaFecha.Click += new System.EventHandler(this.toolBuscarVtaFecha_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(96, 34);
            this.toolStripMenuItem4.Text = "RANKING";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
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
            // tspActualizar
            // 
            this.tspActualizar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tspActualizar.Image = ((System.Drawing.Image)(resources.GetObject("tspActualizar.Image")));
            this.tspActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspActualizar.Name = "tspActualizar";
            this.tspActualizar.Size = new System.Drawing.Size(111, 34);
            this.tspActualizar.Text = "ACTUALIZAR";
            this.tspActualizar.Click += new System.EventHandler(this.tspActualizar_Click);
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 405);
            this.Controls.Add(this.dgVentas);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVentas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "k";
            this.Load += new System.EventHandler(this.frmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVentas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid dgVentas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bORRARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem iMPRIMIRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPrecioU;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDebe;
        private System.Windows.Forms.ToolStripMenuItem toolBuscarVtaFecha;
        private System.Windows.Forms.ToolStripMenuItem tspActualizar;
    }
}