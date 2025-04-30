using Newtonsoft.Json;
using System.Collections.Generic;

namespace SaphetyToDDL.Lib.Models
{
    /// <summary>
    /// Represents a detail.
    /// </summary>
    public class Detail
    {
        [JsonProperty("TransSerial")]
        public string TransSerial;

        [JsonProperty("TransDocument")]
        public string TransDocument;

        [JsonProperty("TransDocNumber")]
        public double? TransDocNumber;

        [JsonProperty("Key")]
        public double? Key;

        [JsonProperty("CreateDate")]
        public System.DateTime? CreateDate;

        [JsonProperty("CreateTime")]
        public System.DateTime? CreateTime;

        [JsonProperty("OriginCreateDate")]
        public System.DateTime? OriginCreateDate;

        [JsonProperty("OriginTransSerial")]
        public string OriginTransSerial;

        [JsonProperty("OriginTransDocument")]
        public string OriginTransDocument;

        [JsonProperty("OriginTransDocNumber")]
        public double? OriginTransDocNumber;

        [JsonProperty("OriginLineItemID")]
        public double? OriginLineItemID;

        [JsonProperty("OriginLineItemSubID")]
        public double? OriginLineItemSubID;

        [JsonProperty("OriginQuantity")]
        public double? OriginQuantity;

        [JsonProperty("OriginUnits")]
        public double? OriginUnits;

        [JsonProperty("DestinationTransSerial")]
        public string DestinationTransSerial;

        [JsonProperty("DestinationTransDocument")]
        public string DestinationTransDocument;

        [JsonProperty("DestinationTransDocNumber")]
        public double? DestinationTransDocNumber;

        [JsonProperty("DestinationLineItemID")]
        public double? DestinationLineItemID;

        [JsonProperty("DestinationLineItemSubID")]
        public double? DestinationLineItemSubID;

        [JsonProperty("DestinationQuantity")]
        public double? DestinationQuantity;

        [JsonProperty("DestinationUnits")]
        public double? DestinationUnits;

        [JsonProperty("TransactionConverted")]
        public bool? TransactionConverted;

        [JsonProperty("LineItemID")]
        public double? LineItemID;

        [JsonProperty("LineItemSubID")]
        public double? LineItemSubID;

        [JsonProperty("ItemID")]
        public string ItemID;

        [JsonProperty("POSItemID")]
        public string POSItemID;

        [JsonProperty("BarCode")]
        public string BarCode;

        //[JsonProperty("Lot")]
        //public Lot Lot;

        [JsonProperty("ItemType")]
        public double? ItemType;

        [JsonProperty("SupplierItemID")]
        public string SupplierItemID;

        //[JsonProperty("Color")]
        //public Color Color;

        //[JsonProperty("Size")]
        //public Size Size;

        [JsonProperty("GridSize")]
        public System.Collections.Generic.List<object> GridSize;

        [JsonProperty("Description")]
        public string Description;

        [JsonProperty("ShortDescription")]
        public string ShortDescription;

        [JsonProperty("TaxableGroupID")]
        public double? TaxableGroupID;

        //[JsonProperty("Taxes")]
        //public List<Taxis>? Taxes;

        [JsonProperty("TaxList")]
        public List<TaxList> TaxList;

        [JsonProperty("UnitOfSaleID")]
        public string UnitOfSaleID;

        [JsonProperty("AlternativeUnitOfStock")]
        public object AlternativeUnitOfStock;

        [JsonProperty("WeightUnitOfMeasure")]
        public string WeightUnitOfMeasure;

        [JsonProperty("WeightMeasure")]
        public double? WeightMeasure;

        [JsonProperty("Graduation")]
        public double? Graduation;

        [JsonProperty("ItemTax")]
        public double? ItemTax;

        [JsonProperty("ItemTax2")]
        public double? ItemTax2;

        [JsonProperty("ItemTax3")]
        public double? ItemTax3;

        [JsonProperty("PhysicalQtyRule")]
        public double? PhysicalQtyRule;

        [JsonProperty("CountedQuantity")]
        public double? CountedQuantity;

        [JsonProperty("ConsignmentQuantity")]
        public double? ConsignmentQuantity;

        [JsonProperty("Quantity1")]
        public double? Quantity1;

        [JsonProperty("Quantity2")]
        public double? Quantity2;

        [JsonProperty("Quantity3")]
        public double? Quantity3;

        [JsonProperty("Quantity4")]
        public double? Quantity4;

        [JsonProperty("ComponentQty")]
        public double? ComponentQty;

