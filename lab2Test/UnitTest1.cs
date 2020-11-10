using IIG.Core.FileWorkingUtils;
using System;
using System.Diagnostics.Contracts;
using System.IO;
using Xunit;

namespace lab2Test
{
    public class FileWorkerTest
    {
        [Fact]
        public void GetDifferentFileNameTest()
        {
            Assert.Equal("testfile.txt", FileWorker.GetFileName(@"C:\testfile.txt"));
            Assert.Equal("db.accdb", FileWorker.GetFileName(@"C:\testing\db.accdb"));
            Assert.Equal("docfile.docx", FileWorker.GetFileName(@"C:\testing\docfile.docx"));
            Assert.Equal("pdftest.pdf", FileWorker.GetFileName(@"C:\testing\pdftest.pdf"));
            Assert.Equal("archive.zip", FileWorker.GetFileName(@"C:\testing\archive.zip"));
            Assert.Equal("picture.jpg", FileWorker.GetFileName(@"C:\testing\picture.jpg"));
            Assert.Equal("present.pptx", FileWorker.GetFileName(@"C:\testing\present.pptx"));
            Assert.Equal("✔️✔️✔️.txt", FileWorker.GetFileName(@"C:\testing\✔️✔️✔️.txt"));
            Assert.Equal("ґєїъэё.txt", FileWorker.GetFileName(@"C:\testing\ґєїъэё.txt"));
            Assert.Equal("mathcad.xmcd", FileWorker.GetFileName(@"C:\testing\mathcad.xmcd"));
            Assert.Equal("somepng.png", FileWorker.GetFileName(@"C:\testing\somepng.png"));
            Assert.Equal("Відео-файл.mp4", FileWorker.GetFileName(@"C:\testing\Відео-файл.mp4"));
            Assert.Equal("music.mp3", FileWorker.GetFileName(@"C:\testing\music.mp3"));
            Assert.Equal("apktest.apk", FileWorker.GetFileName(@"C:\testing\apktest.apk"));
            Assert.Equal("someexe.exe", FileWorker.GetFileName(@"C:\testing\someexe.exe"));
            Assert.Equal("HUH", FileWorker.GetFileName(@"C:\testing\HUH"));
            Assert.Equal("oops.torrent", FileWorker.GetFileName(@"C:\testing\oops.torrent"));
            Assert.Equal(".txt", FileWorker.GetFileName(@"C:\testing\.txt"));
        }

        [Fact]
        public void GetFileNameWrongPathTest()
        {
            Assert.Throws<ArgumentException>(() => FileWorker.GetFileName(@"C:\nottesting\.txt"));
        }

        [Fact]
        public void GetFileNameEmptyTest()
        {
            Assert.Throws<ArgumentException>(() => FileWorker.GetFileName(""));
        }

        [Fact]
        public void GetFullPathTest()
        {
            string path = @"test.txt";

            Assert.Equal(@"C:\Users\otchebuch\source\repos\lab2Test\lab2Test\bin\Debug\netcoreapp3.1\test.txt", FileWorker.GetFullPath(path));
        }

        [Fact]
        public void GetFullWrongPathTest()
        {
            Assert.Throws<ArgumentException>(() => FileWorker.GetFullPath(@"C:\nottesting\.txt"));
        }

        [Fact]
        public void GetFullEmptyPathTest()
        {
            Assert.Throws<ArgumentException>(() => FileWorker.GetFullPath(""));
        }

