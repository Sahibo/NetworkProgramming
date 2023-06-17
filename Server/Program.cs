using System;
using System.IO;
using System.Net;

class Program
{
    static void Main()
    {
        
        string ftpHost = "ftp.sahibo.com";
        string ftpUsername = "anonymous";
        string ftpPassword = ""; 

        string localFilePath = @"C:\Users\sahib\source\repos\NetworkProgramming\FtpServer\test.txt";

        string remoteFilePath = "/test.txt";

        DownloadFileFromFtpServer(ftpHost, ftpUsername, ftpPassword, remoteFilePath, localFilePath);

        UploadFileToFtpServer(ftpHost, ftpUsername, ftpPassword, localFilePath, remoteFilePath);

        Console.WriteLine("Done!");
    }

    static void DownloadFileFromFtpServer(string host, string username, string password, string remoteFilePath, string localFilePath)
    {
        using (WebClient client = new WebClient())
        {
            client.Credentials = new NetworkCredential(username, password);
            client.DownloadFile($"ftp://{host}/{remoteFilePath}", localFilePath);
        }
    }

    static void UploadFileToFtpServer(string host, string username, string password, string localFilePath, string remoteFilePath)
    {
        using (WebClient client = new WebClient())
        {
            client.Credentials = new NetworkCredential(username, password);
            client.UploadFile($"ftp://{host}/{remoteFilePath}", localFilePath);
        }
    }
}