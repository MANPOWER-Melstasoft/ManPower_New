using ManPowerCore.Controller;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManPowerCore.Common
{
    public class ControllerFactory
    {
        public static ProgramAssigneeController CreateProgramAssigneeController()
        {
            ProgramAssigneeController programAssigneeController = new ProgramAssigneeControllerImpl();
            return (ProgramAssigneeController)programAssigneeController;
        }

        public static ProgramAttendenceController CreateProgramAttendenceController()
        {
            ProgramAttendenceController programAttendenceController = new ProgramAttendenceControllerImpl();
            return (ProgramAttendenceController)programAttendenceController;
        }

        public static ProgramBudgetController CreateProgramBudgetController()
        {
            ProgramBudgetController programBudgetController = new ProgramBudgetControllerImpl();
            return (ProgramBudgetController)programBudgetController;
        }

        public static ProgramCategoryController CreateProgramCategoryController()
        {
            ProgramCategoryController programCategoryController = new ProgramCategoryControllerImpl();
            return (ProgramCategoryController)programCategoryController;
        }

        public static ProgramController CreateProgramController()
        {
            ProgramController programController = new ProgramControllerImpl();
            return (ProgramController)programController;
        }

        public static ProgramPlanController CreateProgramPlanController()
        {
            ProgramPlanController programPlanController = new ProgramPlanControllerImpl();
            return (ProgramPlanController)programPlanController;
        }

        public static ProgramTargetController CreateProgramTargetController()
        {
            ProgramTargetController programTargetController = new ProgramTargetControllerImpl();
            return (ProgramTargetController)programTargetController;
        }

        public static ProgramTypeController CreateProgramTypeController()
        {
            ProgramTypeController programTypeController = new ProgramTypeControllerImpl();
            return (ProgramTypeController)programTypeController;
        }

        public static ProjectStatusController CreateProjectStatusController()
        {
            ProjectStatusController projectStatusController = new ProjectStatusControllerImpl();
            return (ProjectStatusController)projectStatusController;
        }

        public static DepartmentUnitTypeController CreateDepartmentUnitTypeController()
        {
            DepartmentUnitTypeController aa = new DepartmentUnitTypeControllerImpl();
            return (DepartmentUnitTypeController)aa;
        }

        public static DepartmentUnitController CreateDepartmentUnitController()
        {
            DepartmentUnitController aa = new DepartmentUnitControllerImpl();
            return (DepartmentUnitController)aa;
        }

        public static PossitionsController CreatePossitionsController()
        {
            PossitionsController possitionsController = new PossitionsControllerImpl();
            return (PossitionsController)possitionsController;
        }

        public static DepartmentUnitPositionsController CreateDepartmentUnitPositionsController()
        {
            DepartmentUnitPositionsController aa = new DepartmentUnitPositionsControllerImpl();
            return (DepartmentUnitPositionsController)aa;
        }

        public static SystemUserController CreateSystemUserController()
        {
            SystemUserController aa = new SystemUserControllerImpl();
            return (SystemUserController)aa;
        }

        public static UserTypeController CreateUserTypeController()
        {
            UserTypeController aa = new UserTypeControllerImpl();
            return (UserTypeController)aa;
        }

        public static DesignationController CreateDesignationController()
        {
            DesignationController aa = new DesignationControllerImpl();
            return (DesignationController)aa;
        }

        public static TaskAllocationController CreateTaskAllocationController()
        {
            TaskAllocationController aa = new TaskAllocationControllerImpl();
            return (TaskAllocationController)aa;
        }

        public static TaskAllocationDetailController CreateTaskAllocationDetailController()
        {
            TaskAllocationDetailController aa = new TaskAllocationDetailControllerImpl();
            return (TaskAllocationDetailController)aa;
        }

        public static TaskTypeController CreateTaskTypeController()
        {
            TaskTypeController aa = new TaskTypeControllerImpl();
            return (TaskTypeController)aa;
        }

        public static ProjectTaskController CreateProjectTaskController()
        {
            ProjectTaskController aa = new ProjectTaskControllerImpl();
            return (ProjectTaskController)aa;
        }

        public static CompanyVecansyRegistationDetailsController CreateCompanyVecansyRegistationDetailsController()
        {
            CompanyVecansyRegistationDetailsController aa = new CompanyVecansyRegistationDetailsControllerImpl();
            return (CompanyVecansyRegistationDetailsController)aa;
        }


        public static ResourcePersonController CreateResourcePersonController()
        {
            ResourcePersonController resourcePersonController = new ResourcePersonControllerImpl();
            return (ResourcePersonController)resourcePersonController;
        }

        public static ResourceProvisionProgressController CreateResourceProvisionProgressController()
        {
            ResourceProvisionProgressController resourceProvisionProgressController = new ResourceProvisionProgressControllerImpl();
            return (ResourceProvisionProgressController)resourceProvisionProgressController;
        }

        public static ProjectPlanResourceController CreateProjectPlanResourceController()
        {
            ProjectPlanResourceController aa = new ProjectPlanResourceControllerImpl();
            return (ProjectPlanResourceController)aa;
        }

        public static EntrepreneurController CreateEntrepreneurController()
        {
            EntrepreneurController aa = new EntrepreneurControllerImpl();
            return (EntrepreneurController)aa;
        }

        public static InduvidualBeneficiaryController CreateInduvidualBeneficiaryController()
        {
            InduvidualBeneficiaryController aa = new InduvidualBeneficiaryControllerImpl();
            return (InduvidualBeneficiaryController)aa;
        }

        public static MarketTypeController CreateMarketTypeController()
        {
            MarketTypeController aa = new MarketTypeControllerImpl();
            return (MarketTypeController)aa;
        }

        public static BusinessTypeController CreateBusinessTypeController()
        {
            BusinessTypeController aa = new BusinessTypeControllerImpl();
            return (BusinessTypeController)aa;
        }

        public static BeneficiaryTypeController CreateBeneficiaryTypeController()
        {
            BeneficiaryTypeController aa = new BeneficiaryTypeControllerImpl();
            return (BeneficiaryTypeController)aa;
        }

        public static BeneficiaryController CreateBeneficiaryController()
        {
            BeneficiaryController aa = new BeneficiaryControllerImpl();
            return (BeneficiaryController)aa;
        }

        public static AutSystemRoleFunctionController CreateAutSystemRoleFunctionController()
        {
            AutSystemRoleFunctionController aa = new AutSystemRoleFunctionControllerImpl();
            return (AutSystemRoleFunctionController)aa;
        }

        public static AutFunctionController CreateAutFunctionController()
        {
            AutFunctionController aa = new AutFunctionControllerImpl();
            return (AutFunctionController)aa;
        }

        public static EthnicityController CreateEthnicityController()
        {
            EthnicityController aa = new EthnicityControllerImpl();
            return (EthnicityController)aa;
        }

        public static ReligionController CreateReligionController()
        {
            ReligionController aa = new ReligionControllerImpl();
            return (ReligionController)aa;
        }
        public static EmployeeController CreateEmployeeController()
        {
            EmployeeController employeeController = new EmployeeControllerImpl();
            return (EmployeeController)employeeController;
        }

        public static EmployeeContactController CreateEmployeeContactController()
        {
            EmployeeContactController employeeContactController = new EmployeeContactControllerImpl();
            return (EmployeeContactController)employeeContactController;
        }

        public static ContactModeController CreateContactModeController()
        {
            ContactModeController contactModeController = new ContactModeControllerImpl();
            return (ContactModeController)contactModeController;
        }

        public static EmergencyContactController CreateEmergencyContactController()
        {
            EmergencyContactController emergencyContactController = new EmergencyContactControllerImpl();
            return (EmergencyContactController)emergencyContactController;
        }

        public static EmploymentDetailsController CreateEmploymentDetailsController()
        {
            EmploymentDetailsController employmentDetailsController = new EmploymentDetailsControllerImpl();
            return (EmploymentDetailsController)employmentDetailsController;
        }

        public static PromotionController CreatePromotionController()
        {
            PromotionController promotionController = new PromotionControllerImpl();
            return (PromotionController)promotionController;
        }

        public static DependantController CreateDependantController()
        {
            DependantController dependantController = new DependantControllerImpl();
            return (DependantController)dependantController;

        }

        public static ContactTypeController CreateContactTypeController()
        {
            ContactTypeController contactTypeController = new ContactTypeControllerImpl();
            return (ContactTypeController)contactTypeController;

        }

        public static EducationTypeController CreateEducationTypeController()
        {
            EducationTypeController educationTypeController = new EducationTypeControllerImpl();
            return (EducationTypeController)educationTypeController;

        }

        public static DependantTypeController CreateDependantTypeController()
        {
            DependantTypeController dependantTypeController = new DependantTypeControllerImpl();
            return (DependantTypeController)dependantTypeController;

        }

        public static EducationDetailsController CreateEducationDetailsController()
        {
            EducationDetailsController educationDetailsController = new EducationDetailsControllerImpl();
            return (EducationDetailsController)educationDetailsController;

        }

        public static UserRegistrationController CreateUserRegistrationController()
        {
            UserRegistrationController educationDetailsController = new UserRegistrationControllerSqlImpl();
            return (UserRegistrationController)educationDetailsController;

        }

        public static AutUserFunctionController CreateAutUserFunctionController()
        {
            AutUserFunctionController autUserFunctionController = new AutUserFunctionControllerSqlImpl();
            return (AutUserFunctionController)autUserFunctionController;

        }

        public static LeaveTypeController CreateLeaveTypeController()
        {
            LeaveTypeController leaveTypeController = new LeaveTypeControllerImpl();
            return (LeaveTypeController)leaveTypeController;
        }

        public static StaffLeaveAllocationController CreateStaffLeaveAllocationController()
        {
            StaffLeaveAllocationController staffLeaveAllocationController = new StaffLeaveAllocationControllerImpl();
            return (StaffLeaveAllocationController)staffLeaveAllocationController;
        }

        public static StaffLeaveControllerImpl CreateStaffLeaveControllerImpl()
        {
            StaffLeaveController staffLeaveController = new StaffLeaveControllerImpl();
            return (StaffLeaveControllerImpl)staffLeaveController;

        }

        public static HolidaySheetController CreateHolidaySheetController()
        {
            HolidaySheetController holidaySheetController = new HolidaySheetControllerImpl();
            return (HolidaySheetController)holidaySheetController;
        }


        public static ServiceTypeController CreateServiceTypeController()
        {
            ServiceTypeController serviceTypeController = new ServiceTypeControllerImpl();
            return (ServiceTypeController)serviceTypeController;

        }

        public static EmployeeServiceController CreateEmployeeServiceController()
        {
            EmployeeServiceController employeeServiceController = new EmployeeServiceControllerImpl();
            return (EmployeeServiceController)employeeServiceController;

        }

        public static ContractTypeController CreateContractTypeController()
        {
            ContractTypeController contractTypeController = new ContractTypeControllerImpl();
            return (ContractTypeController)contractTypeController;

        }

        public static VehicleMaintenanceController CreateVehicleMaintenanceController()
        {
            VehicleMaintenanceController vehicleMaintenanceController = new VehicleMaintenanceControllerImpl();
            return (VehicleMaintenanceController)vehicleMaintenanceController;

        }

        public static VehicleMaintenaceQuatationController CreateVehicleMaintenaceQuatationController()
        {
            VehicleMaintenaceQuatationController vehicleMaintenaceQuatationController = new VehicleMaintenaceQuatationControllerImpl();
            return (VehicleMaintenaceQuatationController)vehicleMaintenaceQuatationController;

        }

        public static QuatationController CreateQuatationController()
        {
            QuatationController quatationController = new QuatationControllerImpl();
            return (QuatationController)quatationController;

        }

        public static MaintenanceCategoryController CreateMaintenanceCategoryController()
        {
            MaintenanceCategoryController maintenanceCategoryController = new MaintenanceCategoryControllerImpl();
            return (MaintenanceCategoryController)maintenanceCategoryController;

        }
        public static ReportController CreateReportController()
        {
            ReportController reportController = new ReportControllerImpl();
            return (ReportController)reportController;
        }

        public static TrainingRequestController CreateTrainingRequestController()
        {
            TrainingRequestController trainingRequestController = new TrainingRequestControllerImpl();
            return (TrainingRequestController)trainingRequestController;

        }

        public static VoteAllocationController CreateVoteAllocationController()
        {
            VoteAllocationController voteAllocationController = new VoteAllocationControllerImpl();
            return (VoteAllocationController)voteAllocationController;
        }

        public static VoteTypeController CreateVoteTypeController()
        {
            VoteTypeController voteTypeController = new VoteTypeControllerImpl();
            return (VoteTypeController)voteTypeController;

        }

        //public static VoteAllocationController CreateVoteAllocationController()
        //{
        //    VoteAllocationController voteAllocationController = new VoteAllocationControllerImpl();
        //    return (VoteAllocationController)voteAllocationController;

        //}

        public static VoteLedgerController CreateVoteLedgerController()
        {
            VoteLedgerController voteLedgerController = new VoteLedgerControllerImpl();
            return (VoteLedgerController)voteLedgerController;

        }

        public static OfficerListController CreateOfficerListController()
        {
            OfficerListController officerListController = new OfficerListControllerImpl();
            return (OfficerListController)officerListController;
        }

        public static DistricDsParentController CreateDistricDsParentController()
        {
            DistricDsParentController districDsParentController = new DistricDsParentControllerImpl();
            return (DistricDsParentController)districDsParentController;
        }

        public static CareerKeyTestResultsController CreateCareerKeyTestResultsController()
        {
            CareerKeyTestResultsController careerKeyTestResultsController = new CareerKeyTestResultsControllerSqlImpl();
            return (CareerKeyTestResultsController)careerKeyTestResultsController;
        }

        public static CareerGuidanceFeedbackController CreateCareerGuidanceFeedbackController()
        {
            CareerGuidanceFeedbackController careerGuidanceFeedbackController = new CareerGuidanceFeedbackControllerSqlImpl();
            return (CareerGuidanceFeedbackController)careerGuidanceFeedbackController;
        }

        public static JobCategoryController CreateJobCategoryController()
        {
            JobCategoryController jobCategoryController = new JobCategoryControllerImpl();
            return (JobCategoryController)jobCategoryController;
        }

        public static JobRefferalsController CreateJobRefferalsController()
        {
            JobRefferalsController jobRefferalsController = new JobRefferalsControllerImpl();
            return (JobRefferalsController)jobRefferalsController;
        }

        public static JobPlacementFeedbackController CreateJobPlacementFeedbackController()
        {
            JobPlacementFeedbackController jobPlacementFeedbackController = new JobPlacementFeedbackControllerImpl();
            return (JobPlacementFeedbackController)jobPlacementFeedbackController;
        }

        public static TrainingRefferalsController CreateTrainingRefferalController()
        {
            TrainingRefferalsController jobPlacementFeedbackController = new TrainingRefferalsControllerSqlImpl();
            return (TrainingRefferalsController)jobPlacementFeedbackController;
        }

        public static TrainingRefferalFeedbackController CreateTrainingRefferalFeedbackController()
        {
            TrainingRefferalFeedbackController trainingRefferalFeedbackController = new TrainingRefferalFeedbackControllerSqlImpl();
            return (TrainingRefferalFeedbackController)trainingRefferalFeedbackController;
        }

        public static RequestTypeController CreateRequestTypeController()
        {
            RequestTypeController requestTypeController = new RequestTypeControllerSqlImpl();
            return (RequestTypeController)requestTypeController;
        }

        public static TransfersRetirementResignationStatusController CreateTransfersRetirementResignationStatusController()
        {
            TransfersRetirementResignationStatusController transfersRetirementResignationStatusController = new TransfersRetirementResignationStatusControllerSqlImpl();
            return (TransfersRetirementResignationStatusController)transfersRetirementResignationStatusController;
        }

        public static ApproveActionController CreateApproveActionController()
        {
            ApproveActionController approveActionController = new ApproveActionControllerSqlImpl();
            return (ApproveActionController)approveActionController;
        }

        public static ReverseReasonController CreateReverseReasonController()
        {
            ReverseReasonController reverseReasonController = new ReverseReasonControllerSqlImpl();
            return (ReverseReasonController)reverseReasonController;
        }

        public static TransferTypeController CreateTransferTypeController()
        {
            TransferTypeController transferTypeController = new TransferTypeControllerSqlImpl();
            return (TransferTypeController)transferTypeController;
        }

        public static RetirementTypeController CreateRetirementTypeController()
        {
            RetirementTypeController retirementTypeController = new RetirementTypeControllerSqlImpl();
            return (RetirementTypeController)retirementTypeController;
        }

        public static TransfersRetirementResignationMainController CreateTransfersRetirementResignationMainController()
        {
            TransfersRetirementResignationMainController transfersRetirementResignationMainController = new TransfersRetirementResignationMainControllerSqlImpl();
            return (TransfersRetirementResignationMainController)transfersRetirementResignationMainController;
        }

        public static ResignationController CreateResignationController()
        {
            ResignationController resignationController = new ResignationControllerSqlImpl();
            return (ResignationController)resignationController;
        }

        public static RetirementController CreateRetirementController()
        {
            RetirementController retirementController = new RetirementControllerSqlImpl();
            return (RetirementController)retirementController;
        }

        public static TransferController CreateTransferController()
        {
            TransferController transferController = new TransferControllerSqlImpl();
            return (TransferController)transferController;
        }


        public static VacancyPositionController CreateVacancyPositionController()
        {
            VacancyPositionController vacancyPositionController = new VacancyPositionControllerImpl();
            return (VacancyPositionController)vacancyPositionController;
        }

        public static DistrictTASummaryController CreateDistrictTASummaryController()
        {
            DistrictTASummaryController districtTASummaryController = new DistrictTASummaryControllerImpl();
            return (DistrictTASummaryController)districtTASummaryController;
        }

        public static TrainingMainController CreateTrainingMainController()
        {
            TrainingMainController trainingMainController = new TrainingMainControllerImpl();
            return (TrainingMainController)trainingMainController;
        }

        public static TrainingRequestsController CreateTrainingRequestsController()
        {
            TrainingRequestsController trainingRequestsController = new TrainingRequestsControllerImpl();
            return (TrainingRequestsController)trainingRequestsController;
        }

        public static AccountCodeController CreateAccountCodeController()
        {
            AccountCodeController accountCodeController = new AccountCodeControllerImpl();
            return (AccountCodeController)accountCodeController;
        }

        public static PaymentVoucherController CreatePaymentVoucherController()
        {
            PaymentVoucherController paymentVoucherController = new PaymentVoucherControllerImpl();
            return (PaymentVoucherController)paymentVoucherController;
        }

        public static SupplierController CreateSupplierController()
        {
            SupplierController supplierController = new SupplierControllerImpl();
            return (SupplierController)supplierController;
        }

        public static SupplierTypeController CreateSupplierTypeController()
        {
            SupplierTypeController supplierTypeController = new SupplierTypeControllerImpl();
            return (SupplierTypeController)supplierTypeController;
        }

        public static VoucherDetailController CreateVoucherDetailController()
        {
            VoucherDetailController voucherDetailController = new VoucherDetailControllerImpl();
            return (VoucherDetailController)voucherDetailController;
        }

        public static LoanTypeController CreateLoanTypeController()
        {
            LoanTypeController loanTypeController = new LoanTypeControllerImpl();
            return (LoanTypeController)loanTypeController;
        }

        public static ApprovalTypeController CreateApprovalTypeController()
        {
            ApprovalTypeController approvalTypeController = new ApprovalTypeControllerImpl();
            return (ApprovalTypeController)approvalTypeController;
        }

        public static LoanDetailsController CreateLoanDetailsController()
        {
            LoanDetailsController loanDetailsController = new LoanDetailsControllerImpl();
            return (LoanDetailsController)loanDetailsController;
        }

        public static ApprovalHistoryController CreateApprovalHistoryController()
        {
            ApprovalHistoryController approvalHistoryController = new ApprovalHistoryControllerImpl();
            return (ApprovalHistoryController)approvalHistoryController;
        }

        public static DistressLoanController CreateDistressLoanController()
        {
            DistressLoanController distressLoanController = new DistressLoanControllerImpl();
            return (DistressLoanController)distressLoanController;
        }

        public static GuarantorDetailController CreateGuarantorDetailController()
        {
            GuarantorDetailController guarantorDetailController = new GuarantorDetailControllerImpl();
            return (GuarantorDetailController)guarantorDetailController;
        }

        public static RequestorGuarantorController CreateRequestorGuarantorController()
        {
            RequestorGuarantorController requestorGuarantorController = new RequestorGuarantorControllerImpl();
            return (RequestorGuarantorController)requestorGuarantorController;
        }

        public static ProgramPlanApprovalDetailsController CreateProgramPlanApprovalDetailsController()
        {
            ProgramPlanApprovalDetailsController programPlanApprovalDetailsController = new ProgramPlanApprovalDetailsControllerImpl();
            return (ProgramPlanApprovalDetailsController)programPlanApprovalDetailsController;
        }
    }
}
