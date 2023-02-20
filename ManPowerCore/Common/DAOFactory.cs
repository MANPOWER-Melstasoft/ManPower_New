//using ManPowerCore.Infrastructure;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Common
{
    public class DAOFactory
    {


        public static TrainingRequestDAO CreateTrainingRequestDAO()
        {
            TrainingRequestDAO trainingdao = new TrainingRequestDAOImpl();
            return (TrainingRequestDAO)trainingdao;
        }

        public static ProgramAssigneeDAO CreateProgramAssigneeDAO()
        {
            ProgramAssigneeDAO programAssigneeDAO = new ProgramAssigneeDAOImpl();
            return (ProgramAssigneeDAO)programAssigneeDAO;
        }


        public static ProgramAttendenceDAO CreateProgramAttendenceDAO()
        {
            ProgramAttendenceDAO programAttendenceDAO = new ProgramAttendenceDAOImpl();
            return (ProgramAttendenceDAO)programAttendenceDAO;
        }



        public static ProgramBudgetDAO CreateProgramBudgetDAO()
        {
            ProgramBudgetDAO programBudgetDAO = new ProgramBudgetDAOImpl();
            return (ProgramBudgetDAO)programBudgetDAO;
        }

        public static ProgramCategoryDAO CreateProgramCategoryDAO()
        {
            ProgramCategoryDAO programCategoryDAO = new ProgramCategoryDAOImpl();
            return (ProgramCategoryDAO)programCategoryDAO;
        }

        public static ProgramDAO CreateProgramDAO()
        {
            ProgramDAO programDAO = new ProgramDAOImpl();
            return (ProgramDAO)programDAO;
        }

        public static ProgramPlanDAO CreateProgramPlanDAO()
        {
            ProgramPlanDAO programPlanDAO = new ProgramPlanDAOImpl();
            return (ProgramPlanDAO)programPlanDAO;
        }

        public static ProgramTargetDAO CreateProgramTargetDAO()
        {
            ProgramTargetDAO programTargetDAO = new ProgramTargetDAOImpl();
            return (ProgramTargetDAO)programTargetDAO;
        }

        public static ProgramTypeDAO CreateProgramTypeDAO()
        {
            ProgramTypeDAO programTypeDAO = new ProgramTypeDAOImpl();
            return (ProgramTypeDAO)programTypeDAO;
        }

        public static ProjectStatusDAO CreateProjectStatusDAO()
        {
            ProjectStatusDAO projectStatusDAO = new ProjectStatusDAOImpl();
            return (ProjectStatusDAO)projectStatusDAO;
        }


        public static UserTypeDAO CreateUserTypeDAO()
        {
            UserTypeDAO aa = new UserTypeDAOImpl();
            return (UserTypeDAO)aa;
        }

        public static PossitionsDAO CreatePossitionsDAO()
        {
            PossitionsDAO aa = new PossitionsDAOImpl();
            return (PossitionsDAO)aa;
        }

        public static SystemUserDAO CreateSystemUserDAO()
        {
            SystemUserDAO aa = new SystemUserDAOImpl();
            return (SystemUserDAO)aa;
        }

        public static DesignationDAO CreateDesignationDAO()
        {
            DesignationDAO aa = new DesignationDAOImpl();
            return (DesignationDAO)aa;
        }

        public static DepartmentUnitTypeDAO CreateDepartmentUnitTypeDAO()
        {
            DepartmentUnitTypeDAO aa = new DepartmentUnitTypeDAOImpl();
            return (DepartmentUnitTypeDAO)aa;
        }

        public static DepartmentUnitPositionsDAO CreateDepartmentUnitPositionsDAO()
        {
            DepartmentUnitPositionsDAO aa = new DepartmentUnitPositionsDAOImpl();
            return (DepartmentUnitPositionsDAO)aa;
        }

        public static DepartmentUnitDAO CreateDepartmentUnitDAO()
        {
            DepartmentUnitDAO aa = new DepartmentUnitDAOImpl();
            return (DepartmentUnitDAO)aa;
        }

        public static TaskAllocationDAO CreateTaskAllocationDAO()
        {
            TaskAllocationDAO aa = new TaskAllocationDAOImpl();
            return (TaskAllocationDAO)aa;
        }

        public static TaskAllocationDetailDAO CreateTaskAllocationDetailDAO()
        {
            TaskAllocationDetailDAO aa = new TaskAllocationDetailDAOImpl();
            return (TaskAllocationDetailDAO)aa;
        }

        public static TaskTypeDAO CreateTaskTypeDAO()
        {
            TaskTypeDAO aa = new TaskTypeDAOImpl();
            return (TaskTypeDAO)aa;
        }

        public static ProjectTaskDAO CreateProjectTaskDAO()
        {
            ProjectTaskDAO aa = new ProjectTaskDAOImpl();
            return (ProjectTaskDAO)aa;
        }


        public static CompanyVecansyRegistationDetailsDAO CreateCompanyVecansyRegistationDetailsDAO()
        {
            CompanyVecansyRegistationDetailsDAO aa = new CompanyVecansyRegistationDetailsDAOImpl();
            return (CompanyVecansyRegistationDetailsDAO)aa;
        }

        public static ResourcePersonDAO CreateResourcePersonDAO()
        {
            ResourcePersonDAO resourcePersonDAO = new ResourcePersonDAOImpl();
            return (ResourcePersonDAO)resourcePersonDAO;
        }

        public static ResourceProvisionProgressDAO CreateResourceProvisionProgressDAO()
        {
            ResourceProvisionProgressDAO resourceProvisionProgressDAO = new ResourceProvisionProgressDAOImpl();
            return (ResourceProvisionProgressDAO)resourceProvisionProgressDAO;
        }

        public static ProjectPlanResourceDAO CreateProjectPlanResourceDAO()
        {
            ProjectPlanResourceDAO aa = new ProjectPlanResourceDAOImpl();
            return (ProjectPlanResourceDAO)aa;
        }

        public static EntrepreneurDAO CreateEntrepreneurDAO()
        {
            EntrepreneurDAO aa = new EntrepreneurDAOImpl();
            return (EntrepreneurDAO)aa;
        }

        public static InduvidualBeneficiaryDAO CreateInduvidualBeneficiaryDAO()
        {
            InduvidualBeneficiaryDAO aa = new InduvidualBeneficiaryDAOImpl();
            return (InduvidualBeneficiaryDAO)aa;
        }

        public static MarketTypeDAO CreateMarketTypeDAO()
        {
            MarketTypeDAO aa = new MarketTypeDAOImpl();
            return (MarketTypeDAO)aa;
        }

        public static BusinessTypeDAO CreateBusinessTypeDAO()
        {
            BusinessTypeDAO aa = new BusinessTypeDAOImpl();
            return (BusinessTypeDAO)aa;
        }

        public static BeneficiaryTypeDAO CreateBeneficiaryTypeDAO()
        {
            BeneficiaryTypeDAO aa = new BeneficiaryTypeDAOImpl();
            return (BeneficiaryTypeDAO)aa;
        }

        public static BeneficiaryDAO CreateBeneficiaryDAO()
        {
            BeneficiaryDAO aa = new BeneficiaryDAOImpl();
            return (BeneficiaryDAO)aa;
        }

        public static AutSystemRoleFunctionDAO CreateAutSystemRoleFunctionDAO()
        {
            AutSystemRoleFunctionDAO aa = new AutSystemRoleFunctionDAOImpl();
            return (AutSystemRoleFunctionDAO)aa;
        }

        public static AutFunctionDAO CreateAutFunctionDAO()
        {
            AutFunctionDAO aa = new AutFunctionDAOImpl();
            return (AutFunctionDAO)aa;
        }

        public static EthnicityDAO CreateEthnicityDAO()
        {
            EthnicityDAO aa = new EthnicityDAOImpl();
            return (EthnicityDAO)aa;
        }

        public static ReligionDAO CreateReligionDAO()
        {
            ReligionDAO aa = new ReligionDAOImpl();
            return (ReligionDAO)aa;
        }

        public static EmployeeDAO CreateEmployeeDAO()
        {
            EmployeeDAO employeeDAO = new EmployeeDAOImpl();
            return (EmployeeDAO)employeeDAO;
        }

        public static EmployeeContactDAO CreateEmployeeContactDAO()
        {
            EmployeeContactDAO employeeContactDAO = new EmployeeContactDAOImpl();
            return (EmployeeContactDAO)employeeContactDAO;
        }

        public static ContactModeDAO CreateContactModeDAO()
        {
            ContactModeDAO contactModeDAO = new ContactModeDAOImpl();
            return (ContactModeDAO)contactModeDAO;
        }

        public static EmergencyContactDAO CreateEmergencyContactDAO()
        {
            EmergencyContactDAO emergencyContactDAO = new EmergencyContactDAOImpl();
            return (EmergencyContactDAO)emergencyContactDAO;
        }

        public static EmploymentDetailsDAO CreateEmploymentDetailsDAO()
        {
            EmploymentDetailsDAO employmentDetailsDAO = new EmploymentDetailsDAOImpl();
            return (EmploymentDetailsDAO)employmentDetailsDAO;
        }

        public static PromotionsDAO CreatePromotionsDAO()
        {
            PromotionsDAO PromotionsDAO = new PromotionsDAOImpl();
            return (PromotionsDAO)PromotionsDAO;
        }

        public static DependentDAO CreateDependentDAO()
        {
            DependentDAO dependentDAO = new DependentDAOImpl();
            return (DependentDAO)dependentDAO;
        }

        public static ContactTypeDAO CreateContactTypeDAO()
        {
            ContactTypeDAO contactTypeDAO = new ContactTypeDAOImpl();
            return (ContactTypeDAO)contactTypeDAO;
        }

        public static EducationTypeDAO CreateEducationTypeDAO()
        {
            EducationTypeDAO educationTypeDAO = new EducationTypeDAOImpl();
            return (EducationTypeDAO)educationTypeDAO;
        }

        public static DependantTypeDAO CreateDependantTypeDAO()
        {
            DependantTypeDAO dependantTypeDAO = new DependantTypeDAOImpl();
            return (DependantTypeDAO)dependantTypeDAO;
        }

        public static EducationDetailsDAO CreateEducationDetailsDAO()
        {
            EducationDetailsDAO educationDetailsDAO = new EducationDetailsDAOImpl();
            return (EducationDetailsDAO)educationDetailsDAO;
        }

        public static UserRegistrationDAO CreateUserRegistrationDAO()
        {
            UserRegistrationDAO userRegistrationDAO = new UserRegistrationDAOSqlImpl();
            return (UserRegistrationDAO)userRegistrationDAO;
        }

        public static AutUserFunctionDAO CreateAutUserFunctionDAO()
        {
            AutUserFunctionDAO autUserFunctionDAO = new AutUserFunctionDAOSqlImpl();
            return (AutUserFunctionDAO)autUserFunctionDAO;
        }
        public static LeaveTypeDAO CreateLeaveTypeDAO()
        {
            LeaveTypeDAO leaveTypeDAO = new LeaveTypeDAOSqlImpl();
            return (LeaveTypeDAO)leaveTypeDAO;

        }
        public static StaffLeaveAllocationDAO CreateStaffLeaveAllocationDAO()
        {
            StaffLeaveAllocationDAO staffLeaveAllocationDAO = new StaffLeaveAllocationDAOSqlImpl();
            return (StaffLeaveAllocationDAO)staffLeaveAllocationDAO;

        }

        public static HolidaySheetDAO CreateHolidaySheetDAO()
        {
            HolidaySheetDAO holidaySheetDAO = new HolidaySheetDAOImpl();
            return (HolidaySheetDAO)holidaySheetDAO;
        }

        public static ServiceTypeDAO CreateServiceTypeDAO()
        {
            ServiceTypeDAO serviceTypeDAO = new ServiceTypeDAOImpl();
            return (ServiceTypeDAO)serviceTypeDAO;
        }

        public static EmployeeServicesDAO CreateEmployeeServicesDAO()
        {
            EmployeeServicesDAO employeeServicesDAO = new EmployeeServicesDAOImpl();
            return (EmployeeServicesDAO)employeeServicesDAO;
        }

        public static ContractTypeDAO CreateContractTypeDAO()
        {
            ContractTypeDAO contractTypeDAO = new ContractTypeDAOImpl();
            return (ContractTypeDAO)contractTypeDAO;
        }

        public static VehicleMaintenanceDAO CreateVehicleMaintenanceDAO()
        {
            VehicleMaintenanceDAO vehicleMaintenanceDAO = new VehicleMaintenanceDAOImpl();
            return (VehicleMaintenanceDAO)vehicleMaintenanceDAO;
        }

        public static VehicleMaintenaceQuatationDAO CreateVehicleMaintenaceQuatationDAO()
        {
            VehicleMaintenaceQuatationDAO vehicleMaintenaceQuatationDAO = new VehicleMaintenaceQuatationDAOImpl();
            return (VehicleMaintenaceQuatationDAO)vehicleMaintenaceQuatationDAO;
        }

        public static QuatationDAO CreateQuatationDAO()
        {
            QuatationDAO quatationDAO = new QuatationDAOImpl();
            return (QuatationDAO)quatationDAO;
        }

        public static MaintenanceCategoryDAO CreateMaintenanceCategoryDAO()
        {
            MaintenanceCategoryDAO maintenanceCategoryDAO = new MaintenanceCategoryDAOImpl();
            return (MaintenanceCategoryDAO)maintenanceCategoryDAO;
        }
        public static StaffLeaveDAO CreateStaffLeaveDAO()
        {
            StaffLeaveDAO staffLeaveDAO = new StaffLeaveDAOSqlImpl();
            return (StaffLeaveDAO)staffLeaveDAO;
        }

        public static ReportDAO CreateReportDAO()
        {
            ReportDAO reportDAO = new ReportDAOSqlImpl();
            return (ReportDAO)reportDAO;
        }

        public static VoteAllocationDAO CreateVoteAllocationDAO()
        {
            VoteAllocationDAO voteAllocationDAO = new VoteAllocationDAOSqlImpl();
            return (VoteAllocationDAO)voteAllocationDAO;
        }

        public static VoteTypeDAO CreateVoteTypeDAO()
        {
            VoteTypeDAO voteTypeDAO = new VoteTypeDAOSqlImpl();
            return (VoteTypeDAO)voteTypeDAO;
        }

        //public static VoteAllocationDAO CreateVoteAllocationDAO()
        //{
        //    VoteAllocationDAO voteAllocationDAO = new VoteAllocationDAOSqlImpl();
        //    return (VoteAllocationDAO)voteAllocationDAO;
        //}

        public static VoteLedgerDAO CreateVoteLedgerDAO()
        {
            VoteLedgerDAO voteLedgerDAO = new VoteLedgerDAOSqlImpl();
            return (VoteLedgerDAO)voteLedgerDAO;
        }

        public static OfficerListDAO CreateOfficerListDAO()
        {
            OfficerListDAO officerListDAO = new OfficerListDAOSqlImpl();
            return (OfficerListDAO)officerListDAO;

        }

        public static DistricDsParentDAO CreateDistricDsParentDAO()
        {
            DistricDsParentDAO districDsParentDAO = new DistricDsParentDAOSqlImpl();
            return (DistricDsParentDAO)districDsParentDAO;
        }

        public static CareerKeyTestResultsDAO CreateCareerKeyTestResultsDAO()
        {
            CareerKeyTestResultsDAO careerKeyTestResultsDAO = new CareerKeyTestResultsDAOSqlImpl();
            return (CareerKeyTestResultsDAO)careerKeyTestResultsDAO;
        }

        public static CareerGuidanceFeedbackDAO CreateCareerGuidanceFeedbackDAO()
        {
            CareerGuidanceFeedbackDAO careerGuidanceFeedbackDAO = new CareerGuidanceFeedbackDAOSqlImpl();
            return (CareerGuidanceFeedbackDAO)careerGuidanceFeedbackDAO;
        }

        public static TrainingRefferalsDAO CreateTrainingRefferalsDAO()
        {
            TrainingRefferalsDAO trainingRefferalsDAO = new TrainingRefferalsDAOSqlImmpl();
            return (TrainingRefferalsDAO)trainingRefferalsDAO;
        }

        public static TrainingRefferalFeedbackDAO CreateTrainingRefferalFeedbackDAO()
        {
            TrainingRefferalFeedbackDAO trainingRefferalFeedbackDAO = new TrainingRefferalFeedbackDAOSqlImpl();
            return (TrainingRefferalFeedbackDAO)trainingRefferalFeedbackDAO;
        }

        public static JobCategoryDAO CreateJobCategoryDAO()
        {
            JobCategoryDAO jobCategoryDAO = new JobCategoryDAOImpl();
            return (JobCategoryDAO)jobCategoryDAO;
        }

        public static JobRefferalsDAO CreateJobRefferalsDAO()
        {
            JobRefferalsDAO jobRefferalsDAO = new JobRefferalsDAOImpl();
            return (JobRefferalsDAO)jobRefferalsDAO;
        }

        public static JobPlacementFeedbackDAO CreateJobPlacementFeedbackDAO()
        {
            JobPlacementFeedbackDAO jobPlacementFeedbackDAO = new JobPlacementFeedbackDAOImpl();
            return (JobPlacementFeedbackDAO)jobPlacementFeedbackDAO;
        }

        public static RequestTypeDAO CreateRequestTypeDAO()
        {
            RequestTypeDAO requestTypeDAO = new RequestTypeDAOSqlImpl();
            return (RequestTypeDAO)requestTypeDAO;
        }

        public static TransfersRetirementResignationStatusDAO CreateTransfersRetirementResignationStatusDAO()
        {
            TransfersRetirementResignationStatusDAO transfersRetirementResignationStatus = new TransfersRetirementResignationStatusDAOSqlImpl();
            return (TransfersRetirementResignationStatusDAO)transfersRetirementResignationStatus;
        }

        public static ApproveActionDAO CreateApproveActionDAO()
        {
            ApproveActionDAO approveActionDAO = new ApproveActionDAOSqlImpl();
            return (ApproveActionDAO)approveActionDAO;
        }

        public static ReverseReasonDAO CreateReverseReasonDAO()
        {
            ReverseReasonDAO reverseReasonDAO = new ReverseReasonDAOSqlImpl();
            return (ReverseReasonDAO)reverseReasonDAO;
        }

        public static TransferTypeDAO CreateTransferTypeDAO()
        {
            TransferTypeDAO transferTypeDAO = new TransferTypeDAOSqlImpl();
            return (TransferTypeDAO)transferTypeDAO;
        }

        public static RetirementTypeDAO CreateRetirementTypeDAO()
        {
            RetirementTypeDAO retirementTypeDAO = new RetirementTypeDAOSqlImpl();
            return (RetirementTypeDAO)retirementTypeDAO;
        }

        public static VacancyPositionDAO CreateVacancyPositionDAO()
        {
            VacancyPositionDAO vacancyPositionDAO = new VacancyPositionDAOImpl();
            return (VacancyPositionDAO)vacancyPositionDAO;
        }

        public static TransfersRetirementResignationMainDAO CreateTransfersRetirementResignationMainDAO()
        {
            TransfersRetirementResignationMainDAO transfersRetirementResignationMainDAO = new TransfersRetirementResignationMainDAOSqlImpl();
            return (TransfersRetirementResignationMainDAO)transfersRetirementResignationMainDAO;
        }

        public static ResignationDAO CreateResignationDAO()
        {
            ResignationDAO resignationDAO = new ResignationDAOSqlImpl();
            return (ResignationDAO)resignationDAO;
        }

        public static RetirementDAO CreateRetirementDAO()
        {
            RetirementDAO retirementDAO = new RetirementDAOSqlImpl();
            return (RetirementDAO)retirementDAO;
        }

        public static TransferDAO CreateTransferDAO()
        {
            TransferDAO transferDAO = new TransferDAOSqlImpl();
            return (TransferDAO)transferDAO;
        }
        public static DistrictTASummaryDAO CreateDistrictTASummaryDAO()
        {
            DistrictTASummaryDAO districtTASummaryDAO = new DistrictTASummaryDAOImpl();
            return (DistrictTASummaryDAO)districtTASummaryDAO;
        }

        public static TrainingMainDAO CreateTrainingMainDAO()
        {
            TrainingMainDAO trainingMainDAO = new TrainingMainDAOSqlImpl();
            return (TrainingMainDAO)trainingMainDAO;
        }

        public static TrainingRequestsDAO createTrainingRequestsDAO()
        {
            TrainingRequestsDAO trainingRequestsDAO = new TrainingRequestsDAOSqlImpl();
            return (TrainingRequestsDAO)trainingRequestsDAO;
        }

        public static AccountCodeDAO createAccountCodeDAO()
        {
            AccountCodeDAO accountCodeDAO = new AccountCodeDAOSqlImpl();
            return (AccountCodeDAO)accountCodeDAO;
        }

        public static PaymentVoucherDAO createPaymentVoucherDAO()
        {
            PaymentVoucherDAO paymentVoucherDAO = new PaymentVoucherDAOSqlImpl();
            return (PaymentVoucherDAO)paymentVoucherDAO;
        }

        public static SupplierDAO createSupplierDAO()
        {
            SupplierDAO supplierDAO = new SupplierDAOSqlImpl();
            return (SupplierDAO)supplierDAO;
        }

        public static SupplierTypeDAO createSupplierTypeDAO()
        {
            SupplierTypeDAO supplierTypeDAO = new SupplierTypeDAOSqlImpl();
            return (SupplierTypeDAO)supplierTypeDAO;
        }

        public static VoucherDetailDAO createVoucherDetailDAO()
        {
            VoucherDetailDAO voucherDetailDAO = new VoucherDetailDAOSqlImpl();
            return (VoucherDetailDAO)voucherDetailDAO;
        }

        public static LoanTypeDAO createLoanTypeDAO()
        {
            LoanTypeDAO loanTypeDAO = new LoanTypeDAOSqlImpl();
            return (LoanTypeDAO)loanTypeDAO;
        }

        public static ApprovalTypeDAO createApprovalTypeDAO()
        {
            ApprovalTypeDAO approvalType = new ApprovalTypeDAOImpl();
            return (ApprovalTypeDAO)approvalType;
        }

        public static LoanDetailDAO createLoanDetailDAO()
        {
            LoanDetailDAO loanDetailDAO = new LoanDetailDAOSqlImpl();
            return (LoanDetailDAO)loanDetailDAO;
        }

        public static ApprovalHistoryDAO createApprovalHistoryDAO()
        {
            ApprovalHistoryDAO approvalHistoryDAO = new ApprovalHistoryDAOSqlImpl();
            return (ApprovalHistoryDAO)approvalHistoryDAO;
        }

        public static DistressLoanDAO createDistressLoanDAO()
        {
            DistressLoanDAO distressLoanDAO = new DistressLoanDAOSqlImpl();
            return (DistressLoanDAO)distressLoanDAO;
        }
    }
}
