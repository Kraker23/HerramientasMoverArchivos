namespace HerramientaMoverArchivos
{
    partial class cMoverArchivos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gAjutes = new System.Windows.Forms.GroupBox();
            this.chkDesc = new System.Windows.Forms.CheckBox();
            this.chkAsc = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nTiempo = new System.Windows.Forms.NumericUpDown();
            this.nBloque = new System.Windows.Forms.NumericUpDown();
            this.chkActivarAjutes = new System.Windows.Forms.CheckBox();
            this.cProgress = new Utilities.Controls.ProgressBarBackGround.cProgressBackground();
            this.chkRecursividad = new System.Windows.Forms.CheckBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btMover = new System.Windows.Forms.Button();
            this.btCopiar = new System.Windows.Forms.Button();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.gAjutes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTiempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBloque)).BeginInit();
            this.SuspendLayout();
            // 
            // gAjutes
            // 
            this.gAjutes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gAjutes.Controls.Add(this.chkDesc);
            this.gAjutes.Controls.Add(this.chkAsc);
            this.gAjutes.Controls.Add(this.label4);
            this.gAjutes.Controls.Add(this.label3);
            this.gAjutes.Controls.Add(this.nTiempo);
            this.gAjutes.Controls.Add(this.nBloque);
            this.gAjutes.Controls.Add(this.chkActivarAjutes);
            this.gAjutes.Location = new System.Drawing.Point(15, 128);
            this.gAjutes.Name = "gAjutes";
            this.gAjutes.Size = new System.Drawing.Size(698, 64);
            this.gAjutes.TabIndex = 19;
            this.gAjutes.TabStop = false;
            this.gAjutes.Text = "Ajustes Adicionales";
            // 
            // chkDesc
            // 
            this.chkDesc.AutoSize = true;
            this.chkDesc.Enabled = false;
            this.chkDesc.Location = new System.Drawing.Point(499, 32);
            this.chkDesc.Name = "chkDesc";
            this.chkDesc.Size = new System.Drawing.Size(122, 17);
            this.chkDesc.TabIndex = 13;
            this.chkDesc.Text = "Orden Descendente";
            this.chkDesc.UseVisualStyleBackColor = true;
            this.chkDesc.CheckedChanged += new System.EventHandler(this.chkDesc_CheckedChanged);
            // 
            // chkAsc
            // 
            this.chkAsc.AutoSize = true;
            this.chkAsc.Checked = true;
            this.chkAsc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAsc.Enabled = false;
            this.chkAsc.Location = new System.Drawing.Point(499, 9);
            this.chkAsc.Name = "chkAsc";
            this.chkAsc.Size = new System.Drawing.Size(115, 17);
            this.chkAsc.TabIndex = 12;
            this.chkAsc.Text = "Orden Ascendente";
            this.chkAsc.UseVisualStyleBackColor = true;
            this.chkAsc.CheckedChanged += new System.EventHandler(this.chkAsc_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tiempo de Ejecucion entre Bloques (Seg)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Bloque de archivos";
            // 
            // nTiempo
            // 
            this.nTiempo.Enabled = false;
            this.nTiempo.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nTiempo.Location = new System.Drawing.Point(280, 29);
            this.nTiempo.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nTiempo.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nTiempo.Name = "nTiempo";
            this.nTiempo.ReadOnly = true;
            this.nTiempo.Size = new System.Drawing.Size(120, 20);
            this.nTiempo.TabIndex = 2;
            this.nTiempo.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // nBloque
            // 
            this.nBloque.Enabled = false;
            this.nBloque.Location = new System.Drawing.Point(134, 29);
            this.nBloque.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nBloque.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nBloque.Name = "nBloque";
            this.nBloque.ReadOnly = true;
            this.nBloque.Size = new System.Drawing.Size(120, 20);
            this.nBloque.TabIndex = 1;
            this.nBloque.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // chkActivarAjutes
            // 
            this.chkActivarAjutes.AutoSize = true;
            this.chkActivarAjutes.Location = new System.Drawing.Point(7, 20);
            this.chkActivarAjutes.Name = "chkActivarAjutes";
            this.chkActivarAjutes.Size = new System.Drawing.Size(96, 17);
            this.chkActivarAjutes.TabIndex = 0;
            this.chkActivarAjutes.Text = "Activar Ajustes";
            this.chkActivarAjutes.UseVisualStyleBackColor = true;
            this.chkActivarAjutes.CheckedChanged += new System.EventHandler(this.chkActivarAjutes_CheckedChanged);
            // 
            // cProgress
            // 
            this.cProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cProgress.Location = new System.Drawing.Point(470, 3);
            this.cProgress.MostrarTiempoCarga = false;
            this.cProgress.Name = "cProgress";
            this.cProgress.Size = new System.Drawing.Size(243, 36);
            this.cProgress.TabIndex = 18;
            this.cProgress.Visible = false;
            // 
            // chkRecursividad
            // 
            this.chkRecursividad.AutoSize = true;
            this.chkRecursividad.Checked = true;
            this.chkRecursividad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursividad.Location = new System.Drawing.Point(15, 15);
            this.chkRecursividad.Name = "chkRecursividad";
            this.chkRecursividad.Size = new System.Drawing.Size(88, 17);
            this.chkRecursividad.TabIndex = 17;
            this.chkRecursividad.Text = "Recursividad";
            this.chkRecursividad.UseVisualStyleBackColor = true;
            // 
            // txtResultado
            // 
            this.txtResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultado.Location = new System.Drawing.Point(15, 198);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(698, 116);
            this.txtResultado.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Carpeta Destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Carpeta Origen";
            // 
            // btMover
            // 
            this.btMover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMover.Location = new System.Drawing.Point(638, 98);
            this.btMover.Name = "btMover";
            this.btMover.Size = new System.Drawing.Size(75, 23);
            this.btMover.TabIndex = 13;
            this.btMover.Text = "Mover";
            this.btMover.UseVisualStyleBackColor = true;
            this.btMover.Click += new System.EventHandler(this.btMover_Click);
            // 
            // btCopiar
            // 
            this.btCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCopiar.Location = new System.Drawing.Point(638, 57);
            this.btCopiar.Name = "btCopiar";
            this.btCopiar.Size = new System.Drawing.Size(75, 23);
            this.btCopiar.TabIndex = 12;
            this.btCopiar.Text = "Copiar";
            this.btCopiar.UseVisualStyleBackColor = true;
            this.btCopiar.Click += new System.EventHandler(this.btCopiar_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestino.Location = new System.Drawing.Point(12, 101);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(624, 20);
            this.txtDestino.TabIndex = 11;
            // 
            // txtOrigen
            // 
            this.txtOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigen.Location = new System.Drawing.Point(12, 57);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(624, 20);
            this.txtOrigen.TabIndex = 10;
            // 
            // cMoverArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gAjutes);
            this.Controls.Add(this.cProgress);
            this.Controls.Add(this.chkRecursividad);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btMover);
            this.Controls.Add(this.btCopiar);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtOrigen);
            this.MaximumSize = new System.Drawing.Size(727, 327);
            this.MinimumSize = new System.Drawing.Size(727, 327);
            this.Name = "cMoverArchivos";
            this.Size = new System.Drawing.Size(727, 327);
            this.gAjutes.ResumeLayout(false);
            this.gAjutes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTiempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBloque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gAjutes;
        private System.Windows.Forms.CheckBox chkDesc;
        private System.Windows.Forms.CheckBox chkAsc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nTiempo;
        private System.Windows.Forms.NumericUpDown nBloque;
        private System.Windows.Forms.CheckBox chkActivarAjutes;
        private Utilities.Controls.ProgressBarBackGround.cProgressBackground cProgress;
        private System.Windows.Forms.CheckBox chkRecursividad;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btMover;
        private System.Windows.Forms.Button btCopiar;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.TextBox txtOrigen;
    }
}
