using System;

namespace AddressBookSystem.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredFieldAttribute : Attribute
    {
    }
}
