using TP1.Billeterie;

namespace TestTP1.ClassesTest;

public class BilletTestable : AbstractBillet
{
    public override int PRIX_BILLETS => 10;

    public override double CalculerGainSiGagnant(AbstractBillet billetTire)
    {
        return 0;
    }
}