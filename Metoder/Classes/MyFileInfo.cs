namespace Metoder.Classes;

public class MyFileInfo
{
    private long _fileSize;
    private string _fileName = String.Empty;

    public long FileSize //{ get; set; }
    {
        get
        {
            return _fileSize;
        }
        set
        {
            _fileSize = value;
        }
    }

    public string FileName
    {
        get
        {
            return _fileName ?? String.Empty;
        }
        set
        {
            _fileName = value;
        }
    }

    public MyFileInfo()
    {
        
    }
}