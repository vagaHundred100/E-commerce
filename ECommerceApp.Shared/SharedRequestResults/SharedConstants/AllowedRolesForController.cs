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
        public const string ADMIN_and_OPERATOR = "ADMIN,OPERATOR";
        /// <summary>
        /// List of roles that are allowed to access the resource => ADMIN and KIOSK
        /// </summary>
        public const string ADMIN_and_KIOSK = "ADMIN,KIOSK";
        /// <summary>
        /// List of roles that are allowed to access the resource => ADMIN and OPERATOR_TABLO
        /// </summary>
        public const string ADMIN_and_OPERATORTABLO = "ADMIN,OPERATOR_TABLO";
        /// <summary>
        /// List of roles that are allowed to access the resource => ADMIN and INFO_TABLO
        /// </summary>
        public const string ADMIN_and_INFOTABLO = "ADMIN,INFO_TABLO";
        /// <summary>
        /// List of roles that are allowed to access the resource => ADMIN and ROOM_BOOKING and OPERATOR
        /// </summary>
        public const string ADMIN_and_ROOMBOOKING_and_OPERATOR = "ADMIN,ROOM_BOOKING,OPERATOR";
        /// <summary>
        /// List of roles that are allowed to access the resource => ADMIN and ROOM_TABLO
        /// </summary>
        public const string ADMIN_and_ROOMTABLO = "ADMIN,ROOM_TABLO";
    }
}