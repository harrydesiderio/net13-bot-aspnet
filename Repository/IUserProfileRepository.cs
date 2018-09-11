using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using SimpleBot.Model;

namespace SimpleBot.Repository
{
    public interface IUserProfileRepository<T>: IDisposable
    {
        T GetProfile(string id);

        void SetProfile(T profile);
    }
}