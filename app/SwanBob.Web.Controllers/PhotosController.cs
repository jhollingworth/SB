using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Facebook.Rest;
using Facebook.Session;
using Facebook.Web.Mvc;
using SwanBob.Web.Controllers.ViewModels.Photos;

namespace SwanBob.Web.Controllers
{
    public class PhotosController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            var api = GetApi();
            var albums = api.Photos.GetAlbums();
            

            return View(new AddPhotosViewModel { Albums = albums.ToList()});
        }

        public ActionResult AlbumIcon(long uid)
        {
            var api = GetApi();
            api.Photos.GetAlbums(uid);
        }

        private static Api GetApi()
        {
            return new Api(
                new ConnectSession(ConfigurationManager.AppSettings["ApiKey"], ConfigurationManager.AppSettings["Secret"])
            );
        }
    }
}