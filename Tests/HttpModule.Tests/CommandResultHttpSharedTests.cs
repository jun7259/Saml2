﻿using FluentAssertions;
using Sustainsys.Saml2.HttpModule;
using Sustainsys.Saml2.WebSso;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Web;

namespace Sustainsys.Saml2.HttpModule.Tests
{
    [TestClass]
    public partial class CommandResultHttpTests
    {
        [TestMethod]
        public void CommandResultHttp_ApplyCookies_NullCheck_CommandResult()
        {
            ((CommandResult)null)
                .Invoking(cr => cr.ApplyCookies(Substitute.For<HttpResponseBase>(), true))
                .ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("commandResult");
        }

        [TestMethod]
        public void CommandResultHttp_ApplyCookies_NullCheck_Response()
        {
            new CommandResult()
                .Invoking(cr => cr.ApplyCookies(null, true))
                .ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("response");
        }
    }
}