        [JsonProperty("UnitCasesCount")]
        public double? UnitCasesCount;

        [JsonProperty("DiscountPercent")]
        public double? DiscountPercent;

        [JsonProperty("DiscountValue")]
        public double? DiscountValue;

        [JsonProperty("UnitDiscountValue")]
        public double? UnitDiscountValue;

        [JsonProperty("OriginalUnitPrice")]
        public double? OriginalUnitPrice;

        [JsonProperty("OriginalTaxIncludedPrice")]
        public double? OriginalTaxIncludedPrice;

        [JsonProperty("OriginalDiscountPercent")]
        public double? OriginalDiscountPercent;

        [JsonProperty("FamilyID")]
        public double? FamilyID;

        [JsonProperty("FamilyName")]
        public string FamilyName;

        [JsonProperty("FamilyMaximumDiscount")]
        public double? FamilyMaximumDiscount;

        [JsonProperty("MandatoryCustomer")]
        public bool? MandatoryCustomer;

        [JsonProperty("WarehouseID")]
        public double? WarehouseID;

        [JsonProperty("WarehouseOutgoing")]
        public double? WarehouseOutgoing;

        [JsonProperty("WarehouseReceipt")]
        public double? WarehouseReceipt;

        [JsonProperty("CumulativeDiscountPercent1")]
        public double? CumulativeDiscountPercent1;

        [JsonProperty("CumulativeDiscountPercent2")]
        public double? CumulativeDiscountPercent2;

        [JsonProperty("CumulativeDiscountPercent3")]
        public double? CumulativeDiscountPercent3;

        [JsonProperty("PaymentDiscountPercent1")]
        public double? PaymentDiscountPercent1;

        [JsonProperty("PaymentDiscountPercent2")]
        public double? PaymentDiscountPercent2;

        [JsonProperty("PaymentDiscountPercent3")]
        public double? PaymentDiscountPercent3;

        [JsonProperty("PartyTypeCode")]
        public double? PartyTypeCode;

        [JsonProperty("PartyID")]
        public double? PartyID;

        [JsonProperty("CustomerImputeID")]
        public double? CustomerImputeID;

        [JsonProperty("ImputeToCustomerID")]
        public double? ImputeToCustomerID;

        [JsonProperty("BillToPartyID")]
        public double? BillToPartyID;

        [JsonProperty("SalesmanId")]
        public double? SalesmanId;

        [JsonProperty("TotalGrossAmount")]
        public double? TotalGrossAmount;

        [JsonProperty("TotalLineItemDiscountAmount")]
        public double? TotalLineItemDiscountAmount;

        [JsonProperty("TotalGlobalDiscountAmount")]
        public double? TotalGlobalDiscountAmount;

        [JsonProperty("TotalNetAmount")]
        public double? TotalNetAmount;

        [JsonProperty("TotalNetBaseTaxAmount")]
        public double? TotalNetBaseTaxAmount;

        [JsonProperty("TotalNetPrintAmout")]
        public double? TotalNetPrintAmout;

        [JsonProperty("TotalTaxAmount")]
        public double? TotalTaxAmount;

        [JsonProperty("TotalOtherTaxAmount")]
        public double? TotalOtherTaxAmount;

        [JsonProperty("TotalAmount")]
        public double? TotalAmount;

        [JsonProperty("TotalTaxIncludedAmount")]
        public double? TotalTaxIncludedAmount;

        [JsonProperty("ShareFreightAmount")]
        public double? ShareFreightAmount;

        //[JsonProperty("BaseCurrency")]
        //public BaseCurrency BaseCurrency;

        [JsonProperty("QntyReorderPoint")]
        public double? QntyReorderPoint;

        [JsonProperty("QntyAvailableBalanceCount")]
        public double? QntyAvailableBalanceCount;

        [JsonProperty("QntyPhysicalBalanceCount")]
        public double? QntyPhysicalBalanceCount;

        [JsonProperty("QntyWrPhysicalBalanceCount")]
        public double? QntyWrPhysicalBalanceCount;

        [JsonProperty("QntyWrAvailableBalanceCount")]
        public double? QntyWrAvailableBalanceCount;

        [JsonProperty("QntyPhysicalBalanceDiff")]
        public double? QntyPhysicalBalanceDiff;

        [JsonProperty("UnitsAvailableBalanceCount")]
        public double? UnitsAvailableBalanceCount;

        [JsonProperty("UnitsPhysicalBalanceCount")]
        public double? UnitsPhysicalBalanceCount;

        [JsonProperty("UnitsWrPhysicalBalanceCount")]
        public double? UnitsWrPhysicalBalanceCount;

