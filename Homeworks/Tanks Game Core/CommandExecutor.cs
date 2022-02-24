using System;
using System.Collections.Generic;
using System.Threading;

namespace Tanks_Game_Core
{
    public class CommandExecutor : Singleton<CommandExecutor>
    {
        private Queue<ICommand> commandsQueue;
        private bool started;
        private FixedSizedQueue<ICommand> LastCompletedCommands;
        private int LastCompletedCommandsQueueSize = 10;

        public CommandExecutor()
        {
            commandsQueue = new Queue<ICommand>();
            LastCompletedCommands = new FixedSizedQueue<ICommand>(LastCompletedCommandsQueueSize);
        }

        public void Add(ICommand command)
        {
            commandsQueue.Enqueue(command);
            if (!started)
                Start();
        }

        public ICommand[] GetLastCompletedCommands() =>
            LastCompletedCommands.ToArray();

        public void ClearLastCompletedCommands() =>
            LastCompletedCommands.Clear();

        public void SetLastCompletedCommandsQueueSize(int size)
        {
            LastCompletedCommandsQueueSize = size;
            LastCompletedCommands = new FixedSizedQueue<ICommand>(size);
        }

        private void Start()
        {
            started = true;
            while (commandsQueue.Count > 0)
            {
                ICommand command = commandsQueue.Dequeue();

                try
                {
                    command.Execute();
                }
                catch (Exception exception)
                {
                    ErrorHandler.Handle(command, exception);
                }
                finally
                {
                    LastCompletedCommands.Enqueue(command);
                }
            }
            Stop();
        }
        
        private void StartAsync()
        {
            Thread thread = new Thread(Start);
            thread.Start();
        }
        
        private void Stop() => started = false;
    }
}