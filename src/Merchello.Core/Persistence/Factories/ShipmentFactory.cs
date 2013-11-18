﻿using Merchello.Core.Models;
using Merchello.Core.Models.Rdbms;

namespace Merchello.Core.Persistence.Factories
{
    internal class ShipmentFactory : IEntityFactory<IShipment, ShipmentDto>
    {
        public IShipment BuildEntity(ShipmentDto dto)
        {
            var shipment = new Shipment(dto.OrderKey)
            {
                Key = dto.Key,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                Locality = dto.Locality,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                CountryCode = dto.CountryCode,
                Phone = dto.Phone,
                ShipMethodKey = dto.ShipMethodKey,
                UpdateDate = dto.UpdateDate,
                CreateDate = dto.CreateDate
            };

            shipment.ResetDirtyProperties();

            return shipment;
        }

        public ShipmentDto BuildDto(IShipment entity)
        {
            var dto = new ShipmentDto()
            {
                Key = entity.Key,
                OrderKey = entity.OrderKey,
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                Locality = entity.Locality,
                Region = entity.Region,
                PostalCode = entity.PostalCode,
                CountryCode = entity.CountryCode,
                ShipMethodKey = entity.ShipMethodKey,
                Phone = entity.Phone,
                UpdateDate = entity.UpdateDate,
                CreateDate = entity.CreateDate                
            };

            return dto;
        }
    }
}
