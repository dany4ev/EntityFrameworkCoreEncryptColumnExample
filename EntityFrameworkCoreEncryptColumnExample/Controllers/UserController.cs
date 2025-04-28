using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace EntityFrameworkCoreEncryptColumnExample.Controllers
{
    public class UserController : Controller
    {
        private ReverseCryptographyService _cryptographyService;
        private readonly ExampleDbContext _dbContext;
        private readonly string _encryptionKey = string.Empty;

        public UserController(ExampleDbContext dbContext)
        {
            _dbContext = dbContext;
            _encryptionKey = EncryptionHelper.GenerateRandomKey(256);
            _cryptographyService = new ReverseCryptographyService(_encryptionKey);
        }

        // GET: UserController
        public ActionResult Index()
        {
            //var usersViaSPFunction = _dbContext.GetUsers();
            var usersViaEF = _dbContext.Users.ToList();

            foreach (var user in usersViaEF)
            {
                _cryptographyService = new ReverseCryptographyService(user.EncryptionKey);
                user.EmailAddress = _cryptographyService.Decrypt(user.EmailAddress);
                user.IdentityNumber = _cryptographyService.Decrypt(user.IdentityNumber);
            }

            return View(usersViaEF);
        }

        // GET: UserController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var keys = collection.Keys.ToList();
                var user = new User
                {
                    FirstName = collection[keys[0]]!,
                    LastName = collection[keys[1]]!,
                    EmailAddress = _cryptographyService.Encrypt(collection[keys[2]]!),
                    IdentityNumber = _cryptographyService.Encrypt(collection[keys[3]]!),
                    EncryptionKey = _encryptionKey
                };
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var keys = collection.Keys.ToList();
                var user = _dbContext.Users.FirstOrDefault(u => u.ID == Guid.Parse(id));

                if (user != null)
                {
                    user.FirstName = collection[keys[0]]!;
                    user.LastName = collection[keys[1]]!;
                    user.EmailAddress = collection[keys[2]]!;
                    user.IdentityNumber = collection[keys[3]]!;

                    _dbContext.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.ID == Guid.Parse(id));

                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    _dbContext.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
