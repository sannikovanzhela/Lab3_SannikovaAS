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
            var except = ("false", "����� ������ ��������� ������� 5 ��������");

            mockView.Raise(x => x.runCheck+= null, "name", "������1","������1");

            mockView.Verify(x => x.ShowResult(except), Times.Once);
        }

        [Test]
        public void InfomationIsEmpty()
        {
            var mockView = new Mock<IView>();
            var mockMessage = new Mock<IMessage>();
            new Controller(mockView.Object, mockMessage.Object);
            var except = ("false", "������� ����� � ������! ����������� ������!");

            mockView.Raise(x => x.runCheck += null, "","","");

            mockView.Verify(x => x.ShowResult(except), Times.Once);
        }

        [Test]
        public void UserIsExist()
        {
            var mockView = new Mock<IView>();
            var mockMessage = new Mock<IMessage>();
            new Controller(mockView.Object, mockMessage.Object);
            var except = ("false", "������������ � ����� ������� ��� ����������!");

            mockView.Raise(x => x.runCheck += null, "ivanovar12@mail.ru", "�����12_0", "�����12_0");

            mockView.Verify(x => x.ShowResult(except), Times.Once);
        }

        [Test]
        public void UserIsAdded()
        {
            CheckRegistrationData check = new CheckRegistrationData();

            var except = ("True", "");
            var actual = check.CheckRegistration("NV_xyz2","��10.���","��10.���"); 

           Assert.That(actual, Is.EqualTo(except));
        }

        [Test]
        public void DataIsAdded()
        {
            DatabaseRepository db = new DatabaseRepository();

            var except = "Data is added";
            var actual = db.AddData("�����1", "������1", "������2", false, "C�������� ����� ������ ����� ������ ��������, ����� � ���� ������������� _");

            Assert.That(actual, Is.EqualTo(except));
        }
    }
}