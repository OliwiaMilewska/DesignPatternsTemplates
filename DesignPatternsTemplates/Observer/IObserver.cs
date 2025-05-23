using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
