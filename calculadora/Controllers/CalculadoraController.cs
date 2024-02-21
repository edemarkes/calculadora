using Microsoft.AspNetCore.Mvc;
using calculadora.Models;

public class CalculadoraController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new CalculadoraModel());
    }

    [HttpPost]
    public IActionResult Index(CalculadoraModel model, string operation)
    {
        switch (operation)
        {
            case "Somar":
                model.Resultado = model.Valor1 + model.Valor2;
                break;
            case "Subtrair":
                model.Resultado = model.Valor1 - model.Valor2;
                break;
            case "Multiplicar":
                model.Resultado = model.Valor1 * model.Valor2;
                break;
            case "Dividir":
                if (model.Valor2 != 0)
                {
                    model.Resultado = model.Valor1 / model.Valor2;
                }
                else
                {
                    ModelState.AddModelError("Valor2", "Não é possível dividir por zero");
                    return View(model);
                }
                break;
        }
        return View(model);
    }
}
