using System;
using System.Web.UI;

public partial class index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        int _error = Util.CopyFileServerToServer(@"D:\Programming\Profile\Content\FileUpload\UploadDocument", "2559000002Profile20-01-2016@14-28-58.jpg", @"\\10.41.101.31\f\STWeb\StudentWeb\Resources\images", "2559000002Profile20-01-2016@14-28-58.jpg");

        string _command = "COPY D:\\Programming\\Profile\\Content\\FileUpload\\UploadDocument\\2559000002Profile20-01-2016@14-28-58.jpg \\\\10.41.101.31\\f\\STWeb\\StudentWeb\\Resources\\images";
        int _errorCommand = Util.ExecuteCommand(_command, 30000);

        int _connServer = Util.ConnectServerToServer(@"\\localhost\IPC$\Profile\Content\FileUpload\UploadDocument", "", "", UDSStaffUtil._mySiteServerPictureStudent, "cccbd", "46900000");

        int _timeOut = 30000;

        string _command = "NET USE " + @"\\localhost\Profile\Content\FileUpload\UploadDocument";
        int _errorCommand1 = Util.ExecuteCommand(_command, _timeOut);

        Response.Write(_errorCommand);
        Use ProcessStartInfo class.
        ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", "/C COPY D:\\Programming\\Profile\\Content\\FileUpload\\UploadDocument\\2559000002Profile20-01-2016@14-28-58.jpg D:\\");
        startInfo.CreateNoWindow = true;
        startInfo.UseShellExecute = true;
        startInfo.WindowStyle = ProcessWindowStyle.Normal;
        startInfo.Arguments = "COPY D:\\Programming\\Profile\\Content\\FileUpload\\UploadDocument\\2559000002Profile20-01-2016@14-28-58.jpg \\\\10.41.101.31\\f\\STWeb\\StudentWeb\\Resources\\images";
        Process _process = Process.Start(startInfo);
        _process.WaitForExit();
        */
    }
}