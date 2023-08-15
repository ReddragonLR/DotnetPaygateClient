using Paygate.Client.Helpers;
using System.Reflection;
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

        protected string GenerateChecksum(string encryptionKey)
        {
            return ChecksumHelper.CreateMD5(ExtractStringValuesWithAttribute() + encryptionKey);
        }

        private string ExtractStringValuesWithAttribute()
        {
            StringBuilder sb = new StringBuilder();
            
            // Using reflection, get properties with the CustomStringAttribute attribute.
            var propertiesWithAttribute = this.GetType()
                                              .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                              .Where(prop => prop.GetCustomAttribute<PartOfChecksumAttribute>() != null
                                                          && prop.PropertyType == typeof(string));
            foreach ( var prop in propertiesWithAttribute )
            {
                sb.Append( prop.Name );
            }
            return sb.ToString();
        }
    }
}
