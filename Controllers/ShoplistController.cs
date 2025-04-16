using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingBackend.Models;

namespace ShoppingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoplistController : ControllerBase
    {
        private readonly ShoplistDbContext db = new();

        // Hakee ostoslistan
        [HttpGet]
        public ActionResult GetShoplist()
        {
            var items = db.Shoplist.ToList();

            return Ok(items);
        }

        // Tavaroiden lisääminen ostoslistalle
        [HttpPost]
        public ActionResult AddNewItem([FromBody] Shoplist item)
        {
            db.Shoplist.Add(item);
            db.SaveChanges();

            return Ok("Added new item");
        }

        // Tavaroiden poistaminen ostoslistalta
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            Shoplist? item = db.Shoplist.Find(id);
            if (item != null)
            {
                db.Shoplist.Remove(item);
                db.SaveChanges();
                return Ok("Item removed successfully.");
            }
            else
            {
                return NotFound("Product with id" + id + " not found.");
            }
        }

        // Tavaroiden merkitseminen ostetuksi
        [HttpPut("{id}")]
        public ActionResult MarkAsPurchased(int id)
        {
            var item = db.Shoplist.Find(id);
            if (item == null) return NotFound();

            item.Purchased = !item.Purchased; // toggle
            db.SaveChanges();

            return Ok(item);
        }
    }
}
