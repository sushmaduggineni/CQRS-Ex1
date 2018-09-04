using System;

namespace CQRS_Ex1
{
    public class Command : EventArgs
    {
        public bool Register = true;
    }
}