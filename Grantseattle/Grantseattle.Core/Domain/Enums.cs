using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Domain
{
    public class Enums
    {
        public enum UserType { Admin = 1, Member }
        public enum JobSearchingStatus { [Display(Name = "Actively looking")] ActivelyLooking = 1, [Display(Name = "Not currently looking, but keeping my options open.")] NotActivelyLookingButKeepingMyOptionsOpen, [Display(Name = "Not looking for jobs at present")] NotLookingForJobsAtPresent }
        public enum MaritalStatus { Married = 1, Single }
        public enum JobType { [Display(Name = "Contract")]Contractual = 1, Freelance, [Display(Name = "Full Time")] FullTime, Internship, [Display(Name = "Part Time")] PartTime, Temporary }
        public enum SocialSiteType { Facebook = 1, Twitter, LinkedIn, GooglePlus, Pinterest }
        public enum OrganizationType { Public = 1 , Private, [Display(Name = "Non-Profit")] NonProfit, Government, Education, Community, Union, Farm, [Display(Name="Co-Op")] CoOp, Web, Utilities, Hospital, Other}
        public enum OrganizationCulture {Casual = 1 , Corporate, Creative, Family, Marketplace, [Display(Name = "High Tech")]HighTech, Traditional, Government, Innovative, Social, Activist, Outdoor, Resort, Independent, [Display(Name = "Multi-Cultural")] MultiCultural, [Display(Name ="Health & Wellness")] HealthAndWellness, Skilled, Other}
        public enum HiringPreference { Formal = 1 , Informal, [Display(Name = "Quick Process")] QuickProcess, [Display(Name = "Collaborative Process")] CollaborativeProcess, [Display(Name = "Use Assessments & Testing")] UseAssessmentsAndTesting }
        public enum Month { Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };
        public enum ContactType { Email = 1, Phone, Fax };
        public enum JobSeekerProfileSection { ProfilePicture = 1, SocialProfiles, Websites, ContactInfo, PersonalDetails, Skills, JobPreferences, Experience, Portfolio, Achievement, Education, Languages, Interests, References, [Display(Name = "Core Values")] CoreValues, [Display(Name = "Technologies")] Technologies, [Display(Name="Upload Video")] UploadVideo }
        public enum EmployerProfileSection { CoverPhoto = 1, Logo, Tagline, SocialProfiles, OrganizationInfo, Websites, Locations, MissionStatement, Summary, Expertise, Services, Products, Achievements, CompanyVideo, [Display(Name = "Core Values")] CoreValues  /*, [Display(Name = "Technologies")] Technologies*/}
        public enum FilterType { Draft = 1, Live, Deactivated, Expired }        
        public enum ContactPrivacy { [Display(Name = "Only Me")] OnlyMe = 1, Public }
        
        public enum MembershipDuration { Monthly = 30, Yearly = 365 }
        public enum MembershipTypeName { Free, Basic, Corporate, Enterprise, Regular, Pro, Premium }
        public enum MembershipFeatureModuleName { Statistics, Profile, Search, Job }
        public enum MembershipFeatureActionName { JobseekersWhoViewedMyProfile, EmployersWhoViewedMyProfile, DataRestriction, NumberOfResultsPerSearch, PricePerJobAnEmployerCanPost, NumberOfJobsAJobseekerCanApplyTo, NumberOfJobsAnEmployerCanApplyTo, ViewRelatedJobs }
        public enum MembershipStatisticsKey { LatestViewersSize, ShowViewCount, ShowViewersList, ViewersListSize }
        public enum MembershipSearchKey { SearchResultSize }
        public enum MembershipJobKey { PricePerJob, JobApplicationQuanity, JobApplicationQuantityExtraPrice, RelatedJobsListSize }

        public enum CreditCardTransactionType { AuthorizationAndCapture, AuthorizationOnly, PriorAuthorizationAndCapture, CaptureOnly, Refund, Void }
        public enum TransactionType { JobPublish, MembershipFee, JobApplication }
        public enum TransactionStatus { Failed, Succeeded, Pending, Authorized, QuanityExceeded, Rejected }
        public enum SubscriptionRequestType { Create, Update, Cancel }

        public enum CategoryType { Campaign, Auction }
        public enum AuthorizeDotNetTransactionType { AuthorizeAndCapture, AuthorizeOnly, CaptureOnly, PriorAuthorizeAndCapture, Credit, Void }
        
    }
}
