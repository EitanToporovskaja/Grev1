using Microsoft.AspNetCore.Mvc;

namespace TPBase.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(Usuario model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        bool isValid = ValidateUser(model.nombreUsu, model.contraseña);

        if (isValid)
        {

            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            return View(model);
        }
    }

    /*private bool ValidateUser(string username, string password)
    {
        // Aquí debes implementar la lógica para verificar las credenciales en tu base de datos
        using (var db = new GrevEntities()) // Reemplaza "GrevEntities" con tu contexto de base de datos
        {
            var user = db.Usuario.FirstOrDefault(u => u.nombreUsu == username && u.contraseña == password && u.activo);
            return (user != null);
        }
    }*/
}
