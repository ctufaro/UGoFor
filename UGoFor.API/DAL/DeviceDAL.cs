using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UGoFor.API.Models;

namespace UGoFor.API.DAL
{
    public class DeviceDAL : BaseDAL
    {
        public void CheckDevice(DeviceModel device)
        {
            //SqlParameter[] parameters = new SqlParameter[]
            //{
            //  new SqlParameter("@USERID", device.UserId),
            //  new SqlParameter("@DEVICEID", device.DeviceId),
            //};

            //ExecuteSPNonReturnData("UpdateDeviceId", parameters);

            //if the device exists
            ////if the deviceids are the same, do nothing
            ////else update table
            //else
            //update users table with device            

            //USE[UGoForDB]
            //GO
            ///****** Object:  StoredProcedure [dbo].[InsertUserPost]    Script Date: 11/27/2015 13:05:11 ******/
            //SET ANSI_NULLS ON
            //GO
            //SET QUOTED_IDENTIFIER ON
            //GO
            //-- =============================================
            //--Author:		< Author,,Name >
            //--Create date: < Create Date,,>
            //--Description:	< Description,,>
            //-- =============================================
            //CREATE PROCEDURE[dbo].[UpdateDeviceId]
            //    -- Add the parameters for the stored procedure here
            //    @USERID INT,
            //    @DEVICEID VARCHAR(1500)
            //AS
            //BEGIN
            //    -- SET NOCOUNT ON added to prevent extra result sets from
            //    -- interfering with SELECT statements.
            //    DECLARE @EXISTINGDEVICE VARCHAR(100)

            //    SET NOCOUNT ON;

            //            IF EXISTS(SELECT TOP 1 * FROM Users WHERE Id = @USERID AND DeviceId IS NOT NULL)
		          //  SET @EXISTINGDEVICE = (SELECT TOP 1 DeviceId FROM Users WHERE Id = @USERID)
		          //  IF(@EXISTINGDEVICE <> @DEVICEID)
            //            UPDATE Users SET DeviceId = @DEVICEID WHERE Id = @USERID
            //    ELSE
            //        UPDATE Users SET DeviceId = @DEVICEID WHERE Id = @USERID

            //END



        }
    }
}