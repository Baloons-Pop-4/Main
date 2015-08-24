﻿namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class PrintFieldCommand : PrintCommands
    {
        private IBaloonsField field;

        public PrintFieldCommand(IPrinter printer, IBaloonsField field)
            :base(printer)
        {
            this.field = field;
        }

        public override void Execute()
        {
            this.printer.PrintField(field.Baloons);
        }
    }
}