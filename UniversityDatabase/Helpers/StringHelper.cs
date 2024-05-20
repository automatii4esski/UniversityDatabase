
namespace UniversityDatabase.Helpers
{
    public static class StringHelper
    {

        public static string GetPhotoPath(string? photoName)
        {
            return "~/photo/" + (photoName ?? "no-photo.jpg");
        }

        public static string GetCuttedText(string text = "", int length = 250)
        {
            return text.Length > length ? text.Substring(0, length) + "..." : text;
        }
    }
}
