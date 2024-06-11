using System;
using System.IO;

namespace Backend.Services
{
    public class ApplicationService
    {
        //Here you should create Menu which your Console application will show to user
        //User should be able to choose between: 1. Movie star 2. Calculate Net salary 3. Exit

        public ApplicationService()
        {
        }

        public void Run()
        {
            var userChoice = DisplayMenu();
        }

        private int DisplayMenu()
        {
            throw new NotImplementedException();
        }

    }
}
