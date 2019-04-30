namespace DesafioCSharp
{
    partial class CRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CRUD));
            this.LFirstName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BAdd = new System.Windows.Forms.Button();
            this.bLast = new System.Windows.Forms.Button();
            this.bFirst = new System.Windows.Forms.Button();
            this.bNext = new System.Windows.Forms.Button();
            this.bPrevious = new System.Windows.Forms.Button();
            this.cPlan = new System.Windows.Forms.ComboBox();
            this.tBirth = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tFirstName = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bNew = new System.Windows.Forms.ToolStripButton();
            this.bSave = new System.Windows.Forms.ToolStripButton();
            this.bEdit = new System.Windows.Forms.ToolStripButton();
            this.bTrash = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tSearch = new System.Windows.Forms.ToolStripTextBox();
            this.bSearch = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LFirstName
            // 
            this.LFirstName.AutoSize = true;
            this.LFirstName.Location = new System.Drawing.Point(8, 35);
            this.LFirstName.Name = "LFirstName";
            this.LFirstName.Size = new System.Drawing.Size(39, 13);
            this.LFirstName.TabIndex = 0;
            this.LFirstName.Text = "Nome*";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BAdd);
            this.panel1.Controls.Add(this.bLast);
            this.panel1.Controls.Add(this.bFirst);
            this.panel1.Controls.Add(this.bNext);
            this.panel1.Controls.Add(this.bPrevious);
            this.panel1.Controls.Add(this.cPlan);
            this.panel1.Controls.Add(this.tBirth);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tLastName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tFirstName);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.LFirstName);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 186);
            this.panel1.TabIndex = 1;
            // 
            // BAdd
            // 
            this.BAdd.Image = ((System.Drawing.Image)(resources.GetObject("BAdd.Image")));
            this.BAdd.Location = new System.Drawing.Point(185, 89);
            this.BAdd.Name = "BAdd";
            this.BAdd.Size = new System.Drawing.Size(23, 22);
            this.BAdd.TabIndex = 13;
            this.BAdd.UseVisualStyleBackColor = true;
            this.BAdd.Click += new System.EventHandler(this.BAdd_Click);
            // 
            // bLast
            // 
            this.bLast.Location = new System.Drawing.Point(317, 135);
            this.bLast.Name = "bLast";
            this.bLast.Size = new System.Drawing.Size(75, 23);
            this.bLast.TabIndex = 12;
            this.bLast.Text = "Último";
            this.bLast.UseVisualStyleBackColor = true;
            this.bLast.Click += new System.EventHandler(this.BLast_Click);
            // 
            // bFirst
            // 
            this.bFirst.Location = new System.Drawing.Point(11, 135);
            this.bFirst.Name = "bFirst";
            this.bFirst.Size = new System.Drawing.Size(75, 23);
            this.bFirst.TabIndex = 11;
            this.bFirst.Text = "Primeiro";
            this.bFirst.UseVisualStyleBackColor = true;
            this.bFirst.Click += new System.EventHandler(this.BFirst_Click);
            // 
            // bNext
            // 
            this.bNext.Location = new System.Drawing.Point(215, 135);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(75, 23);
            this.bNext.TabIndex = 10;
            this.bNext.Text = "Próximo";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Click += new System.EventHandler(this.BNext_Click);
            // 
            // bPrevious
            // 
            this.bPrevious.Location = new System.Drawing.Point(113, 135);
            this.bPrevious.Name = "bPrevious";
            this.bPrevious.Size = new System.Drawing.Size(75, 23);
            this.bPrevious.TabIndex = 9;
            this.bPrevious.Text = "Anterior";
            this.bPrevious.UseVisualStyleBackColor = true;
            this.bPrevious.Click += new System.EventHandler(this.BPrevious_Click);
            // 
            // cPlan
            // 
            this.cPlan.FormattingEnabled = true;
            this.cPlan.Location = new System.Drawing.Point(11, 90);
            this.cPlan.Name = "cPlan";
            this.cPlan.Size = new System.Drawing.Size(168, 21);
            this.cPlan.TabIndex = 8;
            // 
            // tBirth
            // 
            this.tBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tBirth.Location = new System.Drawing.Point(225, 90);
            this.tBirth.MaxDate = new System.DateTime(2019, 4, 23, 0, 0, 0, 0);
            this.tBirth.Name = "tBirth";
            this.tBirth.Size = new System.Drawing.Size(168, 20);
            this.tBirth.TabIndex = 7;
            this.tBirth.Value = new System.DateTime(2019, 4, 23, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data de Nasc.*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Plano";
            // 
            // tLastName
            // 
            this.tLastName.Location = new System.Drawing.Point(225, 51);
            this.tLastName.Name = "tLastName";
            this.tLastName.Size = new System.Drawing.Size(168, 20);
            this.tLastName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sobrenome*";
            // 
            // tFirstName
            // 
            this.tFirstName.Location = new System.Drawing.Point(11, 51);
            this.tFirstName.Name = "tFirstName";
            this.tFirstName.Size = new System.Drawing.Size(168, 20);
            this.tFirstName.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bNew,
            this.bSave,
            this.bEdit,
            this.bTrash,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tSearch,
            this.bSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(409, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bNew
            // 
            this.bNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bNew.Image = ((System.Drawing.Image)(resources.GetObject("bNew.Image")));
            this.bNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(23, 22);
            this.bNew.Text = "toolStripButton1";
            this.bNew.ToolTipText = "Novo";
            this.bNew.Click += new System.EventHandler(this.BNew_Click);
            // 
            // bSave
            // 
            this.bSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSave.Image = ((System.Drawing.Image)(resources.GetObject("bSave.Image")));
            this.bSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(23, 22);
            this.bSave.Text = "toolStripButton1";
            this.bSave.ToolTipText = "Salvar";
            this.bSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // bEdit
            // 
            this.bEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bEdit.Image = ((System.Drawing.Image)(resources.GetObject("bEdit.Image")));
            this.bEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(23, 22);
            this.bEdit.Text = "toolStripButton5";
            this.bEdit.ToolTipText = "Editar";
            this.bEdit.Click += new System.EventHandler(this.BEdit_Click);
            // 
            // bTrash
            // 
            this.bTrash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bTrash.Image = ((System.Drawing.Image)(resources.GetObject("bTrash.Image")));
            this.bTrash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bTrash.Name = "bTrash";
            this.bTrash.Size = new System.Drawing.Size(23, 22);
            this.bTrash.Text = "toolStripButton2";
            this.bTrash.ToolTipText = "Deletar";
            this.bTrash.Click += new System.EventHandler(this.BTrash_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Buscar:";
            // 
            // tSearch
            // 
            this.tSearch.BackColor = System.Drawing.SystemColors.Window;
            this.tSearch.Name = "tSearch";
            this.tSearch.Size = new System.Drawing.Size(200, 25);
            this.tSearch.ToolTipText = "Digite o nome do usuário";
            // 
            // bSearch
            // 
            this.bSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSearch.Image = ((System.Drawing.Image)(resources.GetObject("bSearch.Image")));
            this.bSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(23, 22);
            this.bSearch.Text = "toolStripButton4";
            this.bSearch.Click += new System.EventHandler(this.BSearch_Click);
            // 
            // CRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 193);
            this.Controls.Add(this.panel1);
            this.Name = "CRUD";
            this.Text = "CRUD";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LFirstName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tFirstName;
        private System.Windows.Forms.TextBox tLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker tBirth;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button bPrevious;
        private System.Windows.Forms.ComboBox cPlan;
        private System.Windows.Forms.Button bFirst;
        private System.Windows.Forms.Button bLast;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bNew;
        private System.Windows.Forms.ToolStripButton bSave;
        private System.Windows.Forms.ToolStripButton bEdit;
        private System.Windows.Forms.ToolStripButton bTrash;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tSearch;
        private System.Windows.Forms.ToolStripButton bSearch;
        private System.Windows.Forms.Button BAdd;
    }
}