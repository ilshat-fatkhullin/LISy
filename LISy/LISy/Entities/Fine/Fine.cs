namespace LISy.Entities.Fine
{
    /// <summary>
    /// Describes fines in the library.
    /// </summary>
    public class Fine
    {
        /// <summary>
        /// Id of fined patron.
        /// </summary>
        public long PatronId { get; set; }

        /// <summary>
        /// Id of overdue document,
        /// </summary>
        public long DocumentId { get; set; }

        /// <summary>
        /// Amount of fine.
        /// </summary>
        public int FineAmount { get; set; }
    }
}
