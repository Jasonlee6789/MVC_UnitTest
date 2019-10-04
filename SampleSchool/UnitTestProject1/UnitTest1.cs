
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleSchool.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StudentUnitTest()
        {   //Arrange:Initialise objects and sets the value of sample data used in the method being tested
            StudentUnitTestController controller = new StudentUnitTestController();
            //Act:Invoke the method being tested
            IActionResult result = controller.Index() as IActionResult;
            //Assert: Verify the tested method behaves as expected
            Assert.IsNotNull(result);

        }
    }
}
