using OneDriver.Framework.Libs.Validator;
using OneDriver.Framework.Module;
using OneDriver.Framework.Module.Parameter;
using OneDriver.PowerSupply.Abstract.Channels;
using OneDriver.PowerSupply.Abstract.Contracts;
using System.Collections.ObjectModel;

namespace OneDriver.PowerSupply.Abstract
{
    public abstract class CommonDevice<TDeviceParams, TChannelParams, TChannelProcessData> :
        BaseDeviceWithChannelsPd<TDeviceParams, TChannelParams, TChannelProcessData>, IPowerSupply
        where TDeviceParams : CommonDeviceParams
        where TChannelParams : CommonChannelParams
        where TChannelProcessData : CommonProcessData
    {
        protected CommonDevice(TDeviceParams parameters, IValidator validator,
            ObservableCollection<BaseChannelWithProcessData<TChannelParams, TChannelProcessData>> elements) : base(parameters, validator, elements)
        {
        }

        public abstract int AllChannelsOff();
        public abstract int SetVolts(int channelNumber, double volts);
        public abstract int SetAmps(int channelNumber, double amps);
        public abstract int AllChannelsOn();
    }
}
