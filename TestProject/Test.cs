using DataBaseFunctional;
using Moq;
using RegistrationApp_Test;

namespace RegistrationTest
{
    public class Tests
    {
        [Test]
        public void ProblemLogin()
        {
            var mockView = new Mock<IView>();
            var mockMessage = new Mock<IMessage>();
            new Controller(mockView.Object, mockMessage.Object);
            var except = ("false", "Логин должен содержать минимум 5 символов");

            mockView.Raise(x => x.runCheck+= null, "name", "Пароль1","Пароль1");

            mockView.Verify(x => x.ShowResult(except), Times.Once);
        }

        [Test]
        public void InfomationIsEmpty()
        {
            var mockView = new Mock<IView>();
            var mockMessage = new Mock<IMessage>();
            new Controller(mockView.Object, mockMessage.Object);
            var except = ("false", "Введите логин и пароль! Подтвердите пароль!");

            mockView.Raise(x => x.runCheck += null, "","","");

            mockView.Verify(x => x.ShowResult(except), Times.Once);
        }

        [Test]
        public void UserIsExist()
        {
            var mockView = new Mock<IView>();
            var mockMessage = new Mock<IMessage>();
            new Controller(mockView.Object, mockMessage.Object);
            var except = ("false", "Пользователь с таким логином уже существует!");

            mockView.Raise(x => x.runCheck += null, "ivanovar12@mail.ru", "Румба12_0", "Румба12_0");

            mockView.Verify(x => x.ShowResult(except), Times.Once);
        }

        [Test]
        public void UserIsAdded()
        {
            CheckRegistrationData check = new CheckRegistrationData();

            var except = ("True", "");
            var actual = check.CheckRegistration("NV_xyz2","ЯС10.прп","ЯС10.прп"); 

           Assert.That(actual, Is.EqualTo(except));
        }

        [Test]
        public void DataIsAdded()
        {
            DatabaseRepository db = new DatabaseRepository();

            var except = "Data is added";
            var actual = db.AddData("логин1", "пароль1", "пароль2", false, "Cтроковый логин должен иметь только латиницу, цифры и знак подчеркивания _");

            Assert.That(actual, Is.EqualTo(except));
        }
    }
}