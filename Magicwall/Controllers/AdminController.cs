using BusinessLayer.Abstract;
using CoreLayer.Helpers;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Magicwall.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        private readonly IOpenPositionService _openPositionService;
        private readonly IHomePageItemService _homePageItemService;
        private readonly IAboutService _aboutService;
        private readonly IModelsService _modelsService;
        private readonly IPhotoPageItemService _photoPageItemService;
        private readonly IVideoPageItemService _videoPageItemService;
        private readonly IDocumentsPageItemService _documentsPageItemService;
        private readonly IReferencesPageItemService _referencesPageItemService;
        private readonly ICatalogService _catalogService;
        private readonly IContactService _contactService;
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IBankAccountService _bankAccountService;
        public AdminController(
            IOpenPositionService openPositionService,
            IHomePageItemService homePageItemService,
            IAboutService aboutService,
            IModelsService modelsService,
            IPhotoPageItemService photoPageItemService,
            IVideoPageItemService videoPageItemService,
            IDocumentsPageItemService documentsPageItemService,
            IReferencesPageItemService referencesPageItemService,
            ICatalogService catalogService,
            IContactService contactService,
            IJobApplicationService jobApplicationService,
            IBankAccountService bankAccountService)
        {
            _openPositionService = openPositionService;
            _homePageItemService = homePageItemService;
            _aboutService = aboutService;
            _modelsService = modelsService;
            _photoPageItemService = photoPageItemService;
            _videoPageItemService = videoPageItemService;
            _documentsPageItemService = documentsPageItemService;
            _referencesPageItemService = referencesPageItemService;
            _catalogService = catalogService;
            _contactService = contactService;
            _jobApplicationService = jobApplicationService;
            _bankAccountService = bankAccountService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("HomePageItems");
        }

        #region aboutUs

        public async Task<IActionResult> AboutUsAsync()
        {
            List<About> aboutList = await _aboutService.GetAllAsync();
            return View(aboutList);
        }
        [HttpPost]
        public async Task<IActionResult> AboutUsAsync(About about, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(about.Title) && !string.IsNullOrEmpty(about.Text))
            {
                if (ModelFileInput != null)
                {
                    string? location = await FileHelper.UploadAsync(Path.Combine("Files", "AboutUs"), ModelFileInput, FileType.image);

                    if (location != null)
                    {
                        about.Image = location;
                    }
                }
                await _aboutService.CreateAsync(about);
            }
            return RedirectToAction("AboutUs");
        }

        [HttpPost]
        public async Task<IActionResult> AboutUsUpdate(About about, IFormFile modelFileInput)
        {
            if (!string.IsNullOrEmpty(about.Title) && !string.IsNullOrEmpty(about.Text))
            {
                if (modelFileInput != null)
                {
                    string? location = await FileHelper.UploadAsync(Path.Combine("Files", "AboutUs"), modelFileInput, FileType.image);

                    if (location != null)
                    {
                        about.Image = location;
                    }
                }
                await _aboutService.UpdateAsync(about);
            }
            return RedirectToAction("AboutUs");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAboutUs(int Id)
        {
            await _aboutService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region Models
        public async Task<IActionResult> ModelsAsync()
        {
            List<ModelPageItem> modelPageItems = await _modelsService.GetAllAsync();
            return View(modelPageItems);
        }
        [HttpPost]
        public async Task<IActionResult> ModelsAsync(string Name, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(Name) && ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "Models"), ModelFileInput, FileType.image);

                if (location != null)
                {
                    ModelPageItem modelPageItem = new()
                    {
                        Name = Name,
                        Image = location
                    };
                    await _modelsService.CreateAsync(modelPageItem);
                }
            }
            return RedirectToAction("Models");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteModel(int Id)
        {
            await _modelsService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region PhotoGallery
        public async Task<IActionResult> PhotoPageItemAsync()
        {
            List<PhotoPageItem> photoPageItems = await _photoPageItemService.GetAllAsync();
            return View(photoPageItems);
        }
        [HttpPost]
        public async Task<IActionResult> PhotoPageItemAsync(string Name, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(Name) && ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "PhotoPage"), ModelFileInput, FileType.image);

                if (location != null)
                {
                    PhotoPageItem photoPageItem = new()
                    {
                        Name = Name,
                        Image = location
                    };
                    await _photoPageItemService.CreateAsync(photoPageItem);
                }
            }
            return RedirectToAction("PhotoPageItem");
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePhotoItem(int Id)
        {
            await _photoPageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region VideoGallery
        public async Task<IActionResult> VideoPageItemAsync()
        {
            List<VideoPageItem> videoPageItems = await _videoPageItemService.GetAllAsync();
            return View(videoPageItems);
        }
        [HttpPost]
        public async Task<IActionResult> VideoPageItemAsync(string Name, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(Name) && ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "VideoPage"), ModelFileInput, FileType.video);

                if (location != null)
                {
                    VideoPageItem videoPageItem = new()
                    {
                        Name = Name,
                        Video = location
                    };
                    await _videoPageItemService.CreateAsync(videoPageItem);
                }
            }

            return RedirectToAction("VideoPageItem");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVideoItem(int Id)
        {
            await _videoPageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region Documents
        public async Task<IActionResult> DocumentsPageItemAsync()
        {
            List<DocumentsPageItem> documentsPageItems = await _documentsPageItemService.GetAllAsync();
            return View(documentsPageItems);
        }
        [HttpPost]
        public async Task<IActionResult> DocumentsPageItemAsync(string Name, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(Name) && ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "DocumentPage"), ModelFileInput, FileType.image);

                if (location != null)
                {
                    DocumentsPageItem documentsPageItem = new()
                    {
                        Name = Name,
                        Image = location
                    };
                    await _documentsPageItemService.CreateAsync(documentsPageItem);
                }
            }
            return RedirectToAction("DocumentsPageItem");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDocumentItem(int Id)
        {
            await _documentsPageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region References
        public async Task<IActionResult> ReferencesAsync()
        {
            List<ReferencesPageItem> references = await _referencesPageItemService.GetAllAsync();
            return View(references);
        }
        [HttpPost]
        public async Task<IActionResult> ReferencesAsync(IFormFile ModelFileInput)
        {
            if (ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "References"), ModelFileInput, FileType.image);

                if (location != null)
                {
                    ReferencesPageItem referencesPageItem = new()
                    {
                        Image = location
                    };
                    await _referencesPageItemService.CreateAsync(referencesPageItem);
                }
            }

            return RedirectToAction("References");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteReferenceItem(int Id)
        {
            await _referencesPageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region Catalog
        public async Task<IActionResult> CatalogAsync()
        {
            List<Catalog> catalog = await _catalogService.GetAllAsync();
            return View(catalog);
        }
        [HttpPost]
        public async Task<IActionResult> CatalogAsync(IFormFile ModelFileInput)
        {
            if (ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "Catalog"), ModelFileInput, FileType.document);

                if (location != null)
                {
                    Catalog catalog = new()
                    {
                        PDF = location
                    };
                    await _catalogService.CreateAsync(catalog);
                }
            }

            return RedirectToAction("Catalog");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCatalogItem(int Id)
        {
            await _catalogService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region Contact
        public async Task<IActionResult> ContactAsync()
        {
            List<Contact> contact = await _contactService.GetAllAsync();
            return View(contact);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContactItem(int Id)
        {
            await _contactService.DeleteAsync(Id);
            return Ok();
        }
        public async Task<IActionResult> ContactDetails(int Id)
        {
            return View(await _contactService.GetByIdAsync(Id));
        }
        #endregion

        #region JobApplication
        public async Task<IActionResult> JobApplicationAsync()
        {
            List<JobApplication> jobApplications = await _jobApplicationService.GetAllAsync();
            return View(jobApplications);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJobApplicationItem(int Id)
        {
            await _jobApplicationService.DeleteAsync(Id);
            return Ok();
        }

        public async Task<IActionResult> JobApplicationDetails(int Id)
        {
            return View(await _jobApplicationService.GetByIdAsync(Id));
        }
        #endregion

        #region OpenPositions
        public async Task<IActionResult> OpenPositionsAsync()
        {
            List<OpenPosition> openPositions = await _openPositionService.GetAllAsync();
            return View(openPositions);
        }

        [HttpPost]
        public async Task<IActionResult> OpenPositionsAsync(OpenPosition position)
        {
            await _openPositionService.CreateAsync(position);
            return RedirectToAction("OpenPositions");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOpenPositionsItem(int Id)
        {
            await _openPositionService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region BankAccount
        public async Task<IActionResult> BankAccountAsync()
        {
            List<BankAccount> bankAccounts = await _bankAccountService.GetAllAsync();
            return View(bankAccounts);
        }

        [HttpPost]
        public async Task<IActionResult> BankAccountAsync(BankAccount bankAccount, IFormFile ModelFileInput)
        {
            if (ModelFileInput != null)
            {
                ModelState["Image"].ValidationState = ModelValidationState.Valid;
            }
            if (ModelState.IsValid)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "BankAccount"), ModelFileInput, FileType.image);
                if (location != null)
                {
                    bankAccount.Image = location;
                    await _bankAccountService.CreateAsync(bankAccount);
                }
            }
            return RedirectToAction("BankAccount");
        }

        [HttpPost]
        public async Task<IActionResult> BankAccountUpdate(BankAccount bankAccount, IFormFile? ModelFileInput)
        {

            ModelState["Image"].ValidationState = ModelValidationState.Valid;

            if (ModelState.IsValid)
            {
                if (ModelFileInput != null && ModelFileInput.Length > 0)
                {
                    string? location = await FileHelper.UploadAsync(Path.Combine("Files", "BankAccount"), ModelFileInput, FileType.image);
                    if (location != null)
                    {
                        bankAccount.Image = location;
                    }
                }
                await _bankAccountService.UpdateAsync(bankAccount);
            }
            return RedirectToAction("BankAccount");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBankAccount(int Id)
        {
            await _bankAccountService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region HomePageItems
        public async Task<IActionResult> HomePageItemsAsync()
        {
            List<HomePageItem> homePageItems = await _homePageItemService.GetAllAsync();
            return View(homePageItems);
        }

        [HttpPost]
        public async Task<IActionResult> HomePageItemsAsync(HomePageItem homePageItem, IFormFile ModelFileInput)
        {
            if (ModelState.IsValid)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "homePageItems"), ModelFileInput, FileType.image);
                if (location != null)
                {
                    homePageItem.Image = location;
                    await _homePageItemService.CreateAsync(homePageItem);
                }
            }
            return RedirectToAction("HomePageItems");
        }

        [HttpPost]
        public async Task<IActionResult> HomePageItemsUpdate(HomePageItem homePageItem, IFormFile? modelFileInput)
        {
            if (ModelState.IsValid)
            {
                if (modelFileInput != null && modelFileInput.Length > 0)
                {
                    string? fileLocation = await FileHelper.UploadAsync(Path.Combine("Files", "homePageItems"), modelFileInput, FileType.image);
                    if (fileLocation != null)
                    {
                        homePageItem.Image = fileLocation;
                    }
                }

                await _homePageItemService.UpdateAsync(homePageItem);
            }
            return RedirectToAction("HomePageItems");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHomePageItems(int Id)
        {
            await _homePageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion
    }

}
