
namespace GitRepositoryTool
{
  partial class GitReposMain
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GitReposMain));
      this.aLabelGitPfad = new System.Windows.Forms.Label();
      this.aTextBoxGitPath = new System.Windows.Forms.TextBox();
      this.aDataGridViewContent = new System.Windows.Forms.DataGridView();
      this.Projektname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Branchname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Changes = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.LocalDifferences = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.RemoteDifferences = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.aButtonCheck = new System.Windows.Forms.Button();
      this.aLabelStatus = new System.Windows.Forms.Label();
      this.aButtonClose = new System.Windows.Forms.Button();
      this.buttonSearch = new System.Windows.Forms.Button();
      this.checkBoxCheckOnStart = new System.Windows.Forms.CheckBox();
      this.progressBarStatusCheck = new System.Windows.Forms.ProgressBar();
      this.backgroundWorkerUpdate = new System.ComponentModel.BackgroundWorker();
      this.checkBoxHideEqualRepos = new System.Windows.Forms.CheckBox();
      this.contextMenuStripInteraction = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.updateZeileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.öffneRepositoryOrdnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.projektAufGiteaÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mitGitExtensionsÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.aDataGridViewContent)).BeginInit();
      this.contextMenuStripInteraction.SuspendLayout();
      this.SuspendLayout();
      // 
      // aLabelGitPfad
      // 
      this.aLabelGitPfad.Location = new System.Drawing.Point(12, 21);
      this.aLabelGitPfad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.aLabelGitPfad.Name = "aLabelGitPfad";
      this.aLabelGitPfad.Size = new System.Drawing.Size(46, 17);
      this.aLabelGitPfad.TabIndex = 0;
      this.aLabelGitPfad.Text = "Git-Pfad";
      // 
      // aTextBoxGitPath
      // 
      this.aTextBoxGitPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.aTextBoxGitPath.ImeMode = System.Windows.Forms.ImeMode.Disable;
      this.aTextBoxGitPath.Location = new System.Drawing.Point(60, 17);
      this.aTextBoxGitPath.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
      this.aTextBoxGitPath.Name = "aTextBoxGitPath";
      this.aTextBoxGitPath.Size = new System.Drawing.Size(363, 20);
      this.aTextBoxGitPath.TabIndex = 1;
      this.aTextBoxGitPath.Text = "C:\\DotNet\\Projekte\\Git";
      this.aTextBoxGitPath.TextChanged += new System.EventHandler(this.aTextBoxGitPath_TextChanged);
      // 
      // aDataGridViewContent
      // 
      this.aDataGridViewContent.AllowUserToAddRows = false;
      this.aDataGridViewContent.AllowUserToDeleteRows = false;
      this.aDataGridViewContent.AllowUserToResizeColumns = false;
      this.aDataGridViewContent.AllowUserToResizeRows = false;
      this.aDataGridViewContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.aDataGridViewContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.aDataGridViewContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Projektname,
            this.Branchname,
            this.Changes,
            this.LocalDifferences,
            this.RemoteDifferences});
      this.aDataGridViewContent.Location = new System.Drawing.Point(14, 118);
      this.aDataGridViewContent.Margin = new System.Windows.Forms.Padding(4);
      this.aDataGridViewContent.MultiSelect = false;
      this.aDataGridViewContent.Name = "aDataGridViewContent";
      this.aDataGridViewContent.ReadOnly = true;
      this.aDataGridViewContent.RowHeadersVisible = false;
      this.aDataGridViewContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.aDataGridViewContent.Size = new System.Drawing.Size(450, 383);
      this.aDataGridViewContent.TabIndex = 5;
      this.aDataGridViewContent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.aDataGridViewContent_CellDoubleClick);
      this.aDataGridViewContent.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.aDataGridViewContent_CellMouseClick);
      // 
      // Projektname
      // 
      this.Projektname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Projektname.DataPropertyName = "Name";
      this.Projektname.HeaderText = "Projektname";
      this.Projektname.Name = "Projektname";
      this.Projektname.ReadOnly = true;
      this.Projektname.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      // 
      // Branchname
      // 
      this.Branchname.DataPropertyName = "Branch";
      this.Branchname.HeaderText = "Branchname";
      this.Branchname.Name = "Branchname";
      this.Branchname.ReadOnly = true;
      this.Branchname.ToolTipText = "Der Branch auf dem derzeit lokal gearbeitet wird";
      // 
      // Changes
      // 
      this.Changes.DataPropertyName = "Changes";
      this.Changes.HeaderText = "✏";
      this.Changes.Name = "Changes";
      this.Changes.ReadOnly = true;
      this.Changes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.Changes.ToolTipText = "Lokale Änderungen (noch nicht Commitet)";
      this.Changes.Width = 50;
      // 
      // LocalDifferences
      // 
      this.LocalDifferences.DataPropertyName = "LocalDifferences";
      this.LocalDifferences.HeaderText = "⤴";
      this.LocalDifferences.Name = "LocalDifferences";
      this.LocalDifferences.ReadOnly = true;
      this.LocalDifferences.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.LocalDifferences.ToolTipText = "Lokale Änderungen (Commitet aber nicht gepusht)";
      this.LocalDifferences.Width = 50;
      // 
      // RemoteDifferences
      // 
      this.RemoteDifferences.DataPropertyName = "RemoteDifferences";
      this.RemoteDifferences.HeaderText = "⤵";
      this.RemoteDifferences.Name = "RemoteDifferences";
      this.RemoteDifferences.ReadOnly = true;
      this.RemoteDifferences.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.RemoteDifferences.ToolTipText = "Remote Änderungen vom Server";
      this.RemoteDifferences.Width = 50;
      // 
      // aButtonCheck
      // 
      this.aButtonCheck.Location = new System.Drawing.Point(14, 40);
      this.aButtonCheck.Margin = new System.Windows.Forms.Padding(4);
      this.aButtonCheck.Name = "aButtonCheck";
      this.aButtonCheck.Size = new System.Drawing.Size(162, 27);
      this.aButtonCheck.TabIndex = 3;
      this.aButtonCheck.Text = "Prüfe Ordner auf Updates";
      this.aButtonCheck.Click += new System.EventHandler(this.aButtonCheck_Click);
      // 
      // aLabelStatus
      // 
      this.aLabelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.aLabelStatus.Location = new System.Drawing.Point(331, 40);
      this.aLabelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.aLabelStatus.Name = "aLabelStatus";
      this.aLabelStatus.Size = new System.Drawing.Size(134, 27);
      this.aLabelStatus.TabIndex = 4;
      this.aLabelStatus.Text = "✏0 - ⤴0 - ⤵0";
      this.aLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // aButtonClose
      // 
      this.aButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.aButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.aButtonClose.Location = new System.Drawing.Point(14, 521);
      this.aButtonClose.Margin = new System.Windows.Forms.Padding(4);
      this.aButtonClose.Name = "aButtonClose";
      this.aButtonClose.Size = new System.Drawing.Size(90, 27);
      this.aButtonClose.TabIndex = 6;
      this.aButtonClose.Text = "Schließen";
      this.aButtonClose.Click += new System.EventHandler(this.aButtonClose_Click);
      // 
      // buttonSearch
      // 
      this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonSearch.Location = new System.Drawing.Point(429, 17);
      this.buttonSearch.Margin = new System.Windows.Forms.Padding(4);
      this.buttonSearch.Name = "buttonSearch";
      this.buttonSearch.Size = new System.Drawing.Size(35, 20);
      this.buttonSearch.TabIndex = 2;
      this.buttonSearch.Text = "...";
      this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
      // 
      // checkBoxCheckOnStart
      // 
      this.checkBoxCheckOnStart.AutoSize = true;
      this.checkBoxCheckOnStart.Location = new System.Drawing.Point(15, 69);
      this.checkBoxCheckOnStart.Name = "checkBoxCheckOnStart";
      this.checkBoxCheckOnStart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.checkBoxCheckOnStart.Size = new System.Drawing.Size(99, 17);
      this.checkBoxCheckOnStart.TabIndex = 7;
      this.checkBoxCheckOnStart.Text = "Check bei Start";
      this.checkBoxCheckOnStart.UseVisualStyleBackColor = true;
      // 
      // progressBarStatusCheck
      // 
      this.progressBarStatusCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBarStatusCheck.Location = new System.Drawing.Point(15, 92);
      this.progressBarStatusCheck.Name = "progressBarStatusCheck";
      this.progressBarStatusCheck.Size = new System.Drawing.Size(449, 17);
      this.progressBarStatusCheck.TabIndex = 8;
      // 
      // backgroundWorkerUpdate
      // 
      this.backgroundWorkerUpdate.WorkerReportsProgress = true;
      this.backgroundWorkerUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUpdate_DoWork);
      this.backgroundWorkerUpdate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerUpdate_ProgressChanged);
      this.backgroundWorkerUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUpdate_RunWorkerCompleted);
      // 
      // checkBoxHideEqualRepos
      // 
      this.checkBoxHideEqualRepos.AutoSize = true;
      this.checkBoxHideEqualRepos.Location = new System.Drawing.Point(120, 69);
      this.checkBoxHideEqualRepos.Name = "checkBoxHideEqualRepos";
      this.checkBoxHideEqualRepos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.checkBoxHideEqualRepos.Size = new System.Drawing.Size(203, 17);
      this.checkBoxHideEqualRepos.TabIndex = 9;
      this.checkBoxHideEqualRepos.Text = "Repos ohne Änderungen ausblenden";
      this.checkBoxHideEqualRepos.UseVisualStyleBackColor = true;
      this.checkBoxHideEqualRepos.CheckedChanged += new System.EventHandler(this.checkBoxHideEqualRepos_CheckedChanged);
      // 
      // contextMenuStripInteraction
      // 
      this.contextMenuStripInteraction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateZeileToolStripMenuItem,
            this.detailsToolStripMenuItem,
            this.öffneRepositoryOrdnerToolStripMenuItem,
            this.projektAufGiteaÖffnenToolStripMenuItem,
            this.mitGitExtensionsÖffnenToolStripMenuItem});
      this.contextMenuStripInteraction.Name = "contextMenuStrip1";
      this.contextMenuStripInteraction.Size = new System.Drawing.Size(218, 114);
      // 
      // updateZeileToolStripMenuItem
      // 
      this.updateZeileToolStripMenuItem.Name = "updateZeileToolStripMenuItem";
      this.updateZeileToolStripMenuItem.ShortcutKeyDisplayString = "U";
      this.updateZeileToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
      this.updateZeileToolStripMenuItem.Text = "&Update Zeile";
      this.updateZeileToolStripMenuItem.Click += new System.EventHandler(this.updateZeileToolStripMenuItem_Click);
      // 
      // detailsToolStripMenuItem
      // 
      this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
      this.detailsToolStripMenuItem.ShortcutKeyDisplayString = "D";
      this.detailsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
      this.detailsToolStripMenuItem.Text = "&Details";
      this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
      // 
      // öffneRepositoryOrdnerToolStripMenuItem
      // 
      this.öffneRepositoryOrdnerToolStripMenuItem.Name = "öffneRepositoryOrdnerToolStripMenuItem";
      this.öffneRepositoryOrdnerToolStripMenuItem.ShortcutKeyDisplayString = "R";
      this.öffneRepositoryOrdnerToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
      this.öffneRepositoryOrdnerToolStripMenuItem.Text = "Öffne &Repository Ordner";
      this.öffneRepositoryOrdnerToolStripMenuItem.Click += new System.EventHandler(this.öffneRepositoryOrdnerToolStripMenuItem_Click);
      // 
      // projektAufGiteaÖffnenToolStripMenuItem
      // 
      this.projektAufGiteaÖffnenToolStripMenuItem.Name = "projektAufGiteaÖffnenToolStripMenuItem";
      this.projektAufGiteaÖffnenToolStripMenuItem.ShortcutKeyDisplayString = "G";
      this.projektAufGiteaÖffnenToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
      this.projektAufGiteaÖffnenToolStripMenuItem.Text = "Projekt auf &Gitea öffnen";
      this.projektAufGiteaÖffnenToolStripMenuItem.Click += new System.EventHandler(this.projektAufGiteaÖffnenToolStripMenuItem_Click);
      // 
      // mitGitExtensionsÖffnenToolStripMenuItem
      // 
      this.mitGitExtensionsÖffnenToolStripMenuItem.Name = "mitGitExtensionsÖffnenToolStripMenuItem";
      this.mitGitExtensionsÖffnenToolStripMenuItem.ShortcutKeyDisplayString = "E";
      this.mitGitExtensionsÖffnenToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
      this.mitGitExtensionsÖffnenToolStripMenuItem.Text = "mit Git&Extensions öffnen";
      this.mitGitExtensionsÖffnenToolStripMenuItem.Click += new System.EventHandler(this.mitGitExtensionsÖffnenToolStripMenuItem_Click);
      // 
      // GitReposMain
      // 
      this.AcceptButton = this.aButtonCheck;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.aButtonClose;
      this.ClientSize = new System.Drawing.Size(479, 563);
      this.Controls.Add(this.checkBoxHideEqualRepos);
      this.Controls.Add(this.progressBarStatusCheck);
      this.Controls.Add(this.checkBoxCheckOnStart);
      this.Controls.Add(this.buttonSearch);
      this.Controls.Add(this.aButtonClose);
      this.Controls.Add(this.aLabelStatus);
      this.Controls.Add(this.aButtonCheck);
      this.Controls.Add(this.aDataGridViewContent);
      this.Controls.Add(this.aTextBoxGitPath);
      this.Controls.Add(this.aLabelGitPfad);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
      this.MinimumSize = new System.Drawing.Size(495, 602);
      this.Name = "GitReposMain";
      this.Text = "Git Repository Tool";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GitReposMain_FormClosing);
      this.Load += new System.EventHandler(this.GitReposMain_Load);
      this.Shown += new System.EventHandler(this.GitReposMain_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.aDataGridViewContent)).EndInit();
      this.contextMenuStripInteraction.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label aLabelGitPfad;
    private System.Windows.Forms.TextBox aTextBoxGitPath;
    private System.Windows.Forms.DataGridView aDataGridViewContent;
    private System.Windows.Forms.Button aButtonCheck;
    private System.Windows.Forms.Label aLabelStatus;
    private System.Windows.Forms.Button aButtonClose;
    private System.Windows.Forms.Button buttonSearch;
    private System.Windows.Forms.CheckBox checkBoxCheckOnStart;
    private System.Windows.Forms.ProgressBar progressBarStatusCheck;
    private System.ComponentModel.BackgroundWorker backgroundWorkerUpdate;
    private System.Windows.Forms.CheckBox checkBoxHideEqualRepos;
    private System.Windows.Forms.ContextMenuStrip contextMenuStripInteraction;
    private System.Windows.Forms.DataGridViewTextBoxColumn Projektname;
    private System.Windows.Forms.DataGridViewTextBoxColumn Branchname;
    private System.Windows.Forms.DataGridViewTextBoxColumn Changes;
    private System.Windows.Forms.DataGridViewTextBoxColumn LocalDifferences;
    private System.Windows.Forms.DataGridViewTextBoxColumn RemoteDifferences;
    private System.Windows.Forms.ToolStripMenuItem updateZeileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem öffneRepositoryOrdnerToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem projektAufGiteaÖffnenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mitGitExtensionsÖffnenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
  }
}

