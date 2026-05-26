using Moq;
using task.Domain.Models;
using task.Repositories.Impl;
using task.Services;

namespace TestProject2
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var MockUserRepository = new Mock<IUserRepository>();

            MockUserRepository
                .Setup(x => x.GetByEmail("Test@test.com"))
                .ReturnsAsync(new User
                {
                    Email = "Test@test.com",
                    Id = 1,
                    Password = "password",
                    Name = "Test"

                });




            var MockUnitOfWork = new Mock<IUnityOfWork>();

            MockUnitOfWork
                .Setup(x => x.Users)
                .Returns(MockUserRepository.Object);

            var Service = new UserServices(MockUnitOfWork.Object);

            var user1 = await Service.GetUserByEmail("Test@test.com");

            MockUnitOfWork.Verify(

                x => x.Users.GetByEmail("Test@test.com"),
                Times.Once
            );


            Assert.AreEqual("Test@test.com", user1.Email);


            Assert.AreNotEqual("Test1@test.com", user1.Email);


            var MockUserRepository2 = new Mock<IUserRepository>();

            MockUserRepository2.Setup(x => x.GetByEmail("Test2@test.com"))
                .ReturnsAsync(new User
                {
                    Email = "Test2@test.com",
                    Id = 2,
                    Password = "password",
                    Name = "Test2"

                });


            var MockUnitOfWork2 = new Mock<IUnityOfWork>();

            MockUnitOfWork2
                .Setup(x => x.Users)
                .Returns(MockUserRepository2.Object);

            var service2 = new UserServices(MockUnitOfWork2.Object);


            var user = await service2.GetUserByEmail("Test2@test.com");


            MockUnitOfWork2.Verify(

                x => x.Users.GetByEmail("Test2@test.com"),
                Times.Once
            );


            Assert.AreNotEqual("Test@test.com", user.Email);


            Assert.AreEqual("Test2@test.com", user.Email);





        }
    }
}
