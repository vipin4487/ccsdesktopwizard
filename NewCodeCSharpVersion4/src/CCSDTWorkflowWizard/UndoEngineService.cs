namespace CCSDTWorkflowWizard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;

    public class UndoEngineService : UndoEngine
    {
        private List<UndoEngine.UndoUnit> undoUnitList;
        private int currentPos;
        public static int myNumber = 0;

        public UndoEngineService(IServiceProvider provider) : base(provider)
        {
            this.undoUnitList = new List<UndoEngine.UndoUnit>();
            this.currentPos = 0;
        }

        protected override void AddUndoUnit(UndoEngine.UndoUnit unit)
        {
            this.undoUnitList.RemoveRange(this.currentPos, this.undoUnitList.Count - this.currentPos);
            this.undoUnitList.Add(unit);
            this.currentPos = this.undoUnitList.Count;
        }

        protected override UndoEngine.UndoUnit CreateUndoUnit(string name, bool primary)
        {
            return base.CreateUndoUnit(name, primary);
        }

        protected override void DiscardUndoUnit(UndoEngine.UndoUnit unit)
        {
            this.undoUnitList.Remove(unit);
            base.DiscardUndoUnit(unit);
        }

        public void DoRedo()
        {
            if (this.currentPos < this.undoUnitList.Count)
            {
                this.undoUnitList[this.currentPos].Undo();
                this.currentPos++;
            }
            this.UpdateUndoRedoMenuCommandsStatus();
        }

        public void DoUndo()
        {
            if (this.currentPos > 1)
            {
                this.undoUnitList[this.currentPos - 1].Undo();
                this.currentPos--;
            }
            this.UpdateUndoRedoMenuCommandsStatus();
        }

        public void OnRedo(object sender, EventArgs e)
        {
            this.DoRedo();
        }

        public void OnUndo(object sender, EventArgs e)
        {
            this.DoUndo();
        }

        protected override void OnUndoing(EventArgs e)
        {
            base.OnUndoing(e);
        }

        protected override void OnUndone(EventArgs e)
        {
            base.OnUndone(e);
        }

        private void UpdateUndoRedoMenuCommandsStatus()
        {
            MenuCommandService service = base.GetService(typeof(MenuCommandService)) as MenuCommandService;
            MenuCommand command = service.FindCommand(StandardCommands.Undo);
            MenuCommand command2 = service.FindCommand(StandardCommands.Redo);
            if (command > null)
            {
                command.Enabled = this.currentPos > 0;
            }
            if (command2 > null)
            {
                command2.Enabled = this.currentPos < this.undoUnitList.Count;
            }
        }
    }
}

