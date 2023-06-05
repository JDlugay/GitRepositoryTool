using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitRepositoryTool
{
  public partial class GitReposMain : Form
  {
    List<Repository> mRepositories;
    Repository mSelectedRepository;
    DataGridViewRow mSelectedRow;
    public GitReposMain()
    {
      InitializeComponent();
      aDataGridViewContent.AutoGenerateColumns = false;
    }

    private void GitReposMain_Load(object sender, EventArgs e)
    {
      SetzePfad();
      SetzePosition();
      mRepositories = LoadRepositories();
    }

    private bool SetzeCheckBoxStatus()
    {
      RegistryKey mainKey = Registry.CurrentUser;
      string lsSubKey = @"Software\Novaline\GitRepositoryTool\Dialoge\";
      string lsSubKeyName = Name;
      lsSubKey += GetType().Name;
      RegistryKey subKey = mainKey.CreateSubKey(lsSubKey);
      try
      {
        string lsvalue = (string)subKey.GetValue(lsSubKeyName + "StartupCheck") ?? "";
        checkBoxCheckOnStart.Checked = lsvalue.ToUpper() == "TRUE";
        lsvalue = (string)subKey.GetValue(lsSubKeyName + "FilterRows") ?? "";
        checkBoxHideEqualRepos.Checked = lsvalue.ToUpper() == "TRUE";
      }
      catch { }
      return checkBoxCheckOnStart.Checked;
    }

    private void SetzePfad()
    {
      RegistryKey mainKey = Registry.CurrentUser;
      string lsSubKey = @"Software\Novaline\GitRepositoryTool\Dialoge\";
      string lsSubKeyName = Name;
      lsSubKey += GetType().Name;
      RegistryKey subKey = mainKey.CreateSubKey(lsSubKey);
      try
      {
        string lsvalue = (string)subKey.GetValue(lsSubKeyName + "Pfad") ?? @"C:\DotNet\Projekte\Git";
        aTextBoxGitPath.Text = lsvalue;
      }
      catch { }
    }

    private void MerkePfad()
    {
      RegistryKey mainKey = Registry.CurrentUser;
      string lsSubKey = @"Software\Novaline\GitRepositoryTool\Dialoge\";
      string lsSubKeyName = Name;
      lsSubKey += GetType().Name;
      RegistryKey subKey = mainKey.CreateSubKey(lsSubKey);
      subKey.SetValue(lsSubKeyName + "Pfad", aTextBoxGitPath.Text);
    }

    private void GitReposMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      MerkePosition();
      MerkeCheckBoxStatus();
      MerkePfad();
    }

    private void MerkeCheckBoxStatus()
    {
      RegistryKey mainKey = Registry.CurrentUser;
      string lsSubKey = @"Software\Novaline\GitRepositoryTool\Dialoge\";
      string lsSubKeyName = Name;
      lsSubKey += GetType().Name;
      RegistryKey subKey = mainKey.CreateSubKey(lsSubKey);
      subKey.SetValue(lsSubKeyName + "StartupCheck", checkBoxCheckOnStart.Checked ? "TRUE" : "FALSE");
      subKey.SetValue(lsSubKeyName + "FilterRows", checkBoxHideEqualRepos.Checked ? "TRUE" : "FALSE");
    }


    private void aButtonClose_Click(object sender, EventArgs e)
    {
      Close();
    }


    private void aButtonCheck_Click(object sender, EventArgs e)
    {
      mRepositories = LoadRepositories();
      CheckRepositories();
    }

    private void CheckRepositories()
    {
      if (mRepositories.Count > 0)
      {
        aButtonCheck.Enabled = false;
        checkBoxCheckOnStart.Enabled = false;
        checkBoxHideEqualRepos.Enabled = false;
        buttonSearch.Enabled = false;
        aLabelStatus.BackColor = Color.FromArgb(240, 240, 240);
        aLabelStatus.Text = "✏0 - ⤴0 - ⤵0";
        Cursor = Cursors.WaitCursor;
        mRepositories = LoadRepositories();
        progressBarStatusCheck.Minimum = 1;
        progressBarStatusCheck.Maximum = mRepositories.Count;
        progressBarStatusCheck.Value = 1;
        progressBarStatusCheck.Step = 1;
        backgroundWorkerUpdate.RunWorkerAsync();
      }
    }

    private List<Repository> LoadRepositories()
    {
      string[] lsPaths = aTextBoxGitPath.Text.Split(';');
      string[] lInvalidPaths = lsPaths.Where(s => !Directory.Exists(s)).ToArray();
      List<Repository> lRepositories = new List<Repository>();
      if (lInvalidPaths.Length > 0)
      {
        string lsInvalidPaths = string.Join(Environment.NewLine, lInvalidPaths);
        MessageBox.Show($"Folgende Pfade sind invalide: {Environment.NewLine}{lsInvalidPaths}");
        return lRepositories;
      }
      foreach (string lsPath in lsPaths)
      {
        string[] lsContent = Directory.GetDirectories(lsPath);
        foreach (string lscurrent in lsContent)
        {
          if (Directory.Exists(Path.Combine(lscurrent, ".git")))
          {
            Repository current = new Repository(lscurrent);
            current.GetBranch();
            lRepositories.Add(current);
          }
        }
      }
      aDataGridViewContent.DataSource = new List<Repository>(lRepositories);
      return lRepositories;
    }

    private void UpdateRepository(Repository lRepository)
    {
      lRepository.CountChanges();
      lRepository.GetLocalChanges();
      lRepository.GetRemoteChanges();
      lRepository.GetBranch();
    }

    private void aTextBoxGitPath_TextChanged(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(aTextBoxGitPath.Text))
      {
        aButtonCheck.Enabled = false;
      }
      else
      {
        aButtonCheck.Enabled = true;
      }
    }

    private void buttonSearch_Click(object sender, EventArgs e)
    {
      GFolderBrowserDialog lDlg = new GFolderBrowserDialog();
      lDlg.InitialDirectory = aTextBoxGitPath.Text;
      if (DialogResult.OK == lDlg.ShowDialog())
        aTextBoxGitPath.Text = lDlg.FileName;
    }

    private void MerkePosition()
    {
      if (WindowState == FormWindowState.Minimized)
        return;
      RegistryKey mainKey = Registry.CurrentUser;
      string lsSubKey = @"Software\Novaline\GitRepositoryTool\Dialoge\";
      string lsSubKeyName = Name;
      lsSubKey += GetType().Name;
      RegistryKey subKey = mainKey.CreateSubKey(lsSubKey);
      subKey.SetValue(lsSubKeyName + "TOP", Top);
      subKey.SetValue(lsSubKeyName + "LEFT", Left);
      subKey.SetValue(lsSubKeyName + "WIDTH", Width);
      subKey.SetValue(lsSubKeyName + "HEIGHT", Height);
    }
    private void SetzePosition()
    {
      RegistryKey mainKey = Registry.CurrentUser;
      string lsSubKey = @"Software\Novaline\GitRepositoryTool\Dialoge\";
      string lsSubKeyName = Name;
      lsSubKey += GetType().Name;
      RegistryKey subKey = mainKey.CreateSubKey(lsSubKey);
      try
      {
        if (subKey.GetValue(lsSubKeyName + "TOP") == null)
          return;



        Top = (int)subKey.GetValue(lsSubKeyName + "TOP");
        Left = (int)subKey.GetValue(lsSubKeyName + "LEFT");
        Width = (int)subKey.GetValue(lsSubKeyName + "WIDTH");
        Height = (int)subKey.GetValue(lsSubKeyName + "HEIGHT");
      }
      catch { }
    }

    private void GitReposMain_Shown(object sender, EventArgs e)
    {
      if (SetzeCheckBoxStatus())
        CheckRepositories();
    }

    private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
    {
      Parallel.ForEach(mRepositories, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 }, (r) => { UpdateRepository(r); backgroundWorkerUpdate.ReportProgress(0); });
    }

    private void backgroundWorkerUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBarStatusCheck.PerformStep();
    }

    private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      FilterRepos();
      SetColor();
    }

    private void SetColor()
    {
      foreach (DataGridViewRow lRow in aDataGridViewContent.Rows)
      {
        Repository lRepository = lRow.DataBoundItem as Repository;
        if (lRepository.Changes == 0 && lRepository.LocalDifferences == 0 && lRepository.RemoteDifferences == 0)
        {
          lRow.DefaultCellStyle.BackColor = Color.Lime;
        }
        else if ((lRepository.Changes > 0 && lRepository.LocalDifferences >= 0 && lRepository.RemoteDifferences == 0)
          || (lRepository.Changes >= 0 && lRepository.LocalDifferences > 0 && lRepository.RemoteDifferences == 0))
        {
          lRow.DefaultCellStyle.BackColor = Color.DeepSkyBlue;
        }
        else if (lRepository.Changes == 0 && lRepository.LocalDifferences == 0 && lRepository.RemoteDifferences > 0)
        {
          lRow.DefaultCellStyle.BackColor = Color.Gold;
        }
        else if ((lRepository.Changes > 0 || lRepository.LocalDifferences > 0) && lRepository.RemoteDifferences > 0)
        {
          lRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 28, 28);
        }
      }

      if (mRepositories.Sum(r => r.Changes) == 0 && mRepositories.Sum(r => r.LocalDifferences) == 0 && mRepositories.Sum(r => r.RemoteDifferences) == 0)
      {
        aLabelStatus.BackColor = Color.Lime;
      }
      else if ((mRepositories.Sum(r => r.Changes) > 0 && mRepositories.Sum(r => r.LocalDifferences) >= 0 && mRepositories.Sum(r => r.RemoteDifferences) == 0)
        || (mRepositories.Sum(r => r.Changes) >= 0 && mRepositories.Sum(r => r.LocalDifferences) > 0 && mRepositories.Sum(r => r.RemoteDifferences) == 0))
      {
        aLabelStatus.BackColor = Color.DeepSkyBlue;
      }
      else if (mRepositories.Sum(r => r.Changes) == 0 && mRepositories.Sum(r => r.LocalDifferences) == 0 && mRepositories.Sum(r => r.RemoteDifferences) > 0)
      {
        aLabelStatus.BackColor = Color.Gold;
      }
      else if ((mRepositories.Sum(r => r.Changes) > 0 || mRepositories.Sum(r => r.LocalDifferences) > 0) && mRepositories.Sum(r => r.RemoteDifferences) > 0)
      {
        aLabelStatus.BackColor = Color.FromArgb(255, 28, 28);
      }
      aLabelStatus.Text = string.Format("✏{0} - ⤴{1} - ⤵{2}", mRepositories.Sum(r => r.Changes), mRepositories.Sum(r => r.LocalDifferences), mRepositories.Sum(r => r.RemoteDifferences));
      aDataGridViewContent.ClearSelection();
      checkBoxCheckOnStart.Enabled = true;
      checkBoxHideEqualRepos.Enabled = true;
      aButtonCheck.Enabled = true;
      buttonSearch.Enabled = true;
      Cursor = Cursors.Default;
    }

    private void updateZeileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      checkBoxCheckOnStart.Enabled = false;
      checkBoxHideEqualRepos.Enabled = false;
      aLabelStatus.BackColor = Color.FromArgb(240, 240, 240);
      aLabelStatus.Text = "✏0 - ⤴0 - ⤵0";
      Cursor = Cursors.WaitCursor;
      UpdateRepository(mSelectedRepository);
      aDataGridViewContent.InvalidateRow(mSelectedRow.Index);
      SetColor();
    }

    private void öffneRepositoryOrdnerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start(mSelectedRepository.Path);
    }

    private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DetailedReport();
    }

    private void DetailedReport()
    {
      ReposDetails lDetails = new ReposDetails(mSelectedRepository);
      lDetails.ShowDialog();
    }

    private void projektAufGiteaÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      mSelectedRepository.GetURL();
      Process.Start(mSelectedRepository.RemoteURL);
    }

    private void mitGitExtensionsÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start("gitex", "browse " + mSelectedRepository.Path);
    }

    private void aDataGridViewContent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right && e.ColumnIndex >= 0 && e.RowIndex >= 0)
      {
        mSelectedRepository = aDataGridViewContent.Rows[e.RowIndex].DataBoundItem as Repository;
        mSelectedRow = aDataGridViewContent.Rows[e.RowIndex];
        contextMenuStripInteraction.Show(Cursor.Position);
      }
    }

    private void aDataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
      {
        mSelectedRepository = aDataGridViewContent.Rows[e.RowIndex].DataBoundItem as Repository;
        mSelectedRow = aDataGridViewContent.Rows[e.RowIndex];
        DetailedReport();
      }
    }

    private void checkBoxHideEqualRepos_CheckedChanged(object sender, EventArgs e)
    {
      FilterRepos();
      SetColor();
    }

    private void FilterRepos()
    {
      if (checkBoxHideEqualRepos.Checked)
      {
        aDataGridViewContent.DataSource = mRepositories.Where(r => r.HasChanges).ToList();
      }
      else
      {
        aDataGridViewContent.DataSource = mRepositories;
      }
    }
  }
}
