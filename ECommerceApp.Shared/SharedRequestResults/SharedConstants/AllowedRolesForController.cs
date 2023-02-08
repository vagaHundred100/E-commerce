namespace ECommerceApp.Shared.SharedRequestResults.SharedConstants
{
    /// <summary>
    /// List of roles that are allowed to access the resource
    /// </summary>
    public static class AllowedRolesForController
    {
        /// <summary>
        /// List of roles that are allowed to access the resource => ADMIN
        /// </summary>
        public const string ADMIN = "ADMIN";
        /// <summary>
        /// List of roles that are allowed to access the resource => ADMIN and OPERATOR
        /// </summary>
        public const string ADMIN_and_USER = "ADMIN,USER";
       
    }
}