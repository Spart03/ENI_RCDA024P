using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP1_module5.Models;

namespace TP1_module5.Controllers
{
    public class ChatController : Controller
    {
        private readonly static List<Chat> chats = Chat.GetMeuteDeChats();
        
        // GET: Chat
        public ActionResult Index()
        {
            return View(chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            var chat = chats.FirstOrDefault(x => x.Id == id);
            return View(chat);
        }

        
        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var chat = chats.FirstOrDefault(x => x.Id == id);
            return View(chat);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chat = chats.FirstOrDefault(x => x.Id == id);
              
                chats.Remove(chat);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }
    }
}
