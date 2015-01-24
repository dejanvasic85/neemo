using System;
using System.Linq;
using AutoMapper;
using Neemo.CarParts.EntityFramework.Models;
using Neemo.Orders;

namespace Neemo.CarParts.EntityFramework
{
    public class OrderHeaderToOrderConverter : TypeConverter<Models.OrderHeader, Order>
    {
        protected override Order ConvertCore(OrderHeader source)
        {
            var billingDetails = new PersonalDetails
            {
                AddressLine1 = source.Billing_Address,
                City = source.Billing_City,
                Company = source.Billing_CompanyName,
                Country = source.Billing_Country,
                FirstName = source.Billing_FirstName,
                IsDefault = true,
                PhoneNumber = source.Billing_Mobile,
                Postcode = source.Billing_PostCode,
                State = source.Billing_State,
                Surname = source.Billing_LastName
            };

            var shippingDetails = new PersonalDetails
            {
                AddressLine1 = source.Shipping_Address,
                City = source.Shipping_City,
                Company = source.Shipping_CompanyName,
                Country = source.Shipping_Country,
                FirstName = source.Shipping_FirstName,
                IsDefault = true,
                PhoneNumber = source.Shipping_Mobile,
                Postcode = source.Shipping_PostCode.ToString(),
                State = source.Shipping_State,
                Surname = source.Shipping_LastName
            };

            return Order.Create(
                billingDetails,
                shippingDetails,
                source.DateCreated,
                new Guid(source.GUID),
                source.Handlingcharges.GetValueOrDefault(),
                source.OrderHeaderID,
                source.ShippingCharges.GetValueOrDefault(),
                source.RecordSourceIP,
                source.TaxTotal.GetValueOrDefault(),
                source.TotalAmount.GetValueOrDefault(),
                source.UserName,
                source.OrderDetails.Select(Mapper.Map<Models.OrderDetail, Orders.OrderLineItem>).ToArray()
                );
        }
    }
}