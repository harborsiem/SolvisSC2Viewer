using System;
using System.Collections.Generic;
using System.Text;

namespace SolvisSC2Viewer {
    public class ActionManager {

        private Dictionary<string, Action> actions;

        public ActionManager() {
            this.actions = new Dictionary<string, Action>();
            this.Init();
        }

        public void Init() {
            //file actions
            AddAction(new OpenFileAction());
            AddAction(new Open1DayModeAction());
            AddAction(new PrintPreviewAction());
            AddAction(new PrintAction());
            AddAction(new ExitAction());

            //extras actions
            AddAction(new HeatCurveAction());
            AddAction(new SensorsCheckAction());
            AddAction(new ConfigEditorAction());
            AddAction(new TimeTableAction());
            AddAction(new CounterListAction());
            AddAction(new ParameterListAction());

            //help actions
            AddAction(new DocAction());
            AddAction(new AboutAction());

            //exit
            AddAction(new DisposeAction());
        }

        internal void AddAction(Action action) {
            this.actions.Add(action.ActionName, action);
        }

        public void RemoveAction(string name) {
            this.actions.Remove(name);
        }

        internal Action GetAction(string name) {
            return this.actions[name];
        }

        public IList<string> AvailableKeyBindingActions {
            get {
                IList<string> availableKeyBindingActions = new List<string>();
                foreach (string actionName in this.actions.Keys) {
                    if (GetAction(actionName).IsKeyBindingAvailable()) {
                        availableKeyBindingActions.Add(actionName);
                    }
                }
                return availableKeyBindingActions;
            }
        }
    }
}
