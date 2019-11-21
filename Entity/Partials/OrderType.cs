namespace Entity
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1028:Enum Storage should be Int32", Justification = "<Pending>")]
    public enum OrderType : short
    {
        Limit = 1,
        StopLimit = 2,
        Market = 3,
        StopLoss = 4
    }
}
