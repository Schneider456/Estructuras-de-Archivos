namespace Diccionario_de_datos
{
    partial class Form1
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEntidad = new System.Windows.Forms.TabPage();
            this.EliminaEnt = new System.Windows.Forms.Button();
            this.ModificaEnt = new System.Windows.Forms.Button();
            this.dgEntidades = new System.Windows.Forms.DataGridView();
            this.NombreEntidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEntidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DAtributos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDatos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DSigEntidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregaEnt = new System.Windows.Forms.Button();
            this.txtBIngNoment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNomEntActual = new System.Windows.Forms.ComboBox();
            this.tabAtributo = new System.Windows.Forms.TabPage();
            this.dgAtributos = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoIndice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DSA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminaAtr = new System.Windows.Forms.Button();
            this.cmbtipoIndice = new System.Windows.Forms.ComboBox();
            this.btnModificaAtr = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAltaAtr = new System.Windows.Forms.Button();
            this.txtBoxLong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxNomAtribut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPrimariKey = new System.Windows.Forms.TabPage();
            this.dgPrimaryKey = new System.Windows.Forms.DataGridView();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabForeanKey = new System.Windows.Forms.TabPage();
            this.dgForeanKey = new System.Windows.Forms.DataGridView();
            this.ClaveForanea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dirección10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabRegistros = new System.Windows.Forms.TabPage();
            this.EliminaRegistro = new System.Windows.Forms.Button();
            this.Modifica = new System.Windows.Forms.Button();
            this.NewAdd = new System.Windows.Forms.Button();
            this.GeneraReg = new System.Windows.Forms.Button();
            this.dgRegistros = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgÁrbol = new System.Windows.Forms.DataGridView();
            this.DirNodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoNodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ap1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CB1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ap2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CB2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ap3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CB3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ap4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CB4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ap5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabEntidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEntidades)).BeginInit();
            this.tabAtributo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtributos)).BeginInit();
            this.tabPrimariKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrimaryKey)).BeginInit();
            this.tabForeanKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgForeanKey)).BeginInit();
            this.tabRegistros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRegistros)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgÁrbol)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem1
            // 
            this.archivoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem1,
            this.nuevoToolStripMenuItem1,
            this.cerrarToolStripMenuItem});
            this.archivoToolStripMenuItem1.Name = "archivoToolStripMenuItem1";
            this.archivoToolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem1.Text = "Archivo";
            // 
            // abrirToolStripMenuItem1
            // 
            this.abrirToolStripMenuItem1.Name = "abrirToolStripMenuItem1";
            this.abrirToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.abrirToolStripMenuItem1.Text = "Abrir";
            this.abrirToolStripMenuItem1.Click += new System.EventHandler(this.abrirToolStripMenuItem1_Click);
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.nuevoToolStripMenuItem1.Text = "Nuevo";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoToolStripMenuItem1_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEntidad);
            this.tabControl1.Controls.Add(this.tabAtributo);
            this.tabControl1.Controls.Add(this.tabPrimariKey);
            this.tabControl1.Controls.Add(this.tabForeanKey);
            this.tabControl1.Controls.Add(this.tabRegistros);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 488);
            this.tabControl1.TabIndex = 11;
            // 
            // tabEntidad
            // 
            this.tabEntidad.Controls.Add(this.EliminaEnt);
            this.tabEntidad.Controls.Add(this.ModificaEnt);
            this.tabEntidad.Controls.Add(this.dgEntidades);
            this.tabEntidad.Controls.Add(this.btnAgregaEnt);
            this.tabEntidad.Controls.Add(this.txtBIngNoment);
            this.tabEntidad.Controls.Add(this.label2);
            this.tabEntidad.Controls.Add(this.label1);
            this.tabEntidad.Controls.Add(this.cmbNomEntActual);
            this.tabEntidad.Location = new System.Drawing.Point(4, 22);
            this.tabEntidad.Name = "tabEntidad";
            this.tabEntidad.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntidad.Size = new System.Drawing.Size(760, 462);
            this.tabEntidad.TabIndex = 0;
            this.tabEntidad.Text = "Entidad";
            this.tabEntidad.UseVisualStyleBackColor = true;
            // 
            // EliminaEnt
            // 
            this.EliminaEnt.Location = new System.Drawing.Point(464, 24);
            this.EliminaEnt.Name = "EliminaEnt";
            this.EliminaEnt.Size = new System.Drawing.Size(75, 23);
            this.EliminaEnt.TabIndex = 27;
            this.EliminaEnt.Text = "Elimina";
            this.EliminaEnt.UseVisualStyleBackColor = true;
            this.EliminaEnt.Click += new System.EventHandler(this.EliminaEnt_Click);
            // 
            // ModificaEnt
            // 
            this.ModificaEnt.Location = new System.Drawing.Point(365, 24);
            this.ModificaEnt.Name = "ModificaEnt";
            this.ModificaEnt.Size = new System.Drawing.Size(75, 23);
            this.ModificaEnt.TabIndex = 26;
            this.ModificaEnt.Text = "Modifica";
            this.ModificaEnt.UseVisualStyleBackColor = true;
            this.ModificaEnt.Click += new System.EventHandler(this.ModificaEnt_Click);
            // 
            // dgEntidades
            // 
            this.dgEntidades.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgEntidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEntidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreEntidad,
            this.DEntidad,
            this.DAtributos,
            this.DDatos,
            this.DSigEntidad});
            this.dgEntidades.Location = new System.Drawing.Point(22, 93);
            this.dgEntidades.Name = "dgEntidades";
            this.dgEntidades.ReadOnly = true;
            this.dgEntidades.Size = new System.Drawing.Size(545, 290);
            this.dgEntidades.TabIndex = 25;
            this.dgEntidades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEntidades_CellClick);
            this.dgEntidades.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEntidades_CellDoubleClick);
            // 
            // NombreEntidad
            // 
            this.NombreEntidad.HeaderText = "Nombre";
            this.NombreEntidad.Name = "NombreEntidad";
            this.NombreEntidad.ReadOnly = true;
            // 
            // DEntidad
            // 
            this.DEntidad.HeaderText = "DEntidad";
            this.DEntidad.Name = "DEntidad";
            this.DEntidad.ReadOnly = true;
            // 
            // DAtributos
            // 
            this.DAtributos.HeaderText = "DAtributos";
            this.DAtributos.Name = "DAtributos";
            this.DAtributos.ReadOnly = true;
            // 
            // DDatos
            // 
            this.DDatos.HeaderText = "DDatos";
            this.DDatos.Name = "DDatos";
            this.DDatos.ReadOnly = true;
            // 
            // DSigEntidad
            // 
            this.DSigEntidad.HeaderText = "DSigEntidad";
            this.DSigEntidad.Name = "DSigEntidad";
            this.DSigEntidad.ReadOnly = true;
            // 
            // btnAgregaEnt
            // 
            this.btnAgregaEnt.Location = new System.Drawing.Point(264, 24);
            this.btnAgregaEnt.Name = "btnAgregaEnt";
            this.btnAgregaEnt.Size = new System.Drawing.Size(75, 23);
            this.btnAgregaEnt.TabIndex = 12;
            this.btnAgregaEnt.Text = "Agrega";
            this.btnAgregaEnt.UseVisualStyleBackColor = true;
            this.btnAgregaEnt.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtBIngNoment
            // 
            this.txtBIngNoment.Location = new System.Drawing.Point(73, 24);
            this.txtBIngNoment.MaxLength = 30;
            this.txtBIngNoment.Name = "txtBIngNoment";
            this.txtBIngNoment.Size = new System.Drawing.Size(170, 20);
            this.txtBIngNoment.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Entidad";
            // 
            // cmbNomEntActual
            // 
            this.cmbNomEntActual.FormattingEnabled = true;
            this.cmbNomEntActual.Location = new System.Drawing.Point(73, 53);
            this.cmbNomEntActual.Name = "cmbNomEntActual";
            this.cmbNomEntActual.Size = new System.Drawing.Size(170, 21);
            this.cmbNomEntActual.TabIndex = 9;
            this.cmbNomEntActual.SelectedIndexChanged += new System.EventHandler(this.cmbBoxListValues_SelectedIndexChanged);
            // 
            // tabAtributo
            // 
            this.tabAtributo.Controls.Add(this.dgAtributos);
            this.tabAtributo.Controls.Add(this.btnEliminaAtr);
            this.tabAtributo.Controls.Add(this.cmbtipoIndice);
            this.tabAtributo.Controls.Add(this.btnModificaAtr);
            this.tabAtributo.Controls.Add(this.label6);
            this.tabAtributo.Controls.Add(this.btnAltaAtr);
            this.tabAtributo.Controls.Add(this.txtBoxLong);
            this.tabAtributo.Controls.Add(this.label5);
            this.tabAtributo.Controls.Add(this.cmbTipo);
            this.tabAtributo.Controls.Add(this.label4);
            this.tabAtributo.Controls.Add(this.txtBoxNomAtribut);
            this.tabAtributo.Controls.Add(this.label3);
            this.tabAtributo.Location = new System.Drawing.Point(4, 22);
            this.tabAtributo.Name = "tabAtributo";
            this.tabAtributo.Padding = new System.Windows.Forms.Padding(3);
            this.tabAtributo.Size = new System.Drawing.Size(760, 462);
            this.tabAtributo.TabIndex = 1;
            this.tabAtributo.Text = "Atributo";
            this.tabAtributo.UseVisualStyleBackColor = true;
            // 
            // dgAtributos
            // 
            this.dgAtributos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAtributos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Tipo,
            this.Longitud,
            this.TipoIndice,
            this.DA,
            this.DI,
            this.DSA});
            this.dgAtributos.Location = new System.Drawing.Point(12, 95);
            this.dgAtributos.Name = "dgAtributos";
            this.dgAtributos.ReadOnly = true;
            this.dgAtributos.Size = new System.Drawing.Size(739, 361);
            this.dgAtributos.TabIndex = 24;
            this.dgAtributos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAtributos_CellClick);
            this.dgAtributos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAtributos_CellDoubleClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Longitud
            // 
            this.Longitud.HeaderText = "Longitud";
            this.Longitud.Name = "Longitud";
            this.Longitud.ReadOnly = true;
            // 
            // TipoIndice
            // 
            this.TipoIndice.HeaderText = "TipoIndice";
            this.TipoIndice.Name = "TipoIndice";
            this.TipoIndice.ReadOnly = true;
            // 
            // DA
            // 
            this.DA.HeaderText = "DA";
            this.DA.Name = "DA";
            this.DA.ReadOnly = true;
            // 
            // DI
            // 
            this.DI.HeaderText = "DI";
            this.DI.Name = "DI";
            this.DI.ReadOnly = true;
            // 
            // DSA
            // 
            this.DSA.HeaderText = "DSA";
            this.DSA.Name = "DSA";
            this.DSA.ReadOnly = true;
            // 
            // btnEliminaAtr
            // 
            this.btnEliminaAtr.Enabled = false;
            this.btnEliminaAtr.Location = new System.Drawing.Point(584, 30);
            this.btnEliminaAtr.Name = "btnEliminaAtr";
            this.btnEliminaAtr.Size = new System.Drawing.Size(75, 23);
            this.btnEliminaAtr.TabIndex = 22;
            this.btnEliminaAtr.Text = "Elimina";
            this.btnEliminaAtr.UseVisualStyleBackColor = true;
            this.btnEliminaAtr.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // cmbtipoIndice
            // 
            this.cmbtipoIndice.Enabled = false;
            this.cmbtipoIndice.FormattingEnabled = true;
            this.cmbtipoIndice.Location = new System.Drawing.Point(75, 52);
            this.cmbtipoIndice.Name = "cmbtipoIndice";
            this.cmbtipoIndice.Size = new System.Drawing.Size(83, 21);
            this.cmbtipoIndice.Sorted = true;
            this.cmbtipoIndice.TabIndex = 20;
            // 
            // btnModificaAtr
            // 
            this.btnModificaAtr.Enabled = false;
            this.btnModificaAtr.Location = new System.Drawing.Point(487, 30);
            this.btnModificaAtr.Name = "btnModificaAtr";
            this.btnModificaAtr.Size = new System.Drawing.Size(75, 23);
            this.btnModificaAtr.TabIndex = 23;
            this.btnModificaAtr.Text = "Modifica";
            this.btnModificaAtr.UseVisualStyleBackColor = true;
            this.btnModificaAtr.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tipo Indice";
            // 
            // btnAltaAtr
            // 
            this.btnAltaAtr.Enabled = false;
            this.btnAltaAtr.Location = new System.Drawing.Point(391, 30);
            this.btnAltaAtr.Name = "btnAltaAtr";
            this.btnAltaAtr.Size = new System.Drawing.Size(75, 23);
            this.btnAltaAtr.TabIndex = 21;
            this.btnAltaAtr.Text = "Alta";
            this.btnAltaAtr.UseVisualStyleBackColor = true;
            this.btnAltaAtr.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // txtBoxLong
            // 
            this.txtBoxLong.Enabled = false;
            this.txtBoxLong.Location = new System.Drawing.Point(255, 53);
            this.txtBoxLong.Name = "txtBoxLong";
            this.txtBoxLong.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLong.TabIndex = 18;
            this.txtBoxLong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxLong_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Longitud";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Enabled = false;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(234, 15);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 16;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tipo";
            // 
            // txtBoxNomAtribut
            // 
            this.txtBoxNomAtribut.Enabled = false;
            this.txtBoxNomAtribut.Location = new System.Drawing.Point(58, 15);
            this.txtBoxNomAtribut.MaxLength = 30;
            this.txtBoxNomAtribut.Name = "txtBoxNomAtribut";
            this.txtBoxNomAtribut.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNomAtribut.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nombre";
            // 
            // tabPrimariKey
            // 
            this.tabPrimariKey.Controls.Add(this.dgPrimaryKey);
            this.tabPrimariKey.Location = new System.Drawing.Point(4, 22);
            this.tabPrimariKey.Name = "tabPrimariKey";
            this.tabPrimariKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrimariKey.Size = new System.Drawing.Size(760, 462);
            this.tabPrimariKey.TabIndex = 2;
            this.tabPrimariKey.Text = "PrimaryKey";
            this.tabPrimariKey.UseVisualStyleBackColor = true;
            // 
            // dgPrimaryKey
            // 
            this.dgPrimaryKey.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgPrimaryKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPrimaryKey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Dirección});
            this.dgPrimaryKey.Location = new System.Drawing.Point(6, 7);
            this.dgPrimaryKey.Name = "dgPrimaryKey";
            this.dgPrimaryKey.Size = new System.Drawing.Size(243, 388);
            this.dgPrimaryKey.TabIndex = 0;
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            // 
            // Dirección
            // 
            this.Dirección.HeaderText = "Dirección";
            this.Dirección.Name = "Dirección";
            // 
            // tabForeanKey
            // 
            this.tabForeanKey.Controls.Add(this.dgForeanKey);
            this.tabForeanKey.Location = new System.Drawing.Point(4, 22);
            this.tabForeanKey.Name = "tabForeanKey";
            this.tabForeanKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabForeanKey.Size = new System.Drawing.Size(760, 462);
            this.tabForeanKey.TabIndex = 3;
            this.tabForeanKey.Text = "ForeanKey";
            this.tabForeanKey.UseVisualStyleBackColor = true;
            // 
            // dgForeanKey
            // 
            this.dgForeanKey.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgForeanKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgForeanKey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClaveForanea,
            this.Dirección1,
            this.Dirección2,
            this.Dirección3,
            this.Dirección4,
            this.Dirección5,
            this.Dirección6,
            this.Dirección7,
            this.Dirección8,
            this.Dirección9,
            this.Dirección10});
            this.dgForeanKey.Location = new System.Drawing.Point(6, 5);
            this.dgForeanKey.Name = "dgForeanKey";
            this.dgForeanKey.Size = new System.Drawing.Size(757, 389);
            this.dgForeanKey.TabIndex = 0;
            // 
            // ClaveForanea
            // 
            this.ClaveForanea.HeaderText = "ClaveForanea";
            this.ClaveForanea.Name = "ClaveForanea";
            // 
            // Dirección1
            // 
            this.Dirección1.HeaderText = "Dirección1";
            this.Dirección1.Name = "Dirección1";
            // 
            // Dirección2
            // 
            this.Dirección2.HeaderText = "Dirección2";
            this.Dirección2.Name = "Dirección2";
            // 
            // Dirección3
            // 
            this.Dirección3.HeaderText = "Dirección3";
            this.Dirección3.Name = "Dirección3";
            // 
            // Dirección4
            // 
            this.Dirección4.HeaderText = "Dirección4";
            this.Dirección4.Name = "Dirección4";
            // 
            // Dirección5
            // 
            this.Dirección5.HeaderText = "Dirección5";
            this.Dirección5.Name = "Dirección5";
            // 
            // Dirección6
            // 
            this.Dirección6.HeaderText = "Dirección6";
            this.Dirección6.Name = "Dirección6";
            // 
            // Dirección7
            // 
            this.Dirección7.HeaderText = "Dirección7";
            this.Dirección7.Name = "Dirección7";
            // 
            // Dirección8
            // 
            this.Dirección8.HeaderText = "Dirección8";
            this.Dirección8.Name = "Dirección8";
            // 
            // Dirección9
            // 
            this.Dirección9.HeaderText = "Dirección9";
            this.Dirección9.Name = "Dirección9";
            // 
            // Dirección10
            // 
            this.Dirección10.HeaderText = "Dirección10";
            this.Dirección10.Name = "Dirección10";
            // 
            // tabRegistros
            // 
            this.tabRegistros.Controls.Add(this.EliminaRegistro);
            this.tabRegistros.Controls.Add(this.Modifica);
            this.tabRegistros.Controls.Add(this.NewAdd);
            this.tabRegistros.Controls.Add(this.GeneraReg);
            this.tabRegistros.Controls.Add(this.dgRegistros);
            this.tabRegistros.Location = new System.Drawing.Point(4, 22);
            this.tabRegistros.Name = "tabRegistros";
            this.tabRegistros.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegistros.Size = new System.Drawing.Size(760, 462);
            this.tabRegistros.TabIndex = 4;
            this.tabRegistros.Text = "Registros";
            this.tabRegistros.UseVisualStyleBackColor = true;
            // 
            // EliminaRegistro
            // 
            this.EliminaRegistro.Location = new System.Drawing.Point(506, 6);
            this.EliminaRegistro.Name = "EliminaRegistro";
            this.EliminaRegistro.Size = new System.Drawing.Size(75, 23);
            this.EliminaRegistro.TabIndex = 4;
            this.EliminaRegistro.Text = "Elimina";
            this.EliminaRegistro.UseVisualStyleBackColor = true;
            this.EliminaRegistro.Click += new System.EventHandler(this.EliminaRegistro_Click);
            // 
            // Modifica
            // 
            this.Modifica.Location = new System.Drawing.Point(425, 6);
            this.Modifica.Name = "Modifica";
            this.Modifica.Size = new System.Drawing.Size(75, 23);
            this.Modifica.TabIndex = 3;
            this.Modifica.Text = "Modifica";
            this.Modifica.UseVisualStyleBackColor = true;
            this.Modifica.Click += new System.EventHandler(this.Modifica_Click);
            // 
            // NewAdd
            // 
            this.NewAdd.Enabled = false;
            this.NewAdd.Location = new System.Drawing.Point(587, 6);
            this.NewAdd.Name = "NewAdd";
            this.NewAdd.Size = new System.Drawing.Size(75, 23);
            this.NewAdd.TabIndex = 2;
            this.NewAdd.Text = "Nuevo";
            this.NewAdd.UseVisualStyleBackColor = true;
            this.NewAdd.Click += new System.EventHandler(this.NewAdd_Click);
            // 
            // GeneraReg
            // 
            this.GeneraReg.Location = new System.Drawing.Point(668, 6);
            this.GeneraReg.Name = "GeneraReg";
            this.GeneraReg.Size = new System.Drawing.Size(98, 23);
            this.GeneraReg.TabIndex = 1;
            this.GeneraReg.Text = "Genera Registros";
            this.GeneraReg.UseVisualStyleBackColor = true;
            this.GeneraReg.Click += new System.EventHandler(this.GeneraReg_Click);
            // 
            // dgRegistros
            // 
            this.dgRegistros.AllowUserToAddRows = false;
            this.dgRegistros.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRegistros.Location = new System.Drawing.Point(6, 42);
            this.dgRegistros.Name = "dgRegistros";
            this.dgRegistros.Size = new System.Drawing.Size(755, 414);
            this.dgRegistros.TabIndex = 0;
            this.dgRegistros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRegistros_CellClick);
            this.dgRegistros.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgRegistros_EditingControlShowing);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgÁrbol);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(760, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Árbol";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgÁrbol
            // 
            this.dgÁrbol.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgÁrbol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgÁrbol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DirNodo,
            this.TipoNodo,
            this.Ap1,
            this.CB1,
            this.Ap2,
            this.CB2,
            this.Ap3,
            this.CB3,
            this.Ap4,
            this.CB4,
            this.Ap5});
            this.dgÁrbol.Location = new System.Drawing.Point(13, 5);
            this.dgÁrbol.Name = "dgÁrbol";
            this.dgÁrbol.Size = new System.Drawing.Size(742, 452);
            this.dgÁrbol.TabIndex = 0;
            // 
            // DirNodo
            // 
            this.DirNodo.HeaderText = "DirNodo";
            this.DirNodo.Name = "DirNodo";
            this.DirNodo.Width = 70;
            // 
            // TipoNodo
            // 
            this.TipoNodo.HeaderText = "TipoNodo";
            this.TipoNodo.Name = "TipoNodo";
            this.TipoNodo.Width = 70;
            // 
            // Ap1
            // 
            this.Ap1.HeaderText = "Ap1";
            this.Ap1.Name = "Ap1";
            this.Ap1.Width = 62;
            // 
            // CB1
            // 
            this.CB1.HeaderText = "CB1";
            this.CB1.Name = "CB1";
            this.CB1.Width = 62;
            // 
            // Ap2
            // 
            this.Ap2.HeaderText = "Ap2";
            this.Ap2.Name = "Ap2";
            this.Ap2.Width = 62;
            // 
            // CB2
            // 
            this.CB2.HeaderText = "CB2";
            this.CB2.Name = "CB2";
            this.CB2.Width = 62;
            // 
            // Ap3
            // 
            this.Ap3.HeaderText = "Ap3";
            this.Ap3.Name = "Ap3";
            this.Ap3.Width = 62;
            // 
            // CB3
            // 
            this.CB3.HeaderText = "CB3";
            this.CB3.Name = "CB3";
            this.CB3.Width = 62;
            // 
            // Ap4
            // 
            this.Ap4.HeaderText = "Ap4";
            this.Ap4.Name = "Ap4";
            this.Ap4.Width = 62;
            // 
            // CB4
            // 
            this.CB4.HeaderText = "CB4";
            this.CB4.Name = "CB4";
            this.CB4.Width = 62;
            // 
            // Ap5
            // 
            this.Ap5.HeaderText = "Ap5";
            this.Ap5.Name = "Ap5";
            this.Ap5.Width = 62;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 518);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabEntidad.ResumeLayout(false);
            this.tabEntidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEntidades)).EndInit();
            this.tabAtributo.ResumeLayout(false);
            this.tabAtributo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtributos)).EndInit();
            this.tabPrimariKey.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPrimaryKey)).EndInit();
            this.tabForeanKey.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgForeanKey)).EndInit();
            this.tabRegistros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRegistros)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgÁrbol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEntidad;
        private System.Windows.Forms.DataGridView dgEntidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DAtributos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DSigEntidad;
        private System.Windows.Forms.Button btnAgregaEnt;
        private System.Windows.Forms.TextBox txtBIngNoment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNomEntActual;
        private System.Windows.Forms.TabPage tabAtributo;
        private System.Windows.Forms.DataGridView dgAtributos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoIndice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DI;
        private System.Windows.Forms.DataGridViewTextBoxColumn DSA;
        private System.Windows.Forms.Button btnEliminaAtr;
        private System.Windows.Forms.ComboBox cmbtipoIndice;
        private System.Windows.Forms.Button btnModificaAtr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAltaAtr;
        private System.Windows.Forms.TextBox txtBoxLong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxNomAtribut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.Button EliminaEnt;
        private System.Windows.Forms.Button ModificaEnt;
        private System.Windows.Forms.TabPage tabPrimariKey;
        private System.Windows.Forms.TabPage tabForeanKey;
        private System.Windows.Forms.TabPage tabRegistros;
        private System.Windows.Forms.Button GeneraReg;
        private System.Windows.Forms.DataGridView dgRegistros;
        private System.Windows.Forms.Button NewAdd;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgPrimaryKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección;
        private System.Windows.Forms.DataGridView dgForeanKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveForanea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dirección10;
        private System.Windows.Forms.Button Modifica;
        private System.Windows.Forms.Button EliminaRegistro;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgÁrbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirNodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoNodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ap1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CB1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ap2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CB2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ap3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CB3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ap4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CB4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ap5;
    }
}

