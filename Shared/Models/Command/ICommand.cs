using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Command
{
    public interface ICommand
    {
        Obstacle Obstacle { get; }
        void Execute();
        void Undo();
    }
}
