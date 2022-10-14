using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyApi.Model;
using MyApi.Models;

namespace MyApi.Controllers
{
    public class ChatRoomsController : ApiController
    {
        private FirsttDataBaseShulanovEntities db = new FirsttDataBaseShulanovEntities();

        // GET: api/ChatRooms
        public IHttpActionResult GetChatRoom()
        {
            return Ok(db.ChatRoom.Include(i => i.ChatMessage).ToList().ConvertAll(i => new ResponceChatRoom(i)));
        }

        // GET: api/ChatRooms/5
        [ResponseType(typeof(ChatRoom))]
        public IHttpActionResult GetChatRoom(int id)
        {
            ChatRoom chatRoom = db.ChatRoom.Find(id);
            if (chatRoom == null)
            {
                return NotFound();
            }

            return Ok(chatRoom);
        }

        // PUT: api/ChatRooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChatRoom(int id, ChatRoom chatRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatRoom.Id)
            {
                return BadRequest();
            }

            db.Entry(chatRoom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ChatRooms
        [ResponseType(typeof(ChatRoom))]
        public IHttpActionResult PostChatRoom(ChatRoom chatRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChatRoom.Add(chatRoom);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ChatRoomExists(chatRoom.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = chatRoom.Id }, chatRoom);
        }

        // DELETE: api/ChatRooms/5
        [ResponseType(typeof(ChatRoom))]
        public IHttpActionResult DeleteChatRoom(int id)
        {
            ChatRoom chatRoom = db.ChatRoom.Find(id);
            if (chatRoom == null)
            {
                return NotFound();
            }

            db.ChatRoom.Remove(chatRoom);
            db.SaveChanges();

            return Ok(chatRoom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatRoomExists(int id)
        {
            return db.ChatRoom.Count(e => e.Id == id) > 0;
        }
    }
}