 /* نوشتن متن*/
            string strDate = PublicFunctions.MiladyDateToShamsi(GetDateControlValue("pdc_date_fl_DateRequestWorkorder").ToShortDateString()); //Format - dd/MM/yyyy
            //split string date by separator, here I'm using '/'
            string[] arrDate = strDate.Split('/');
            //now use array to get specific date object
            string day = arrDate[0].ToString();
            string month = arrDate[1].ToString();
            string year = arrDate[2].ToString();
            string yearShams = (day + month + year);
            string SQL = "Select fl_DateRequestWorkorder, fl_NumberWorkJob from tbl_FRM_WorkOrder where fl_DateRequestWorkorder = (select Max(fl_DateRequestWorkorder) from tbl_FRM_WorkOrder)";
            DataSet ds = Saba.Data.Helper.ExecuteDataset(SystemEnglishName, CommandType.Text, SQL);
            if (ds != null && ds.Tables[0].Rows.Count != 0) //return false;
            {
                string ADD_Str = ds.Tables[0].Rows[0]["fl_DateRequestWorkorder"].ToString();
                string strDate1 = PublicFunctions.MiladyDateToShamsi(ADD_Str);
                string[] arrDate1 = strDate1.Split('/');
                //now use array to get specific date object
                string day1 = arrDate1[0].ToString();
                string month1 = arrDate1[1].ToString();
                string year1 = arrDate1[2].ToString();
                string yearShams1 = (day1 + month1 + year1);
                int ID_Plus1 = Convert.ToInt32(yearShams1);
                int ID_Plus = Convert.ToInt32(yearShams);
                if (ID_Plus != ID_Plus1)
                {
                    string constA = "100";
                    string Sum_Work_Number = yearShams + constA;
                    SetControlValue("txt_fl_NumberWorkJob", Sum_Work_Number);
                }
                else
                {
                    string ADD_Str1 = ds.Tables[0].Rows[0]["fl_NumberWorkJob"].ToString();
                    double ID_Plus_Sum = Convert.ToDouble(ADD_Str1);
                    double sum_ID = ID_Plus_Sum + 1;
                    string id_Str = Convert.ToString(sum_ID);
                    SetControlValue("txt_fl_NumberWorkJob", id_Str);
                }
                //SetControlValue("txt_fl_NumberWorkJob", yearShams1);