using CRUDWithRepository.Models;
using CRUDWithRepository.Repositories;
using CRUDWithRepository.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithRepository.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private object product;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProducts();
                return View(products);
            }
            catch (Exception ax)
            {

                TempData["errorMessage"] = ax.Message;
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, ProductName, Price, Qty")]
        Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.ProductRepository.Add(product);
                    await _unitOfWork.SaveASync();
                    TempData["successMessage"] = "Product has been created.";
                    return RedirectToAction("Index");
                }
                TempData["errorMessage"] = "Model state is invalid.";
                return View(product);
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View(product);
            }
        }
        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (id == 0)
                {
                    return View();
                }
                var product = await _unitOfWork.ProductRepository.GetProductById(id);
                if (product == null)
                {
                    return View();
                }
                return View(product);
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        // Action Method to Post the data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProductName, Price, Qty")]
        Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return View();
                }
                if (ModelState.IsValid)
                {
                    await _unitOfWork.ProductRepository.Update(product);
                    await _unitOfWork.SaveASync();
                    TempData["successMessage"] = "Product has been Updated.";
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception rx)
            {

                TempData["errorMessage"] = rx.Message;
                return View(product);
            }
        }
        // Details
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (id == 0)
                {
                    return View();
                }
                var product = await _unitOfWork.ProductRepository.GetProductById(id);
                if (product == null)
                {
                    return View();
                }
                return View(product);
            }
            catch (Exception dx)
            {

                TempData["errorMessage"] = dx.Message;
                return View();
            }
        }
        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                if (id == 0)
                {
                    return View();
                }
                var product = await _unitOfWork.ProductRepository.GetProductById(id);
                if (product == null)
                {
                    return View();
                }
                return View(product);
            }
            catch (Exception dx)
            {

                TempData["errorMessage"] = dx.Message;
                return View();
            }
        }
        // Action Method to Post the data
        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id, ProductName, Price, Qty")]
        Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return View();
                }
                if (ModelState.IsValid)
                {
                    await _unitOfWork.ProductRepository.Delete(id);
                    await _unitOfWork.SaveASync();
                    TempData["successMessage"] = "Product has been deleted.";
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception xx)
            {

                TempData["errorMessage"] = xx.Message;
                return View(product);
            }
        }
    }
}
