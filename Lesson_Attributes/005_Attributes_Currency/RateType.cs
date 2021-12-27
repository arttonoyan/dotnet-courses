namespace _005_Attributes_Currency
{
    public enum RateType
    {
        [RateInfo("hy-AM")]
        Amd,
        [RateInfo("en-US")]
        Usd,
        [RateInfo("ru-RU")]
        Rub,
        [RateInfo("ar-EG")]
        Are,
        [RateInfo("ar-LB")]
        Arb
    }
}
