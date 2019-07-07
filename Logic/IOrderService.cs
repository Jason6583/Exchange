using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IOrderService
    {
        Orders FindById(int id);
    }
}
