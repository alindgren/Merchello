﻿using System;
using Merchello.Core.Models;
using Umbraco.Core.Persistence.Repositories;

namespace Merchello.Core.Persistence.Repositories
{
    /// <summary>
    /// Marker interface for the invoice repository
    /// </summary>
    public interface IInvoiceRepository : IRepositoryQueryable<Guid, IInvoice>
    {
    }
}
