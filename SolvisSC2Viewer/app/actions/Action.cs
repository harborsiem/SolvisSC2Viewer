using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SolvisSC2Viewer {

    internal abstract class Action {

        protected const int AutoLock = 0x01;

        protected const int AutoUnlock = 0x02;

        protected const int AutoUpdate = 0x04;

        protected const int KeyBindingAvailable = 0x08;

        public string ActionName { get; private set; }

        protected int Flags { get; private set; }
        private object m_lock = new object();

        protected Action(string name, int flags) {
            this.ActionName = name;
            this.Flags = flags;
        }

        protected abstract int Execute(ActionData data);

        private void Process(ActionData data) {
            lock (m_lock) {
                if (!ActionLock.IsLocked && !MainForm.IsLocked) {
                    int flags = Flags;

                    if ((flags & AutoLock) != 0) {
                        ActionLock.Lock();
                    }
                    //new SyncThread(delegate {
                    if (!AppManager.MainForm.IsDisposed) {
                        int result = Execute(data);

                        if (((flags | result) & AutoUnlock) != 0) {
                            ActionLock.Unlock();
                        }
                    }
                    //}).AsyncStart();
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ProcessEvent(object sender, EventArgs e) {
            ToolStripItem widget = sender as ToolStripItem;

            Object widgetData = (widget != null ? widget.Tag : null);
            ActionData actionData = widgetData as ActionData;
            if (actionData == null) {
                actionData = new ActionData();
            }
            actionData.Sender = sender;
            actionData.EventArgs = e;
            this.Process(actionData);
        }

        public bool IsKeyBindingAvailable() {
            return ((Flags & KeyBindingAvailable) != 0);
        }
    }
}