using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using DoceCantinho.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DoceCantinho.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IDoceService _doceService;
        private readonly ICategoryService _categoryService;

        public AdminController(IDoceService doceService, ICategoryService categoryService)
        {
            _doceService = doceService;
            _categoryService = categoryService;
        }

        // ==========================================
        // DASHBOARD ADMINISTRATIVO
        // ==========================================
        public async Task<IActionResult> Index()
        {
            ViewData["ActiveMenu"] = "Dashboard";
            ViewData["Title"] = "Dashboard";
            ViewData["Subtitle"] = "Resumo do sistema DoceCantinho";

            var viewModel = new DashboardViewModel
            {
                TotalDoces = await _doceService.CountAsync(),
                TotalCategories = await _categoryService.CountAsync(),
                FeaturedDoces = (await _doceService.GetFeaturedAsync()).Count(),
                RecentDoces = (await _doceService.GetAllAsync()).Take(5),
                Categories = await _categoryService.GetAllAsync()
            };
            return View(viewModel);
        }

        // ==========================================
        // CRUD DE DOCE
        // ==========================================

        public async Task<IActionResult> Doces()
        {
            ViewData["ActiveMenu"] = "Doces";
            ViewData["Title"] = "Gerenciar Doces";
            ViewData["Subtitle"] = "Cadastre, edite e exclua doces do catálogo";

            var doces = await _doceService.GetAllAsync();
            return View(doces);
        }

        /// <summary>
        /// Formulário para criação de um novo game.
        /// GET : /Admin/CreateGame
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CreateDoce()
        {
            ViewData["ActiveMenu"] = "Doces";
            ViewData["Title"] = "Cadastrar Novo Doce";

            var categories = await _categoryService.GetAllAsync();
            var viewModel = new DoceFormViewModel
            {
                Categories = categories
            };

            return View(viewModel);
        }

        //Processa a criação de um novo game.
        // POST : /Admin/CreateGame
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDoce(DoceFormViewModel viewModel)
        {
            var dto = new CreateDoceDto
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                CoverImageUrl = viewModel.CoverImageUrl,
                CategoryId = viewModel.CategoryId,
                Preco = viewModel.Preco,
                IsFeatured = viewModel.IsFeatured
            };

            await _doceService.CreateAsync(dto);
            TempData["Success"] = "Doce cadastrado com sucesso!";
            return RedirectToAction(nameof(Doces));
        }

        [HttpGet]
        public async Task<IActionResult> EditDoces(int id)
        {
            ViewData["ActiveMenu"] = "Doces";
            ViewData["Title"] = "Editar Doce";

            var doce = await _doceService.GetByIdAsync(id);
            if (doce == null) return NotFound();

            var categories = await _categoryService.GetAllAsync();
            var viewModel = new DoceFormViewModel
            {
                Id = doce.Id,
                Title = doce.Title,
                Description = doce.Description,
                CoverImageUrl = doce.CoverImageUrl,
                CategoryId = doce.CategoryId,
                IsFeatured = doce.IsFeatured,
                Preco = doce.Preco,
                Categories = categories
            };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDoce(int id, DoceFormViewModel viewModel)
        {
            var dto = new UpdateDoceDto
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                CoverImageUrl = viewModel.CoverImageUrl,
                CategoryId = viewModel.CategoryId,
                Preco = viewModel.Preco,
                IsFeatured = viewModel.IsFeatured
            };

            var result = await _doceService.UpdateAsync(id, dto);

            if (result == null)
                return NotFound();

            TempData["Success"] = "Doce atualizado com sucesso!";
            return RedirectToAction(nameof(Doces));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteDoce(int id)
        {
            ViewData["ActiveMenu"] = "Doces";
            ViewData["Title"] = "Excluir Doce";

            var doce = await _doceService.GetByIdAsync(id);
            if (doce == null) return NotFound();

            return View(doce);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDoceConfirmed(int id)
        {
            await _doceService.DeleteAsync(id);
            TempData["Success"] = "Doce excluído com sucesso!";
            return RedirectToAction(nameof(Doces));
        }

        //==========================================
        // CRUD DE CATEGORIAS
        //==========================================

        public async Task<IActionResult> Categories()
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Gerenciar Categorias";
            ViewData["Subtitle"] = "Cadastre, edite e exclua categorias de doces";

            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Nova Categoria";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            await _categoryService.CreateAsync(dto);
            TempData["Success"] = "Categoria cadastrada com sucesso!";
            return RedirectToAction(nameof(Categories));
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Editar Categoria";

            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, UpdateCategoryDto dto)
        {
            var result = await _categoryService.UpdateAsync(id, dto);
            if (result == null) return NotFound();

            TempData["Success"] = "Categoria atualizada com sucesso!";
            return RedirectToAction(nameof(Categories));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Excluir Categoria";

            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoryConfirmed(int id)
        {
            var deleted = await _categoryService.DeleteAsync(id);
            if (!deleted)
            {
                TempData["Error"] = "Não foi possível excluir a categoria. Verifique se há games associados.";
                return RedirectToAction(nameof(Categories));
            }

            TempData["Success"] = "Categoria excluída com sucesso!";
            return RedirectToAction(nameof(Categories));
        }
    }
}
