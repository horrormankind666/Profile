// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๓๑/๐๘/๒๕๕๘>
// Modify date  : <๑๗/๐๕/๒๕๕๙>
// Description  : <หน้าใช้งานเกี่ยวกับการอัพโหลดไฟล์>
// =============================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NUtil;

public partial class UDSStaffUploadFile : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _section = Request.Form["uploadfile-section"];
        string _personId = Request.Form["uploadfile-personid"];
        string _fileName = String.Empty;
        string _fileExtension = String.Empty;
        string _fileDelete = String.Empty;
        string _sourceFile = String.Empty;
        int _error = 0;
        int _width = 0;
        int _height = 0;
        int _widthShow = 0;
        int _heightShow = 0;
        int _maxWidth = 0;
        int _maxHeight = 0;
        float _ratio = 0;
        Dictionary<string, object> _fileAttribute = UDSStaffUploadSubmitDocumentUtil.GetFileAttribute(_section);
        Dictionary<string, object> _widthheightImage = new Dictionary<string, object>();
        StringBuilder _uploadfileResult = new StringBuilder();

        try
        {
            Bitmap _sourceImage = new Bitmap(Request.Files[_section.ToLower() + "-browse-uploadfile"].InputStream);

            _width = _sourceImage.Width;
            _height = _sourceImage.Height;
            _maxWidth = (int)_fileAttribute["Width"];
            _maxHeight = (int)_fileAttribute["Height"];
            _error = (_width >= _maxWidth && _height >= _maxHeight ? 0 : 2);

            if (_error.Equals(0))
            {
                _widthheightImage = GetWidthHeightImage(_width, _height, _maxWidth, _maxHeight);
                _width = (int)_widthheightImage["Width"];
                _height = (int)_widthheightImage["Height"];

                Bitmap _destImage = new Bitmap(_width, _height);
                Graphics _objGraphic = Graphics.FromImage(_destImage);

                _objGraphic.SmoothingMode = SmoothingMode.AntiAlias;
                _objGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                _objGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;

                _objGraphic.DrawImage(_sourceImage, new Rectangle(0, 0, _width, _height));

                FileInfo _file = new FileInfo(Request.Files[_section.ToLower() + "-browse-uploadfile"].FileName);
                _fileExtension = _file.Extension;

                _error = Util.RemoveMultipleFiles(UDSStaffUtil._myFileUploadTempPath, ("*" + _personId + _fileAttribute["Section"].ToString() + "*.*"));
                _fileName = (_personId + _fileAttribute["Section"].ToString() + Util.GeneratePasscode(30, 0) + (DateTime.Now).ToString("dd-MM-yyyy@HH-mm-ss", new CultureInfo("en-US")));
                _sourceFile = Server.MapPath(UDSStaffUtil._myFileUploadTempPath + "/" + _fileName + _fileExtension.ToLower());

                _destImage.Save(_sourceFile, Util.ImageProcessUtil.GetImageFormat(_fileExtension.ToLower()));

                _sourceImage.Dispose();
                _destImage.Dispose();
                _objGraphic.Dispose();

                _widthheightImage = GetWidthHeightImage(_width, _height, (int)_fileAttribute["WidthShow"], (int)_fileAttribute["HeightShow"]);
                _width = (int)_widthheightImage["Width"];
                _height = (int)_widthheightImage["Height"];
            }

            _uploadfileResult.AppendFormat("result:'{0}',section:'{1}',fileDir:'{2}',fileName:'{3}',width:'{4}',height:'{5}',widthShow:'{6}',heightShow:'{7}'",
                _error.ToString(),
                _section,
                UDSStaffUtil._myFileUploadTempPath,
                (_fileName + _fileExtension),
                _width,
                _height,
                (int)_fileAttribute["WidthShow"],
                (int)_fileAttribute["HeightShow"]);
        }
        catch
        {
            _error = 1;

            _uploadfileResult.AppendFormat("result:'{0}',section:'{1}',fileDir:'{2}',fileName:'{3}',width:'{4}',height:'{5}',widthShow:'{6}',heightShow:'{7}'",
                _error.ToString(),
                "",
                "",
                "",
                "",
                "",
                "",
                "");
        }

        Response.Write("<script language='javascript' type='text/javascript'>window.parent.Util.tut.tus.sectionAddUpdate.stopUploadFile({" + _uploadfileResult.ToString() + "})</script>");

    }

    private static Dictionary<string, object> GetWidthHeightImage(int _width, int _height, int _maxWidth, int _maxHeight)
    {
        Dictionary<string, object> _widthheightImageResult = new Dictionary<string, object>();
        float _ratio = 0;

        if (_width > _maxWidth)
            _ratio = (float)_width / (float)_maxWidth;

        if (_height > _maxHeight)
            _ratio = (float)_height / (float)_maxHeight;

        if (!_width.Equals(_maxWidth) && !_height.Equals(_maxHeight))
        {
            _width = (int)(_width / _ratio);
            _height = (int)(_height / _ratio);

            if (_width < _maxWidth)
            {
                _ratio = (float)_maxWidth / (float)_width;
                _width = _maxWidth;
                _height = (int)(_height * _ratio);
            }

            if (_height < _maxHeight)
            {
                _ratio = (float)_maxHeight / (float)_height;
                _width = (int)(_width * _ratio);
                _height = _maxHeight;
            }
        }

        _widthheightImageResult.Add("Width", _width);
        _widthheightImageResult.Add("Height", _height);

        return _widthheightImageResult;
    }
}