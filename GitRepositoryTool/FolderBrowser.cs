using System;
using System.Reflection;
using System.Windows.Forms;

namespace GitRepositoryTool
{
  public class GFolderBrowserDialog
  {
    // This class modifies the private .NET class through reflection to create the modern folder browser dialog.
    private const string FoldersFilter = "Folders|\n";

    private const BindingFlags CustomBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    private static readonly Assembly WindowsFormsAssembly = typeof(FileDialog).Assembly;
    private static readonly Type FileDialogType = WindowsFormsAssembly.GetType("System.Windows.Forms.FileDialogNative+IFileDialog");
    private static readonly MethodInfo CreateVistaDialogMethodInfo = typeof(OpenFileDialog).GetMethod("CreateVistaDialog", CustomBindingFlags);
    private static readonly MethodInfo OnBeforeVistaDialogMethodInfo = typeof(OpenFileDialog).GetMethod("OnBeforeVistaDialog", CustomBindingFlags);
    private static readonly MethodInfo GetOptionsMethodInfo = typeof(FileDialog).GetMethod("GetOptions", CustomBindingFlags);
    private static readonly MethodInfo SetOptionsMethodInfo = FileDialogType.GetMethod("SetOptions", CustomBindingFlags);
    private static readonly uint FosPickFoldersBitFlag = (uint)WindowsFormsAssembly
      .GetType("System.Windows.Forms.FileDialogNative+FOS")
      .GetField("FOS_PICKFOLDERS")
      .GetValue(null);
    private static readonly ConstructorInfo VistaDialogEventsConstructorInfo = WindowsFormsAssembly
      .GetType("System.Windows.Forms.FileDialog+VistaDialogEvents")
      .GetConstructor(CustomBindingFlags, null, new[] { typeof(FileDialog) }, null);
    private static readonly MethodInfo AdviseMethodInfo = FileDialogType.GetMethod("Advise");
    private static readonly MethodInfo UnAdviseMethodInfo = FileDialogType.GetMethod("Unadvise");
    private static readonly MethodInfo ShowMethodInfo = FileDialogType.GetMethod("Show");

    private string msInitialDirectory;

    public string InitialDirectory
    {
      get => string.IsNullOrEmpty(msInitialDirectory) ? Environment.CurrentDirectory : msInitialDirectory;
      set => msInitialDirectory = value;
    }

    public string Title { get; set; } = string.Empty;
    public string FileName { get; private set; } = string.Empty;

    public DialogResult ShowDialog(IWin32Window pWindow = null)
    {
      OpenFileDialog lOpenFileDialog = new OpenFileDialog
      {
        AddExtension = false,
        CheckFileExists = false,
        DereferenceLinks = true,
        Filter = FoldersFilter,
        InitialDirectory = InitialDirectory,
        Multiselect = false,
        Title = Title
      };

      object loFileDialog = CreateVistaDialogMethodInfo.Invoke(lOpenFileDialog, new object[] { });
      OnBeforeVistaDialogMethodInfo.Invoke(lOpenFileDialog, new[] { loFileDialog });
      SetOptionsMethodInfo.Invoke(loFileDialog, new object[] { (uint)GetOptionsMethodInfo.Invoke(lOpenFileDialog, new object[] { }) | FosPickFoldersBitFlag });
      object[] lParameters = { VistaDialogEventsConstructorInfo.Invoke(new object[] { lOpenFileDialog }), 0U };
      AdviseMethodInfo.Invoke(loFileDialog, lParameters);

      try
      {
        int liReturnValue = (int)ShowMethodInfo.Invoke(loFileDialog, new object[] { pWindow?.Handle ?? IntPtr.Zero });

        FileName = lOpenFileDialog.FileName;
        return liReturnValue == 0 ? DialogResult.OK : DialogResult.Cancel;
      }
      finally
      {
        UnAdviseMethodInfo.Invoke(loFileDialog, new[] { lParameters[1] });
      }
    }
  }
}
