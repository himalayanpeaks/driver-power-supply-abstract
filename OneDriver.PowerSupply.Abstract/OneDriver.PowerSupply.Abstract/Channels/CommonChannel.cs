using OneDriver.Framework.Module.Parameter;

namespace OneDriver.PowerSupply.Abstract.Channels
{
    /// <summary>
    /// Unused class
    /// </summary>
    /// <typeparam name="TChannelParams"></typeparam>
    /// <typeparam name="TChannelProcessData"></typeparam>
    public class CommonChannel<TChannelParams, TChannelProcessData>
        : BaseChannelWithProcessData<TChannelParams, TChannelProcessData>
        where TChannelParams : CommonChannelParams
        where TChannelProcessData : CommonProcessData
    {
        protected CommonChannel(TChannelParams parameters, TChannelProcessData processData) : base(parameters, processData)
        {
        }
    }
}
