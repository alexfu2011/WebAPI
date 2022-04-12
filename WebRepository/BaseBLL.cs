using DBUtility;
using System;

namespace BLL
{
    public class BaseBLL<T> : DbContext<T> where T : class, new()
    {
    }
}
