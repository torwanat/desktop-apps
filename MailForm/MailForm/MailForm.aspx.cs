using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;

namespace MailForm
{
    public partial class MailForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbFrom.Text = "";
            tbTo.Text = "";
            tbText.Text = "";
            tbServer.Text = "";
            lbInfo1.Text = "";
            tbSubject.Text = "";
            tbPort.Text = "";
            tbUser.Text = "";
            tbPassword.Text = "";
            lbInfo2.Text = "";
            lxAttachments.Items.Clear();
            rblModes.ClearSelection();
            btSend.Enabled = false;
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            if (fuUpload.HasFile)
            {
                string fileName = fuUpload.FileName;
                string serverPath = Server.MapPath("~/") + fileName;
                fuUpload.SaveAs(serverPath);
                lxAttachments.Items.Add(fileName);
                lbInfo2.Text = "Attachment downloaded";
            }
        }

        protected void btSend_Click(object sender, EventArgs e)
        {
            SmtpClient client;
            MailMessage message;
            ArrayList attachmentList = new ArrayList();
            string mode = rblModes.SelectedValue;
            try
            {
                message = new MailMessage(tbFrom.Text, tbTo.Text);
                message.Subject = tbSubject.Text;
                message.Body = tbText.Text;
                if(mode == "local")
                {
                    client = new SmtpClient("127.0.0.1");
                    client.Credentials = CredentialCache.DefaultNetworkCredentials;

                }
                else {
                    client = new SmtpClient(tbServer.Text, int.Parse(tbPort.Text));
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(tbUser.Text, tbPassword.Text);
                }
                for (int i = 0; i < lxAttachments.Items.Count; i++)
                {
                    Attachment attachment = new Attachment(Server.MapPath("~/") + lxAttachments.Items[i].ToString());
                    message.Attachments.Add(attachment);
                    attachmentList.Add(attachment);
                }
                client.Send(message);
                lbInfo1.Text = "Message sent";
                for(int i = 0; i < attachmentList.Count; i++)
                {
                    ((Attachment)attachmentList[i]).Dispose();
                }
                for(int i = 0; i < lxAttachments.Items.Count; i++)
                {
                    File.Delete(Server.MapPath("~/") + lxAttachments.Items[i].ToString());
                }
                lxAttachments.Items.Clear();
                lbInfo2.Text = "";
            }
            catch (Exception ex)
            {
                lbInfo1.Text = "You cannot send messages (" + ex.Message + ")";
            }
        }

        protected void rblMeasurementSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMode  = rblModes.SelectedValue;
            if(selectedMode == "auth")
            {
                tbPort.Enabled = true;
                tbPassword.Enabled = true;
                tbUser.Enabled = true;
                tbServer.Enabled = true;
            }
            else
            {
                tbServer.Enabled = false;
                tbPort.Enabled = false;
                tbPassword.Enabled= false;
                tbUser.Enabled= false;
            }
            tbPort.Text = "";
            tbPassword.Text = "";
            tbUser.Text = "";
            tbServer.Text = "";
            btSend.Enabled = true;
        }
    }
}