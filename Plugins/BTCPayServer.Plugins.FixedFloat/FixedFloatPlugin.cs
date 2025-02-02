using BTCPayServer.Abstractions.Contracts;
using BTCPayServer.Abstractions.Models;
using BTCPayServer.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BTCPayServer.Plugins.FixedFloat
{
    public class FixedFloatPlugin : BaseBTCPayServerPlugin
    {
        public override IBTCPayServerPlugin.PluginDependency[] Dependencies { get; } =
        {
            new() { Identifier = nameof(BTCPayServer), Condition = ">=1.9.0" }
        };
        public override void Execute(IServiceCollection applicationBuilder)
        {
            applicationBuilder.AddSingleton<FixedFloatService>();
            applicationBuilder.AddSingleton<IUIExtension>(new UIExtension("FixedFloat/FixedFloatNav",
                "store-integrations-nav"));
            // Checkout v2
            applicationBuilder.AddSingleton<IUIExtension>(new UIExtension("FixedFloat/CheckoutPaymentMethodExtension",
                "checkout-payment-method"));
            applicationBuilder.AddSingleton<IUIExtension>(new UIExtension("FixedFloat/CheckoutPaymentExtension",
                "checkout-payment"));
            // Checkout Classic
            applicationBuilder.AddSingleton<IUIExtension>(new UIExtension("FixedFloat/CheckoutContentExtension",
                "checkout-bitcoin-post-content"));
            applicationBuilder.AddSingleton<IUIExtension>(new UIExtension("FixedFloat/CheckoutContentExtension",
                "checkout-lightning-post-content"));
            applicationBuilder.AddSingleton<IUIExtension>(new UIExtension("FixedFloat/CheckoutTabExtension",
                "checkout-bitcoin-post-tabs"));
            applicationBuilder.AddSingleton<IUIExtension>(new UIExtension("FixedFloat/CheckoutTabExtension",
                "checkout-lightning-post-tabs"));
            applicationBuilder.AddSingleton<IUIExtension>(new UIExtension("FixedFloat/CheckoutEnd",
                "checkout-end"));
            base.Execute(applicationBuilder);
        }
    }

}
