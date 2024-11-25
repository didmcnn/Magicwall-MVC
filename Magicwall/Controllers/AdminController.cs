using BusinessLayer.Abstract;
using CoreLayer.Helpers;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Magicwall.Controllers
{
    [Authorize]
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

        public ActionResult Index()
        {
            return View();
        }

        #region aboutUs

        public async Task<ActionResult> AboutUsAsync()
        {
            List<About> aboutList = await _aboutService.GetAllAsync();
            return View(aboutList);
        }
        [HttpPost]
        public async Task<ActionResult> AboutUsAsync(About about, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(about.Title) && !string.IsNullOrEmpty(about.Text) && ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "AboutUs"), ModelFileInput, FileType.image);

                if (location != null)
                {
                    about.Image = location;
                    await _aboutService.CreateAsync(about);
                }
            }
            return RedirectToAction("AboutUs");
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAboutUs(int Id)
        {
            await _aboutService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region Models
        public async Task<ActionResult> ModelsAsync()
        {
            List<ModelPageItem> modelPageItems = await _modelsService.GetAllAsync();
            return View(modelPageItems);
        }
        [HttpPost]
        public async Task<ActionResult> ModelsAsync(string Name, IFormFile ModelFileInput)
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
        public async Task<ActionResult> DeleteModel(int Id)
        {
            await _modelsService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region PhotoGallery
        public async Task<ActionResult> PhotoPageItemAsync()
        {
            List<PhotoPageItem> photoPageItems = await _photoPageItemService.GetAllAsync();
            return View(photoPageItems);
        }
        [HttpPost]
        public async Task<ActionResult> PhotoPageItemAsync(string Name, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(Name) && ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "PhotoPage"), ModelFileInput, FileType.image);

                if (location != null)
                {
                    PhotoPageItem photoPageItem = new()
                    {
                        Name=Name,
                        Image= location
                    };
                    await _photoPageItemService.CreateAsync(photoPageItem);
                }
            }
            return RedirectToAction("PhotoPageItem");
        }
        [HttpDelete]
        public async Task<ActionResult> DeletePhotoItem(int Id)
        {
            await _photoPageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region VideoGallery
        public async Task<ActionResult> VideoPageItemAsync()
        {
            List<VideoPageItem> videoPageItems = await _videoPageItemService.GetAllAsync();
            return View(videoPageItems);
        }
        [HttpPost]
        public async Task<ActionResult> VideoPageItemAsync(string Name, IFormFile ModelFileInput)
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
        public async Task<ActionResult> DeleteVideoItem(int Id)
        {
            await _videoPageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region Documents
        public async Task<ActionResult> DocumentsPageItemAsync()
        {
            List<DocumentsPageItem> documentsPageItems = await _documentsPageItemService.GetAllAsync();
            return View(documentsPageItems);
        }
        [HttpPost]
        public async Task<ActionResult> DocumentsPageItemAsync(string Name, IFormFile ModelFileInput)
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
        public async Task<ActionResult> DeleteDocumentItem(int Id)
        {
            await _documentsPageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region References
        public async Task<ActionResult> ReferencesAsync()
        {
            List<ReferencesPageItem> references = await _referencesPageItemService.GetAllAsync();
            return View(references);
        }
        [HttpPost]
        public async Task<ActionResult> ReferencesAsync(IFormFile ModelFileInput)
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
        public async Task<ActionResult> DeleteReferenceItem(int Id)
        {
            await _referencesPageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion
       
        #region Catalog
        public async Task<ActionResult> CatalogAsync()
        {
            List<Catalog> catalog = await _catalogService.GetAllAsync();
            return View(catalog);
        }
        [HttpPost]
        public async Task<ActionResult> CatalogAsync(IFormFile ModelFileInput)
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
        public async Task<ActionResult> DeleteCatalogItem(int Id)
        {
            await _catalogService.DeleteAsync(Id);
            return Ok();
        }
        #endregion
        
        #region Contact
        public async Task<ActionResult> ContactAsync()
        {
            List<Contact> contact = await _contactService.GetAllAsync();
            return View(contact);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteContactItem(int Id)
        {
            await _contactService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region JobApplication
        public async Task<ActionResult> JobApplicationAsync()
        {
            List<JobApplication> jobApplications = await _jobApplicationService.GetAllAsync();
            return View(jobApplications);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteJobApplicationItem(int Id)
        {
            await _jobApplicationService.DeleteAsync(Id);
            return Ok();
        }
        #endregion
    
        #region OpenPositions
        public async Task<ActionResult> OpenPositionsAsync()
        {
            List<OpenPosition> openPositions = await _openPositionService.GetAllAsync();

            return View(openPositions);
        }

        [HttpPost]
        public async Task<ActionResult> OpenPositionsAsync(OpenPosition position)
        {
            await _openPositionService.CreateAsync(position);

            return RedirectToAction("Catalog");
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteOpenPositionsItem(int Id)
        {
            await _jobApplicationService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region BankAccount
        public async Task<ActionResult> BankAccountAsync()
        {
            List<BankAccount> bankAccounts = await _bankAccountService.GetAllAsync();

            return View(bankAccounts);
        }

        [HttpPost]
        public async Task<ActionResult> BankAccountAsync(BankAccount bankAccount)
        {
            await _bankAccountService.CreateAsync(bankAccount);

            List<BankAccount> bankAccounts = await _bankAccountService.GetAllAsync();
            return View(bankAccounts);
        }
        #endregion
        
        #region HomePageItems
        public async Task<ActionResult> HomePageItemsAsync()
        {
            List<HomePageItem> homePageItems = await _homePageItemService.GetAllAsync();
            return View(homePageItems);
        }

        [HttpPost]
        public async Task<ActionResult> HomePageItemsAsync(HomePageItem homePageItem)
        {
            await _homePageItemService.CreateAsync(homePageItem);
            return RedirectToAction("HomePageItems");
        }
        #endregion
    }

}
