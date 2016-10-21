using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAC_Web_Application.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
