﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace SaphetyToDDL.Lib.Models
{
    /// <summary>
    /// Represents an item transaction.
    /// </summary>
    public class ItemTransaction
    {
        [JsonProperty("TransDocType")]
        public double? TransDocType;

        [JsonProperty("TransBehavior")]
        public double? TransBehavior;

        [JsonProperty("TransactionGuid")]
        public string TransactionGuid;

        [JsonProperty("TempTransIndex")]
        public double? TempTransIndex;

        [JsonProperty("CreateDate")]
        public System.DateTime? CreateDate;

        [JsonProperty("CreateTime")]
        public System.DateTime? CreateTime;

        [JsonProperty("DeferredPaymentDate")]
        public System.DateTime? DeferredPaymentDate;

        [JsonProperty("ActualDeliveryDate")]
        public System.DateTime? ActualDeliveryDate;

        [JsonProperty("ContractReferenceNumber")]
        public string ContractReferenceNumber;

        [JsonProperty("DefaultWarehouse")]
        public double? DefaultWarehouse;

        [JsonProperty("PartyAddressID")]
        public double? PartyAddressID;

        [JsonProperty("PartyAddressLine1")]
        public string PartyAddressLine1;

        [JsonProperty("PartyAddressLine2")]
        public string PartyAddressLine2;

        [JsonProperty("PartyPostalCode")]
        public string PartyPostalCode;

        [JsonProperty("PartyGLN")]
        public string PartyGLN;

        [JsonProperty("PartyDelivery")]
        public string PartyDelivery;

        [JsonProperty("BillToPartyAddressID")]
        public double? BillToPartyAddressID;

        [JsonProperty("BillToPartyAddressLine1")]
        public object BillToPartyAddressLine1;

        [JsonProperty("BillToPartyAddressLine2")]
        public object BillToPartyAddressLine2;

        [JsonProperty("BillToPartyPostalCode")]
        public object BillToPartyPostalCode;

        //[JsonProperty("Zone")]
        //public Zone Zone;

        //[JsonProperty("BaseCurrency")]
        //public BaseCurrency BaseCurrency;

        //[JsonProperty("AlternCurrency")]
        //public AlternCurrency? AlternCurrency;

        [JsonProperty("Salesman")]
        public Salesman Salesman;

        [JsonProperty("Payment")]
        public Payment Payment;

        [JsonProperty("Tender")]
        public Tender Tender;

        //[JsonProperty("Carrier")]
        //public Carrier Carrier;

        [JsonProperty("LoadPlace")]
        public LoadPlace LoadPlace;

        [JsonProperty("UnloadPlace")]
        public UnloadPlace UnloadPlace;

        [JsonProperty("LoadPlaceDateTime")]
        public System.DateTime? LoadPlaceDateTime;

        [JsonProperty("UnloadPlaceDateTime")]
        public System.DateTime? UnloadPlaceDateTime;

        [JsonProperty("LoadPlaceAddress")]
        public LoadPlaceAddress LoadPlaceAddress;

        [JsonProperty("UnloadPlaceAddress")]
        public UnloadPlaceAddress UnloadPlaceAddress;

        [JsonProperty("TransactionTaxIncluded")]
        public bool? TransactionTaxIncluded = false;

        [JsonProperty("TransactionCreditSale")]
        public bool? TransactionCreditSale;

        [JsonProperty("TransactionConverted")]
        public bool? TransactionConverted;

        [JsonProperty("Comments")]
        public string Comments;

        [JsonProperty("RectificationMotive")]
        public string RectificationMotive;

        [JsonProperty("RetentionTax")]
        public double? RetentionTax;

        [JsonProperty("GlobalDiscountPercent")]
        public double? GlobalDiscountPercent;

        [JsonProperty("PaymentDiscountPercent")]
        public double? PaymentDiscountPercent;

        [JsonProperty("PaymentCumulativeDiscountPercent1")]
        public double? PaymentCumulativeDiscountPercent1;

        [JsonProperty("PaymentCumulativeDiscountPercent2")]
        public double? PaymentCumulativeDiscountPercent2;

        [JsonProperty("PaymentCumulativeDiscountPercent3")]
        public double? PaymentCumulativeDiscountPercent3;

        [JsonProperty("TotalGrossAmount")]
        public double? TotalGrossAmount;

        [JsonProperty("TotalLineItemDiscountAmount")]
        public double? TotalLineItemDiscountAmount;

        [JsonProperty("TotalPaymentDiscountAmount")]
        public double? TotalPaymentDiscountAmount;

        [JsonProperty("TotalRedeemedVoucherAmount")]
        public double? TotalRedeemedVoucherAmount;

        [JsonProperty("TotalGlobalDiscountAmount")]
        public double? TotalGlobalDiscountAmount;

        [JsonProperty("TotalNetAmount")]
        public double? TotalNetAmount;

        [JsonProperty("TotalTaxAmount")]
        public double? TotalTaxAmount;

        [JsonProperty("TotalOtherTaxesAmount")]
        public double? TotalOtherTaxesAmount;

        [JsonProperty("TotalFreightAmount")]
        public double? TotalFreightAmount;

        [JsonProperty("TotalFreightAmountWithTax")]
        public double? TotalFreightAmountWithTax;

        [JsonProperty("FreightTaxableGroupID")]
        public double? FreightTaxableGroupID;

        [JsonProperty("FreightTaxes")]
        public System.Collections.Generic.List<object> FreightTaxes;

        [JsonProperty("FreightTaxList")]
        public System.Collections.Generic.List<object> FreightTaxList;

        [JsonProperty("TotalAdjustmentAmount")]
        public double? TotalAdjustmentAmount;

        [JsonProperty("TotalAmount")]
        public double? TotalAmount;

        [JsonProperty("TotalRetentionAmount")]
        public double? TotalRetentionAmount;

        [JsonProperty("TotalAdvancementRetentionAmount")]
        public double? TotalAdvancementRetentionAmount;

        [JsonProperty("TotalAllowanceAmount")]
        public double? TotalAllowanceAmount;

        [JsonProperty("TotalChargeAmount")]
        public double? TotalChargeAmount;

        [JsonProperty("TotalTransactionAmount")]
        public double? TotalTransactionAmount;

        [JsonProperty("TotalPayedAmount")]
        public double? TotalPayedAmount;

        [JsonProperty("SecondIssue")]
        public bool? SecondIssue;

        [JsonProperty("TransStatus")]
        public double? TransStatus;

        [JsonProperty("StatusFlags")]
        public double? StatusFlags;

        [JsonProperty("SecondHandTaxRegimen")]
        public bool? SecondHandTaxRegimen;

        //[JsonProperty("Taxes")]
        //public List<Taxis>? Taxes;

        [JsonProperty("Details")]
        public List<Detail> Details;

        [JsonProperty("LedgerAccount")]
        public System.Collections.Generic.List<object> LedgerAccount;

        [JsonProperty("TenderLineItem")]
        public System.Collections.Generic.List<object> TenderLineItem;

        //[JsonProperty("ExtraFieldList")]
        //public List<ExtraFieldList>? ExtraFieldList;

        [JsonProperty("BankReceiptList")]
        public System.Collections.Generic.List<object> BankReceiptList;

        [JsonProperty("AccountTransaction")]
        public object AccountTransaction;

        //[JsonProperty("WorkstationStamp")]
        //public WorkstationStamp? WorkstationStamp;

        [JsonProperty("BalconyScaleTicketProcessed")]
        public System.Collections.Generic.List<object> BalconyScaleTicketProcessed;

        [JsonProperty("AllowancesCharges")]
        public System.Collections.Generic.List<object> AllowancesCharges;

        [JsonProperty("RedeemedVouchers")]
        public System.Collections.Generic.List<object> RedeemedVouchers;

        [JsonProperty("FrequentShopperPoints")]
        public double? FrequentShopperPoints;

        [JsonProperty("DiscountFreqShopperPoints")]
        public double? DiscountFreqShopperPoints;

        [JsonProperty("AccountingExportDate")]
        public System.DateTime? AccountingExportDate;

        [JsonProperty("VoucherSpentValueAmount")]
        public double? VoucherSpentValueAmount;

        [JsonProperty("VoucherDocSpentList")]
        public System.Collections.Generic.List<object> VoucherDocSpentList;

        [JsonProperty("Reconciled")]
        public bool? Reconciled;

        [JsonProperty("DownPaymentInvoice")]
        public bool? DownPaymentInvoice;

        [JsonProperty("VoucherGiftTransSerial")]
        public string VoucherGiftTransSerial;

        [JsonProperty("VoucherGiftTransDocument")]
        public string VoucherGiftTransDocument;

        [JsonProperty("VoucherGiftTransDocNumber")]
        public double? VoucherGiftTransDocNumber;

        [JsonProperty("VoucherGiftValue")]
        public double? VoucherGiftValue;

        [JsonProperty("VoucherGiftFamilyList")]
        public object VoucherGiftFamilyList;

        [JsonProperty("TotalOtherCostAmount")]
        public double? TotalOtherCostAmount;

        [JsonProperty("BuyShareOtherCostList")]
        public System.Collections.Generic.List<object> BuyShareOtherCostList;

        [JsonProperty("CurrentStatusID")]
        public string CurrentStatusID;

        [JsonProperty("AccountingOperation")]
        public string AccountingOperation;

        [JsonProperty("PrintedCopies")]
        public double? PrintedCopies;

        [JsonProperty("OfferVoucherGiftValue")]
        public double? OfferVoucherGiftValue;

        //[JsonProperty("Till")]
        //public Till Till;

        [JsonProperty("SignatureInvoiceNo")]
        public string SignatureInvoiceNo;

        [JsonProperty("VoidMotive")]
        public object VoidMotive;

        [JsonProperty("SystemEntryUser")]
        public string SystemEntryUser;

        [JsonProperty("TransmissionStatus")]
        public double? TransmissionStatus;

        [JsonProperty("ShipmentDocumentType")]
        public double? ShipmentDocumentType;

        [JsonProperty("RegistrationPlate")]
        public string RegistrationPlate;

        [JsonProperty("CashAccountingSchemeType")]
        public double? CashAccountingSchemeType;

        [JsonProperty("CustomerPaidDeductibleAmount")]
        public double? CustomerPaidDeductibleAmount;

        [JsonProperty("PaymentDiscountAmountChangeFlags")]
        public double? PaymentDiscountAmountChangeFlags;

        [JsonProperty("PlantProtectionActivityAuth")]
        public string PlantProtectionActivityAuth;

        [JsonProperty("PlantProtectionApplicator")]
        public string PlantProtectionApplicator;

        [JsonProperty("EInvoiceStatus")]
        public double? EInvoiceStatus;

        [JsonProperty("EInvoiceStatusDate")]
        public System.DateTime? EInvoiceStatusDate;

        [JsonProperty("EInvoiceSender")]
        public string EInvoiceSender;

        [JsonProperty("EInvoiceReceiver")]
        public string EInvoiceReceiver;

        [JsonProperty("EInvoiceSubmitDate")]
        public System.DateTime? EInvoiceSubmitDate;

        [JsonProperty("LoyaltyId")]
        public string LoyaltyId;

        [JsonProperty("LoyaltyUploadDate")]
        public System.DateTime? LoyaltyUploadDate;

        [JsonProperty("BalanceFreqShopperPoints")]
        public double? BalanceFreqShopperPoints;

        [JsonProperty("OnlineReceiptTagType")]
        public double? OnlineReceiptTagType;

        [JsonProperty("OnlineReceiptTag")]
        public string OnlineReceiptTag;

        [JsonProperty("OnlineReceiptToken")]
        public string OnlineReceiptToken;

        [JsonProperty("OnlineReceiptEmail")]
        public string OnlineReceiptEmail;

        [JsonProperty("PABudgetExpenditureNumber")]
        public string PABudgetExpenditureNumber;

        [JsonProperty("PAContractNumber")]
        public string PAContractNumber;

        [JsonProperty("PACommitmentNumber")]
        public string PACommitmentNumber;

        [JsonProperty("ATCUD")]
        public string ATCUD;

        [JsonProperty("QRCode")]
        public string QRCode;

        [JsonProperty("FrequentShopperProcessingState")]
        public double? FrequentShopperProcessingState;

        [JsonProperty("ATDocCodeId")]
        public string ATDocCodeId;

        //[JsonProperty("Entity")]
        //public Entity? Entity;

        //[JsonProperty("BillToEntity")]
        //public BillToEntity? BillToEntity;

        [JsonProperty("PartyTypeCode")]
        public double? PartyTypeCode;

        [JsonProperty("BillToPartyTypeCode")]
        public double? BillToPartyTypeCode;

        [JsonProperty("ExtendedProperties")]
        public System.Collections.Generic.List<object> ExtendedProperties;

        [JsonProperty("CustomerImpute")]
        public object CustomerImpute;

        [JsonProperty("TotalAdvancementAmount")]
        public double? TotalAdvancementAmount;

        [JsonProperty("TotalAdvancementNetAmount")]
        public double? TotalAdvancementNetAmount;

        [JsonProperty("CustomerParty")]
        public Party CustomerParty;

        [JsonProperty("SupplierParty")]
        public Party SupplierParty;

        [JsonProperty("Party")]
        public Party Party;

        //[JsonProperty("BillToParty")]
        //public BillToParty? BillToParty;

        [JsonProperty("PartyID")]
        public double? PartyID;

        [JsonProperty("BillToPartyID")]
        public double? BillToPartyID;

        [JsonProperty("PartyOrganizationName")]
        public string PartyOrganizationName;

        [JsonProperty("BillToPartyOrganizationName")]
        public object BillToPartyOrganizationName;

        [JsonProperty("PartyFederalTaxID")]
        public string PartyFederalTaxID;

        [JsonProperty("BillToPartyFederalTaxID")]
        public object BillToPartyFederalTaxID;

        [JsonProperty("PartyFiscalStatus")]
        public double? PartyFiscalStatus;

        [JsonProperty("BillToPartyFiscalStatus")]
        public double? BillToPartyFiscalStatus;

        [JsonProperty("PartyTelephone")]
        public string PartyTelephone;

        [JsonProperty("PartyFax")]
        public string PartyFax;

        [JsonProperty("PartyMobilePhone")]
        public string PartyMobilePhone;

        [JsonProperty("PartyEmail")]
        public string PartyEmail;

        [JsonProperty("PartyAccountBalance")]
        public double? PartyAccountBalance;

        [JsonProperty("BillToPartyAccountBalance")]
        public double? BillToPartyAccountBalance;

        [JsonProperty("PartyAccountCurrencyID")]
        public string PartyAccountCurrencyID;

        [JsonProperty("BillToPartyAccountCurrencyID")]
        public string BillToPartyAccountCurrencyID;

        [JsonProperty("PartyFrequentShopperPoints")]
        public double? PartyFrequentShopperPoints;

        [JsonProperty("PartyCountryID")]
        public string PartyCountryID;

        [JsonProperty("BillToPartyCountryID")]
        public object BillToPartyCountryID;

        [JsonProperty("PartyProvinceID")]
        public string PartyProvinceID;

        [JsonProperty("BillToPartyProvinceID")]
        public object BillToPartyProvinceID;

        [JsonProperty("PartyLocalityID")]
        public double? PartyLocalityID;

        [JsonProperty("BillToPartyLocalityID")]
        public double? BillToPartyLocalityID;

        [JsonProperty("PartyCarrierID")]
        public double? PartyCarrierID;

        [JsonProperty("PartyBankAccountNumber")]
        public object PartyBankAccountNumber;

        [JsonProperty("PartyBankCode")]
        public object PartyBankCode;

        [JsonProperty("PartyBranchCode")]
        public object PartyBranchCode;

        [JsonProperty("PartyAccountCheckDigit")]
        public object PartyAccountCheckDigit;

        [JsonProperty("PartyBankName")]
        public object PartyBankName;

        [JsonProperty("PartyPriceItemDecimalPlaces")]
        public double? PartyPriceItemDecimalPlaces;

        [JsonProperty("PartyFreightOnLedgerAccount")]
        public bool? PartyFreightOnLedgerAccount;

        [JsonProperty("PartyAccountingGeneralLedgerID")]
        public string PartyAccountingGeneralLedgerID;

        [JsonProperty("PartySupplierCustomerID")]
        public object PartySupplierCustomerID;

        [JsonProperty("PartyVehicleID")]
        public double? PartyVehicleID;

        [JsonProperty("PartyVehicleLicensePlate")]
        public object PartyVehicleLicensePlate;

        [JsonProperty("PartyVehicleMake")]
        public object PartyVehicleMake;

        [JsonProperty("PartyVehicleModel")]
        public object PartyVehicleModel;

        [JsonProperty("PartyVehicleYear")]
        public double? PartyVehicleYear;

        [JsonProperty("PartyVehicleMonth")]
        public double? PartyVehicleMonth;

        [JsonProperty("PartyVehicleDateOfFirstRegistration")]
        public System.DateTime? PartyVehicleDateOfFirstRegistration;

        [JsonProperty("PartyVehicleColor")]
        public object PartyVehicleColor;

        [JsonProperty("PartyVehicleFrameNumber")]
        public object PartyVehicleFrameNumber;

        [JsonProperty("PartyVehicleEngineNumber")]
        public object PartyVehicleEngineNumber;

        [JsonProperty("PartyVehicleKilometers")]
        public double? PartyVehicleKilometers;

        [JsonProperty("PartyVehicleOriginalKilometers")]
        public double? PartyVehicleOriginalKilometers;

        [JsonProperty("PartyVehicleComments")]
        public object PartyVehicleComments;

        [JsonProperty("PartyWorkID")]
        public double? PartyWorkID;

        [JsonProperty("PartyWorkComments")]
        public object PartyWorkComments;

        [JsonProperty("PartyWorkDescription")]
        public object PartyWorkDescription;

        [JsonProperty("PartyWorkBudgetValue")]
        public double? PartyWorkBudgetValue;

        [JsonProperty("PartyWorkStartDate")]
        public System.DateTime? PartyWorkStartDate;

        [JsonProperty("PartyWorkEndDate")]
        public System.DateTime? PartyWorkEndDate;

        [JsonProperty("PartyCustomerLevel")]
        public double? PartyCustomerLevel;

        [JsonProperty("PartyPrintCopies")]
        public double? PartyPrintCopies;

        [JsonProperty("OriginatingON")]
        public string OriginatingON;

        [JsonProperty("HandWrittenTransactionNumber")]
        public string HandWrittenTransactionNumber;

        [JsonProperty("IsOnPreparednessState")]
        public bool? IsOnPreparednessState;

        [JsonProperty("HasValidSignature")]
        public bool? HasValidSignature;

        [JsonProperty("Signature")]
        public object Signature;

        [JsonProperty("SignatureMessage")]
        public object SignatureMessage;

        [JsonProperty("SignatureControl")]
        public double? SignatureControl;

        [JsonProperty("SoftwareCertificateNumber")]
        public double? SoftwareCertificateNumber;

        [JsonProperty("SystemEntryDate")]
        public System.DateTime? SystemEntryDate;

        //[JsonProperty("TransactionID")]
        //public TransactionID TransactionID;

        [JsonProperty("TransSerial")]
        public string TransSerial;

        [JsonProperty("TransDocument")]
        public string TransDocument;

        [JsonProperty("TransDocNumber")]
        public double? TransDocNumber;

        [JsonProperty("TotalServiceAmount")]
        public double? TotalServiceAmount;

        [JsonProperty("RetentionPaidAmount")]
        public double? RetentionPaidAmount;

        [JsonProperty("CanBeCalculatedOnTaxIncluded")]
        public bool? CanBeCalculatedOnTaxIncluded;

        [JsonProperty("WithholdingTaxType")]
        public string WithholdingTaxType;

        [JsonProperty("_ISignableTransaction_Signature")]
        public object ISignableTransactionSignature;

        [JsonProperty("_ISignableTransaction_TotalAmount")]
        public double? ISignableTransactionTotalAmount;

        [JsonProperty("_ISignableTransaction_SystemEntryDate")]
        public System.DateTime? ISignableTransactionSystemEntryDate;

        [JsonProperty("_ISignableTransaction_TransactionID")]
        public string ISignableTransactionTransactionID;

        [JsonProperty("Base64")]
        public string Base64;
    }
}