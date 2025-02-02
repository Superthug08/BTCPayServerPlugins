namespace BTCPayServer.Plugins.SideShift
{
    public class SideShiftSettings
    {
        public bool Enabled { get; set; }
        public decimal AmountMarkupPercentage { get; set; } = 0;
        
        public string? PreferredTargetPaymentMethodId { get; set; }
        public string[] ExplicitMethods { get; set; }
        public bool OnlyShowExplicitMethods { get; set; } = false;

        
    }
}
