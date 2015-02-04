using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static partial class MVC
{
    public static class RouteNames
    {
        #region Auction

        public static class Auction
        {
            public const string AuctionList = "AuctionList";
            public const string AuctionDetails = "AuctionDetails";
            public const string AuctionContribute = "AuctionContribute";
        }

        #endregion

        #region Item

        public static class Item
        {
            public const string CreateItem = "CreateItem";
            public const string ItemList = "ItemList";
        }

        #endregion

        #region News

        public static class News
        {
            public const string PublishNews = "PublishNews";
            public const string NewsList = "NewsList";
        }
        #endregion

        #region Home

        public static class Home
        {
            public const string Index = "Index";
            public const string IndexCampaigns = "IndexCampaigns";
            public const string IndexAuctions = "IndexAuctions";
            public const string HowItWorks = "HowItWorks";
            public const string About = "About";
            public const string SubscribeToNewsletter = "SubscribeToNewsletter";
            //public const string PrivacyPolicy = "PrivacyPolicy";
            //public const string TermsOfUse = "TermsOfUse";
            public const string FAQ = "FAQ";
            //public const string Subscribe = "Subscribe";
        }

        #endregion

        #region Account

        public static class Account
        {
            public const string Profile = "Profile";
            public const string SignIn = "SignIn";
            public const string LogInWithFacebook = "LogInWithFacebook";
            public const string SignUpWithFacebook = "SignUpWithFacebook";
            public const string SignUp = "SignUp";
            public const string SignOut = "SignOut";
            public const string ForgotPassword = "ForgotPassword";
            public const string EmailExist = "EmailExist";
            public const string EmailConfirmation = "EmailConfirmation";
            public const string ResetPassword = "ResetPassword";
        }

        #endregion

        #region Campaign

        public static class Campaign
        {
            public const string Campaigns = "Campaigns";
            public const string CampaignDetails = "CampaignDetails";
            public const string Contribute = "Contribute";
            public const string Widget = "CampaignWidget";
            public const string Updates = "CampaignUpdates";
            public const string Overview = "CampaignOverview";
            public const string Comments = "CampaignComments";
            public const string Backers = "CampaignBackers";
        }

        #endregion

        #region File

        public static class File
        {
            public const string UploadFile = "UploadFile";
        }

        #endregion
    }
}
