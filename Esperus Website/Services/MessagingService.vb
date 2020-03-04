Imports System.Net
Imports System.Net.Mail
Imports Esperus.Models

Namespace Services
    Public Class MessagingService
        Public Function SendMessage(messageModel As MessageModel)
            If String.IsNullOrEmpty(messageModel.SenderName) Or String.IsNullOrEmpty(messageModel.SenderTelephone) Or String.IsNullOrEmpty(messageModel.SenderEmail) Then
                Return False
            End If

            Try
                Dim mail As New MailMessage()

                If messageModel.Type = MessageType.DemoRequest Then
                    messageModel.SenderSubject = "Demo Request"
                    mail.Subject = "(Demo Request) Esperus Systems"
                Else
                    messageModel.SenderSubject = "Contact Request"
                    mail.Subject = "(Contact Request) Esperus Systems"
                End If

                Dim compiledTelephone As String = ""

                If Not String.IsNullOrWhiteSpace(messageModel.SenderCallingCode) Then
                    compiledTelephone = compiledTelephone & "(+" & messageModel.SenderCallingCode & ") "
                End If

                compiledTelephone = compiledTelephone & messageModel.SenderTelephone

                If Not String.IsNullOrWhiteSpace(messageModel.SenderExtension) Then
                    compiledTelephone = compiledTelephone & " (ext. " & messageModel.SenderExtension & ")"
                End If

                Dim body As New StringBuilder()
                body.Append("<div style=""font-size: 12px; font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Helvetica, Arial, sans - serif, Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol;""\>")

                body.Append("<p><i><b>This is an automated message from Esperus Systems.</b></i></p>")
                body.Append("<p>We appreciate how busy you are, therefore we thank you for taking the time to fill in our <b>" & messageModel.SenderSubject & "</b> form.</p>")
                body.Append("<p>One of our specialists will contact you to discuss your request as soon as possible. In the meantime, if your enquiry is urgent, please feel free to call us on <a target='_blank' href='tel:+442089209888'>+44(0)20 8920 9888</a> (Option 1).</p>")

                body.Append("<p>Date: " + DateTime.Now + "<br />")
                body.Append("Subject: <b>(" + messageModel.SenderSubject + ")</b> Esperus Systems</p>")

                body.Append("<p>Name: " + messageModel.SenderName + "<br />")
                body.Append("Company: " + messageModel.SenderCompany + "<br />")
                body.Append("E-Mail: " + messageModel.SenderEmail + "<br />")
                body.Append("Telephone: " + compiledTelephone + "</p>")

                body.Append("<p>Interest: " + messageModel.SenderInterest + "<br />")
                body.Append("Source: " + messageModel.SenderReferer + "<br /></p>")

                If messageModel.SenderMailingList Then
                    body.Append("<p>Mailing List: Opt In<br /></p>")
                Else
                    body.Append("<p>Mailing List: Opt Out<br /></p>")
                End If

                body.Append("<p>Message:" + "<br />")
                body.Append(messageModel.SenderMessage + "</p>")

                body.Append("</div>")

                mail.Body = body.ToString()
                mail.BodyEncoding = Encoding.UTF8
                mail.[To].Add("josh@esperus.com")
                mail.CC.Add(messageModel.SenderEmail)
                mail.From = New MailAddress("info@esperus.com")
                mail.IsBodyHtml = True
                mail.Priority = MailPriority.High

                Dim client As New SmtpClient("owa.so-email.co.uk")
                client.Port = 587
                client.DeliveryMethod = SmtpDeliveryMethod.Network
                client.DeliveryFormat = SmtpDeliveryFormat.International
                client.UseDefaultCredentials = False
                client.EnableSsl = False
                client.Credentials = New NetworkCredential("info@esperus.com", "Espd836!")

                client.Send(mail)

                Return True
            Catch exception As Exception
                Return False
            End Try

            Return True
        End Function
    End Class
End Namespace
