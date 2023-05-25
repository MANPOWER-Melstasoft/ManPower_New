﻿using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
	public interface VehicleMaintenanceDAO
	{
		int SaveVehicleMeintenance(VehicleMeintenance vehicleMeintenance, DBConnection dbConnection);

		int UpdateApprovals(int id, int approval, int officer, string reason, DBConnection dbConnection);

		int UpdateRecommandationTOStatus(int id, int approvalStatus, string fileNo, int officer, string reason, DBConnection dbConnection);

		int UpdateRecommandationStatus(int id, int approval, int officer, string reason, DBConnection dbConnection);

		int UpdateRecommandationADStatus(int id, int approvalStatus, int officer, string reason, DBConnection dbConnection);

		List<VehicleMeintenance> GetAllVehicleMeintenance(DBConnection dbConnection);
	}

	public class VehicleMaintenanceDAOImpl : VehicleMaintenanceDAO
	{
		public int SaveVehicleMeintenance(VehicleMeintenance vehicleMeintenance, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.CommandType = System.Data.CommandType.Text;
			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "INSERT INTO VEHICLE_MAINTANCE(Employee_ID,Date,Vehicle_Number,Description," +
				"Is_Approved,Approved_By,Approved_date,Estimated_Cost,Attachment,Maintenance_Category_Id,Requested_By,File_No,Rejected_Reason, Vehicle_Meter,Vehicle_Previous_Meter, Mileage,Enginner_Attachment,Is_Enginner_Recommendatin,Insurance_Start_Date,Insurance_End_Date) " +

			"VALUES(@EmpId,@RequestDate,@VehicleNumber,@RequestDescription,@IsApproved,@ApprovedBy,@ApprovedDate,@EstimatedCost," +
			"@Attachment,@CategoryId,@RequestedBy,@FileNo,@RejectedReason, @VehicleMeter,@VehiclePrevMeter,@Mileage,@EnginnerAttachment,@Is_Enginner_Recommendatin,@InsuranceStartDate,@InsuranceEndDate) ";

			dbConnection.cmd.Parameters.AddWithValue("@EmpId", vehicleMeintenance.EmpId);
			dbConnection.cmd.Parameters.AddWithValue("@RequestDate", vehicleMeintenance.RequestDate);
			dbConnection.cmd.Parameters.AddWithValue("@VehicleNumber", vehicleMeintenance.VehicleNumber);
			dbConnection.cmd.Parameters.AddWithValue("@RequestDescription", vehicleMeintenance.RequestDescription);
			dbConnection.cmd.Parameters.AddWithValue("@IsApproved", vehicleMeintenance.IsApproved);
			dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", vehicleMeintenance.ApprovedBy);
			dbConnection.cmd.Parameters.AddWithValue("@ApprovedDate", vehicleMeintenance.ApprovedDate);
			dbConnection.cmd.Parameters.AddWithValue("@EstimatedCost", vehicleMeintenance.EstimatedCost);
			dbConnection.cmd.Parameters.AddWithValue("@Attachment", vehicleMeintenance.Attachment);
			dbConnection.cmd.Parameters.AddWithValue("@CategoryId", vehicleMeintenance.CategoryId);
			dbConnection.cmd.Parameters.AddWithValue("@RequestedBy", vehicleMeintenance.RequestedBy);
			dbConnection.cmd.Parameters.AddWithValue("@FileNo", vehicleMeintenance.FileNo);
			dbConnection.cmd.Parameters.AddWithValue("@RejectedReason", vehicleMeintenance.RejectedReason);
			dbConnection.cmd.Parameters.AddWithValue("@VehicleMeter", vehicleMeintenance.VehicleMeter);
			dbConnection.cmd.Parameters.AddWithValue("@VehiclePrevMeter", vehicleMeintenance.VehiclePrevMeter);
			dbConnection.cmd.Parameters.AddWithValue("@Mileage", vehicleMeintenance.Mileage);
			dbConnection.cmd.Parameters.AddWithValue("@EnginnerAttachment", vehicleMeintenance.EngineerFileAttachment);
			dbConnection.cmd.Parameters.AddWithValue("@Is_Enginner_Recommendatin", vehicleMeintenance.IsEngineerRecommendation);
			/*dbConnection.cmd.Parameters.AddWithValue("@RecommededBy", vehicleMeintenance.RecomandBy);*/

			if (vehicleMeintenance.InsuranceStartDate.Year == 1)
			{
				dbConnection.cmd.Parameters.AddWithValue("@InsuranceStartDate", SqlDateTime.Null);

			}
			else
			{
				dbConnection.cmd.Parameters.AddWithValue("@InsuranceStartDate", vehicleMeintenance.InsuranceStartDate);

			}


			if (vehicleMeintenance.InsuranceEndDate.Year == 1)
			{
				dbConnection.cmd.Parameters.AddWithValue("@InsuranceEndDate", SqlDateTime.Null);

			}
			else
			{
				dbConnection.cmd.Parameters.AddWithValue("@InsuranceEndDate", vehicleMeintenance.InsuranceEndDate);

			}


			dbConnection.cmd.ExecuteNonQuery();
			return 1;
		}

		public List<VehicleMeintenance> GetAllVehicleMeintenance(DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.CommandText = "SELECT * FROM VEHICLE_MAINTANCE ";

			dbConnection.dr = dbConnection.cmd.ExecuteReader();
			DataAccessObject dataAccessObject = new DataAccessObject();
			return dataAccessObject.ReadCollection<VehicleMeintenance>(dbConnection.dr);

		}

		public int UpdateApprovals(int id, int approvalStatus, int officer, string reason, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "UPDATE VEHICLE_MAINTANCE SET IS_APPROVED = @approvalStatus, APPROVED_BY = @officer, Approved_date = @date, REJECTED_REASON = @reason WHERE ID = " + id + " ";

			dbConnection.cmd.Parameters.AddWithValue("@approvalStatus", approvalStatus);
			dbConnection.cmd.Parameters.AddWithValue("@officer", officer);
			dbConnection.cmd.Parameters.AddWithValue("@reason", reason);
			dbConnection.cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);

			dbConnection.cmd.ExecuteNonQuery();
			return 1;
		}


		public int UpdateRecommandationStatus(int id, int approval, int officer, string reason, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "UPDATE VEHICLE_MAINTANCE SET IS_APPROVED = @approvalStatus, Recommend_AD = @officer, Recommend_AD_Date = @date, REJECTED_REASON = @reason WHERE ID = " + id + " ";

			dbConnection.cmd.Parameters.AddWithValue("@approvalStatus", approval);
			dbConnection.cmd.Parameters.AddWithValue("@officer", officer);
			dbConnection.cmd.Parameters.AddWithValue("@reason", reason);
			dbConnection.cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);

			dbConnection.cmd.ExecuteNonQuery();
			return 1;
		}


		// Approve By TO and Send TO AD
		public int UpdateRecommandationTOStatus(int id, int approvalStatus, string fileNo, int officer, string reason, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "UPDATE VEHICLE_MAINTANCE SET IS_APPROVED = @approvalStatus, Recomand_By = @officer, Recomand_Date = @date, File_No=@fileNo,REJECTED_REASON = @reason WHERE ID = " + id + " ";

			dbConnection.cmd.Parameters.AddWithValue("@approvalStatus", approvalStatus);
			dbConnection.cmd.Parameters.AddWithValue("@officer", officer);
			dbConnection.cmd.Parameters.AddWithValue("@reason", reason);
			dbConnection.cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
			dbConnection.cmd.Parameters.AddWithValue("@fileNo", fileNo);

			dbConnection.cmd.ExecuteNonQuery();
			return 1;
		}

		// Approve By AD and Send TO Director
		public int UpdateRecommandationADStatus(int id, int approvalStatus, int officer, string reason, DBConnection dbConnection)
		{
			if (dbConnection.dr != null)
				dbConnection.dr.Close();

			dbConnection.cmd.Parameters.Clear();
			dbConnection.cmd.CommandText = "UPDATE VEHICLE_MAINTANCE SET IS_APPROVED = @approvalStatus, Recommend_Director = @officer, Recommend_Director_Date = @date,REJECTED_REASON = @reason WHERE ID = " + id + " ";

			dbConnection.cmd.Parameters.AddWithValue("@approvalStatus", approvalStatus);
			dbConnection.cmd.Parameters.AddWithValue("@officer", officer);
			dbConnection.cmd.Parameters.AddWithValue("@reason", reason);
			dbConnection.cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);

			dbConnection.cmd.ExecuteNonQuery();
			return 1;
		}



	}
}
