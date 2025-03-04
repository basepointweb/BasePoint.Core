﻿using BasePoint.Core.Extensions;
using BasePoint.Core.Tests.Application.Dtos.Builders;
using BasePoint.Core.Tests.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace BasePoint.Core.Tests.Extensions
{
    public class EnumerableExtensionTests
    {
        [Fact]
        public void WherePropertyIn_ExistsItemsWithInValues_ReturnsItems()
        {
            var entity1 = new SampleEntityBuilder().Build();
            var entity2 = new SampleEntityBuilder().Build();

            var sampleEntityList = new List<SampleEntity>() { entity1, entity2 };

            var entitiesIds = sampleEntityList.Select(x => x.Id);

            var resultList = sampleEntityList.WherePropertyIn(x => x.Id, entitiesIds);

            resultList.Should().HaveCount(entitiesIds.Count());
            resultList.Should().Contain(entity1);
            resultList.Should().Contain(entity2);
        }

        [Fact]
        public void WherePropertyIn_NotExistsItemsWithInValues_ReturnsEmptyList()
        {
            var entity1 = new SampleEntityBuilder().Build();
            var entity2 = new SampleEntityBuilder().Build();

            var sampleEntityList = new List<SampleEntity>() { entity1, entity2 };

            var entitiesIds = sampleEntityList.Select(x => x.Id);

            var resultList = sampleEntityList.WherePropertyIn(x => x.Id, Guid.NewGuid());

            resultList.Should().HaveCount(0);
        }

        [Fact]
        public void WherePropertyNotIn_DoesNotExistsItemsWithInValues_ReturnsItems()
        {
            var entity1 = new SampleEntityBuilder().Build();
            var entity2 = new SampleEntityBuilder().Build();

            var sampleEntityList = new List<SampleEntity>() { entity1, entity2 };

            var entitiesIds = new List<Guid>() { Guid.NewGuid() };

            var resultList = sampleEntityList.WherePropertyNotIn(x => x.Id, entitiesIds);

            resultList.Should().HaveCount(sampleEntityList.Count());
            resultList.Should().Contain(entity1);
            resultList.Should().Contain(entity2);
        }

        [Fact]
        public void WherePropertyNotIn_ExistsItemsWithInValues_ReturnsEnptyList()
        {
            var entity1 = new SampleEntityBuilder().Build();
            var entity2 = new SampleEntityBuilder().Build();

            var sampleEntityList = new List<SampleEntity>() { entity1, entity2 };

            var entitiesIds = new List<Guid>() { entity1.Id, entity2.Id };

            var resultList = sampleEntityList.WherePropertyNotIn(x => x.Id, entitiesIds);

            resultList.Should().HaveCount(0);
        }
    }
}