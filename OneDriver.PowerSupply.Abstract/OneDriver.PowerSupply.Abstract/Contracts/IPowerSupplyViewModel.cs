using OneDriver.Framework.Module;
using System.Windows.Input;

namespace OneDriver.PowerSupply.Abstract.Contracts
{
    public interface IPowerSupplyViewModel : IDeviceViewModel
    {
        ICommand CommandAllChannelsOn { get; }
        ICommand CommandAllChannelsOff { get; }
        ICommand CommandSetVolts { get; }
        ICommand CommandSetAmps { get; }
    }
}
