﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;
using Merchello.Core.Models;
using Merchello.Core.Models.Rdbms;
using Merchello.Tests.Base.SqlSyntax;
using NUnit.Framework;
using Umbraco.Core.Persistence;

namespace Merchello.Tests.UnitTests.Querying
{
    [TestFixture]
    [Category("SqlSyntax")]
    public class TransactiontSqlClausesTests : BaseUsingSqlServerSyntax<IAppliedPayment>
    {
        /// <summary>
        /// Test to verify that the typed <see cref="TransactionDto"/> query matches generic "select * ..." query 
        /// </summary>
        [Test]
        public void Can_Verify_Transaction_Base_Sql_Clause()
        {
            //// Arrange
            var key = Guid.NewGuid();

            var expected = new Sql();
            expected.Select("*")
                .From("[merchTransaction]")
                .Where("[merchPayment].[pk] = '" + key.ToString() + "'");

            //// Act
            var sql = new Sql();
            sql.Select("*")
                .From<TransactionDto>()
                .Where<PaymentDto>(x => x.Key == key);

            //// Assert
            Assert.That(sql.SQL, Is.EqualTo(expected.SQL));
        }

    }
}
