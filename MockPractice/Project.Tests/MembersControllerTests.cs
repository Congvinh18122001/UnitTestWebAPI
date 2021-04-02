using NUnit.Framework;
using Moq;
using ProjectLib.Object;
using ProjectAPI.Controllers;
using System.Net;
namespace Project.Tests
{
    public class MembersControllerTests
    {
        Mock<IMembersRepository> _repoMock;
        MembersController _MemberController;
        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IMembersRepository>();
            _MemberController = new MembersController(_repoMock.Object);
        }

        [Test]
        public void GetMember_ReturnStatusCode_StatusOK()
        {
            // Arrange
             _repoMock.Setup(r=>r.GetMemberById(It.IsAny<int>())).Returns(new Member() {  ID = 2 , Name="Le Cong M",Phone="0123654789",Birthday="18/12/2000",Gender="Male",Email="asd2@gmail.com",BirthPlace="Ha Noi"});
            //Act
            var result = _MemberController.GetMember(2);
            //assert
            Assert.AreEqual(HttpStatusCode.OK, result);
        }
        [Test]
        public void GetMember_ReturnStatusCode_StatusNotFound()
        {
            // Arrange
            // _repoMock.Setup(r=>r.GetMemberById(It.IsAny<int>())).Returns(null);
            //Act
            var result = _MemberController.GetMember(1);
            //assert
            Assert.AreEqual(HttpStatusCode.NotFound, result);
        }
    }
}