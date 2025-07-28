using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Main.Extensions
{
    public static class ObjectExtension
    {
        public static void ValidateValue(this object @object, string fieldName)
        {
            if (@object == null || (@object is string str && string.IsNullOrWhiteSpace(str)))
            {
                throw new ValidationException($"el campo '{fieldName}' es obligatorio");
            }
        }
    }
}
