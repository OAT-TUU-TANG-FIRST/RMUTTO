﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class About : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            int count = DatabaseManager.ExecuteInt("SELECT COUNTER FROM TB_WEB WHERE ID = 1");
            LabelCounter.Text = "จำนวนผู้เข้าชมทั้งหมด : " + count.ToString("#,###") + " ครั้ง";  
        }
    }
}