        [Fact]
        public void GetDifferentFullPathTest()
        {
            Assert.Equal(@"C:\testing\db.accdb", FileWorker.GetFullPath(@"C:\testing\db.accdb"));
            Assert.Equal(@"C:\testing\docfile.docx", FileWorker.GetFullPath(@"C:\testing\docfile.docx"));
            Assert.Equal(@"C:\testing\pdftest.pdf", FileWorker.GetFullPath(@"C:\testing\pdftest.pdf"));
            Assert.Equal(@"C:\testing\archive.zip", FileWorker.GetFullPath(@"C:\testing\archive.zip"));
            Assert.Equal(@"C:\testing\picture.jpg", FileWorker.GetFullPath(@"C:\testing\picture.jpg"));
            Assert.Equal(@"C:\testing\present.pptx", FileWorker.GetFullPath(@"C:\testing\present.pptx"));
            Assert.Equal(@"C:\testing\✔️✔️✔️.txt", FileWorker.GetFullPath(@"C:\testing\✔️✔️✔️.txt"));
            Assert.Equal(@"C:\testing\ґєїъэё.txt", FileWorker.GetFullPath(@"C:\testing\ґєїъэё.txt"));
            Assert.Equal(@"C:\testing\mathcad.xmcd", FileWorker.GetFullPath(@"C:\testing\mathcad.xmcd"));
            Assert.Equal(@"C:\testing\somepng.png", FileWorker.GetFullPath(@"C:\testing\somepng.png"));
            Assert.Equal(@"C:\testing\Відео-файл.mp4", FileWorker.GetFullPath(@"C:\testing\Відео-файл.mp4"));
            Assert.Equal(@"C:\testing\music.mp3", FileWorker.GetFullPath(@"C:\testing\music.mp3"));
            Assert.Equal(@"C:\testing\apktest.apk", FileWorker.GetFullPath(@"C:\testing\apktest.apk"));
            Assert.Equal(@"C:\testing\someexe.exe", FileWorker.GetFullPath(@"C:\testing\someexe.exe"));
            Assert.Equal(@"C:\testing\HUH", FileWorker.GetFullPath(@"C:\testing\HUH"));
            Assert.Equal(@"C:\testing\oops.torrent", FileWorker.GetFullPath(@"C:\testing\oops.torrent"));
            Assert.Equal(@"C:\testing\.txt", FileWorker.GetFullPath(@"C:\testing\.txt"));
        }

        [Fact]
        public void CreateDirectoryTest()
        {
            string path = @"C:\ilovetest";

            Assert.Equal(@"C:\ilovetest", FileWorker.MkDir(path));
        }

        [Fact]
        public void CreateDirectoryEmptyTest()
        {
            string path = "";

            Assert.Throws<ArgumentException>(() => FileWorker.MkDir(path));
        }

        [Fact]
        public void CreateDirectoryNotAllowedTest()
        {
            string path = @"C:\ilovetest\CON";

            Assert.Throws<ArgumentException>(() => FileWorker.MkDir(path));
        }

        [Fact]
        public void CreateDirectorySymbolsTest()
        {
            string path = @"C:\ilovetest\?????";

            Assert.Throws<ArgumentException>(() => FileWorker.MkDir(path));
        }

        [Fact]
        public void PathValidTest()
        {
            string path = @"C:\ilovetest";

            Assert.True(FileWorker.IsPathValid(path));
        }

        [Fact]
        public void PathInvalidTest()
        {
            string path = "\\/////.";

            Assert.False(FileWorker.IsPathValid(path));
        }

        [Fact]
        public void PathValidEmptyTest()
        {
            Assert.Throws<ArgumentException>(() => FileWorker.IsPathValid(""));
        }

        [Fact]
        public void ReadAllEmptyTest()
        {
            Assert.Throws<ArgumentException>(() => FileWorker.ReadAll(""));
        }

        [Fact]
        public void ReadAllTest()
        {
            string path = @"F:\testfile.txt";

            Assert.Equal("Wowwww\r\nHoly\r\nMoly", FileWorker.ReadAll(path));
        }

        [Fact]
        public void ReadAllNoTextTest()
        {
            string path = @"F:\testfile2.txt";

            Assert.Equal("", FileWorker.ReadAll(path));
        }

        [Fact]
        public void ReadAllNotTxtTest()
        {
          Assert.NotNull(FileWorker.ReadAll(@"C:\testing\someexe.exe"));
        }

        [Fact]
        public void ReadAllWrongPathTest()
        {
            Assert.Null(FileWorker.ReadAll("wrongpath"));
        }

        [Fact]
        public void ReadLinesEmptyTest()
        {
            Assert.Throws<ArgumentException>(() => FileWorker.ReadLines(""));
        }

