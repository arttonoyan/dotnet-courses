using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_Generics_Practice
{
    public interface ICopyable<out T>
    {
        T Copy();
    }
}
