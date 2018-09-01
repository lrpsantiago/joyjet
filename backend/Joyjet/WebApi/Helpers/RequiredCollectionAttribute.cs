using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Joyjet.WebApi.Helpers
{
    public class RequiredCollectionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var collection = (ICollection)value;

            return collection.Count > 0;
        }
    }
}
