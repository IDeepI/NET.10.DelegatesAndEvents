using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET._10.DelegatesAndEvents.Handlers
{
     interface ICutDownNotifier
    {
        void Init(Timer theTimer);
        void Run(Timer theTimer);    

    }
}
