using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.GameException
{
    public class InvalidCellNumberException : Exception
    {
        public InvalidCellNumberException(string message) : base(message)
        {
        }

        public InvalidCellNumberException(int numCell) : 
            base($"Клетка с номером '{numCell}' уже содержит знак. Выбери другую клетку!")
        {
        }
    }
}
