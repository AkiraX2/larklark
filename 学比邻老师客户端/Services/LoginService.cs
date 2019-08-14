using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anotar.NLog;
using Fody;

namespace 学比邻老师客户端.Services
{
    [ConfigureAwait(false)]
    public class LoginService
    {
        public async Task<(int, string)> DoLogin(string username, string password)
        {
            try
            {
                if (username == null) throw new ArgumentNullException(nameof(username));
                if (password == null) throw new ArgumentNullException(nameof(password));


                return await Task.Run(() =>
                {
                    Thread.Sleep(2500);

                    throw new Exception("检测到您在异地登录，请先联系机构进行异地登录授权");

                    return (new Random().Next(2), "msg");
                });
            }
            catch (Exception e)
            {
                LogTo.InfoException(e.Message, e);
                return (-1, e.Message);
            }
        }


        
    }
}