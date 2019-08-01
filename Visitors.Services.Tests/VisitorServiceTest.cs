using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Visitors.Data;
using Visitors.Domain;
using Visitors.Services.Contracts;
using Xunit;

namespace Visitors.Services.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetDelta()
        {
            var service = GetService();

            var result = service.GetDelta();

            Assert.True(result.Count == 2);
            Assert.True(result.First(di => di.Id == 1).DeltaTime == 1800);
            Assert.True(result.First(di => di.Id == 2).DeltaTime == 2400);

            //var dbOptionsBuilder = new DbContextOptionsBuilder();

            //dbOptionsBuilder.UseSqlServer("Server=(local);Initial Catalog=Testim;Persist Security Info=False;User ID=testim;Password=testim123;MultipleActiveResultSets=False;Connection Timeout=30;");

            //var context = new DataContext(dbOptionsBuilder.Options);
            //var repo = new EfRepository<Visitor>(context);
            //var query = repo.TableNoTracking
            //    .Where(at => at.Fullname.Equals("Vassea"))
            //    .OrderByDescending(a => a.CreateDate)
            //    .Take(10)
            //    .ToList();
        }

        private static IVisitorService GetService()
        {
            var visitor1 = new Visitor() { Id = 1, CreateDate = new DateTime(2019, 1, 1, 12, 0, 0), LastEnterDate = new DateTime(2019, 1, 1, 12, 30, 0) };
            var visitor2 = new Visitor() { Id = 2, CreateDate = new DateTime(2019, 1, 1, 12, 0, 0), LastEnterDate = new DateTime(2019, 1, 1, 12, 40, 0) };
            var table = new List<Visitor>();
            table.Add(visitor1);
            table.Add(visitor2);
            var repositoryMock = new Mock<IRepository<Visitor>>();
            repositoryMock.Setup(r => r.TableNoTracking).Returns(table.AsQueryable());
            return new VisitorService(repositoryMock.Object);
        }
    }
}
