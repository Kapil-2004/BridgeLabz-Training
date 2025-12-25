using System;

class OTPGenerator
{
    // a. Generate a 6-digit OTP using Math.Random()
    static int GenerateOTP()
    {
        // Generates number between 100000 and 999999
        int otp = (int)(Math.Random() * 900000) + 100000;
        return otp;
    }

    // c. Check whether all OTPs are unique
    static bool AreOTPsUnique(int[] otps)
    {
        for (int i = 0; i < otps.Length; i++)
        {
            for (int j = i + 1; j < otps.Length; j++)
            {
                if (otps[i] == otps[j])
                {
                    return false; // Duplicate found
                }
            }
        }
        return true; // All unique
    }

    static void Main()
    {
        // b. Array to store 10 OTPs
        int[] otpArray = new int[10];

        // Generate OTPs
        for (int i = 0; i < otpArray.Length; i++)
        {
            otpArray[i] = GenerateOTP();
            Console.WriteLine("Generated OTP " + (i + 1) + ": " + otpArray[i]);
        }

        // Check uniqueness
        bool isUnique = AreOTPsUnique(otpArray);

        if (isUnique)
            Console.WriteLine("All generated OTPs are unique.");
        else
            Console.WriteLine("Duplicate OTPs found.");
    }
}
