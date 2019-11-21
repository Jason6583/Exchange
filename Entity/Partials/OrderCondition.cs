namespace Entity.Partials
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1028:Enum Storage should be Int32", Justification = "<Pending>")]
    public enum OrderCondition : byte
    {
        None = 0,
        ImmediateOrCancel = 1,
        BookOrCancel = 2,
        FillOrKill = 4,
    }
}
