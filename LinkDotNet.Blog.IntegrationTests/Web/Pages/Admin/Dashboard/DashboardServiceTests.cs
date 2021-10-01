﻿using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using LinkDotNet.Blog.Domain;
using LinkDotNet.Blog.Web.Pages.Admin;
using Xunit;

namespace LinkDotNet.Blog.IntegrationTests.Web.Pages.Admin.Dashboard
{
    public class DashboardServiceTests : SqlDatabaseTestBase<UserRecord>
    {
        private readonly DashboardService sut;

        public DashboardServiceTests()
        {
            sut = new DashboardService(Repository);
        }

        [Fact]
        public async Task ShouldGetTotalUsers()
        {
            var record1 = new UserRecord
            {
                UserIdentifierHash = 2,
                DateTimeUtcClicked = DateTime.UtcNow,
                UrlClicked = string.Empty,
            };
            var record2 = new UserRecord
            {
                UserIdentifierHash = 1,
                UrlClicked = string.Empty,
            };
            var record3 = new UserRecord
            {
                UserIdentifierHash = 2,
                UrlClicked = string.Empty,
            };
            await Repository.StoreAsync(record1);
            await Repository.StoreAsync(record2);
            await Repository.StoreAsync(record3);

            var data = await sut.GetDashboardDataAsync();

            data.TotalAmountOfUsers.Should().Be(2);
            data.AmountOfUsersLast30Days.Should().Be(1);
        }

        [Fact]
        public async Task ShouldGetTotalClicks()
        {
            var record1 = new UserRecord
            {
                DateTimeUtcClicked = DateTime.UtcNow,
                UrlClicked = "index",
            };
            var record2 = new UserRecord
            {
                UrlClicked = string.Empty,
            };
            var record3 = new UserRecord
            {
                UrlClicked = string.Empty,
            };
            await Repository.StoreAsync(record1);
            await Repository.StoreAsync(record2);
            await Repository.StoreAsync(record3);

            var data = await sut.GetDashboardDataAsync();

            data.TotalPageClicks.Should().Be(3);
            data.PageClicksLast30Days.Should().Be(1);
        }

        [Fact]
        public async Task ShouldGetAboutMeClicks()
        {
            var record1 = new UserRecord
            {
                DateTimeUtcClicked = DateTime.UtcNow,
                UrlClicked = "AboutMe",
            };
            var record2 = new UserRecord
            {
                UrlClicked = string.Empty,
            };
            var record3 = new UserRecord
            {
                UrlClicked = "AboutMe",
            };
            await Repository.StoreAsync(record1);
            await Repository.StoreAsync(record2);
            await Repository.StoreAsync(record3);

            var data = await sut.GetDashboardDataAsync();

            data.TotalAboutMeClicks.Should().Be(2);
            data.AboutMeClicksLast30Days.Should().Be(1);
        }

        [Fact]
        public async Task ShouldGetBlogPostClicks()
        {
            var record1 = new UserRecord
            {
                UrlClicked = "blogPost/1",
            };
            var record2 = new UserRecord
            {
                UrlClicked = "blogPost/2",
            };
            var record3 = new UserRecord
            {
                UrlClicked = "blogPost/1",
            };
            var record4 = new UserRecord
            {
                UrlClicked = "unrelated",
            };
            await Repository.StoreAsync(record1);
            await Repository.StoreAsync(record2);
            await Repository.StoreAsync(record3);
            await Repository.StoreAsync(record4);

            var data = (await sut.GetDashboardDataAsync()).BlogPostVisitCount.ToList();

            data.Count.Should().Be(2);
            data[0].Key.Should().Be("blogPost/1");
            data[0].Value.Should().Be(2);
            data[1].Key.Should().Be("blogPost/2");
            data[1].Value.Should().Be(1);
        }
    }
}