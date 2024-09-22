using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Structure.Models;

namespace Project_Structure.Controllers
{
    public class MoviesController:Controller
    {

        // Action: Public non-static object member method inside the controller
        [ActionName("Index")]
        [HttpGet] // baseUrl/Movies/Index
        public string GetAllMovies()
        {
            return "Index = All Movies";
        }

        //  baseUrl/Movies/GetMovie/{id}
        //public void GetMovie(int id)
        //{

        //}
        [Authorize(Roles ="VIP")]
        [HttpGet]  // baseUrl/Movies/GetMovie/{id}?name=
        //public string GetMovie([FromRoute]int id)
        //public string GetMovie(int id)
        public string GetMovie(int id, string name)
        {
            return $"Movie with Name {name} and  id : {id}";
        }

        [HttpGet]
        //[AcceptVerbs("GET","POST")]
        public ViewResult createMovie()
        {
            return new ViewResult();
        }

        [HttpPost]
        [ActionName("ConfirmCreateMovie")]
        public OkResult createMovie(Movie movie)
        {
            return new OkResult();
        }
    }
}
