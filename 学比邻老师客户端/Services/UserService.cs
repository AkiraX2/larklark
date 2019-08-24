using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anotar.NLog;
using Fody;
using 学比邻老师客户端.ViewModels;

namespace 学比邻老师客户端.Services
{
    [ConfigureAwait(false)]
    public class UserService
    {
        public async Task<(int, UserProfile)> GetUserProfile(string token)
        {
            try
            {
                return await Task.Run(() =>
                {
                    Thread.Sleep(0);

                    return (0, new UserProfile() {
                        Email = "tianke645@163.com",
                        Username = "tianke"
                        
                    });
                });
            }
            catch (Exception e)
            {
                LogTo.InfoException(e.Message, e);
                return (-1, null);
            }
        }


        
    }
}