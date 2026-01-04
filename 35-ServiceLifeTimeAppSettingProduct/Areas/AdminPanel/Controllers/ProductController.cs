using _34_Front_To_BackSqlConnection.Areas.AdminPanel.ViewModels;
using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _34_Front_To_BackSqlConnection.Utilities.Enums;
using _34_Front_To_BackSqlConnection.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _34_Front_To_BackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env     = env;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Where(p => !p.IsDeleted)
                .Select(p => new GetProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Prize = p.Prize,
                    CategoryName = p.Category.Name,
                    ImageURL = p.ProductImages.Where(pi => pi.IsMain == true).FirstOrDefault().ImageUrl
                })
                .ToListAsync();

            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new ProductCreateVM
            {
                Tags = await _context.Tags.ToListAsync(),
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
                Sizes = await _context.Sizes.ToListAsync()
            };

            return View(productCreateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            productCreateVM.Tags = await _context.Tags.ToListAsync();
            productCreateVM.Sizes = await _context.Sizes.ToListAsync();


            if (!ModelState.IsValid) return View(productCreateVM);


            if (!productCreateVM.MainPhoto.IsImage("image/"))
            {
                ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File type is incorrect");
                return View(productCreateVM);
            }

            if (!productCreateVM.MainPhoto.isSizeAllowed(FileSize.Mb, 1))
            {
                ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File size must be less than 1 mb");
                return View(productCreateVM);
            }

            if (!productCreateVM.HoverPhoto.IsImage("image/"))
            {
                ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File type is incorrect");
                return View(productCreateVM);
            }

            if (!productCreateVM.HoverPhoto.isSizeAllowed(FileSize.Mb, 1))
            {
                ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File size must be less than 1 mb");
                return View(productCreateVM);
            }



            bool existCategory = productCreateVM.Categories.Any(c => c.Id == productCreateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.CategoryId),"Selected category does not exist");

                return View(productCreateVM);
            }

            if (productCreateVM.TagIds != null)
            {
                bool existTag = productCreateVM.TagIds.Any(tagId => !productCreateVM.Tags.Exists(t => t.Id == tagId));

                if (existTag)
                {
                    ModelState.AddModelError(nameof(productCreateVM.TagIds), "Selected tags do not exist.");
                    return View(productCreateVM);
                }
            }

            ProductImage mainImage = new()
            {
                ImageUrl = await productCreateVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                IsMain = true,
            };

            ProductImage hoverImage = new()
            {
                ImageUrl = await productCreateVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                IsMain = false,
            };


            Product product = new Product
            {
                Name = productCreateVM.Name,
                Prize = productCreateVM.Prize,
                Description = productCreateVM.Description,
                SKU = productCreateVM.SKU,
                CategoryId = productCreateVM.CategoryId.Value,
                ProductImages = new List<ProductImage> { mainImage, hoverImage },
            };

            if (productCreateVM.TagIds != null)
            {
                product.ProductTags = productCreateVM.TagIds
                    .Select(tId => new ProductTag { TagId = tId })
                    .ToList();

            }

            if (productCreateVM.SizeIds is null || !productCreateVM.SizeIds.Any())
            {
                ModelState.AddModelError(nameof(productCreateVM.SizeIds), "At least one size must be selected.");
                return View(productCreateVM);
            }

            productCreateVM.SizeIds = productCreateVM.SizeIds.Distinct().ToList();

            bool existSize = productCreateVM.SizeIds.Any(sizeId => !productCreateVM.Sizes.Exists(s => s.Id == sizeId));
            if (existSize)
            {
                ModelState.AddModelError(nameof(productCreateVM.SizeIds), "Selected sizes do not exist.");
                return View(productCreateVM);
            }

            if (productCreateVM.AdditionalPhotos != null)
            {
                string text = string.Empty;
                foreach (IFormFile file in productCreateVM.AdditionalPhotos)
                {
                    if (!file.IsImage("image/"))
                    {

                        text += $"<p class=\"text-danger\">{file.FileName} type is incorrect</p>";
                        continue;
                    }
                    if (!file.isSizeAllowed(FileSize.Mb, 1))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName} size must be less than 1 mb</p>";
                        continue;
                    }
                    ProductImage additionalImage = new()
                    {
                        ImageUrl = await file.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                        IsMain = null,
                    };
                    product.ProductImages.Add(additionalImage);
                }


                TempData["FileWarning"] = text;
            }

            if (productCreateVM.SizeIds != null)
            {
                product.ProductSizes = new List<ProductSize>();
                foreach (var sizeId in productCreateVM.SizeIds)
                {
                    product.ProductSizes.Add(new ProductSize { SizeId = sizeId });
                }
            }

            await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            if (!ModelState.IsValid) return View();

            Product existProduct = await _context.Products
                .Include(pi => pi.ProductImages)
                .Include(p => p.ProductTags)
                .Include(p => p.ProductSizes)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existProduct == null) return NotFound();


            ProductUpdateVM productUpdateVM = new ProductUpdateVM
            {
                Name = existProduct.Name,
                Prize = existProduct.Prize,
                Description = existProduct.Description,
                SKU = existProduct.SKU,
                CategoryId = existProduct.CategoryId,
                TagIds = existProduct.ProductTags?.Select(pt => pt.TagId).ToList(),
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.ToListAsync(),
                ProductImages = existProduct.ProductImages,
                Sizes = await _context.Sizes.ToListAsync(),
                SizeIds = existProduct.ProductSizes.Select(ps => ps.SizeId).ToList()
            };
            return View(productUpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {

            if (id is null || id < 1) return BadRequest();

            Product existProduct = await _context.Products
                .Include(pi => pi.ProductImages)
                .Include(p => p.ProductTags)
                .Include(p => p.ProductSizes)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existProduct is null) return NotFound();

            productUpdateVM.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            productUpdateVM.Tags = await _context.Tags.ToListAsync();
            productUpdateVM.ProductImages = existProduct.ProductImages;
            productUpdateVM.Sizes = await _context.Sizes.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(productUpdateVM);
            }



            if (productUpdateVM.MainPhoto is not null)
            {
                if (!productUpdateVM.MainPhoto.IsImage("image/"))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.MainPhoto), "File type is incorrect");
                    return View(productUpdateVM);
                }

                if (!productUpdateVM.MainPhoto.isSizeAllowed(FileSize.Mb, 1))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.MainPhoto), "File size must be less than 1 mb");
                    return View(productUpdateVM);
                }
            }

            if (productUpdateVM.HoverPhoto is not null)
            {
                if (!productUpdateVM.HoverPhoto.IsImage("image/"))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.HoverPhoto), "File type is incorrect");
                    return View(productUpdateVM);
                }

                if (!productUpdateVM.HoverPhoto.isSizeAllowed(FileSize.Mb, 1))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.HoverPhoto), "File size must be less than 1 mb");
                    return View(productUpdateVM);
                }
            }


            bool existCategory = await _context.Categories.AnyAsync(c => c.Id == productUpdateVM.CategoryId);
            if (!existCategory)
            {
                return View(productUpdateVM);
            }

            //
            if (productUpdateVM.TagIds != null)
            {
                bool existTag = productUpdateVM.TagIds.Any(tagId => !productUpdateVM.Tags.Exists(t => t.Id == tagId));
                if (existTag)
                {
                    ModelState.AddModelError(nameof(productUpdateVM.TagIds), "Selected tags do not exist.");
                    return View(productUpdateVM);
                }
            }
            //
            if (productUpdateVM.SizeIds != null)
            {
                bool existSize = productUpdateVM.SizeIds.Any(sizeId => !productUpdateVM.Sizes.Exists(s => s.Id == sizeId));
                if (existSize)
                {
                    ModelState.AddModelError(nameof(productUpdateVM.SizeIds), "Selected sizes do not exist.");
                    return View(productUpdateVM);
                }
            }

            if (productUpdateVM.TagIds is null)
            {
                productUpdateVM.TagIds = new();
            }
            else
            {
                productUpdateVM.TagIds = productUpdateVM.TagIds.Distinct().ToList();
            }

            if (productUpdateVM.TagIds is not null)
            {
                _context.ProductTags.RemoveRange(
                existProduct.ProductTags
                .Where(pTag => !productUpdateVM.TagIds
                .Exists(tId => tId == pTag.TagId)).ToList()
                );

                _context.ProductTags.AddRange(
                    productUpdateVM.TagIds
                    .Where(tId => !existProduct.ProductTags
                    .Exists(pt => pt.TagId == tId))
                    .Select(tId => new ProductTag
                    {
                        ProductId = existProduct.Id,
                        TagId = tId
                    })
                 );
            }


            //
            if (productUpdateVM.SizeIds is null)
            {
                productUpdateVM.SizeIds = new();
            }
            else
            {
                productUpdateVM.SizeIds = productUpdateVM.SizeIds.Distinct().ToList();
            }

            if (productUpdateVM.SizeIds is not null)
            {
                _context.ProductSizes.RemoveRange(
                    existProduct.ProductSizes
                    .Where(pSize => !productUpdateVM.SizeIds
                    .Exists(sId => sId == pSize.SizeId)).ToList()
                );

                _context.ProductSizes.AddRange(
                    productUpdateVM.SizeIds
                    .Where(sId => !existProduct.ProductSizes
                    .Exists(ps => ps.SizeId == sId))
                    .Select(sId => new ProductSize
                    {
                        ProductId = existProduct.Id,
                        SizeId = sId
                    })
                );
            }




            if (productUpdateVM.MainPhoto is not null)
            {
                string fileName = await productUpdateVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images");

                ProductImage? mainImage = existProduct.ProductImages
                    .FirstOrDefault(p => p.IsMain == true);

                mainImage!.ImageUrl.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

                existProduct.ProductImages.Remove(mainImage);

                existProduct.ProductImages.Add(new ProductImage
                {
                    ImageUrl = fileName,
                    IsMain = true
                });
            }

            if (productUpdateVM.HoverPhoto is not null)
            {
                string fileName = await productUpdateVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images");

                ProductImage? hoverImage = existProduct.ProductImages
                    .FirstOrDefault(p => p.IsMain == false);

                hoverImage!.ImageUrl.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

                existProduct.ProductImages.Remove(hoverImage);

                existProduct.ProductImages.Add(new ProductImage
                {
                    ImageUrl = fileName,
                    IsMain = false
                });
            }


            if (productUpdateVM.ImageIds is null)
            {
                productUpdateVM.ImageIds = new();
            }

            var deletedImages = existProduct.ProductImages
                .Where(pi => !productUpdateVM.ImageIds.Contains(pi.Id) && pi.IsMain == null)
                .ToList();

            deletedImages.ForEach(di =>
            {
                di.ImageUrl.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
            });

            _context.ProductImages.RemoveRange(deletedImages);


            if (productUpdateVM.AdditionalPhotos is not null)
            {
                string text = string.Empty;
                foreach (IFormFile file in productUpdateVM.AdditionalPhotos)
                {
                    if (!file.IsImage("image/"))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName} type is incorrect</p>";
                        continue;
                    }
                    if (!file.isSizeAllowed(FileSize.Mb, 1))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName} size must be less than 1 mb</p>";
                        continue;
                    }
                    ProductImage additionalImage = new()
                    {
                        ImageUrl = await file.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                        IsMain = null,
                    };
                    existProduct.ProductImages.Add(additionalImage);
                }

                TempData["FileWarning"] = text;

            }
            existProduct.Name = productUpdateVM.Name;
            existProduct.Prize = productUpdateVM.Prize;
            existProduct.Description = productUpdateVM.Description;
            existProduct.SKU = productUpdateVM.SKU;
            existProduct.CategoryId = productUpdateVM.CategoryId.Value;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1)
                return BadRequest();

            Product existProduct = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (existProduct == null)
                return NotFound();

            existProduct.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags).ThenInclude(pt => pt.Tag)
                .Include(p => p.ProductSizes).ThenInclude(ps => ps.Size)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            ProductDetailVM detailProductVM = new()
            {
                Id = product.Id,
                Name = product.Name,
                Prize = product.Prize,
                Description = product.Description,
                SKU = product.SKU,
                CategoryName = product.Category.Name,
                MainImage = product.ProductImages.FirstOrDefault(pi => pi.IsMain == true)?.ImageUrl,
                AdditionalImages = product.ProductImages
                    .Where(pi => pi.IsMain == null)
                    .Select(pi => pi.ImageUrl)
                    .ToList(),
                Tags = product.ProductTags
                    .Select(pt => pt.Tag.Name)
                    .ToList(),
                Sizes = product.ProductSizes
            };

            return View(detailProductVM);
        }

    }
}
    