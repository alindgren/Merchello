﻿(function (directives, undefined) {


    angular.module("umbraco").run(["$templateCache", function ($templateCache) {
        $templateCache.put("product-main-edit.html", '<div><div class="row-fluid"><div class="form-group col-xs-6 span6"><label for="price"><localize key="merchelloGeneral_price"/></label><input id="price" name="price" required data-ng-pattern="/^\d+(\.\d+)?$/" type="text" class="form-control col-xs-8 span8" data-ng-model="productVariant.price" /></div><div class="form-group col-xs-6 span6"><label for="saleprice"><localize key="merchelloGeneral_salePrice"/></label><input id="saleprice" name="saleprice" type="text" class="form-control col-xs-8 span8" data-ng-model="productVariant.salePrice" /></div></div><div class="row-fluid"><div class="form-group col-xs-6 span6"><label for="sku"><localize key="merchelloVariant_baseSku"/> <small><localize key="merchelloVariant_mustUniqueSku" /></small></label><input id="sku" data-ng-required="!creatingVariant" data-ng-disabled="creatingVariant" name="sku" required type="text" class="form-control col-xs-8 span8" data-ng-model="productVariant.sku" /></div><div class="form-group col-xs-6 span6"><label for="barcode"><localize key="merchelloVariant_barcode"/> <small><localize key="merchelloVariant_barcodeExamples"/></small></label><input id="barcode" name="barcode" type="text" class="form-control col-xs-8 span8" data-ng-model="productVariant.barcode" /></div></div><div class="row-fluid"><div class="form-group col-xs-6 span6"><label for="manufacturer"><localize key="merchelloVariant_manufacturer"/></label><input id="manufacturer" name="manufacturer" type="text" class="form-control col-xs-8 span8" data-ng-model="productVariant.manufacturer" /></div><div class="form-group col-xs-6 span6"><label for="manufacturermodelnumber"><localize key="merchelloVariant_manufacturerModel"/></label><input id="manufacturermodelnumber" name="manufacturermodelnumber" type="text" class="form-control col-xs-8 span8" data-ng-model="productVariant.manufacturerModelNumber" /></div></div><div class="row-fluid"><div class="form-group col-xs-6 span6"><label class="label-checkbox"><input name="digital" type="checkbox" data-ng-model="productVariant.hasDigitalDownload"> <span><localize key="merchelloVariant_hasDigitalDownload"/></span></label><label class="label-checkbox" data-ng-show="!creatingVariant && !editingVariant"><input name="hasoptions" type="checkbox" data-ng-model="product.hasOptions" data-ng-click="ensureInitialOption()"> <span><localize key="merchelloVariant_hasOptions" /></span></label><label class="label-checkbox"><input name="taxable" type="checkbox" data-ng-model="productVariant.taxable"> <span><localize key="merchelloVariant_isTaxable"/></span></label></div><div class="form-group col-xs-6 span6"><label class="label-checkbox"><input name="trackinventory" type="checkbox" data-ng-model="productVariant.trackInventory" data-ng-disabled="product.hasOptions || productVariant.hasDigitalDownload" data-ng-click="ensureCatalogInventory()"> <span><localize key="merchelloVariant_trackInventory"/></span></label><label class="label-checkbox"><input name="shippable" type="checkbox" data-ng-model="productVariant.shippable"> <span><localize key="merchelloVariant_isShippable" /></span></label></div></div></div>');
    }]);

    /**
     * @ngdoc directive
     * @name ProductVariantMainProperties
     * @function
     * 
     * @description
     * directive to collect the main information for the product / product variant (sku, price, etc)
     */

    directives.ProductVariantMainProperties = function () {
        return {
            restrict: 'E',
            replace: true,
            scope: {
                productVariant: '=',
                creatingVariant: '=',
                editingVariant: '='
            },
            templateUrl: '/App_Plugins/Merchello/Modules/Catalog/Directives/product-main-edit.html'
            //templateUrl: 'product-main-edit.html'
    };
    };

    angular.module("umbraco").directive('productVariantMainProperties', merchello.Directives.ProductVariantMainProperties);

}(window.merchello.Directives = window.merchello.Directives || {}));