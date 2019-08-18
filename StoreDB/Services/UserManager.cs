using StoreDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreDB
{
   public class UserManager : IUser
    {
        readonly StoreDB.DB.StoreDBContext _context;

        public UserManager(StoreDB.DB.StoreDBContext context)
        {
            this._context = context;
        }

        public void Add(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ed) {
            }

        }        

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }
  
        public User FindUser(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId).FirstOrDefault();
        }

        public User Get(long id)
        {
            var user = _context.Users.Where(us => us.UserId == id).FirstOrDefault();
            return user;            
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Select(a => a).ToList();
        }        

        public List<User> ListUsersBy()
        {
            //sorted List
            return _context.Users.ToList();
        }

        public void Update(User dbEntity, User entity)
        {
            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;
            dbEntity.Email = entity.Email;

            _context.SaveChanges();
        }
    }
}
