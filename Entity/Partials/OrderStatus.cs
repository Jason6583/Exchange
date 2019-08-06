namespace Entity.Partials
{
    public enum OrderStatus : short
    {
        /// <summary>
        /// order is received by system, needs to be passed to order matcher
        /// </summary>
        Received = 1,

        /// <summary>
        /// order matcher received order accepted, order
        /// </summary>
        Accepted = 2,

        /// <summary>
        /// fully filled
        /// </summary>
        Filled = 3,

        /// <summary>
        /// cancelled
        /// </summary>
        Cancelled = 4,

        /// <summary>
        /// rejected by order matcher.
        /// </summary>
        Rejected = 5 //self trade, checkd by order matcher
    }
}
