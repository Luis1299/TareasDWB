using System;
using System.Collections.Generic;
using System.Text;
using Tarea.Models;

namespace Tarea.Services
{
    public class BaseSC
    {
        protected NorthwindContext northwindContext = new NorthwindContext();
    }
}
