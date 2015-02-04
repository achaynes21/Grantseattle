using InventoryERP.Core.WebContext;

namespace InventoryERP.Core
{
    public class ConfigurationVariables
    {
        /*
        public ConfigurationVariable<bool> EnableScheduler = new ConfigurationVariable<bool>("EnableScheduler");
        public ConfigurationVariable<bool> DebugMode = new ConfigurationVariable<bool>("DebugMode");
        public ConfigurationVariable<int> CheckFrequency = new ConfigurationVariable<int>("CheckFrequency");
        public ConfigurationVariable<string> PingUrl = new ConfigurationVariable<string>("PingUrl");        

        public ConfigurationVariable<int> PageSize = new ConfigurationVariable<int>("PageSize");
        public ConfigurationVariable<int> LoginTimeOut = new ConfigurationVariable<int>("LoginTimeOut");
        
        public ConfigurationVariable<string> CssPath = new ConfigurationVariable<string>("CssPath");
        public ConfigurationVariable<string> ImagePath = new ConfigurationVariable<string>("ImagePath");
        public ConfigurationVariable<string> AllowedImageFileTypes = new ConfigurationVariable<string>("AllowedImageFileTypes");
        public ConfigurationVariable<string> ConnectionStringName = new ConfigurationVariable<string>("ConnectionStringName");

        public ConfigurationVariable<bool> IsTest = new ConfigurationVariable<bool>("IsTest");
        public ConfigurationVariable<string> ApiLoginId = new ConfigurationVariable<string>("ApiLoginId");
        public ConfigurationVariable<string> TransactionKey = new ConfigurationVariable<string>("TransactionKey");
        public ConfigurationVariable<string> SandboxUrl = new ConfigurationVariable<string>("SandboxUrl");
        public ConfigurationVariable<string> ProductionUrl = new ConfigurationVariable<string>("ProductionUrl");

        public ConfigurationVariable<string> ImageGallery = new ConfigurationVariable<string>("ImageGallery");
        public ConfigurationVariable<string> AllowedExtensionForImageGallery = new ConfigurationVariable<string>("AllowedExtensionForImageGallery");

        */

        //public ConfigurationVariable<string> AllowedImageFileTypes = new ConfigurationVariable<string>("AllowedImageFileTypes");

        public ConfigurationVariable<string> ConnectionString = new ConfigurationVariable<string>("ConnectionString");
        public ConfigurationVariable<string> DatabaseName = new ConfigurationVariable<string>("DatabaseName");

        //public ConfigurationVariable<string> AdminEmail = new ConfigurationVariable<string>("AdminEmail");
        //public ConfigurationVariable<string> AdminEmailName = new ConfigurationVariable<string>("AdminEmailName");
        public ConfigurationVariable<string> FromEmail = new ConfigurationVariable<string>("aileenhaynes21@gmail.com");
        public ConfigurationVariable<string> FromEmailName = new ConfigurationVariable<string>("aileenhaynes");
        //public ConfigurationVariable<string> GreenEarthEmail = new ConfigurationVariable<string>("GreenEarthEmail");
        //public ConfigurationVariable<string> HasnaeenEmail = new ConfigurationVariable<string>("HasnaeenEmail");

        public ConfigurationVariable<string> EmailTemplatePath = new ConfigurationVariable<string>("EmailTemplatePath");
        public ConfigurationVariable<string> EmailVerification = new ConfigurationVariable<string>("EmailVerification");
        public ConfigurationVariable<string> EmailVerificationSubject = new ConfigurationVariable<string>("EmailVerificationSubject");
        public ConfigurationVariable<string> ForgotPassword = new ConfigurationVariable<string>("ForgotPassword");
        public ConfigurationVariable<string> ForgotPasswordSubject = new ConfigurationVariable<string>("ForgotPasswordSubject");
        public ConfigurationVariable<string> EmailSubscriptionSubject = new ConfigurationVariable<string>("EmailSubscriptionSubject");
        public ConfigurationVariable<string> EmailSubscription = new ConfigurationVariable<string>("EmailSubscription");
        //public ConfigurationVariable<string> ShareJobseekerProfileViaEmailSubject = new ConfigurationVariable<string>("ShareJobseekerProfileViaEmailSubject");
        //public ConfigurationVariable<string> ShareJobseekerProfileViaEmail = new ConfigurationVariable<string>("ShareJobseekerProfileViaEmail");

