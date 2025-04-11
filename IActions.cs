using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface IActions
    {
        bool Work();
        bool Play();
        bool Chat();
        bool ListenMusic();
        bool WatchVideo();

    }
}
