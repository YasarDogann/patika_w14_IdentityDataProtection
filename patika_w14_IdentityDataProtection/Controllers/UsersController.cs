using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using patika_w14_IdentityDataProtection.Data;
using patika_w14_IdentityDataProtection.Models;
using patika_w14_IdentityDataProtection.Services;

namespace patika_w14_IdentityDataProtection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly EncryptionService _encryptionService;

        // Dependency Injection ile DbContext ve EncryptionService'i ekliyoruz.
        public UsersController(ApplicationDbContext context, EncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            // Tüm kullanıcıları bir koleksiyon olarak döndürüyoruz.
            return _context.Users.ToList();
        }


        //Kullanıcı kaydı içn endpoint
        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            //Gelen modelin geçerliliğini kontrol edelim
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // kullanıcı şifresini şifreler
            user.Password = _encryptionService.Encrypt(user.Password);

            //kullanıcıyı vt ekler
            _context.Users.Add(user);
            _context.SaveChanges();

            //başarılı sonucu döner
            return Ok();    
        }


    }
}
