using System;

namespace Tanks_Game_Core
{
    public interface IErrorHandler
    {
        public void Handle(ICommand command, Exception exception);
    }
}