using Paygate.Client.Helpers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Paygate.Client.Models.Common
{
    public abstract class ModelBase
    {
        public ModelBase(string encryptionKey)
        {
            EncryptionKey = encryptionKey;
        }

        public string EncryptionKey { get; }

        protected bool IsChecksumValid(string checksum)
        {
            if (string.IsNullOrEmpty(checksum)) return false;
            var calculatedChecksum = ChecksumHelper.CreateMD5(ExtractStringValuesWithAttribute());
            return string.Equals(calculatedChecksum, checksum);
        }

        public string GenerateChecksum(string encryptionKey)
        {
            var test = ChecksumHelper.CreateMD5(ExtractStringValuesWithAttribute() + encryptionKey);
            return test;
        }

        public string ExtractStringValuesWithAttribute()
        {
            StringBuilder sb = new StringBuilder();

            // Using reflection, get properties with the CustomStringAttribute attribute.
            IEnumerable<PropertyInfo> propertiesWithAttribute = this.GetType()
                                              .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                              .Where(prop => prop.GetCustomAttribute<PartOfChecksumAttribute>() != null);
            foreach ( var prop in propertiesWithAttribute )
            {
                var value = prop.GetValue(this).ToString();
                sb.Append(value);
            }
            return sb.ToString();
        }
    }
}
