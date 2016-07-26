using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace WEB_PERSONAL
{
    public partial class psPerson_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                //search
                ddlSearchGroup.Items.Insert(0, new ListItem("--กลุ่มระดับ--", "0"));
                ddlSearchGroup.Items.Add(new ListItem("1","1"));
                ddlSearchGroup.Items.Add(new ListItem("2","2"));
                ddlSearchGroup.Items.Add(new ListItem("3","3"));
                ddlSearchGroup.Items.Add(new ListItem("4","4"));
                ddlSearchGroup.Items.Add(new ListItem("5","5"));

                ddlSearchNameGroup.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));
                ddlSearchNameGroup.Items.Add(new ListItem("ตำแหน่งประเภทบริหาร", "ตำแหน่งประเภทบริหาร"));
                ddlSearchNameGroup.Items.Add(new ListItem("ตำแหน่งประเภทอำนวยการ", "ตำแหน่งประเภทอำนวยการ"));
                ddlSearchNameGroup.Items.Add(new ListItem("ตำแหน่งประเภทวิชาการ", "ตำแหน่งประเภทวิชาการ"));
                ddlSearchNameGroup.Items.Add(new ListItem("ตำแหน่งประเภททั่วไป", "ตำแหน่งประเภททั่วไป"));
                ddlSearchNameGroup.Items.Add(new ListItem("ตำแหน่งพนักงานราชการ", "ตำแหน่งพนักงานราชการ"));

                ddlSearchTypeName.Items.Insert(0, new ListItem("--ประเภทของตำแหน่ง--", "0"));
                ddlSearchTypeName.Items.Add(new ListItem("ข้าราชการ", "ข้าราชการ"));
                ddlSearchTypeName.Items.Add(new ListItem("พนักงานราชการ", "พนักงานราชการ"));

                //insert
                ddlInsertGroup.Items.Insert(0, new ListItem("--กลุ่มระดับ--", "0"));
                ddlInsertGroup.Items.Add(new ListItem("1", "1"));
                ddlInsertGroup.Items.Add(new ListItem("2", "2"));
                ddlInsertGroup.Items.Add(new ListItem("3", "3"));
                ddlInsertGroup.Items.Add(new ListItem("4", "4"));
                ddlInsertGroup.Items.Add(new ListItem("5", "5"));

                ddlInsertNameGroup.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));
                ddlInsertNameGroup.Items.Add(new ListItem("ตำแหน่งประเภทบริหาร", "ตำแหน่งประเภทบริหาร"));
                ddlInsertNameGroup.Items.Add(new ListItem("ตำแหน่งประเภทอำนวยการ", "ตำแหน่งประเภทอำนวยการ"));
                ddlInsertNameGroup.Items.Add(new ListItem("ตำแหน่งประเภทวิชาการ", "ตำแหน่งประเภทวิชาการ"));
                ddlInsertNameGroup.Items.Add(new ListItem("ตำแหน่งประเภททั่วไป", "ตำแหน่งประเภททั่วไป"));
                ddlInsertNameGroup.Items.Add(new ListItem("ตำแหน่งพนักงานราชการ", "ตำแหน่งพนักงานราชการ"));

                ddlInsertTypeName.Items.Insert(0, new ListItem("--ประเภทของตำแหน่ง--", "0"));
                ddlInsertTypeName.Items.Add(new ListItem("ข้าราชการ", "ข้าราชการ"));
                ddlInsertTypeName.Items.Add(new ListItem("พนักงานราชการ", "พนักงานราชการ"));
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["psPerson"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["psPerson"] = data;
        }

        #endregion

        void BindData()
        {
            ClassPsPosition p = new ClassPsPosition();
            DataTable dt = p.GetPsPosition("", "", "","");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (!string.IsNullOrEmpty(txtSearchDegree.Text))
            {
                ClassPsPosition p = new ClassPsPosition();
                DataTable dt = p.GetPsPosition(txtSearchDegree.Text, "", "", "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (ddlSearchGroup.SelectedIndex != 0)
            {
                ClassPsPosition p = new ClassPsPosition();
                DataTable dt = p.GetPsPosition("", ddlSearchGroup.SelectedValue, "", "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (ddlSearchNameGroup.SelectedIndex != 0)
            {
                ClassPsPosition p = new ClassPsPosition();
                DataTable dt = p.GetPsPosition("", "", ddlSearchNameGroup.SelectedValue, "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (ddlSearchTypeName.SelectedIndex != 0)
            {
                ClassPsPosition p = new ClassPsPosition();
                DataTable dt = p.GetPsPosition(txtSearchDegree.Text, "", "", ddlSearchTypeName.SelectedValue);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        private void ClearData()
        {
            txtSearchDegree.Text = "";
            ddlSearchGroup.SelectedIndex = 0;
            ddlSearchNameGroup.SelectedIndex = 0;
            ddlSearchTypeName.SelectedIndex = 0;
            txtInsertDegree.Text = "";
            ddlInsertGroup.SelectedIndex = 0;
            ddlInsertNameGroup.SelectedIndex = 0;
            ddlInsertTypeName.SelectedIndex = 0;
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertDegree.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อระดับ')", true);
                return;
            }
            if (ddlInsertGroup.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก กลุ่มระดับ')", true);
                return;
            }
            if (ddlInsertNameGroup.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ตำแหน่งประเภท')", true);
                return;
            }
            if (ddlInsertTypeName.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ประเภทของตำแหน่ง')", true);
                return;
            }
            ClassPsPosition p = new ClassPsPosition();
            p.P_NAME = txtInsertDegree.Text;
            p.P_GROUP = Convert.ToInt32(ddlInsertGroup.SelectedValue);
            p.P_NAMEGROUP = ddlInsertNameGroup.SelectedValue;
            p.P_TYPENAME = ddlInsertTypeName.SelectedValue;

            if (p.CheckUsePsPositionNameAndGroup())
            {
                p.InsertPsPosition();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ข้อมูลที่จะเพิ่ม มีอยู่ในระบบแล้ว !')", true);
            }
        }

        protected void modEditCommand(Object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; ;
            BindData();
        }
        protected void modCancelCommand(Object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1; ;
            BindData();
        }
        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ClassPsPosition p = new ClassPsPosition();
            p.P_ID = id;
            p.DeletePsPosition();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1; ;
            BindData();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblpsPersonIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblpsPersonIDEdit");
            TextBox txtpsPersonDegreeEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtpsPersonDegreeEdit");
            DropDownList ddlpsPersonGroupEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlpsPersonGroupEdit");
            DropDownList ddlpsPersonNameGroupEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlpsPersonNameGroupEdit");
            DropDownList ddlpsPersonTypeNameEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlpsPersonTypeNameEdit");

            ClassPsPosition p = new ClassPsPosition(Convert.ToInt32(lblpsPersonIDEdit.Text)
                , txtpsPersonDegreeEdit.Text
                , Convert.ToInt32(ddlpsPersonGroupEdit.SelectedValue)
                , ddlpsPersonNameGroupEdit.SelectedValue
                , ddlpsPersonTypeNameEdit.SelectedValue);

            if (p.CheckUsePsPositionNameAndGroup())
            {
                p.UpdatePsPosition();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                GridView1.EditIndex = -1;
                BindData();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ข้อมูลที่จะอัพเดท มีอยู่ในระบบแล้ว !')", true);
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อระดับ " + DataBinder.Eval(e.Row.DataItem, "P_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlpsPersonGroupEdit = (DropDownList)e.Row.FindControl("ddlpsPersonGroupEdit");           
                    ddlpsPersonGroupEdit.Items.Insert(0, new ListItem("--กลุ่มระดับ--", "0"));
                    ddlpsPersonGroupEdit.Items.Add(new ListItem("1", "1"));
                    ddlpsPersonGroupEdit.Items.Add(new ListItem("2", "2"));
                    ddlpsPersonGroupEdit.Items.Add(new ListItem("3", "3"));
                    ddlpsPersonGroupEdit.Items.Add(new ListItem("4", "4"));
                    ddlpsPersonGroupEdit.Items.Add(new ListItem("5", "5"));
                    ddlpsPersonGroupEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "P_GROUP").ToString();
                    DataRowView dr1 = e.Row.DataItem as DataRowView;

                    DropDownList ddlpsPersonNameGroupEdit = (DropDownList)e.Row.FindControl("ddlpsPersonNameGroupEdit");  
                    ddlpsPersonNameGroupEdit.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));
                    ddlpsPersonNameGroupEdit.Items.Add(new ListItem("ตำแหน่งประเภทบริหาร", "ตำแหน่งประเภทบริหาร"));
                    ddlpsPersonNameGroupEdit.Items.Add(new ListItem("ตำแหน่งประเภทอำนวยการ", "ตำแหน่งประเภทอำนวยการ"));
                    ddlpsPersonNameGroupEdit.Items.Add(new ListItem("ตำแหน่งประเภทวิชาการ", "ตำแหน่งประเภทวิชาการ"));
                    ddlpsPersonNameGroupEdit.Items.Add(new ListItem("ตำแหน่งประเภททั่วไป", "ตำแหน่งประเภททั่วไป"));
                    ddlpsPersonNameGroupEdit.Items.Add(new ListItem("ตำแหน่งพนักงานราชการ", "ตำแหน่งพนักงานราชการ"));
                    ddlpsPersonNameGroupEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "P_NAMEGROUP").ToString();
                    DataRowView dr2 = e.Row.DataItem as DataRowView;         

                    DropDownList ddlpsPersonTypeNameEdit = (DropDownList)e.Row.FindControl("ddlpsPersonTypeNameEdit");    
                    ddlpsPersonTypeNameEdit.Items.Insert(0, new ListItem("--ประเภทของตำแหน่ง--", "0"));
                    ddlpsPersonTypeNameEdit.Items.Add(new ListItem("ข้าราชการ", "ข้าราชการ"));
                    ddlpsPersonTypeNameEdit.Items.Add(new ListItem("พนักงานราชการ", "พนักงานราชการ"));
                    ddlpsPersonTypeNameEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "P_TYPENAME").ToString();
                    DataRowView dr3 = e.Row.DataItem as DataRowView;  
                }
            }
        }
        protected void myGridViewpsPerson_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPsPosition p = new ClassPsPosition();
            DataTable dt = p.GetPsPosition("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchDegree.Text) && ddlSearchGroup.SelectedIndex == 0 && ddlSearchNameGroup.SelectedIndex == 0 && ddlSearchTypeName.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearchDegree.Text))
                {
                    ClassPsPosition p = new ClassPsPosition();
                    DataTable dt = p.GetPsPosition(txtSearchDegree.Text, "", "", "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (ddlSearchGroup.SelectedIndex != 0)
                {
                    ClassPsPosition p = new ClassPsPosition();
                    DataTable dt = p.GetPsPosition("", ddlSearchGroup.SelectedValue, "", "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (ddlSearchNameGroup.SelectedIndex != 0)
                {
                    ClassPsPosition p = new ClassPsPosition();
                    DataTable dt = p.GetPsPosition("", "", ddlSearchNameGroup.SelectedValue, "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (ddlSearchTypeName.SelectedIndex != 0)
                {
                    ClassPsPosition p = new ClassPsPosition();
                    DataTable dt = p.GetPsPosition(txtSearchDegree.Text, "", "", ddlSearchTypeName.SelectedValue);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPsPosition p = new ClassPsPosition();
            DataTable dt = p.GetPsPosition("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}
