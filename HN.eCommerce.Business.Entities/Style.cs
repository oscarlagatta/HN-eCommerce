using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Core;

namespace HN.eCommerce.Business.Entities
{
    public class Style : EntityBase, IIdentifiableEntity
    {
        public int MerretStyleID { get; set; }
        public string MerretDescription { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string BrandID { get; set; }
        public string WebAttribute1 { get; set; }
        public string WebAttribute2 { get; set; }
        public string WebAttribute3 { get; set; }
        public string WebAttribute4 { get; set; }
        public string WebAttribute5 { get; set; }
        public string WebAttribute6 { get; set; }
        public string WebAttribute7 { get; set; }
        public string WebAttribute8 { get; set; }
        public string WebAttribute9 { get; set; }
        public string WebAttribute10 { get; set; }
        public string ShortWebDescription { get; set; }
        public string LongWebDescription { get; set; }
        public Nullable<int> StyleTemplateID { get; set; }
        public bool Live { get; set; }
        public Nullable<decimal> MinPrice { get; set; }
        public Nullable<decimal> MaxPrice { get; set; }
        public Nullable<bool> OverrideMerretVAT { get; set; }
        public Nullable<decimal> VAT { get; set; }
        public Nullable<int> StyleType { get; set; }
        public string ExtendedProductDetail { get; set; }
        public Nullable<short> GradeID { get; set; }
        public Nullable<bool> HasImage { get; set; }
        public int BucketID { get; set; }
        public string Season { get; set; }
        public string WebApplicable { get; set; }
        public Nullable<bool> IsMatrix { get; set; }
        public bool IsHamper { get; set; }
        public bool HasGiftBox { get; set; }
        public Nullable<bool> EnabledMagento { get; set; }
        public bool MarkedDown { get; set; }
        public Nullable<int> MagentoID { get; set; }
        public Nullable<int> MaxItemsBasket { get; set; }
        public Nullable<bool> IsCategoryDirty { get; set; }
        public string EditorsView { get; set; }
        public Nullable<bool> InStoreOnly { get; set; }
        public Nullable<bool> GroupColourOptions { get; set; }
        public Nullable<bool> IsSeasonal { get; set; }
        public Nullable<int> SizeGuideID { get; set; }
        public Nullable<int> DeliveryInfoID { get; set; }
        public Nullable<int> MerchandiseBrandID { get; set; }
        public bool IsDirty { get; set; }
        public bool IsMerretDirty { get; set; }
        public bool Over18Only { get; set; }
        public Nullable<decimal> MagentoPrice { get; set; }
        public Nullable<int> TaxClassID { get; set; }
        public string FamilyBusiness { get; set; }
        public Nullable<bool> IsFashion { get; set; }
        public Nullable<System.DateTime> LastImportedDate { get; set; }
        public bool ImportedToGAE { get; set; }
        public bool ImageImportedToGAE { get; set; }
        public Nullable<System.DateTime> FirstEnabled { get; set; }
        public Nullable<bool> IsMerretMatrix { get; set; }
        public Nullable<bool> IsColourOnly { get; set; }
        public Nullable<bool> InconsistentPrice { get; set; }
        public string ProductLink { get; set; }
        public Nullable<bool> AutomaticStock { get; set; }
        public Nullable<bool> ProductLinkingDone { get; set; }
        public Nullable<System.DateTime> RequestedGoLiveDate { get; set; }
        public string EmailWhenLive { get; set; }
        public Nullable<bool> ClickToPurchase { get; set; }
        public int VersionNumber { get; set; }
        public Nullable<bool> StyledWith { get; set; }
        public string PIMStyleID { get; set; }
        public Nullable<bool> ClickTry { get; set; }
        public Nullable<bool> IncludeInFeed { get; set; }
        public Nullable<int> SizeTypeID { get; set; }


        public int EntityId
        {
            get { return MerretStyleID; }
            set { MerretStyleID = value; }
        }
    }
}