        [JsonProperty("UnitsWrAvailableBalanceCount")]
        public double? UnitsWrAvailableBalanceCount;

        [JsonProperty("UnitsPhysicalBalanceDiff")]
        public double? UnitsPhysicalBalanceDiff;

        [JsonProperty("AverageCostPrice")]
        public double? AverageCostPrice;

        [JsonProperty("LastCostPrice")]
        public double? LastCostPrice;

        [JsonProperty("AverageCostStockValue")]
        public double? AverageCostStockValue;

        [JsonProperty("LastCostStockValue")]
        public double? LastCostStockValue;

        [JsonProperty("DatePhysicalBalanceCount")]
        public System.DateTime? DatePhysicalBalanceCount;

        [JsonProperty("TimeAdjustmentBalanceCount")]
        public System.DateTime? TimeAdjustmentBalanceCount;

        [JsonProperty("FrequentShopperPoints")]
        public double? FrequentShopperPoints;

        [JsonProperty("VoucherGiftValue")]
        public double? VoucherGiftValue;

        [JsonProperty("TransactionDetailClosed")]
        public bool? TransactionDetailClosed;

        [JsonProperty("TempContractReferenceNumber")]
        public object TempContractReferenceNumber;

        //[JsonProperty("ItemExtraInfo")]
        //public ItemExtraInfo? ItemExtraInfo;

        //[JsonProperty("ItemProperties")]
        //public ItemProperties ItemProperties;

        [JsonProperty("ItemContractGuid")]
        public string ItemContractGuid;

        [JsonProperty("IsComponent")]
        public bool? IsComponent;

        [JsonProperty("Comments")]
        public string Comments;

        [JsonProperty("SecondHandTaxRegimen")]
        public bool? SecondHandTaxRegimen;

        [JsonProperty("PriceAndDiscountChangeFlags")]
        public double? PriceAndDiscountChangeFlags;

        [JsonProperty("OfferTypeFlags")]
        public double? OfferTypeFlags;

        [JsonProperty("PromotionApplied")]
        public bool? PromotionApplied;

        [JsonProperty("PromotionAppliedQERO")]
        public bool? PromotionAppliedQERO;

        [JsonProperty("ProductCode")]
        public string ProductCode;

        [JsonProperty("PlantProtectionSaleAuthNumber")]
        public string PlantProtectionSaleAuthNumber;

        [JsonProperty("ProductCategory")]
        public double? ProductCategory;

        [JsonProperty("ExtendedProperties")]
        public System.Collections.Generic.List<object> ExtendedProperties;

        //[JsonProperty("DiscountSettings")]
        //public DiscountSettings? DiscountSettings;

        [JsonProperty("Guid")]
        public string Guid;

        [JsonProperty("Quantity")]
        public double? Quantity;

        [JsonProperty("Units")]
        public double? Units;

        [JsonProperty("StockUnits")]
        public double? StockUnits;

        [JsonProperty("UnitConversion")]
        public double? UnitConversion;

        [JsonProperty("PackQuantity")]
        public double? PackQuantity;

        [JsonProperty("QuantityFactor")]
        public double? QuantityFactor;

        [JsonProperty("PackUnitPrice")]
        public double? PackUnitPrice;

        [JsonProperty("PackTaxIncludedPrice")]
        public double? PackTaxIncludedPrice;

        [JsonProperty("UnitList")]
        public System.Collections.Generic.List<object> UnitList;

        [JsonProperty("HasComponents")]
        public bool? HasComponents;

        [JsonProperty("HasPropertiesOnComponents")]
        public bool? HasPropertiesOnComponents;

        [JsonProperty("TaxIncludedPrice")]
        public double? TaxIncludedPrice;

        [JsonProperty("UnitPrice")]
        public double? UnitPrice;

        [JsonProperty("ActualDeliveryDate")]
        public System.DateTime? ActualDeliveryDate;

        [JsonProperty("PhysicalQtyDate")]
        public System.DateTime? PhysicalQtyDate;

        [JsonProperty("RequiredDeliveryDateTime")]
        public System.DateTime? RequiredDeliveryDateTime;

        [JsonProperty("ComponentList")]
        public System.Collections.Generic.List<object> ComponentList;

        [JsonProperty("Signature")]
        public string Signature;

        [JsonProperty("ExtraFieldList")]
        public System.Collections.Generic.List<object> ExtraFieldList;

        [JsonProperty("RetentionTax")]
        public double? RetentionTax;

        [JsonProperty("Notes")]
        public List<string> DetailNotes;
    }
}
