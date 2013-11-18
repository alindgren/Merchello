﻿using System.Net.Http.Formatting;
using umbraco;
using Umbraco.Core;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using umbraco.BusinessLogic.Actions;
using Umbraco.Web.Models.Trees;

namespace Merchello.Web.UI.Trees
{
    [Tree("merchello", "merchello", "Merchello")]
    [PluginController("Merchello")]
    public class MerchelloTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            //we only support one tree level for data types
            //if (id != Constants.System.Root.ToInvariantString())
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            var collection = new TreeNodeCollection();
            if (id == "settings")
            {
                collection.Add(CreateTreeNode("shipping", "settings", queryStrings, "Shipping", "icon-truck", false, "merchello/merchello/Shipping/"));
                collection.Add(CreateTreeNode("vendors", "settings", queryStrings, "Vendors", "icon-handshake", false, "merchello/merchello/Vendors/"));
                collection.Add(CreateTreeNode("taxation", "settings", queryStrings, "Taxation", "icon-piggy-bank", false, "merchello/merchello/Taxation/"));
                collection.Add(CreateTreeNode("payment", "settings", queryStrings, "Payment", "icon-bill-dollar", false, "merchello/merchello/Payment/"));
                collection.Add(CreateTreeNode("notifications", "settings", queryStrings, "Notifications", "icon-chat", false, "merchello/merchello/Notifications/"));
                collection.Add(CreateTreeNode("debuglog", "settings", queryStrings, "Debug Log", "icon-alert", false, "merchello/merchello/Debug/"));
            }
            else if (id == "reports")
            {
                collection.Add(CreateTreeNode("salesOverTime", "reports", queryStrings, "Sales Over Time", "icon-loading", false, "merchello/merchello/SalesOverTime/"));
                collection.Add(CreateTreeNode("salesByItem", "reports", queryStrings, "Sales By Item", "icon-barcode", false, "merchello/merchello/SalesByItem/"));
                collection.Add(CreateTreeNode("taxesByDestination","reports", queryStrings, "Taxes By Destination", "icon-piggy-bank", false, "merchello/merchello/TaxesByDestination/"));
            }
            else
            {
                collection.Add(CreateTreeNode("catalog", "", queryStrings, "Catalog", "icon-barcode", false, "merchello/merchello/ProductList/"));
                collection.Add(CreateTreeNode("orders", "", queryStrings, "Orders", "icon-receipt-dollar", false, "merchello/merchello/OrderList/"));
                collection.Add(CreateTreeNode("customers", "", queryStrings, "Customers", "icon-user", false, "merchello/merchello/CustomerList/"));
                collection.Add(CreateTreeNode("reports", "", queryStrings, "Reports", "icon-bar-chart", true, "merchello/merchello/Reports/"));
                collection.Add(CreateTreeNode("settings", "", queryStrings, "Settings", "icon-settings", true, "merchello/merchello/Settings/"));
            }

            //collection.AddRange(
            //    Services.DataTypeService.GetAllDataTypeDefinitions()
            //            .OrderBy(x => x.Name)
            //            .Select(dt =>
            //                    CreateTreeNode(
            //                        dt.Id.ToInvariantString(),
            //                        queryStrings,
            //                        dt.Name,
            //                        "icon-autofill",
            //                        false)));
            return collection;
        }

        // TODO : Umbraco Refactored the TreeNodeController and it's underlying collections.  This
        // TODO : broke with the introduction of the Umbraco Nightly Build 111
        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            var menu = new MenuItemCollection();

            if (id == "settings")
            {
                menu.Items.Add<RefreshNode, ActionRefresh>(ui.Text("actions", ActionRefresh.Instance.Alias), true);
            }

            //if (id == Constants.System.Root.ToInvariantString())
            //{
            //    // root actions              
            //    menu.Items.Add<RefreshNode, ActionRefresh>(ui.Text("actions", ActionRefresh.Instance.Alias), true);
            //    return menu;
            //}
            //else if (id == "catalog")
            //{
            //    //create product
            //    menu.Items.Add<MerchelloActionNewProduct>(ui.Text("actions", MerchelloActionNewProduct.Instance.Alias));
            //}
            //else
            //{
                //only have refres for each node
             //menu.Items.Add<RefreshNode, ActionRefresh>(ui.Text("actions", ActionRefresh.Instance.Alias), true);
            //}

            return menu;
        }

    }
}