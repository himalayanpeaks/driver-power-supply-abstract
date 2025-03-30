using OneDriver.Framework.Base;
using OneDriver.Framework.Libs;
using OneDriver.Framework.Module.ViewModel;
using OneDriver.PowerSupply.Abstract.Channels;
using OneDriver.PowerSupply.Abstract.Contracts;
using System.Windows.Input;

namespace OneDriver.PowerSupply.Abstract
{
    public class CommonDeviceViewModel<TParams, TChannelParams, TChannelProcessData> : 
        BaseDeviceWithChannelsPdViewModel<TParams, TChannelParams, TChannelProcessData>, IPowerSupplyViewModel
        where TParams : CommonDeviceParams
        where TChannelParams : CommonChannelParams
        where TChannelProcessData : CommonProcessData
    {
        public CommonDevice<TParams, TChannelParams, TChannelProcessData> PowerSupply;
        public CommonDeviceViewModel(CommonDevice<TParams, TChannelParams, TChannelProcessData> device) : base(device)
        {
            PowerSupply = device;
            CommandAllChannelsOn = new RelayCommand(execute: _ => AllChannelsOn(),  canExecute: _ => CanAllChannelsOn());
            CommandAllChannelsOff = new RelayCommand(execute: _ => AllChannelsOff(), canExecute: _ => CanAllChannelsOff());
            CommandSetVolts = new RelayCommand(execute: _ => SetVolts(), canExecute: _ => CanSetVolts());
            CommandSetAmps = new RelayCommand(execute: _ => SetAmps(), canExecute: _ => CanSetAmps());


        }

        private void SetAmps()
        {
            PowerSupply.SetAmps(ChannelNumber, DesiredAmps);
        }
        

        public double DesiredVolts
        {
            get => PowerSupply.Elements[ChannelNumber].Parameters.DesiredVolts;
            set => PowerSupply.Elements[ChannelNumber].Parameters.DesiredVolts = value;
        }


        public double DesiredAmps
        {
            get => PowerSupply.Elements[ChannelNumber].Parameters.DesiredAmps;
            set => PowerSupply.Elements[ChannelNumber].Parameters.DesiredAmps = value;
        }
        public int ChannelNumber { get ; set;  }


        private void SetVolts()
        {
            PowerSupply.SetVolts(ChannelNumber, DesiredVolts);
        }

        private bool CanSetAmps()
        {
            return PowerSupply.Parameters.IsConnected;
        }

        private bool CanSetVolts()
        {
            return PowerSupply.Parameters.IsConnected;
        }

        private bool CanAllChannelsOff()
        {
            return PowerSupply.Parameters.IsConnected;         
        }

        private void AllChannelsOff()
        {
            PowerSupply.AllChannelsOff();
        }

        private bool CanAllChannelsOn()
        {
            return PowerSupply.Parameters.IsConnected;
        }

        private void AllChannelsOn()
        {
            PowerSupply.AllChannelsOn();
        }

        public ICommand CommandAllChannelsOn { get; }

        public ICommand CommandAllChannelsOff { get; }

        public ICommand CommandSetVolts { get; }

        public ICommand CommandSetAmps { get; }
    }
}
