
namespace SRM.Domain.Common.Enums
{
    public static class Hierarchy
    {
        public enum Role
        {
            Employee,
            TeamLead,
            SectionHead,
            DepartmentManager,
            DivisionHead,
            Executive,
            CEO
        }

        public enum Division
        {
            Operations,
            Engineering,
            Commercial,
            SharedServices,
            HSEQ,
            CorporateAffairs
        }

        public enum Department
        {
            Onshore,
            Offshore,
            Construction,
            Sales,
            Shipping,
            HumanResources,
            Finance,
            InformationTechnology,
            Legal,
            Supply,
            Safety,
            Environment,
            QualityAssurance,
            Medical,
            PublicRelations,
            GovermentAffairs
        }

        public enum Section
        {
            LNGTrains,
            Utilities,
            Production,
            Saftey,
            SiteManagement,
            QualityControl,
            ContractManagement,
            MarketAnalysis,
            FleetOperations,
            MarineAssurance,
            Recruitment,
            Payroll,
            Accounts,
            Budgeting,
            BusinessApplications,
            Cybersecurity,
            Contracts,
            Litigation,
            Procurement,
            Logistics,
            ProcessSafety,
            EmergencyResponse,
            WaterAndWaste,
            Sustainability,
            Audit,
            Inspection,
            Services,
            Wellness,
            MediaAndPublications,
            Events,
            GovermentLiaison,
            StakeholderEngagement
        }
    }
}
