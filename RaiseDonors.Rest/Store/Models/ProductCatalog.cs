using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest.Models;

namespace RaiseDonors.Rest.Store.Models {
    public class ProductCatalog {
        public ProductCatalog() {
            Products = new List<Lookup>();
        }

        public long ID { get; set; }

        public string Name { get; set; }

        public string ShortUrl { get; set; }

        public Lookup Fund { get; set; }

        public MediaContent ThankyouMediaContent { get; set; }

        public MediaContent EmailReceiptMediaContent { get; set; }

        public string LogoUrl { get; set; }

        public bool DonorLoginLink { get; set; }

        public bool HelpInfoLink { get; set; }

        public bool ShowTopicBrowsing { get; set; }

        public bool ShowFormatBrowsing { get; set; }

        public bool ShowSearchField { get; set; }

        public int ProductsPerPage { get; set; }

        public bool ShowSocialSharing { get; set; }

        public bool ShowRelatedProducts { get; set; }

        public bool AcceptACH { get; set; }

        public bool AcceptCC { get; set; }

        public bool AllowAdditionalDonation { get; set; }

        public bool AllowRecurringGift { get; set; }

        public bool DonorCoversFee { get; set; }

        public bool ProvidePhone { get; set; }

        public bool ProvideOrganizationName { get; set; }

        public bool ProvideHowYouHeard { get; set; }

        public bool DonorCanComment { get; set; }

        public bool ShowMailingListSubscribe { get; set; }

        public bool MailingListDefault { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public string CatalogFont { get; set; }

        public string HeaderBackgroundColor { get; set; }

        public string PrimaryButtonColor { get; set; }

        public string PrimaryButtonTextColor { get; set; }

        public string PrimaryButtonHoverColor { get; set; }

        public string PrimaryButtonHoverTextColor { get; set; }

        public string SubsectionBackgroundColor { get; set; }

        public string SecondaryButtonColor { get; set; }

        public string SecondaryButtonTextColor { get; set; }

        public string MotivationCode { get; set; }

        public string SourceCode { get; set; }

        public string FeeCoveragePercentage { get; set; }

        public string FeeCoverageRequest { get; set; }

        public string FeeCoverageTooltip { get; set; }

        public string CheckoutButtonText { get; set; }

        public string OtherAmountPlaceholderText { get; set; }

        public string DonorCommentText { get; set; }

        public string MaillingListWording { get; set; }

        public ProductCatalogHomepage HomePage { get; set; }

        public List<Lookup> Products {  get; set;  }
    }
}
