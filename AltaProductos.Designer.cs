
namespace inventarioIMG
{
    partial class AltaProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaProductos));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textnombre = new System.Windows.Forms.TextBox();
            this.textprecio = new System.Windows.Forms.TextBox();
            this.textcategoria = new System.Windows.Forms.TextBox();
            this.textcantidad = new System.Windows.Forms.TextBox();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.groupAlta = new System.Windows.Forms.GroupBox();
            this.groupMod = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbModProd = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textModStock = new System.Windows.Forms.TextBox();
            this.textModCategoria = new System.Windows.Forms.TextBox();
            this.textModPrecio = new System.Windows.Forms.TextBox();
            this.textModProd = new System.Windows.Forms.TextBox();
            this.groupEliminar = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbeliminarprod = new System.Windows.Forms.ComboBox();
            this.groupBuscar = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbBuscarProducto = new System.Windows.Forms.ComboBox();
            this.cmbBuscarProd = new System.Windows.Forms.ComboBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupAlta.SuspendLayout();
            this.groupMod.SuspendLayout();
            this.groupEliminar.SuspendLayout();
            this.groupBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "nombre producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "precio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "categoria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "cantidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 15);
            this.label5.TabIndex = 4;
            // 
            // textnombre
            // 
            this.textnombre.Location = new System.Drawing.Point(170, 28);
            this.textnombre.Name = "textnombre";
            this.textnombre.Size = new System.Drawing.Size(106, 23);
            this.textnombre.TabIndex = 5;
            // 
            // textprecio
            // 
            this.textprecio.Location = new System.Drawing.Point(170, 57);
            this.textprecio.Name = "textprecio";
            this.textprecio.Size = new System.Drawing.Size(106, 23);
            this.textprecio.TabIndex = 6;
            this.textprecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textprecio_KeyPress);
            // 
            // textcategoria
            // 
            this.textcategoria.Location = new System.Drawing.Point(442, 28);
            this.textcategoria.Name = "textcategoria";
            this.textcategoria.Size = new System.Drawing.Size(106, 23);
            this.textcategoria.TabIndex = 7;
            // 
            // textcantidad
            // 
            this.textcantidad.Location = new System.Drawing.Point(442, 57);
            this.textcantidad.Name = "textcantidad";
            this.textcantidad.Size = new System.Drawing.Size(106, 23);
            this.textcantidad.TabIndex = 8;
            this.textcantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textcantidad_KeyPress);
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.Width = 150;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Precio,
            this.Cantidad});
            this.dataGridView1.Location = new System.Drawing.Point(75, 173);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(604, 267);
            this.dataGridView1.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.toolStripButton1,
            this.cutToolStripButton,
            this.toolStripSeparator,
            this.saveToolStripButton,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(747, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&Alta de Producto";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Editar Producto";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::inventarioIMG.Properties.Resources.loupe_78956;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Tag = "Buscar Productos";
            this.toolStripButton1.Text = "Buscar Productos";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "Eliminar Producto";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Guardar";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::inventarioIMG.Properties.Resources.file_type_excel_icon_130611;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Exportar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // groupAlta
            // 
            this.groupAlta.Controls.Add(this.textnombre);
            this.groupAlta.Controls.Add(this.label1);
            this.groupAlta.Controls.Add(this.label2);
            this.groupAlta.Controls.Add(this.textcantidad);
            this.groupAlta.Controls.Add(this.label3);
            this.groupAlta.Controls.Add(this.textcategoria);
            this.groupAlta.Controls.Add(this.label4);
            this.groupAlta.Controls.Add(this.textprecio);
            this.groupAlta.Location = new System.Drawing.Point(75, 45);
            this.groupAlta.Name = "groupAlta";
            this.groupAlta.Size = new System.Drawing.Size(588, 99);
            this.groupAlta.TabIndex = 13;
            this.groupAlta.TabStop = false;
            this.groupAlta.Text = "Alta de Productos";
            this.groupAlta.Visible = false;
            this.groupAlta.Enter += new System.EventHandler(this.groupAlta_Enter);
            // 
            // groupMod
            // 
            this.groupMod.Controls.Add(this.label10);
            this.groupMod.Controls.Add(this.cmbModProd);
            this.groupMod.Controls.Add(this.label9);
            this.groupMod.Controls.Add(this.label8);
            this.groupMod.Controls.Add(this.label7);
            this.groupMod.Controls.Add(this.label6);
            this.groupMod.Controls.Add(this.textModStock);
            this.groupMod.Controls.Add(this.textModCategoria);
            this.groupMod.Controls.Add(this.textModPrecio);
            this.groupMod.Controls.Add(this.textModProd);
            this.groupMod.Location = new System.Drawing.Point(75, 28);
            this.groupMod.Name = "groupMod";
            this.groupMod.Size = new System.Drawing.Size(605, 121);
            this.groupMod.TabIndex = 14;
            this.groupMod.TabStop = false;
            this.groupMod.Text = "Modificar Productos";
            this.groupMod.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "Nombre Producto";
            // 
            // cmbModProd
            // 
            this.cmbModProd.FormattingEnabled = true;
            this.cmbModProd.Location = new System.Drawing.Point(144, 22);
            this.cmbModProd.Name = "cmbModProd";
            this.cmbModProd.Size = new System.Drawing.Size(121, 23);
            this.cmbModProd.TabIndex = 15;
            this.cmbModProd.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(285, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Stock";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(285, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Categoria";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Precio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Nombre Producto";
            // 
            // textModStock
            // 
            this.textModStock.Enabled = false;
            this.textModStock.Location = new System.Drawing.Point(429, 81);
            this.textModStock.Name = "textModStock";
            this.textModStock.Size = new System.Drawing.Size(100, 23);
            this.textModStock.TabIndex = 3;
            // 
            // textModCategoria
            // 
            this.textModCategoria.Location = new System.Drawing.Point(429, 52);
            this.textModCategoria.Name = "textModCategoria";
            this.textModCategoria.Size = new System.Drawing.Size(100, 23);
            this.textModCategoria.TabIndex = 2;
            // 
            // textModPrecio
            // 
            this.textModPrecio.Location = new System.Drawing.Point(157, 81);
            this.textModPrecio.Name = "textModPrecio";
            this.textModPrecio.Size = new System.Drawing.Size(100, 23);
            this.textModPrecio.TabIndex = 1;
            this.textModPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textModPrecio_KeyPress);
            // 
            // textModProd
            // 
            this.textModProd.Location = new System.Drawing.Point(157, 52);
            this.textModProd.Name = "textModProd";
            this.textModProd.Size = new System.Drawing.Size(100, 23);
            this.textModProd.TabIndex = 0;
            // 
            // groupEliminar
            // 
            this.groupEliminar.Controls.Add(this.label11);
            this.groupEliminar.Controls.Add(this.cmbeliminarprod);
            this.groupEliminar.Location = new System.Drawing.Point(75, 45);
            this.groupEliminar.Name = "groupEliminar";
            this.groupEliminar.Size = new System.Drawing.Size(605, 99);
            this.groupEliminar.TabIndex = 15;
            this.groupEliminar.TabStop = false;
            this.groupEliminar.Text = "Eliminar Productos";
            this.groupEliminar.Visible = false;
            this.groupEliminar.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "Producto";
            // 
            // cmbeliminarprod
            // 
            this.cmbeliminarprod.FormattingEnabled = true;
            this.cmbeliminarprod.Location = new System.Drawing.Point(102, 32);
            this.cmbeliminarprod.Name = "cmbeliminarprod";
            this.cmbeliminarprod.Size = new System.Drawing.Size(121, 23);
            this.cmbeliminarprod.TabIndex = 0;
            this.cmbeliminarprod.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBuscar
            // 
            this.groupBuscar.Controls.Add(this.label13);
            this.groupBuscar.Controls.Add(this.label12);
            this.groupBuscar.Controls.Add(this.cmbBuscarProducto);
            this.groupBuscar.Controls.Add(this.cmbBuscarProd);
            this.groupBuscar.Location = new System.Drawing.Point(74, 45);
            this.groupBuscar.Name = "groupBuscar";
            this.groupBuscar.Size = new System.Drawing.Size(605, 104);
            this.groupBuscar.TabIndex = 16;
            this.groupBuscar.TabStop = false;
            this.groupBuscar.Text = "Buscar Productos";
            this.groupBuscar.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 15);
            this.label13.TabIndex = 3;
            this.label13.Text = "Categoria";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(277, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Producto";
            // 
            // cmbBuscarProducto
            // 
            this.cmbBuscarProducto.FormattingEnabled = true;
            this.cmbBuscarProducto.Location = new System.Drawing.Point(361, 41);
            this.cmbBuscarProducto.Name = "cmbBuscarProducto";
            this.cmbBuscarProducto.Size = new System.Drawing.Size(121, 23);
            this.cmbBuscarProducto.TabIndex = 1;
            this.cmbBuscarProducto.TextChanged += new System.EventHandler(this.cmbBuscarProducto_TextChanged);
            // 
            // cmbBuscarProd
            // 
            this.cmbBuscarProd.FormattingEnabled = true;
            this.cmbBuscarProd.Location = new System.Drawing.Point(102, 41);
            this.cmbBuscarProd.Name = "cmbBuscarProd";
            this.cmbBuscarProd.Size = new System.Drawing.Size(121, 23);
            this.cmbBuscarProd.TabIndex = 0;
            this.cmbBuscarProd.TextChanged += new System.EventHandler(this.cmbBuscarProd_TextChanged);
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.BackColor = System.Drawing.Color.Transparent;
            this.labelUsuario.Location = new System.Drawing.Point(602, 0);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(16, 15);
            this.labelUsuario.TabIndex = 17;
            this.labelUsuario.Text = "...";
            // 
            // AltaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(747, 513);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.groupBuscar);
            this.Controls.Add(this.groupEliminar);
            this.Controls.Add(this.groupMod);
            this.Controls.Add(this.groupAlta);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.Name = "AltaProductos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.AltaProductos_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupAlta.ResumeLayout(false);
            this.groupAlta.PerformLayout();
            this.groupMod.ResumeLayout(false);
            this.groupMod.PerformLayout();
            this.groupEliminar.ResumeLayout(false);
            this.groupEliminar.PerformLayout();
            this.groupBuscar.ResumeLayout(false);
            this.groupBuscar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textnombre;
        private System.Windows.Forms.TextBox textprecio;
        private System.Windows.Forms.TextBox textcategoria;
        private System.Windows.Forms.TextBox textcantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.GroupBox groupAlta;
        private System.Windows.Forms.GroupBox groupMod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textModStock;
        private System.Windows.Forms.TextBox textModCategoria;
        private System.Windows.Forms.TextBox textModPrecio;
        private System.Windows.Forms.TextBox textModProd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbModProd;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.GroupBox groupEliminar;
        private System.Windows.Forms.ComboBox cmbeliminarprod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox groupBuscar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbBuscarProducto;
        private System.Windows.Forms.ComboBox cmbBuscarProd;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label labelUsuario;
    }
}