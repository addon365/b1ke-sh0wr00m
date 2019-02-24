using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using addon365.Domain.Entity.Bots;
using FizzWare.NBuilder;
using Moq;
using Newtonsoft.Json.Linq;
using addon365.Web.API.Controllers;
using addon365.Database.Service;
using Threenine.Data;
using Xunit;

namespace addon365.Web.API.Tests
{
    public class ReferrerControllerTests
    {
        [Fact]
        public void Get_Should_Return_List_Of_Referrers()
        {
            var referrerList = Builder<Referrer>.CreateListOfSize(20).Build().AsEnumerable();
            var referrerServiceMock = new Mock<IReferrerService>();
            referrerServiceMock.Setup(service => service.GetAllActive())
                .Returns(referrerList);

            var controller = new ReferrerController(referrerServiceMock.Object);
            var values = controller.Get();

            Assert.Equal(20, values.Count());
            Assert.IsAssignableFrom<IEnumerable<Referrer>>(values);

        }

        [Fact]
        public void Get_Should_Return_Null()
        {
           var referrerServiceMock = new Mock<IReferrerService>();
            referrerServiceMock.Setup(service => service.GetAllActive());

            var controller = new ReferrerController(referrerServiceMock.Object);
            var values = controller.Get();

            Assert.Null(values);
         }


    }
}
