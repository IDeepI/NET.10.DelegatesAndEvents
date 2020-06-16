using NET._10.DelegatesAndEvents.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET._10.DelegatesAndEvents
{
    class MethodTimer : ICutDownNotifier
    {
        void ICutDownNotifier.Init(Timer theTimer)
        {
            throw new NotImplementedException();
        }

        void ICutDownNotifier.Run(Timer theTimer)
        {
            throw new NotImplementedException();
        }
    }
}
