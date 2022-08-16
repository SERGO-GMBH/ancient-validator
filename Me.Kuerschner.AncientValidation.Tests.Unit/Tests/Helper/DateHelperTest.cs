using System;
using Me.Kuerschner.AncientValidation.Helper;
using Xunit;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Tests.Helper
{
    public class DateHelperTest
    {
        [Fact]
        public void Test_GetMinDateTime()
        {
            //Assent
            var minDateTime = DateTime.Now.AddMinutes(-10);
            var maxDateTime = DateTime.Now;
            //Act
            var min = DateHelper.GetMinDateTime(minDateTime, maxDateTime);

            //Assert
            Assert.Equal(minDateTime, min);
        }

        [Fact]
        public void Test_GetMaxDateTime()
        {
            //Assent
            var minDateTime = DateTime.Now.AddMinutes(-10);
            var maxDateTime = DateTime.Now;

            //Act
            var max = DateHelper.GetMaxDateTime(minDateTime, maxDateTime);

            //Assert
            Assert.Equal(maxDateTime, max);
        }
    }
}
