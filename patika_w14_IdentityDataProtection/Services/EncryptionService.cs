using Microsoft.AspNetCore.DataProtection;

namespace patika_w14_IdentityDataProtection.Services
{
    public class EncryptionService
    {
        private readonly IDataProtector _protector;

        // Şifreleme için bir veri koruyucu oluşturuyoruz.
        public EncryptionService(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("IdentityDataProtection.EncryptionService"); // Yazım hatası düzeltildi
        }

        // VERİYİ ŞİFRELER
        public string Encrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty", nameof(input));

            return _protector.Protect(input);
        }

        // Şifrelene veriyi çözer
        public string Decrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty", nameof(input));

            try
            {
                return _protector.Unprotect(input);
            }
            catch (Exception ex)
            {
                // Hata yönetimi eklenebilir.
                throw new InvalidOperationException("Decryption failed", ex);
            }
        }
    }
}
