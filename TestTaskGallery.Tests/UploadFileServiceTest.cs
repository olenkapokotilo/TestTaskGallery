using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.Core.Services.Interfaces;

namespace TestTaskGallery.Tests
{
    [TestClass]
    public class UploadFileServiceTest
    {
        [TestMethod]
        public void SavePicture_SaveNotAPicture_FileIsNotSaveTest()
        {
            // Arrange
            //var postedFileMock = new Mock<HttpPostedFileBase>();
            //postedFileMock.Setup(x => x.FileName).Returns("not-a-picture.exe");
            //postedFileMock.Setup(x => x.SaveAs(It.IsAny<string>()));

            //var uploadFileRepositoryMock = new Mock<IUploadFileRepository>();
            //uploadFileRepositoryMock.Setup(x => x.SaveFile(It.IsAny<object>()));

            //Ioc.Add(uploadFileRepositoryMock.Object);

            //var uploadFileService = Ioc.Get<IUploadFileService>();

            //// Act
            //var result = uploadFileService.SavePicture(postedFileMock.Object, 1);

            //// Assert
            //Assert.AreEqual(result.Message, "Only picture allowed.");
            //uploadFileRepositoryMock.Verify(x => x.SaveFile(It.IsAny<object>()), Times.Never);
            //postedFileMock.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Never);
        }
    }
}