        //public ConfigurationVariable<string> CampaignPhotoPlaceHolder = new ConfigurationVariable<string>("CampaignPhotoPlaceHolder");
        //public ConfigurationVariable<string> MemberPhotoPlaceHolder = new ConfigurationVariable<string>("MemberPhotoPlaceHolder");


        //public ConfigurationVariable<int> SearchEmployerListPageSize = new ConfigurationVariable<int>("SearchEmployerListPageSize");
        //public ConfigurationVariable<int> SearchJobseekerListPageSize = new ConfigurationVariable<int>("SearchJobseekerListPageSize");
        //public ConfigurationVariable<int> SearchJobListPageSize = new ConfigurationVariable<int>("SearchJobListPageSize");

        public ConfigurationVariable<bool> ProductionMode = new ConfigurationVariable<bool>("ProductionMode");
        //public ConfigurationVariable<bool> PreviewMode = new ConfigurationVariable<bool>("PreviewMode");

        //public ConfigurationVariable<bool> FacebookAppId = new ConfigurationVariable<bool>("FacebookAppId");
        //public ConfigurationVariable<bool> FacebookAppSecret = new ConfigurationVariable<bool>("FacebookAppSecret");

        //public ConfigurationVariable<string> LogosLocation = new ConfigurationVariable<string>("LogosLocation");
        //public ConfigurationVariable<string> ProfilePictureLocation = new ConfigurationVariable<string>("ProfilePictureLocation");
        //public ConfigurationVariable<string> CountryFlagImageLocation = new ConfigurationVariable<string>("CountryFlagImageLocation");

        //public ConfigurationVariable<string> BookmarkedJobPageSize = new ConfigurationVariable<string>("BookmarkedJobPageSize");
        //public ConfigurationVariable<string> BookmarkedEmployerPageSize = new ConfigurationVariable<string>("BookmarkedEmployerPageSize");
        //public ConfigurationVariable<string> BookmarkedJobseekerPageSize = new ConfigurationVariable<string>("BookmarkedJobseekerPageSize");

        //public ConfigurationVariable<string> MemberProfilePicturePlaceholder = new ConfigurationVariable<string>("MemberProfilePicturePlaceholder");
        //public ConfigurationVariable<string> EmployerLogoPlaceholder = new ConfigurationVariable<string>("EmployerLogoPlaceholder");
        //public ConfigurationVariable<string> EmployerLogoPlaceholder1 = new ConfigurationVariable<string>("EmployerLogoPlaceholder1");
        //public ConfigurationVariable<string> EmployerCoverPhotoPlaceholder = new ConfigurationVariable<string>("EmployerCoverPhotoPlaceholder");

        //public ConfigurationVariable<string> VimeoConsumerKey = new ConfigurationVariable<string>("VimeoConsumerKey");
        //public ConfigurationVariable<string> VimeoConsumerSecret = new ConfigurationVariable<string>("VimeoConsumerSecret");
        //public ConfigurationVariable<string> VimeoAccessToken = new ConfigurationVariable<string>("VimeoAccessToken");
        //public ConfigurationVariable<string> VimeoAccessTokenSecret = new ConfigurationVariable<string>("VimeoAccessTokenSecret");
        //public ConfigurationVariable<string> VimeoRequestTokenURL = new ConfigurationVariable<string>("VimeoRequestTokenURL");
        //public ConfigurationVariable<string> VimeoAuthorizeURL = new ConfigurationVariable<string>("VimeoAuthorizeURL");
        //public ConfigurationVariable<string> VimeoAccessTokenURL = new ConfigurationVariable<string>("VimeoAccessTokenURL");
        //public ConfigurationVariable<string> AuthenticatedAuthorizationHeader = new ConfigurationVariable<string>("AuthenticatedAuthorizationHeader");
        //public ConfigurationVariable<string> VimeoUrl = new ConfigurationVariable<string>("VimeoUrl");

