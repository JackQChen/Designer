﻿namespace FormsDesigner.Commands
{
    using System.ComponentModel.Design;

    public class BringToFront : AbstractFormsDesignerCommand
    {
        public override System.ComponentModel.Design.CommandID CommandID
        {
            get
            {
                return StandardCommands.BringToFront;
            }
        }
    }
}

