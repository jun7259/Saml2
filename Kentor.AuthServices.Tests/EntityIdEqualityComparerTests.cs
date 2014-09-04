﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IdentityModel.Metadata;
using FluentAssertions;

namespace Kentor.AuthServices.Tests
{
    [TestClass]
    public class EntityIdEqualityComparerTests
    {
        [TestMethod]
        public void EntityIdEqualityComparerTests_EqualsOnSame()
        {
            var id = "someEntityId";
            var eid1 = new EntityId(id);
            var eid2 = new EntityId(id);

            EntityIdEqualityComparer.Instance.Equals(eid1, eid2).Should().BeTrue();
        }

        [TestMethod]
        public void EntityIdEqualityComparerTests_DiffOnDifferent()
        {
            var eid1 = new EntityId("whatever");
            var eid2 = new EntityId("somethingElse");

            EntityIdEqualityComparer.Instance.Equals(eid1, eid2).Should().BeFalse();
        }

        [TestMethod]
        public void EntityIdEqualityComparerTests_SameHashCodeOnSame()
        {
            var id = "someEntityID";
            var eid1 = new EntityId(id);
            var eid2 = new EntityId(id);

            EntityIdEqualityComparer.Instance.GetHashCode(eid1)
                .Should().Be(EntityIdEqualityComparer.Instance.GetHashCode(eid2));
        }

        [TestMethod]
        public void EntityIdEqualityComparerTests_DiffHashCodeOnDifferent()
        {
            var eid1 = new EntityId("whatever");
            var eid2 = new EntityId("somethingElse");

            EntityIdEqualityComparer.Instance.GetHashCode(eid1)
                .Should().NotBe(EntityIdEqualityComparer.Instance.GetHashCode(eid2));
        }

        [TestMethod]
        public void EntityIdEqualityComparerTests_EqualsNullCheckX()
        {
            var eid = new EntityId();

            Action a = () => EntityIdEqualityComparer.Instance.Equals(null, eid);

            a.ShouldThrow<ArgumentNullException>("x");
        }

        [TestMethod]
        public void EntityIdEqualityComparerTests_EqualsNullCheckY()
        {
            var eid = new EntityId();

            Action a = () => EntityIdEqualityComparer.Instance.Equals(eid, null);

            a.ShouldThrow<ArgumentNullException>("y");
        }

        [TestMethod]
        public void EntityIdEqualityComparerTests_GetHashCodeNullCheck()
        {
            Action a = () => EntityIdEqualityComparer.Instance.GetHashCode(null);

            a.ShouldThrow<ArgumentNullException>("obj");
        }

        [TestMethod]
        public void EntityIdEqualityComparerTests_GetHashCodeHandlesNullId()
        {
            var entityId = new EntityId();
            entityId.Id.Should().BeNull();

            Action a = () => EntityIdEqualityComparer.Instance.GetHashCode(entityId);

            a.ShouldNotThrow();
        }
    }
}
