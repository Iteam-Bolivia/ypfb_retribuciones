/*
 * @author acastellon
 * Mail Class
 * Created on 01 de Marzo de 2011, 10:00 AM
 */

using System;
using System.Net.Mail;
using System.Net.Mime;

namespace Model
{
  class Mail
  {
    /* Constructor of Cliente */
    public Mail()
    {
    }

    /* Method sendMail */
    /* Return int
     * 0: Succesfully
     * 1 or n: Error
     */
    public int sendMail(String destinatario, String remitenteMail, String remitenteNombre, String referencia, String cuerpoMail, String direccionAdjunto)
    {
      int res = 1;

      // Prepared new message
      System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

      // Destiny
      msg.To.Add(destinatario);

      // Sender
      msg.From = new MailAddress(remitenteMail, remitenteNombre, System.Text.Encoding.UTF8);

      // Subject
      msg.Subject = referencia;

      // Encoding Subject
      msg.SubjectEncoding = System.Text.Encoding.UTF8;

      // Body
      msg.Body = cuerpoMail;

      // Encodig Body
      msg.BodyEncoding = System.Text.Encoding.Unicode;

      // Body is HTML
      msg.IsBodyHtml = false;

      // Attach File Dir
      string file = direccionAdjunto;

      // Attach File
      Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
      ContentDisposition disposition = data.ContentDisposition;
      disposition.CreationDate = System.IO.File.GetCreationTime(file);
      disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
      disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
      msg.Attachments.Add(data);

      // Send Mail Prepared
      SmtpClient client = new SmtpClient();

      // Credentials Send
      client.Credentials = new System.Net.NetworkCredential("iteambo@gmail.com", "iteam123");

      // Port
      client.Port = 587;

      // SMTP Server
      client.Host = "smtp.gmail.com";

      // SSL Security
      client.EnableSsl = true;

      // Try Send Mail
      try
      {
        client.Send(msg);
        res = 0;
      }
      catch (System.Net.Mail.SmtpException ex)
      {
        Console.WriteLine(ex.Message);
        Console.ReadLine();
        res = 1;
      }
      return res;

    }/* End Method sendMail */
  }/*End Class */
} /*End namespace*/