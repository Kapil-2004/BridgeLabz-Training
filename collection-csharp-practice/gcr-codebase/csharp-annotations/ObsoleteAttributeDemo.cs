using System;

public class ObsoleteAttributeDemo
{
    class LegacyAPI
    {
        [Obsolete("OldFeature() is obsolete. Use NewFeature() instead.")]
        public void OldFeature()
        {
            Console.WriteLine("Executing old feature...");
        }

        public void NewFeature()
        {
            Console.WriteLine("Executing new feature...");
        }
    }

    public static void Main()
    {
        LegacyAPI api = new LegacyAPI();

        // This will produce a compile-time warning
        api.OldFeature();

        // This is the recommended method
        api.NewFeature();
    }
}
