using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Visitors.Data;
using Visitors.Domain;
using Visitors.Services.Contracts;
using Visitors.Services.Tests.Infrastructure;
using Xunit;

namespace Visitors.Services.Tests
{
    public class VisitorServiceTest
    {
        [Fact]
        public async void GetDelta()
        {
            var service = GetService();
            var result = await service.GetDelta();
            Assert.Equal(2, result.Count);
            Assert.Equal(1800, result.First(di => di.Id == 1).DeltaTime);
            Assert.Equal(2400, result.First(di => di.Id == 2).DeltaTime);
        }

        private static IVisitorService GetService()
        {
            var visitor1 = new Visitor() { Id = 1, CreateDate = new DateTime(2019, 1, 1, 12, 0, 0), LastEnterDate = new DateTime(2019, 1, 1, 12, 30, 0) };
            var visitor2 = new Visitor() { Id = 2, CreateDate = new DateTime(2019, 1, 1, 12, 0, 0), LastEnterDate = new DateTime(2019, 1, 1, 12, 40, 0) };
            var table = new List<Visitor>();

            table.Add(visitor1);
            table.Add(visitor2);

            var data = table.AsQueryable();

            var mockSet = new Mock<DbSet<Visitor>>();

            mockSet.As<IAsyncEnumerable<Visitor>>()
                .Setup(m => m.GetEnumerator())
                .Returns(new TestAsyncEnumerator<Visitor>(data.GetEnumerator()));

            mockSet.As<IQueryable<Visitor>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<Visitor>(data.Provider));

            mockSet.As<IQueryable<Visitor>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Visitor>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repositoryMock = new Mock<IRepository<Visitor>>();
            repositoryMock.Setup(r => r.TableNoTracking).Returns(mockSet.Object.AsNoTracking());
            return new VisitorService(repositoryMock.Object);
        }
    }
}
