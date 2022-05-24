using System.ComponentModel;

namespace NeurositySDK
{
    public enum Metrics
    {
        Awareness,
        Kinesis,
        Brainwaves,
        Accelerometer,
        [Description("signalQuality")]
        SignalQuality
    }
}