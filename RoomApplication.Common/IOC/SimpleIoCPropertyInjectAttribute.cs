using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApplication.Common.IOC
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class SimpleIoCPropertyInjectAttribute : Attribute
    {

    }
}
