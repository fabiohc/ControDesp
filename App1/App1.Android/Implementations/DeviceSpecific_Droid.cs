using Android.OS;
using App1.Droid.Implementations;
using App1.Interfaces;


[assembly: Xamarin.Forms.Dependency(typeof(DeviceSpecific_Droid))]
namespace App1.Droid.Implementations
{
    public class DeviceSpecific_Droid : IDeviceSpecific
    {
        public void CloseApplication()
        {
            Process.KillProcess(Process.MyPid());
        }
    }
}