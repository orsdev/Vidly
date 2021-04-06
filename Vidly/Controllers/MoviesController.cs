using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        /*
         *  links the database server to the data model class
         */
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public ActionResult New()
        {
            var _genre = _context.Genres.ToList();

            var viewModel = new MovieViewModel
            {
                Movies = new Movies(),
                Genres = _genre
            };


            return View("MovieForm", viewModel);
        }


        public ActionResult Edit(int id)
        {
            var _movies = _context.Movies.SingleOrDefault(c => c.Id == id);
            var _genre = _context.Genres.ToList();

            var viewModel = new MovieViewModel
            {
                Movies = _movies,
                Genres = _genre
            };


            return View("MovieForm",viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movies)
        {

            if(!ModelState.IsValid)
            {
                var _genre = _context.Genres.ToList();

                var viewModel = new MovieViewModel
                {
                    Movies = new Movies(),
                    Genres = _genre
                };

                return View("MovieForm", viewModel);

            }

            if (movies.Id == 0)
            {
                _context.Movies.Add(movies);
            }
            else
            {

                var DBMovies = _context.Movies.SingleOrDefault(c => c.Id == movies.Id);

                if (DBMovies == null)
                {
                    return HttpNotFound();
                }

                DBMovies.Name = movies.Name;
                DBMovies.GenreId = movies.GenreId;
                DBMovies.NumberInStock = movies.NumberInStock;
                DBMovies.ReleaseDate = movies.ReleaseDate;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}