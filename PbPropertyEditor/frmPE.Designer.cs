namespace PbPropertyEditor
{
    partial class frmPE
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
            this.lblPropValue = new System.Windows.Forms.Label();
            this.txtPropertyValue = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnFolderBrowse = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnFileBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cboPropertyNames = new System.Windows.Forms.ComboBox();
            this.clbPropertyNames1 = new System.Windows.Forms.CheckedListBox();
            this.lblClb1 = new System.Windows.Forms.Label();
            this.lblPropName = new System.Windows.Forms.Label();
            this.btnSelectAll1 = new System.Windows.Forms.Button();
            this.btnSelectNone1 = new System.Windows.Forms.Button();
            this.btnSaveSettings1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCopyAndRename = new System.Windows.Forms.CheckBox();
            this.chkEnumSelFirstAll = new System.Windows.Forms.CheckBox();
            this.chkEnumSelAll = new System.Windows.Forms.CheckBox();
            this.chkEnumAllSingle = new System.Windows.Forms.CheckBox();
            this.chkCompareDates = new System.Windows.Forms.CheckBox();
            this.chkPropertyInfo = new System.Windows.Forms.CheckBox();
            this.chkSetProperty = new System.Windows.Forms.CheckBox();
            this.chkGetProperty = new System.Windows.Forms.CheckBox();
            this.btnOKSel = new System.Windows.Forms.Button();
            this.clbPropertyNames2 = new System.Windows.Forms.CheckedListBox();
            this.btnSaveSettings2 = new System.Windows.Forms.Button();
            this.btnSelectNone2 = new System.Windows.Forms.Button();
            this.btnSelectAll2 = new System.Windows.Forms.Button();
            this.lblClb2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInitReg = new System.Windows.Forms.Button();
            this.btnClearReg = new System.Windows.Forms.Button();
            this.lblTargetFolder = new System.Windows.Forms.Label();
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.btnTargetFolderBrowse = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPropValue
            // 
            this.lblPropValue.AutoSize = true;
            this.lblPropValue.Location = new System.Drawing.Point(22, 298);
            this.lblPropValue.Name = "lblPropValue";
            this.lblPropValue.Size = new System.Drawing.Size(76, 13);
            this.lblPropValue.TabIndex = 6;
            this.lblPropValue.Text = "Property Value";
            this.lblPropValue.Visible = false;
            // 
            // txtPropertyValue
            // 
            this.txtPropertyValue.Location = new System.Drawing.Point(117, 298);
            this.txtPropertyValue.Name = "txtPropertyValue";
            this.txtPropertyValue.Size = new System.Drawing.Size(241, 20);
            this.txtPropertyValue.TabIndex = 9;
            this.txtPropertyValue.Visible = false;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Enabled = false;
            this.lblFile.Location = new System.Drawing.Point(22, 381);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(23, 13);
            this.lblFile.TabIndex = 11;
            this.lblFile.Text = "File";
            this.lblFile.Visible = false;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(117, 378);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(682, 20);
            this.txtFile.TabIndex = 12;
            this.txtFile.Visible = false;
            // 
            // btnFolderBrowse
            // 
            this.btnFolderBrowse.Location = new System.Drawing.Point(828, 336);
            this.btnFolderBrowse.Name = "btnFolderBrowse";
            this.btnFolderBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnFolderBrowse.TabIndex = 13;
            this.btnFolderBrowse.Text = "Browse";
            this.btnFolderBrowse.UseVisualStyleBackColor = true;
            this.btnFolderBrowse.Visible = false;
            this.btnFolderBrowse.Click += new System.EventHandler(this.btnFolderBrowse_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(22, 341);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(36, 13);
            this.lblFolder.TabIndex = 14;
            this.lblFolder.Text = "Folder";
            this.lblFolder.Visible = false;
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(117, 338);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(682, 20);
            this.txtFolder.TabIndex = 15;
            this.txtFolder.Visible = false;
            // 
            // btnFileBrowse
            // 
            this.btnFileBrowse.Location = new System.Drawing.Point(828, 376);
            this.btnFileBrowse.Name = "btnFileBrowse";
            this.btnFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnFileBrowse.TabIndex = 16;
            this.btnFileBrowse.Text = "Browse";
            this.btnFileBrowse.UseVisualStyleBackColor = true;
            this.btnFileBrowse.Visible = false;
            this.btnFileBrowse.Click += new System.EventHandler(this.btnFileBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cboPropertyNames
            // 
            this.cboPropertyNames.FormattingEnabled = true;
            this.cboPropertyNames.Location = new System.Drawing.Point(117, 257);
            this.cboPropertyNames.Name = "cboPropertyNames";
            this.cboPropertyNames.Size = new System.Drawing.Size(377, 21);
            this.cboPropertyNames.TabIndex = 25;
            this.cboPropertyNames.Visible = false;
            // 
            // clbPropertyNames1
            // 
            this.clbPropertyNames1.FormattingEnabled = true;
            this.clbPropertyNames1.Location = new System.Drawing.Point(25, 564);
            this.clbPropertyNames1.Name = "clbPropertyNames1";
            this.clbPropertyNames1.Size = new System.Drawing.Size(324, 259);
            this.clbPropertyNames1.TabIndex = 27;
            this.clbPropertyNames1.Visible = false;
            // 
            // lblClb1
            // 
            this.lblClb1.AutoSize = true;
            this.lblClb1.Location = new System.Drawing.Point(72, 503);
            this.lblClb1.Name = "lblClb1";
            this.lblClb1.Size = new System.Drawing.Size(233, 13);
            this.lblClb1.TabIndex = 28;
            this.lblClb1.Text = "Enum Selected Properties for all Files in a Folder";
            this.lblClb1.Visible = false;
            // 
            // lblPropName
            // 
            this.lblPropName.AutoSize = true;
            this.lblPropName.Enabled = false;
            this.lblPropName.Location = new System.Drawing.Point(22, 260);
            this.lblPropName.Name = "lblPropName";
            this.lblPropName.Size = new System.Drawing.Size(77, 13);
            this.lblPropName.TabIndex = 30;
            this.lblPropName.Text = "Property Name";
            this.lblPropName.Visible = false;
            // 
            // btnSelectAll1
            // 
            this.btnSelectAll1.Location = new System.Drawing.Point(43, 535);
            this.btnSelectAll1.Name = "btnSelectAll1";
            this.btnSelectAll1.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll1.TabIndex = 31;
            this.btnSelectAll1.Text = "Select All";
            this.btnSelectAll1.UseVisualStyleBackColor = true;
            this.btnSelectAll1.Visible = false;
            this.btnSelectAll1.Click += new System.EventHandler(this.btnSelectAll1_Click);
            // 
            // btnSelectNone1
            // 
            this.btnSelectNone1.Location = new System.Drawing.Point(124, 535);
            this.btnSelectNone1.Name = "btnSelectNone1";
            this.btnSelectNone1.Size = new System.Drawing.Size(75, 23);
            this.btnSelectNone1.TabIndex = 32;
            this.btnSelectNone1.Text = "Select None";
            this.btnSelectNone1.UseVisualStyleBackColor = true;
            this.btnSelectNone1.Visible = false;
            this.btnSelectNone1.Click += new System.EventHandler(this.btnSelectNone1_Click);
            // 
            // btnSaveSettings1
            // 
            this.btnSaveSettings1.Location = new System.Drawing.Point(205, 535);
            this.btnSaveSettings1.Name = "btnSaveSettings1";
            this.btnSaveSettings1.Size = new System.Drawing.Size(92, 23);
            this.btnSaveSettings1.TabIndex = 33;
            this.btnSaveSettings1.Text = "Save Settings";
            this.btnSaveSettings1.UseVisualStyleBackColor = true;
            this.btnSaveSettings1.Visible = false;
            this.btnSaveSettings1.Click += new System.EventHandler(this.btnSaveSettings1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCopyAndRename);
            this.groupBox1.Controls.Add(this.chkEnumSelFirstAll);
            this.groupBox1.Controls.Add(this.chkEnumSelAll);
            this.groupBox1.Controls.Add(this.chkEnumAllSingle);
            this.groupBox1.Controls.Add(this.chkCompareDates);
            this.groupBox1.Controls.Add(this.chkPropertyInfo);
            this.groupBox1.Controls.Add(this.chkSetProperty);
            this.groupBox1.Controls.Add(this.chkGetProperty);
            this.groupBox1.Controls.Add(this.btnOKSel);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 223);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Function";
            // 
            // chkCopyAndRename
            // 
            this.chkCopyAndRename.AutoSize = true;
            this.chkCopyAndRename.Location = new System.Drawing.Point(248, 132);
            this.chkCopyAndRename.Name = "chkCopyAndRename";
            this.chkCopyAndRename.Size = new System.Drawing.Size(133, 17);
            this.chkCopyAndRename.TabIndex = 108;
            this.chkCopyAndRename.Text = "Copy and rename Files";
            this.chkCopyAndRename.UseVisualStyleBackColor = true;
            this.chkCopyAndRename.Click += new System.EventHandler(this.chkCopyAndRename_Click);
            // 
            // chkEnumSelFirstAll
            // 
            this.chkEnumSelFirstAll.AutoSize = true;
            this.chkEnumSelFirstAll.Location = new System.Drawing.Point(248, 60);
            this.chkEnumSelFirstAll.Name = "chkEnumSelFirstAll";
            this.chkEnumSelFirstAll.Size = new System.Drawing.Size(279, 17);
            this.chkEnumSelFirstAll.TabIndex = 107;
            this.chkEnumSelFirstAll.Text = "Enum selected Properties for the first File in All Folders";
            this.chkEnumSelFirstAll.UseVisualStyleBackColor = true;
            this.chkEnumSelFirstAll.Click += new System.EventHandler(this.chkEnumSelFirstAll_Click);
            // 
            // chkEnumSelAll
            // 
            this.chkEnumSelAll.AutoSize = true;
            this.chkEnumSelAll.Location = new System.Drawing.Point(248, 26);
            this.chkEnumSelAll.Name = "chkEnumSelAll";
            this.chkEnumSelAll.Size = new System.Drawing.Size(298, 17);
            this.chkEnumSelAll.TabIndex = 106;
            this.chkEnumSelAll.Text = "Enum selected Properties for all the Files in a single Folder";
            this.chkEnumSelAll.UseVisualStyleBackColor = true;
            this.chkEnumSelAll.Click += new System.EventHandler(this.chkEnumSelAll_Click);
            // 
            // chkEnumAllSingle
            // 
            this.chkEnumAllSingle.AutoSize = true;
            this.chkEnumAllSingle.Location = new System.Drawing.Point(248, 94);
            this.chkEnumAllSingle.Name = "chkEnumAllSingle";
            this.chkEnumAllSingle.Size = new System.Drawing.Size(182, 17);
            this.chkEnumAllSingle.TabIndex = 105;
            this.chkEnumAllSingle.Text = "Enum all Poperties in a single File";
            this.chkEnumAllSingle.UseVisualStyleBackColor = true;
            this.chkEnumAllSingle.Click += new System.EventHandler(this.chkEnumAllSingle_Click);
            // 
            // chkCompareDates
            // 
            this.chkCompareDates.AutoSize = true;
            this.chkCompareDates.Location = new System.Drawing.Point(8, 132);
            this.chkCompareDates.Name = "chkCompareDates";
            this.chkCompareDates.Size = new System.Drawing.Size(187, 17);
            this.chkCompareDates.TabIndex = 104;
            this.chkCompareDates.Text = "Compare Dates.Created in all Files";
            this.chkCompareDates.UseVisualStyleBackColor = true;
            this.chkCompareDates.Click += new System.EventHandler(this.chkCompareDates_Click);
            // 
            // chkPropertyInfo
            // 
            this.chkPropertyInfo.AutoSize = true;
            this.chkPropertyInfo.Location = new System.Drawing.Point(8, 94);
            this.chkPropertyInfo.Name = "chkPropertyInfo";
            this.chkPropertyInfo.Size = new System.Drawing.Size(155, 17);
            this.chkPropertyInfo.TabIndex = 103;
            this.chkPropertyInfo.Text = "Info about a single Property";
            this.chkPropertyInfo.UseVisualStyleBackColor = true;
            this.chkPropertyInfo.Click += new System.EventHandler(this.chkPropertyInfo_Click);
            // 
            // chkSetProperty
            // 
            this.chkSetProperty.AutoSize = true;
            this.chkSetProperty.Location = new System.Drawing.Point(8, 60);
            this.chkSetProperty.Name = "chkSetProperty";
            this.chkSetProperty.Size = new System.Drawing.Size(96, 17);
            this.chkSetProperty.TabIndex = 102;
            this.chkSetProperty.Text = "Set  a Property";
            this.chkSetProperty.UseVisualStyleBackColor = true;
            this.chkSetProperty.Click += new System.EventHandler(this.chkSetProperty_Click);
            // 
            // chkGetProperty
            // 
            this.chkGetProperty.AutoSize = true;
            this.chkGetProperty.Location = new System.Drawing.Point(8, 26);
            this.chkGetProperty.Name = "chkGetProperty";
            this.chkGetProperty.Size = new System.Drawing.Size(94, 17);
            this.chkGetProperty.TabIndex = 101;
            this.chkGetProperty.Text = "Get a Property";
            this.chkGetProperty.UseVisualStyleBackColor = true;
            this.chkGetProperty.Click += new System.EventHandler(this.chkGetProperty_Click);
            // 
            // btnOKSel
            // 
            this.btnOKSel.Enabled = false;
            this.btnOKSel.Location = new System.Drawing.Point(394, 162);
            this.btnOKSel.Name = "btnOKSel";
            this.btnOKSel.Size = new System.Drawing.Size(75, 23);
            this.btnOKSel.TabIndex = 35;
            this.btnOKSel.Text = "OK";
            this.btnOKSel.UseVisualStyleBackColor = true;
            this.btnOKSel.Visible = false;
            this.btnOKSel.Click += new System.EventHandler(this.btnOKSel_Click);
            // 
            // clbPropertyNames2
            // 
            this.clbPropertyNames2.FormattingEnabled = true;
            this.clbPropertyNames2.Location = new System.Drawing.Point(465, 564);
            this.clbPropertyNames2.Name = "clbPropertyNames2";
            this.clbPropertyNames2.Size = new System.Drawing.Size(324, 259);
            this.clbPropertyNames2.TabIndex = 35;
            this.clbPropertyNames2.Visible = false;
            // 
            // btnSaveSettings2
            // 
            this.btnSaveSettings2.Location = new System.Drawing.Point(650, 535);
            this.btnSaveSettings2.Name = "btnSaveSettings2";
            this.btnSaveSettings2.Size = new System.Drawing.Size(92, 23);
            this.btnSaveSettings2.TabIndex = 38;
            this.btnSaveSettings2.Text = "Save Settings";
            this.btnSaveSettings2.UseVisualStyleBackColor = true;
            this.btnSaveSettings2.Visible = false;
            this.btnSaveSettings2.Click += new System.EventHandler(this.btnSaveSettings2_Click);
            // 
            // btnSelectNone2
            // 
            this.btnSelectNone2.Location = new System.Drawing.Point(569, 535);
            this.btnSelectNone2.Name = "btnSelectNone2";
            this.btnSelectNone2.Size = new System.Drawing.Size(75, 23);
            this.btnSelectNone2.TabIndex = 37;
            this.btnSelectNone2.Text = "Select None";
            this.btnSelectNone2.UseVisualStyleBackColor = true;
            this.btnSelectNone2.Visible = false;
            this.btnSelectNone2.Click += new System.EventHandler(this.btnSelectNone2_Click);
            // 
            // btnSelectAll2
            // 
            this.btnSelectAll2.Location = new System.Drawing.Point(488, 535);
            this.btnSelectAll2.Name = "btnSelectAll2";
            this.btnSelectAll2.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll2.TabIndex = 36;
            this.btnSelectAll2.Text = "Select All";
            this.btnSelectAll2.UseVisualStyleBackColor = true;
            this.btnSelectAll2.Visible = false;
            this.btnSelectAll2.Click += new System.EventHandler(this.btnSelectAll2_Click);
            // 
            // lblClb2
            // 
            this.lblClb2.AutoSize = true;
            this.lblClb2.Location = new System.Drawing.Point(478, 503);
            this.lblClb2.Name = "lblClb2";
            this.lblClb2.Size = new System.Drawing.Size(264, 13);
            this.lblClb2.TabIndex = 39;
            this.lblClb2.Text = "Enum Selected Properties for the first File  in all Folders";
            this.lblClb2.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInitReg);
            this.groupBox2.Controls.Add(this.btnClearReg);
            this.groupBox2.Location = new System.Drawing.Point(698, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 196);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // btnInitReg
            // 
            this.btnInitReg.Location = new System.Drawing.Point(16, 59);
            this.btnInitReg.Name = "btnInitReg";
            this.btnInitReg.Size = new System.Drawing.Size(149, 23);
            this.btnInitReg.TabIndex = 42;
            this.btnInitReg.Text = "Initialize the Registry Entries";
            this.btnInitReg.UseVisualStyleBackColor = true;
            this.btnInitReg.Click += new System.EventHandler(this.btnInitReg_Click);
            // 
            // btnClearReg
            // 
            this.btnClearReg.Location = new System.Drawing.Point(16, 26);
            this.btnClearReg.Name = "btnClearReg";
            this.btnClearReg.Size = new System.Drawing.Size(149, 23);
            this.btnClearReg.TabIndex = 41;
            this.btnClearReg.Text = "Clear the Registry Entries";
            this.btnClearReg.UseVisualStyleBackColor = true;
            this.btnClearReg.Click += new System.EventHandler(this.btnClearReg_Click);
            // 
            // lblTargetFolder
            // 
            this.lblTargetFolder.AutoSize = true;
            this.lblTargetFolder.Location = new System.Drawing.Point(22, 421);
            this.lblTargetFolder.Name = "lblTargetFolder";
            this.lblTargetFolder.Size = new System.Drawing.Size(70, 13);
            this.lblTargetFolder.TabIndex = 41;
            this.lblTargetFolder.Text = "Target Folder";
            this.lblTargetFolder.Visible = false;
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.Location = new System.Drawing.Point(120, 418);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.Size = new System.Drawing.Size(679, 20);
            this.txtTargetFolder.TabIndex = 42;
            this.txtTargetFolder.Visible = false;
            // 
            // btnTargetFolderBrowse
            // 
            this.btnTargetFolderBrowse.Enabled = false;
            this.btnTargetFolderBrowse.Location = new System.Drawing.Point(828, 415);
            this.btnTargetFolderBrowse.Name = "btnTargetFolderBrowse";
            this.btnTargetFolderBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnTargetFolderBrowse.TabIndex = 43;
            this.btnTargetFolderBrowse.Text = "Browse";
            this.btnTargetFolderBrowse.UseVisualStyleBackColor = true;
            this.btnTargetFolderBrowse.Visible = false;
            // 
            // frmPE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 835);
            this.Controls.Add(this.btnTargetFolderBrowse);
            this.Controls.Add(this.txtTargetFolder);
            this.Controls.Add(this.lblTargetFolder);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblClb2);
            this.Controls.Add(this.btnSaveSettings2);
            this.Controls.Add(this.btnSelectNone2);
            this.Controls.Add(this.btnSelectAll2);
            this.Controls.Add(this.clbPropertyNames2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveSettings1);
            this.Controls.Add(this.btnSelectNone1);
            this.Controls.Add(this.btnSelectAll1);
            this.Controls.Add(this.lblPropName);
            this.Controls.Add(this.lblClb1);
            this.Controls.Add(this.clbPropertyNames1);
            this.Controls.Add(this.cboPropertyNames);
            this.Controls.Add(this.btnFileBrowse);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.btnFolderBrowse);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtPropertyValue);
            this.Controls.Add(this.lblPropValue);
            this.Name = "frmPE";
            this.Text = "PB Extended File Properties Editor";
            this.Load += new System.EventHandler(this.frmPE_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPropValue;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnFolderBrowse;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnFileBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cboPropertyNames;
        private System.Windows.Forms.CheckedListBox clbPropertyNames1;
        private System.Windows.Forms.Label lblClb1;
        private System.Windows.Forms.Label lblPropName;
        private System.Windows.Forms.Button btnSelectAll1;
        private System.Windows.Forms.Button btnSelectNone1;
        private System.Windows.Forms.Button btnSaveSettings1;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.TextBox txtPropertyValue;
        private System.Windows.Forms.Button btnOKSel;
        private System.Windows.Forms.CheckedListBox clbPropertyNames2;
        private System.Windows.Forms.Button btnSaveSettings2;
        private System.Windows.Forms.Button btnSelectNone2;
        private System.Windows.Forms.Button btnSelectAll2;
        private System.Windows.Forms.Label lblClb2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnInitReg;
        private System.Windows.Forms.Button btnClearReg;
        private System.Windows.Forms.Label lblTargetFolder;
        private System.Windows.Forms.TextBox txtTargetFolder;
        private System.Windows.Forms.Button btnTargetFolderBrowse;
        private System.Windows.Forms.CheckBox chkGetProperty;
        private System.Windows.Forms.CheckBox chkEnumSelFirstAll;
        private System.Windows.Forms.CheckBox chkEnumSelAll;
        private System.Windows.Forms.CheckBox chkEnumAllSingle;
        private System.Windows.Forms.CheckBox chkCompareDates;
        private System.Windows.Forms.CheckBox chkPropertyInfo;
        private System.Windows.Forms.CheckBox chkSetProperty;
        private System.Windows.Forms.CheckBox chkCopyAndRename;
    }
}

