using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Geta.Commerce.Payments.Verifone.HostedPages.Mvc;
using Geta.Verifone;
using Geta.Verifone.Extensions;
using Geta.Verifone.Security;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Website;

namespace Geta.Commerce.Payments.Verifone.HostedPages.Models
{
    [ModelBinder(typeof(VerifoneModelBinder))]
    public class VerifonePaymentRequest : VerifoneParameterModelBase, IPaymentOption
    {
        public Guid PaymentMethodId { get; set; }
        public string TransactionNumber { get; set; }
        public string FilingCode { get; set; }

        [BindAlias(VerifoneConstants.ParameterName.PaymentLocale)]
        public string PaymentLocale
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.PaymentLocale); }
            set { SetParameterValue(VerifoneConstants.ParameterName.PaymentLocale, value.Truncate(VerifoneConstants.ParameterMaxLength.PaymentLocale)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.PaymentTimestamp)]
        public string PaymentTimestamp
        {
            get
            {
                string value = GetParameterValue(VerifoneConstants.ParameterName.PaymentTimestamp);

                return string.IsNullOrWhiteSpace(value) == false
                    ? value
                    : DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
            set
            {
                SetParameterValue(VerifoneConstants.ParameterName.PaymentTimestamp, value);
            }
        }

        [BindAlias(VerifoneConstants.ParameterName.MerchantAgreementCode)]
        public string MerchantAgreementCode
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.MerchantAgreementCode); }
            set { SetParameterValue(VerifoneConstants.ParameterName.MerchantAgreementCode, value.Truncate(VerifoneConstants.ParameterMaxLength.MerchantAgreementCode)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.OrderNumber)]
        public string OrderNumber
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.OrderNumber); }
            set { SetParameterValue(VerifoneConstants.ParameterName.OrderNumber, value.Truncate(VerifoneConstants.ParameterMaxLength.OrderNumber)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.OrderTimestamp)]
        public string OrderTimestamp
        {
            get
            {
                string value = GetParameterValue(VerifoneConstants.ParameterName.OrderTimestamp);

                return string.IsNullOrWhiteSpace(value) == false 
                    ? value
                    : DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
            set
            {
                SetParameterValue(VerifoneConstants.ParameterName.OrderTimestamp, value);
            }
        }

        [BindAlias(VerifoneConstants.ParameterName.OrderCurrencyCode)]
        public string OrderCurrencyCode
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.OrderCurrencyCode); }
            set { SetParameterValue(VerifoneConstants.ParameterName.OrderCurrencyCode, value.Truncate(VerifoneConstants.ParameterMaxLength.OrderCurrencyCode)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.OrderNetAmount)]
        public string OrderNetAmount
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.OrderNetAmount); }
            set { SetParameterValue(VerifoneConstants.ParameterName.OrderNetAmount, value.Truncate(VerifoneConstants.ParameterMaxLength.OrderNetAmount)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.OrderGrossAmount)]
        public string OrderGrossAmount
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.OrderGrossAmount); }
            set { SetParameterValue(VerifoneConstants.ParameterName.OrderGrossAmount, value.Truncate(VerifoneConstants.ParameterMaxLength.OrderGrossAmount)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.OrderVatAmount)]
        public string OrderVatAmount
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.OrderVatAmount); }
            set { SetParameterValue(VerifoneConstants.ParameterName.OrderVatAmount, value.Truncate(VerifoneConstants.ParameterMaxLength.OrderVatAmount)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.OrderVatPercentage)]
        public string OrderVatPercentage
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.OrderVatPercentage); }
            set { SetParameterValue(VerifoneConstants.ParameterName.OrderVatPercentage, value.Truncate(VerifoneConstants.ParameterMaxLength.OrderVatPercentage)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.BuyerFirstName)]
        public string BuyerFirstName
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.BuyerFirstName); }
            set { SetParameterValue(VerifoneConstants.ParameterName.BuyerFirstName, value.Truncate(VerifoneConstants.ParameterMaxLength.BuyerFirstName)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.BuyerLastName)]
        public string BuyerLastName
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.BuyerLastName); }
            set { SetParameterValue(VerifoneConstants.ParameterName.BuyerLastName, value.Truncate(VerifoneConstants.ParameterMaxLength.BuyerLastName)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.BuyerPhoneNumber)]
        public string BuyerPhoneNumber
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.BuyerPhoneNumber); }
            set { SetParameterValue(VerifoneConstants.ParameterName.BuyerPhoneNumber, value.Truncate(VerifoneConstants.ParameterMaxLength.BuyerPhoneNumber)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.BuyerEmailAddress)]
        public string BuyerEmailAddress
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.BuyerEmailAddress); }
            set { SetParameterValue(VerifoneConstants.ParameterName.BuyerEmailAddress, value.Truncate(VerifoneConstants.ParameterMaxLength.BuyerEmailAddress)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.DeliveryAddressLineOne)]
        public string DeliveryAddressLineOne
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressLineOne); }
            set { SetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressLineOne, value.Truncate(VerifoneConstants.ParameterMaxLength.DeliveryAddressLineOne)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.DeliveryAddressLineTwo)]
        public string DeliveryAddressLineTwo
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressLineTwo); }
            set { SetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressLineTwo, value.Truncate(VerifoneConstants.ParameterMaxLength.DeliveryAddressLineTwo)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.DeliveryAddressLineThree)]
        public string DeliveryAddressLineThree
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressLineThree); }
            set { SetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressLineThree, value.Truncate(VerifoneConstants.ParameterMaxLength.DeliveryAddressLineThree)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.DeliveryAddressCity)]
        public string DeliveryAddressCity
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressCity); }
            set { SetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressCity, value.Truncate(VerifoneConstants.ParameterMaxLength.DeliveryAddressCity)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.DeliveryAddressPostalCode)]
        public string DeliveryAddressPostalCode
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressPostalCode); }
            set { SetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressPostalCode, value.Truncate(VerifoneConstants.ParameterMaxLength.DeliveryAddressPostalCode)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.DeliveryAddressCountryCode)]
        public string DeliveryAddressCountryCode
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressCountryCode); }
            set { SetParameterValue(VerifoneConstants.ParameterName.DeliveryAddressCountryCode, value.Truncate(VerifoneConstants.ParameterMaxLength.DeliveryAddressCountryCode)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.PaymentMethodCode)]
        public string PaymentMethodCode
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.PaymentMethodCode); }
            set { SetParameterValue(VerifoneConstants.ParameterName.PaymentMethodCode, value.Truncate(VerifoneConstants.ParameterMaxLength.PaymentMethodCode)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.SavedPaymentMethodId)]
        public string SavedPaymentMethodId
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.SavedPaymentMethodId); }
            set { SetParameterValue(VerifoneConstants.ParameterName.SavedPaymentMethodId, value.Truncate(VerifoneConstants.ParameterMaxLength.SavedPaymentMethodId)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.StyleCode)]
        public string StyleCode
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.StyleCode); }
            set { SetParameterValue(VerifoneConstants.ParameterName.StyleCode, value.Truncate(VerifoneConstants.ParameterMaxLength.StyleCode)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.RecurringPayment)]
        public string RecurringPayment
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.RecurringPayment); }
            set { SetParameterValue(VerifoneConstants.ParameterName.RecurringPayment, value.Truncate(VerifoneConstants.ParameterMaxLength.RecurringPayment)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.DeferredPayment)]
        public string DeferredPayment
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.DeferredPayment); }
            set { SetParameterValue(VerifoneConstants.ParameterName.DeferredPayment, value.Truncate(VerifoneConstants.ParameterMaxLength.DeferredPayment)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.SavePaymentMethod)]
        public string SavePaymentMethod
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.SavePaymentMethod); }
            set { SetParameterValue(VerifoneConstants.ParameterName.SavePaymentMethod, value.Truncate(VerifoneConstants.ParameterMaxLength.SavePaymentMethod)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.SkipConfirmationPage)]
        public string SkipConfirmationPage
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.SkipConfirmationPage); }
            set { SetParameterValue(VerifoneConstants.ParameterName.SkipConfirmationPage, value.Truncate(VerifoneConstants.ParameterMaxLength.SkipConfirmationPage)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.ShortSuccessUrl)]
        public string ShortSuccessUrl
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.ShortSuccessUrl); }
            set { SetParameterValue(VerifoneConstants.ParameterName.ShortSuccessUrl, value.Truncate(VerifoneConstants.ParameterMaxLength.ShortSuccessUrl)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.LongSuccessUrl)]
        public string LongSuccessUrl
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.LongSuccessUrl); }
            set { SetParameterValue(VerifoneConstants.ParameterName.LongSuccessUrl, value.Truncate(VerifoneConstants.ParameterMaxLength.LongSuccessUrl)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.ShortRejectedUrl)]
        public string ShortRejectedUrl
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.ShortRejectedUrl); }
            set { SetParameterValue(VerifoneConstants.ParameterName.ShortRejectedUrl, value.Truncate(VerifoneConstants.ParameterMaxLength.ShortRejectedUrl)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.LongRejectedUrl)]
        public string LongRejectedUrl
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.LongRejectedUrl); }
            set { SetParameterValue(VerifoneConstants.ParameterName.LongRejectedUrl, value.Truncate(VerifoneConstants.ParameterMaxLength.LongRejectedUrl)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.ShortCancelUrl)]
        public string ShortCancelUrl
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.ShortCancelUrl); }
            set { SetParameterValue(VerifoneConstants.ParameterName.ShortCancelUrl, value.Truncate(VerifoneConstants.ParameterMaxLength.ShortCancelurl)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.LongCancelUrl)]
        public string LongCancelUrl
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.LongCancelUrl); }
            set { SetParameterValue(VerifoneConstants.ParameterName.LongCancelUrl, value.Truncate(VerifoneConstants.ParameterMaxLength.LongCancelUrl)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.ShortExpiredUrl)]
        public string ShortExpiredUrl
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.ShortExpiredUrl); }
            set { SetParameterValue(VerifoneConstants.ParameterName.ShortExpiredUrl, value.Truncate(VerifoneConstants.ParameterMaxLength.ShortExpiredUrl)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.LongExpiredUrl)]
        public string LongExpiredUrl
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.LongExpiredUrl); }
            set { SetParameterValue(VerifoneConstants.ParameterName.LongExpiredUrl, value.Truncate(VerifoneConstants.ParameterMaxLength.LongExpiredUrl)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.ShortErrorUrl)]
        public string ShortErrorUrl
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.ShortErrorUrl); }
            set { SetParameterValue(VerifoneConstants.ParameterName.ShortErrorUrl, value.Truncate(VerifoneConstants.ParameterMaxLength.ShortErrorUrl)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.LongErrorUrl)]
        public string LongErrorUrl
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.LongErrorUrl); }
            set { SetParameterValue(VerifoneConstants.ParameterName.LongErrorUrl, value.Truncate(VerifoneConstants.ParameterMaxLength.LongErrorUrl)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.Software)]
        public string Software
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.Software); }
            set { SetParameterValue(VerifoneConstants.ParameterName.Software, value.Truncate(VerifoneConstants.ParameterMaxLength.Software)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.SoftwareVersion)]
        public string SoftwareVersion
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.SoftwareVersion); }
            set { SetParameterValue(VerifoneConstants.ParameterName.SoftwareVersion, value.Truncate(VerifoneConstants.ParameterMaxLength.SoftwareVersion)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.InterfaceVersion)]
        public string InterfaceVersion
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.InterfaceVersion); }
            set { SetParameterValue(VerifoneConstants.ParameterName.InterfaceVersion, value.Truncate(VerifoneConstants.ParameterMaxLength.InterfaceVersion)); }
        }

        [BindAlias(VerifoneConstants.ParameterName.SignatureOne)]
        public string SignatureOne
        {
            get
            {
                string content = PointSignatureUtil.FormatParameters(_parameters);
                string signatureOne = PointSignatureUtil.CreateSignature(PointCertificateUtil.GetMerchantCertificate(), content, HashAlgorithm.SHA1);
                SetParameterValue(VerifoneConstants.ParameterName.SignatureOne, signatureOne);
                return signatureOne;
            }
        }

        [BindAlias(VerifoneConstants.ParameterName.SignatureTwo)]
        public string SignatureTwo
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.SignatureTwo); }
            set { SetParameterValue(VerifoneConstants.ParameterName.SignatureTwo, value.Truncate(VerifoneConstants.ParameterMaxLength.SignatureTwo)); }
        }

        public string Submit
        {
            get { return GetParameterValue(VerifoneConstants.ParameterName.Submit); }
            set { SetParameterValue(VerifoneConstants.ParameterName.Submit, value.Truncate(VerifoneConstants.ParameterMaxLength.Submit)); }
        }

        public readonly IList<BasketItem> BasketItems;

        public SortedDictionary<string, string> Parameters
        {
            get
            {
                return _parameters;
            }
        }

        public VerifonePaymentRequest()
        {
            InitializeParameters();
            BasketItems = new List<BasketItem>();
        }
        
        public override SortedDictionary<string, string> GetParameters()
        {
            EnsureParameters();
            return base.GetParameters();
        }
        
        public bool ValidateData()
        {
            return true;
        }

        public Payment PreProcess(OrderForm orderForm)
        {
            return null;
        }

        public bool PostProcess(OrderForm orderForm)
        {
            return true;
        }

        protected virtual void EnsureParameters()
        {
            SetParameterValue(VerifoneConstants.ParameterName.PaymentToken, CreatePaymentToken());
            SetParameterValue(VerifoneConstants.ParameterName.SignatureOne, CreateSignatureOne());
            //_parameters[VerifoneConstants.ParameterName.SignatureTwo] = CreateSignatureTwo();
        }

        protected virtual string CreatePaymentToken()
        {
            return PointSignatureUtil.CreatePaymentToken(_parameters);
        }

        protected virtual string CreateSignatureOne()
        {
            string content = PointSignatureUtil.FormatParameters(_parameters);
            return PointSignatureUtil.CreateSignature(PointCertificateUtil.GetMerchantCertificate(), content, HashAlgorithm.SHA1);
        }
        
        private void InitializeParameters()
        {
            var utcNow = DateTime.Now.ToUniversalTime();
            PaymentLocale = "no_NO";
            PaymentTimestamp = utcNow.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            OrderTimestamp = utcNow.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}