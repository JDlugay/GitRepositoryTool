using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRepositoryTool
{
  public class Repository
  {
    public string Name { get; set; }
    public string RemoteURL { get; set; }
    public string Path { get; set; }
    public string Branch { get; set; }
    public int Changes { get; set; }
    public int LocalDifferences { get; set; }
    public int RemoteDifferences { get; set; }
    public bool HasChanges => Changes > 0 || LocalDifferences > 0 || RemoteDifferences > 0;
    public Repository(string psPath)
    {
      Path = psPath;
      Name = new DirectoryInfo(Path).Name;
    }

    public void GetBranch()
    {
      var lGetBranchProcess = new Process
      {
        StartInfo = new ProcessStartInfo
        {
          WorkingDirectory = Path,
          FileName = "git",
          Arguments = "branch",
          UseShellExecute = false,
          RedirectStandardOutput = true,
          CreateNoWindow = true
        }
      };
      lGetBranchProcess.Start();
      while (!lGetBranchProcess.StandardOutput.EndOfStream)
      {
        string lsvalue = lGetBranchProcess.StandardOutput.ReadLine();
        if (lsvalue.StartsWith("*"))
        {
          Branch = lsvalue.Replace("* ", string.Empty);
        }
      }
    }
    public void GetURL()
    {
      var lGetURLProcess = new Process
      {
        StartInfo = new ProcessStartInfo
        {
          WorkingDirectory = Path,
          FileName = "git",
          Arguments = "remote -v",
          UseShellExecute = false,
          RedirectStandardOutput = true,
          CreateNoWindow = true
        }
      };
      lGetURLProcess.Start();
      while (!lGetURLProcess.StandardOutput.EndOfStream)
      {
        string lsValue = lGetURLProcess.StandardOutput.ReadLine();
        if (lsValue.Contains("origin\t"))
        {
          lsValue = lsValue.Replace("origin\t", string.Empty);
        }
        if (lsValue.Contains(" (fetch)"))
        {
          lsValue = lsValue.Replace(" (fetch)", string.Empty);
        }
        if (lsValue.Contains(" (push)"))
        {
          lsValue = lsValue.Replace(" (push)", string.Empty);
        }
        RemoteURL = lsValue;
      }
    }

    public void CountChanges()
    {
      Changes = 0;
      var lCountDiffProcess = new Process
      {
        StartInfo = new ProcessStartInfo
        {
          WorkingDirectory = Path,
          FileName = "git",
          Arguments = "status --porcelain=v1 --untracked-files",
          UseShellExecute = false,
          RedirectStandardOutput = true,
          CreateNoWindow = true
        }
      };
      lCountDiffProcess.Start();
      while (!lCountDiffProcess.StandardOutput.EndOfStream)
      {
        lCountDiffProcess.StandardOutput.ReadLine();
        Changes++;
      }
    }

    public void GetLocalChanges()
    {
      LocalDifferences = 0;
      Process lGetLocalProcess = new Process
      {
        StartInfo = new ProcessStartInfo
        {
          WorkingDirectory = Path,
          FileName = "git",
          Arguments = "rev-list origin..HEAD",
          UseShellExecute = false,
          RedirectStandardOutput = true,
          CreateNoWindow = true
        }
      };
      lGetLocalProcess.Start();
      while (!lGetLocalProcess.StandardOutput.EndOfStream)
      {
        lGetLocalProcess.StandardOutput.ReadLine();
        LocalDifferences++;
      }
    }

    public void GetRemoteChanges()
    {
      RemoteDifferences = 0;
      Process lFetchProcess = new Process
      {
        StartInfo = new ProcessStartInfo
        {
          WorkingDirectory = Path,
          FileName = "git",
          Arguments = "fetch",
          UseShellExecute = false,
          RedirectStandardOutput = true,
          CreateNoWindow = true
        }
      };
      lFetchProcess.Start();
      lFetchProcess.WaitForExit();
      Process lGetOriginProcess = new Process
      {
        StartInfo = new ProcessStartInfo
        {
          WorkingDirectory = Path,
          FileName = "git",
          Arguments = "rev-list HEAD..origin",
          UseShellExecute = false,
          RedirectStandardOutput = true,
          CreateNoWindow = true
        }
      };
      lGetOriginProcess.Start();
      while (!lGetOriginProcess.StandardOutput.EndOfStream)
      {
        lGetOriginProcess.StandardOutput.ReadLine();
        RemoteDifferences++;
      }
    }
  }
}
