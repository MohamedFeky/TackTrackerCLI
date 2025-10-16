using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerCLI
{
    internal interface ICommand
    {
        public Task ExecuteAsync();

    }
}
