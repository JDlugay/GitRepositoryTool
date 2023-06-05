using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitRepositoryTool
{
  public partial class ReposDetails : Form
  {
    Repository mSelectedRepos;
    public ReposDetails(Repository SelectedRepos)
    {
      InitializeComponent();
      mSelectedRepos = SelectedRepos;
      Text = string.Format("{0} Detailübersicht", SelectedRepos.Name);
    }

    private void ReposDetails_Load(object sender, EventArgs e)
    {
      SetzePosition();
      textBoxDetailReport.Text = string.Format("{0}{1}{1}", mSelectedRepos.Name, Environment.NewLine);
      ReportChanges();
    }

    private void ReposDetails_FormClosing(object sender, FormClosingEventArgs e)
    {
      MerkePosition();
    }

    public void ReportChanges()
    {
      List<string> llDetailReport = new List<string>();
      var lGetReportProcess = new Process
      {
        StartInfo = new ProcessStartInfo
        {
          WorkingDirectory = mSelectedRepos.Path,
          FileName = "git",
          Arguments = "status ",
          UseShellExecute = false,
          RedirectStandardOutput = true,
          CreateNoWindow = true
        }
      };
      lGetReportProcess.Start();
      while (!lGetReportProcess.StandardOutput.EndOfStream)
      {
        llDetailReport.Add(lGetReportProcess.StandardOutput.ReadLine());
      }
      foreach (string lsLine in llDetailReport)
      {
        textBoxDetailReport.Text += lsLine + Environment.NewLine;
      }
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

    private void buttonClose_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
