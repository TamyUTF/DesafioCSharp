namespace DesafioCSharp
{
    partial class FormPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlan));
            this.bNext = new System.Windows.Forms.Button();
            this.tEndDate = new System.Windows.Forms.DateTimePicker();
            this.tStartDate = new System.Windows.Forms.DateTimePicker();
            this.tName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.bPrevious = new System.Windows.Forms.Button();
            this.BBack = new System.Windows.Forms.ToolStripButton();
            this.tSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bNew = new System.Windows.Forms.ToolStripButton();
            this.bDelete = new System.Windows.Forms.ToolStripButton();
            this.bSave = new System.Windows.Forms.ToolStripButton();
            this.bEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bSearch = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lResults = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bNext
            // 
            this.bNext.Location = new System.Drawing.Point(256, 112);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(75, 23);
            this.bNext.TabIndex = 7;
            this.bNext.Text = "PRÓXIMO";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Click += new System.EventHandler(this.BNext_Click);
            // 
            // tEndDate
            // 
            this.tEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tEndDate.Location = new System.Drawing.Point(185, 67);
            this.tEndDate.Name = "tEndDate";
            this.tEndDate.Size = new System.Drawing.Size(146, 20);
            this.tEndDate.TabIndex = 5;
            // 
            // tStartDate
            // 
            this.tStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tStartDate.Location = new System.Drawing.Point(6, 67);
            this.tStartDate.Name = "tStartDate";
            this.tStartDate.Size = new System.Drawing.Size(144, 20);
            this.tStartDate.TabIndex = 4;
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(6, 28);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(325, 20);
            this.tName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ínicio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome*";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Buscar:";
            // 
            // bPrevious
            // 
            this.bPrevious.Location = new System.Drawing.Point(6, 112);
            this.bPrevious.Name = "bPrevious";
            this.bPrevious.Size = new System.Drawing.Size(75, 23);
            this.bPrevious.TabIndex = 6;
            this.bPrevious.Text = "ANTERIOR";
            this.bPrevious.UseVisualStyleBackColor = true;
            this.bPrevious.Click += new System.EventHandler(this.BPrevious_Click);
            // 
            // BBack
            // 
            this.BBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BBack.Image = ((System.Drawing.Image)(resources.GetObject("BBack.Image")));
            this.BBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BBack.Name = "BBack";
            this.BBack.Size = new System.Drawing.Size(23, 22);
            this.BBack.Text = "toolStripButton6";
            this.BBack.Click += new System.EventHandler(this.BBack_Click);
            // 
            // tSearch
            // 
            this.tSearch.Name = "tSearch";
            this.tSearch.Size = new System.Drawing.Size(150, 25);
            this.tSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TSearch_KeyUp);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bNew
            // 
            this.bNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bNew.Image = ((System.Drawing.Image)(resources.GetObject("bNew.Image")));
            this.bNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(23, 22);
            this.bNew.Text = "BClear";
            this.bNew.Click += new System.EventHandler(this.BNew_Click);
            // 
            // bDelete
            // 
            this.bDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDelete.Image = ((System.Drawing.Image)(resources.GetObject("bDelete.Image")));
            this.bDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(23, 22);
            this.bDelete.Text = "BDelete";
            this.bDelete.Click += new System.EventHandler(this.BDelete_Click);
            // 
            // bSave
            // 
            this.bSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSave.Image = ((System.Drawing.Image)(resources.GetObject("bSave.Image")));
            this.bSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(23, 22);
            this.bSave.Text = "toolStripButton1";
            this.bSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // bEdit
            // 
            this.bEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bEdit.Image = ((System.Drawing.Image)(resources.GetObject("bEdit.Image")));
            this.bEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(23, 22);
            this.bEdit.Text = "BEdit";
            this.bEdit.Click += new System.EventHandler(this.BEdit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BBack,
            this.bNew,
            this.bSave,
            this.bEdit,
            this.bDelete,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tSearch,
            this.bSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(356, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bSearch
            // 
            this.bSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSearch.Image = ((System.Drawing.Image)(resources.GetObject("bSearch.Image")));
            this.bSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(23, 22);
            this.bSearch.Text = "toolStripButton5";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lResults);
            this.panel1.Controls.Add(this.bNext);
            this.panel1.Controls.Add(this.bPrevious);
            this.panel1.Controls.Add(this.tEndDate);
            this.panel1.Controls.Add(this.tStartDate);
            this.panel1.Controls.Add(this.tName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 149);
            this.panel1.TabIndex = 3;
            // 
            // lResults
            // 
            this.lResults.AutoSize = true;
            this.lResults.Location = new System.Drawing.Point(7, 90);
            this.lResults.Name = "lResults";
            this.lResults.Size = new System.Drawing.Size(81, 13);
            this.lResults.TabIndex = 8;
            this.lResults.Text = "Foi encontrado:";
            this.lResults.Visible = false;
            // 
            // FormPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 194);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "FormPlan";
            this.Text = "FormPlan";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.DateTimePicker tEndDate;
        private System.Windows.Forms.DateTimePicker tStartDate;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Button bPrevious;
        private System.Windows.Forms.ToolStripButton BBack;
        private System.Windows.Forms.ToolStripTextBox tSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bNew;
        private System.Windows.Forms.ToolStripButton bDelete;
        private System.Windows.Forms.ToolStripButton bSave;
        private System.Windows.Forms.ToolStripButton bEdit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lResults;
    }
}