        [Fact]
        public void ReadLinesTest()
        {
            string path = @"F:\testfile.txt";
            string[] expected = { "Wowwww", "Holy", "Moly" };

            Assert.Equal(expected, FileWorker.ReadLines(path));
        }

        [Fact]
        public void ReadLinesNoTextTest()
        {
            string path = @"F:\testfile2.txt";
            string[] expected = {};

            Assert.Equal(expected, FileWorker.ReadLines(path));
        }

        [Fact]
        public void ReadLinesNotTxtTest()
        {
            Assert.NotNull(FileWorker.ReadLines(@"C:\testing\someexe.exe"));
        }

        [Fact]
        public void ReadLinesWrongPathTest()
        {
            Assert.Null(FileWorker.ReadLines("wrongpath"));
        }

        [Fact]
        public void TryCopyTest()
        {
            Assert.True(FileWorker.TryCopy(@"F:\copy1.txt", @"F:\copynew.txt", false, 1));
        }

        [Fact]
        public void TryCopyExistingTest()
        {
            Assert.Throws<IOException>(() => FileWorker.TryCopy(@"F:\copy1.txt", @"F:\copy2.txt", false, 1));
        }

        [Fact]
        public void TryCopyWrongPathTest()
        {
            Assert.False(FileWorker.TryCopy(@"F:\doesntexist", @"F:\copy2.txt", false, 1));
        }

        [Fact]
        public void TryCopyWrongPath2Test()
        {
            Assert.False(FileWorker.TryCopy(@"F:\doesntexist", @"F:\copy2.txt", true, 1));
        }

        [Fact]
        public void TryCopyRewriteTest()
        {
            Assert.True(FileWorker.TryCopy(@"F:\copy1.txt", @"F:\copy2.txt", true, 1));
        }

        [Fact]
        public void TryCopyRewriteNewTest()
        {
            Assert.True(FileWorker.TryCopy(@"F:\copy1.txt", @"F:\copynew2.txt", true, 1));
        }

        [Fact]
        public void TryCopyEmptyTest()
        {
            Assert.True(FileWorker.TryCopy(@"F:\copy1.txt", @"F:\copynew2.txt", true, 1));
        }

        [Fact]
        public void TryCopyDiffTypesTest()
        {
            Assert.True(FileWorker.TryCopy(@"C:\testing\somepng.png", @"C:\testing\someexe.exe", true, 1));
        }

        [Fact]
        public void TryWriteTest()
        {
            Assert.True(FileWorker.TryWrite("TryWrite test", @"F:\write1.txt", 1));
        }

        [Fact]
        public void TryWriteEmptyTest()
        {
            Assert.True(FileWorker.TryWrite("", @"F:\write1.txt", 1));
        }

        [Fact]
        public void TryWriteDiffTypesTest()
        {
            Assert.True(FileWorker.TryWrite("TryWrite test", @"C:\testing\somepng.png", 1));
        }

        [Fact]
        public void TryWriteExistingTest()
        {
            Assert.True(FileWorker.TryWrite("TryWrite test", @"F:\write2.txt", 1));
        }

        [Fact]
        public void TryWriteWrongPathTest()
        {
            Assert.True(FileWorker.TryWrite("TryWrite test", "12345", 1));
        }

        [Fact]
        public void WriteTest()
        {
            Assert.True(FileWorker.Write("Write test", @"F:\write2.txt"));
        }

        [Fact]
        public void WriteEmptyTest()
        {
            Assert.True(FileWorker.Write("", @"F:\write2.txt"));
        }

        [Fact]
        public void WriteDiffTypesTest()
        {
            Assert.True(FileWorker.Write("Write test", @"C:\testing\somepng.png"));
        }

        [Fact]
        public void WriteExistingTest()
        {
            Assert.True(FileWorker.Write("Write test", @"F:\write2.txt"));
        }

        [Fact]
        public void WriteWrongPathTest()
        {
            Assert.True(FileWorker.Write("Write test", "12345"));
        }

    }
}
