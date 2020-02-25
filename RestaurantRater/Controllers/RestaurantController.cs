using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();
        //Post
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
            if(ModelState.IsValid && restaurant !=null)
            {
                _context.Restaurants.Add(restaurant);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(ModelState);
        }

        //Get All

        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        //Get by ID
        public async Task<IHttpActionResult> GetById(int id)
        {
            Restaurant restaurant =  await _context.Restaurants.FindAsync(id);
            if(restaurant==null)
            {
                return NotFound();
            }
                return Ok(restaurant);
        }
        //Put (Update Restaurant)

        //Delete by ID (Delete Restaurant)


    }
}
