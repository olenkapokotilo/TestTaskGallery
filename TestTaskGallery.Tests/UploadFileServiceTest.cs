using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.Core.Services;
using TestTaskGallery.Core.Services.Interfaces;

namespace TestTaskGallery.Tests
{
    [TestClass]
    public class UploadFileServiceTest
    {

        [TestInitialize]
        public void SetupTests()
        {
            Ioc.Add<IUploadFileService, UploadFileService>();
        }

        [TestCleanup]
        public void CleanUpTests()
        {
            Ioc.CleanUp();
        }

        [TestMethod]
        public void SavePicture_SaveNotAPicture_FileIsNotSaveTest()
        {
             //Arrange
            var postedFileMock = new Mock<HttpPostedFileBase>();
            postedFileMock.Setup(x => x.FileName).Returns("not-a-picture.exe");
            postedFileMock.Setup(x => x.SaveAs(It.IsAny<string>()));

            var uploadFileRepositoryMock = new Mock<IUploadFileRepository>();
            uploadFileRepositoryMock.Setup(x => x.SaveFile(It.IsAny<object>()));

            var fileSystemPathServiceMock = new Mock<IFileSystemPathService>();
            fileSystemPathServiceMock.Setup(x => x.GetImageSavePath());

            Ioc.Add(uploadFileRepositoryMock.Object);
            Ioc.Add(fileSystemPathServiceMock.Object);
            var uploadFileService = Ioc.Get<IUploadFileService>();

            // Act
            var result = uploadFileService.SavePicture(postedFileMock.Object, 1);

            // Assert
            Assert.AreEqual(result.Message, "Only picture allowed.");
            uploadFileRepositoryMock.Verify(x => x.SaveFile(It.IsAny<object>()), Times.Never);
            postedFileMock.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void SavePicture_SaveAPictureFile_FileIsSaveTest()
        {
            // Arrange
            var savePath = "testPath/";

            var postedPictureFileMock1 = new Mock<HttpPostedFileBase>();
            postedPictureFileMock1.Setup(x => x.FileName).Returns("picture1.jpg");
            postedPictureFileMock1.Setup(x => x.SaveAs(It.IsAny<string>()));

            var postedPictureFileMock2 = new Mock<HttpPostedFileBase>();
            postedPictureFileMock2.Setup(x => x.FileName).Returns("picture1.png");

            var postedPictureFileMock3 = new Mock<HttpPostedFileBase>();
            postedPictureFileMock3.Setup(x => x.FileName).Returns("picture1.gif");

            var fileSystemPathServiceMock = new Mock<IFileSystemPathService>();
            
            fileSystemPathServiceMock.Setup(x => x.GenerateUniqueFileName(It.Is<string>(s => s == "picture1.jpg"))).Returns("picture1_unique.jpg");
            fileSystemPathServiceMock.Setup(x => x.GenerateUniqueFileName(It.Is<string>(s => s == "picture1.png"))).Returns("picture1_unique.png");
            fileSystemPathServiceMock.Setup(x => x.GenerateUniqueFileName(It.Is<string>(s => s == "picture1.gif"))).Returns("picture1_unique.gif");
            fileSystemPathServiceMock.Setup(x => x.GetImageSavePath()).Returns(savePath);

            var uploadFileRepositoryMock = new Mock<IUploadFileRepository>();
            uploadFileRepositoryMock.Setup(x => x.SaveFile(It.IsAny<object>()));
            uploadFileRepositoryMock.Setup(x => x.DeleteFile(It.IsAny<object>()));

            Ioc.Add(fileSystemPathServiceMock.Object);
            Ioc.Add(uploadFileRepositoryMock.Object);

            var uploadFileService = Ioc.Get<IUploadFileService>();

            // Act
            var result1 = uploadFileService.SavePicture(postedPictureFileMock1.Object, 1);
            var result2 = uploadFileService.SavePicture(postedPictureFileMock2.Object, 1);
            var result3 = uploadFileService.SavePicture(postedPictureFileMock3.Object, 1);

            // Assert
            Assert.AreEqual(result1.Status, "Success");
            postedPictureFileMock1.Verify(x => x.SaveAs("testPath/picture1_unique.jpg"), Times.Once);
            postedPictureFileMock2.Verify(x => x.SaveAs("testPath/picture1_unique.png"), Times.Once);
            postedPictureFileMock3.Verify(x => x.SaveAs("testPath/picture1_unique.gif"), Times.Once);
            fileSystemPathServiceMock.Verify(x => x.GetImageSavePath(), Times.Exactly(3));
            uploadFileRepositoryMock.Verify(x => x.SaveFile(It.IsAny<object>()), Times.Exactly(3));
            uploadFileRepositoryMock.Verify(x => x.DeleteFile(It.IsAny<object>()), Times.Never());
        }

        [TestMethod]
        public void SavePicture_ThrowExceptionWhenSaveFileToFileSystem_DeleteFileCalledTest()
        {
            // Arrange
            var savePath = "testPath/";

            var postedPictureFileMock1 = new Mock<HttpPostedFileBase>();
            postedPictureFileMock1.Setup(x => x.FileName).Returns("picture1.jpg");
            postedPictureFileMock1.Setup(x => x.SaveAs("testPath/picture1_unique.jpg")).Throws(new Exception());

            var fileSystemPathServiceMock = new Mock<IFileSystemPathService>();
            fileSystemPathServiceMock.Setup(x => x.GenerateUniqueFileName(It.Is<string>(s => s == "picture1.jpg"))).Returns("picture1_unique.jpg");
            fileSystemPathServiceMock.Setup(x => x.GetImageSavePath()).Returns(savePath);

            var uploadFileRepositoryMock = new Mock<IUploadFileRepository>();
            uploadFileRepositoryMock.Setup(x => x.SaveFile(It.IsAny<object>()));
            uploadFileRepositoryMock.Setup(x => x.DeleteFile(It.IsAny<object>()));

            Ioc.Add(fileSystemPathServiceMock.Object);
            Ioc.Add(uploadFileRepositoryMock.Object);

            var uploadFileService = Ioc.Get<IUploadFileService>();

            // Act
            var result1 = uploadFileService.SavePicture(postedPictureFileMock1.Object, 1);

            // Assert
            Assert.AreEqual(result1.Status, "Error");
            postedPictureFileMock1.Verify(x => x.SaveAs("testPath/picture1_unique.jpg"), Times.Once);
            fileSystemPathServiceMock.Verify(x => x.GetImageSavePath(), Times.Once);
            uploadFileRepositoryMock.Verify(x => x.SaveFile(It.IsAny<object>()), Times.Once);
            uploadFileRepositoryMock.Verify(x => x.DeleteFile(It.IsAny<object>()), Times.Once());
        }
    }
}
