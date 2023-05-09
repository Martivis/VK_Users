using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_Users.Common;

public interface IModelValidator<T> where T : class
{
    void Check(T model);
}
