using ApiCallManager;
using Microsoft.AspNetCore.Mvc;

namespace WinFormsTester
{
    public class ClassHelper
    {
        public static IApiManager apiManager;

        public static void ShowApiCallError(ApiCallManager.ValidationProblemDetails? error)
        {
            if (error != null)
            {
                MessageBox.Show($"Title: {error?.Title ?? "-"}\n\rDetails: {error?.Detail ?? "-"}", "API Call Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"An unknown error has occurred!", "API Call Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
