using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_app
{
    public interface IDrivable
    {
        void StartEngine();
        void StopEngine();
        void Drive(double km);
        bool CanDrive(double km);
    }
}
