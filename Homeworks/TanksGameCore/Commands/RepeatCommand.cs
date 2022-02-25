namespace Tanks_Game_Core
{
    public class RepeatCommand : ICommand
    {
        public readonly ICommand RepeatableCommand;
        public readonly int Iteration = 1;

        public RepeatCommand(ICommand repeatableCommand) 
        {
            this.RepeatableCommand = repeatableCommand;
        }
        
        public RepeatCommand(ICommand repeatableCommand, int iteration)
        {
            this.RepeatableCommand = repeatableCommand;
            this.Iteration = iteration;
        }

        public void Execute() =>
            //CommandExecutor.Instance.Add(RepeatableCommand);
            RepeatableCommand.Execute();

        public void Undo() =>
            RepeatableCommand.Undo();
    }
}