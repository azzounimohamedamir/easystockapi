using System;

namespace SmartRestaurant.API.Helpers
{
    public class RandomPasswordGenerator
    {
        private const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        private const string UPPER_CAES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NUMBERS = "123456789";
        private const string SPECIALS = @"!@£$%^&*()#€";

        public static string GeneratePassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial,
            int passwordSize)
        {
            var _password = new char[passwordSize];
            var charSet = ""; // Initialise to blank
            var _random = new Random();
            int counter;

            // Build up the character set to choose from
            if (useLowercase) charSet += LOWER_CASE;

            if (useUppercase) charSet += UPPER_CAES;

            if (useNumbers) charSet += NUMBERS;

            if (useSpecial) charSet += SPECIALS;

            for (counter = 0; counter < passwordSize; counter++)
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];

            return string.Join(null, _password);
        }
    }
}