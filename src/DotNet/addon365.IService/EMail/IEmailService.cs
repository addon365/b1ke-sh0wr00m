using addon365.Domain.Entity.EMail;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.IService.EMail
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
}
