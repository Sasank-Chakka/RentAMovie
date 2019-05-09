//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using RentAMovie.Models;
//using RentAMovie.ViewModel;
//using System.Data.Entity;
//namespace RentAMovie.Controllers
//{
//    [RequireHttps]
//    public class MovieController : Controller
//    {
//        private ApplicationDbContext dbContext = null;
//        public MovieController()
//        {
//            dbContext = new ApplicationDbContext();
//        }
//        protected override void Dispose(bool disposing)
//        {
//            dbContext.Dispose();
//        }
//        // GET: Movie
//        public ActionResult mIndex()
//        {
//            List<Movie> Movies = dbContext.movies.Include(g => g.Genre).ToList();
//            return View(Movies);
//        }
//        public ActionResult Details(int Id)
//        {
//            var Movie = dbContext.movies.Include(g => g.Genre).SingleOrDefault(c => c.id == Id);
//            if (Movie == null)
//            {
//                return HttpNotFound();
//            }
//            return View(Movie);
//        }
//        [HttpGet]
//        public ActionResult Create()
//        {
//            MovieMembershipViewModel viewModel = new MovieMembershipViewModel();
//            Movie movie = new Movie();
//            var Genre = dbContext.genres.ToList();
//            viewModel.Movie = movie;
//            viewModel.Genres = Genre;
//            return View(viewModel);
//        }
//        [HttpPost]
//        public ActionResult Create(Movie movie)
//        {
//            if (ModelState.IsValid)
//            {
//                dbContext.movies.Add(movie);
//                dbContext.SaveChanges();//store in db
//                return RedirectToAction("mIndex", "Movie");
//            }
//            MovieMembershipViewModel viewModel = new MovieMembershipViewModel();
//            Movie movie1 = new Movie();
//            var Genre = dbContext.genres.ToList();
//            viewModel.Movie = movie1;
//            viewModel.Genres = Genre;
//            return View(viewModel);
//        }


//        public List<Movie> GetMovies()
//        {
//            List<Movie> movie = new List<Movie>
//            {
//                new Movie{ id=1,name="Bhahubali",ReleaseDate=Convert.ToDateTime("01-01-2019"),AddDate=Convert.ToDateTime("02-02-2019")},
//                new Movie{ id=2,name="Happy days",ReleaseDate=Convert.ToDateTime("01-01-2018"),AddDate=Convert.ToDateTime("02-02-2018")},
//                new Movie{ id=3,name="Avengers",ReleaseDate=Convert.ToDateTime("01-01-2017"),AddDate=Convert.ToDateTime("02-02-2017")}
//            };
//            return movie;
//        }
//    }
//}
