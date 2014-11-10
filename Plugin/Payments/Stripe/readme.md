# Merchello.Plugin.Payments.Stripe

     // Author: Alex Lindgren
     // Twitter: @alexlindgren
     // Compatible: Merchello 1.4.1 and Umbraco 7.1.6

## About this package

This Merchello plugin is a payment provider for Stripe (https://stripe.com/).  You need a Stripe account and API Key.

## Making a charge with Stripe

Merchello payment providers use payment information from a `Merchello.Core.Gateways.Payment.ProcessorArgumentCollection` object (which is a `Dictionary<string, string>` collection).  The collection must include either a Stripe customer ID, a Stripe credit card token or credit card info (number, expiration date, etc.).  Using the Stripe customer ID or credit card token allows one to use this provider with  customers and credit cards saved in the Stripe system.  Note that this Stripe provider for Merchello does not yet support Stripe API calls for saving Customer data and credit cards but the `StripeHelper` class has a method for getting a Stripe token.