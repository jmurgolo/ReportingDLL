Imports System.Windows.Media.Imaging
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Security.Permissions
Imports System.Runtime.InteropServices


Public Class GetImage

    Public Shared Function GetImageFromWeb(ByVal _URL)
        Dim _tmpImage = Nothing

        Try
            ' Open a connection
            Dim myWebPermission As New WebPermission(PermissionState.Unrestricted)
            myWebPermission.Demand()
            Dim _HttpWebRequest As System.Net.HttpWebRequest = CType(System.Net.HttpWebRequest.Create(_URL), System.Net.HttpWebRequest)

            _HttpWebRequest.AllowWriteStreamBuffering = True

            ' You can also specify additional header values like the user agent or the referer: (Optional)
            '_HttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)"
            '_HttpWebRequest.Referer = "http://www.google.com/"

            ' set timeout for 20 seconds (Optional)
            _HttpWebRequest.Timeout = 20000

            ' Request response:
            Dim _WebResponse As System.Net.WebResponse = _HttpWebRequest.GetResponse()

            ' Open data stream:
            Dim _WebStream As System.IO.Stream = _WebResponse.GetResponseStream()

            ' convert webstream to System.Drawing.Image
            _tmpImage = System.Drawing.Image.FromStream(_WebStream)

            ' Cleanup
            _WebResponse.Close()
            _WebResponse.Close()
        Catch _Exception As Exception
            ' Error - Console.WriteLine("Exception caught in process: {0}", _Exception.ToString())
            Throw New Exception("Error discover!" & _Exception.ToString())
            Return _tmpImage
        End Try
        Return _tmpImage
    End Function

    Public Shared Function GetImageFromWebToByteArray(ByVal _URL)
        Dim _tmpImage = Nothing

        Try
            ' Open a connection
            Dim myWebPermission As New WebPermission(PermissionState.Unrestricted)
            myWebPermission.Demand()
            Dim _HttpWebRequest As System.Net.HttpWebRequest = CType(System.Net.HttpWebRequest.Create(_URL), System.Net.HttpWebRequest)

            _HttpWebRequest.AllowWriteStreamBuffering = True

            ' You can also specify additional header values like the user agent or the referer: (Optional)
            '_HttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)"
            '_HttpWebRequest.Referer = "http://www.google.com/"

            ' set timeout for 20 seconds (Optional)
            _HttpWebRequest.Timeout = 20000

            ' Request response:
            Dim _WebResponse As System.Net.WebResponse = _HttpWebRequest.GetResponse()

            ' Open data stream:
            Dim _WebStream As System.IO.Stream = _WebResponse.GetResponseStream()

            ' convert webstream to System.Drawing.Image
            _tmpImage = System.Drawing.Image.FromStream(_WebStream)

            ' Cleanup
            _WebResponse.Close()
            _WebResponse.Close()
        Catch _Exception As Exception
            ' Error - Console.WriteLine("Exception caught in process: {0}", _Exception.ToString())
            Throw New Exception("Error discover!" & _Exception.ToString())
            Return _tmpImage
        End Try

        Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream()
        _tmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim imagedata As Byte()
        imagedata = ms.GetBuffer()

        Return imagedata

    End Function

End Class
