using ApiCallManager;
using Microsoft.AspNetCore.Mvc;

namespace WinFormsTester
{
    public class ClassHelper
    {
        public static IApiManager apiManager;

        public static void ShowApiCallError(ValidationProblemDetails? error)
        {
            if (error != null)
            {
                MessageBox.Show($"Title: {error?.Title ?? "-"}\n\rDetails: {error?.Detail ?? "-"}", "خطای فراخوانی وب سرویس", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"خطای نامعلومی رخ داده است", "خطای فراخوانی وب سرویس", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
