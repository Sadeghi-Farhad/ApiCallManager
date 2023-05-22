namespace ApiCallManager
{
    public struct ErrorTypes
    {
        /// <summary>
        /// درخواست تکراری است
        /// </summary>
        public const string duplicate_request = "duplicate_request";
        /// <summary>
        /// تعداد درخواست بیش از حد انتظار است
        /// </summary>
        public const string high_number_request = "high_number_request";
        /// <summary>
        /// درخواست صحیح (معتبر) نیست
        /// </summary>
        public const string invalid_request = "invalid_request";
        /// <summary>
        /// اجازه دسترسی وجود ندارد
        /// </summary>
        public const string unauthorized = "unauthorized";
        /// <summary>
        /// خطایی سمت سرور رخ داده است
        /// </summary>
        public const string server_error = "server_error";
        /// <summary>
        /// خطای ناخواسته ای سمت سرور رخ داده است
        /// </summary>
        public const string server_unexpected_error = "server_unexpected_error";
        /// <summary>
        /// موردی یافت نشد
        /// </summary>
        public const string not_found = "not_found";
        /// <summary>
        /// مشکل ارتباطی وجود دارد
        /// </summary>
        public const string connection_error = "connection_error";
    }
}
