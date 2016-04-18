using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WEB_PERSONAL {
    public partial class UploadList : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                string[] filePaths = Directory.GetFiles(Server.MapPath("Upload"));

                List<ListItem> files = new List<ListItem>();

                foreach (string filePath in filePaths) {
                    string name = Path.GetFileName(filePath);
                    string path = "Upload/" + name;

                    if (Path.GetExtension(filePath) == ".png" || Path.GetExtension(filePath) == ".jpg") {
                        PanelImage.Controls.Add(new LiteralControl("<a class='tImage' href='" + path + "'><img src='" + path + "'/></a>"));
                    } else {
                        PanelFile.Controls.Add(new LiteralControl("<a class='tFile' href='" + path + "'>" + name + "</a>"));
                    }
                }
            }



        }
    }
}