namespace Entity.Partials
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1028:Enum Storage should be Int32", Justification = "<Pending>")]
    public enum TransactionType : short
    {
        //odd for credit, even for debit
        BlockchainReceived = 1,
        BlockchainSend = 2,
        InternalReceived = 3,
        InternalSend = 4,
        Deposit = 5,
        Withdraw = 6,
        BidTradeCredit = 7,
        BidOrderDebit = 8,
        AskTradeCredit = 9,
        AskOrderDebit = 10
    }
}
