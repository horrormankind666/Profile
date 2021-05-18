using System;
using System.IO;
using System.Web.UI;
using NUtil;

public partial class StudentPictureTransform : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string imagepath = @"D:\StudentPicture\Images";
        string sourcePath = @"D:\StudentPicture\Source";
        int complete = 0;
        int incomplete = 0;
        
        for (int i = 0; i < 100; i++)
        {
            Directory.CreateDirectory(imagepath + "\\" + (i.ToString().Length < 2 ? ("0" + i.ToString()) : i.ToString()));
        }
        
        string[] filePaths = Directory.GetFiles(sourcePath);

        foreach (string fp in filePaths)
        {
            FileInfo file = new FileInfo(fp);
            string fileName = file.Name.Replace(file.Extension, "");

            try
            {
                string folder = Util.GetFolderNameFromStudentId(fileName);
                string newFileName = Util.EncodeToMD5(fileName);
                string newFilePath = (folder + "/" + newFileName + file.Extension);

                File.Copy((sourcePath + "\\" + file.Name), (imagepath + "\\" + folder + "\\" + newFileName + file.Extension), true);

                Response.Write(fileName + " => " + newFilePath + "<br />");

                complete++;
            }
            catch
            {
                Response.Write("incomplete => " + fileName + "<br />");
                incomplete++;
            }
        }

        Response.Write("<br />");
        Response.Write(filePaths.GetLength(0).ToString() + " Files<br />");
        Response.Write("Complete " + complete + " Files<br />");
        Response.Write("Incomplete " + incomplete + " Files");
    }
}