        //public ConfigurationVariable<string> FacebookShareUrl = new ConfigurationVariable<string>("facebookShareUrl");
        //public ConfigurationVariable<string> TwitterShareUrl = new ConfigurationVariable<string>("twitterShareUrl");
        //public ConfigurationVariable<string> GooglePlusShareUrl = new ConfigurationVariable<string>("googlePlusShareUrl");
        //public ConfigurationVariable<string> LinkedInShareUrl = new ConfigurationVariable<string>("linkedInShareUrl");
        //public ConfigurationVariable<string> PinterestShareUrl = new ConfigurationVariable<string>("pinterestShareUrl");

        //public ConfigurationVariable<string> MemberProfilePictureSearchPlaceholder = new ConfigurationVariable<string>("MemberProfilePictureSearchPlaceholder");

        
        //public ConfigurationVariable<int> NumberOfUserPerPage = new ConfigurationVariable<int>("NumberOfUserPerPage");
        //public ConfigurationVariable<int> NumberOfCampaignPerPage = new ConfigurationVariable<int>("NumberOfCampaignPerPage");
        //public ConfigurationVariable<int> NumberOfAuctionPerPage = new ConfigurationVariable<int>("NumberOfAuctionPerPage");

        
        //public ConfigurationVariable<int> NumberOfCommentsPerPage = new ConfigurationVariable<int>("NumberOfCommentsPerPage");
        

        //public ConfigurationVariable<string> MemberProfilePictureSmallPlaceholder = new ConfigurationVariable<string>("MemberProfilePictureSmallPlaceholder");
        //public ConfigurationVariable<string> EmployerLogoSmallPlaceholder = new ConfigurationVariable<string>("EmployerLogoSmallPlaceholder");

        public ConfigurationVariable<string> SendMessage = new ConfigurationVariable<string>("SendMessage");
        public ConfigurationVariable<string> SendMessageSubject = new ConfigurationVariable<string>("SendMessageSubject");

        //public ConfigurationVariable<string> AuthorizeDotNetAPILoginID = new ConfigurationVariable<string>("AuthorizeDotNetAPILoginID");
        //public ConfigurationVariable<string> AuthorizeDotNetTransactionKey = new ConfigurationVariable<string>("AuthorizeDotNetTransactionKey");
        //public ConfigurationVariable<bool> AuthorizeDotNetSandbox = new ConfigurationVariable<bool>("AuthorizeDotNetSandbox");

        public ConfigurationVariable<int> MaximumGeocodingRequest = new ConfigurationVariable<int>("MaximumGeocodingRequest");

        //public ConfigurationVariable<string> MemberEmailSharingSubject = new ConfigurationVariable<string>("MemberEmailSharingSubject");
        //public ConfigurationVariable<string> EmployerEmailSharingSubject = new ConfigurationVariable<string>("EmployerEmailSharingSubject");

        //public ConfigurationVariable<string> MailChimpApiKey = new ConfigurationVariable<string>("MailChimpApiKey");
        //public ConfigurationVariable<string> MailChimpSubscriptionListId = new ConfigurationVariable<string>("MailChimpSubscriptionListId");

        //public ConfigurationVariable<string> ErrorLogLocation = new ConfigurationVariable<string>("ErrorLogLocation");

        public ConfigurationVariable<int> ItemListSize = new ConfigurationVariable<int>("ItemListSize");
        
    }
}
