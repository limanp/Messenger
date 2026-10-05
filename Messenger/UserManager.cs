using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    internal class UserManager
    {
        // Private fields 
        private UserProfile? _currentUser;
        private bool _isOnline;

        // Logic (Business Logic). Methods of action 

        // User authoriztion method
        public void Authorization()
        {
            // The password verification logic will go here.

            // Successful authorization
            _currentUser = new UserProfile("Pavlo", "Gereminos", "Latiso123", "Latiso123@gmail.com");
            _isOnline = true;
        }

        // User logout method
        public void Logout()
        {
            _currentUser = null;
            _isOnline = false; 
        }
    }
}
