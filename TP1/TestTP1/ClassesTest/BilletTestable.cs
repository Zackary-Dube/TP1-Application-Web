/* Zackary Dubé */
using TP1.Billeterie;

namespace TestTP1.ClassesTest;

public class BilletTestable : AbstractBillet
{
    public override int PRIX_BILLETS => 10;
    private double _gain;

    public BilletTestable(double gain = 0)
    {
        _gain = gain;
    }

    public override double CalculerGainSiGagnant(AbstractBillet billetTire)
    {
        return _gain;
    }
}