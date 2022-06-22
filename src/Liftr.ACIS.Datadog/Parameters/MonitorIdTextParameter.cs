using Microsoft.WindowsAzure.Wapd.Acis.Contracts;

namespace Microsoft.Liftr.ACIS.NotificationService
{
    public class MonitorIdTextParameter : AcisSMETextParameter
    {
        public override string Name => "Monitor Id";
        public override string HelpText => "Enter the affected Monitor Id";
    }
}