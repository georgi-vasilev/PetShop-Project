namespace PetShop.Data
{
    /// <summary>
    /// Class connection which saves the connection string.
    /// </summary>
    public static class Connection
    {
        /// <summary>
        /// Static string where we save the connection string to the database.
        /// </summary>
        public static string ConnectionString = "Server=.\\SQLEXPRESS;Database=PetShop;Trusted_Connection=True;";
    }
}
