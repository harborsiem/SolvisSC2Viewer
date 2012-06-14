using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SolvisSC2Viewer {

    public sealed class ActionLock {
        private static bool working;
        private static object m_lock = new object();

        private ActionLock() {
        }

        public static bool IsLocked {
            get {
                lock (m_lock) {
                    return working;
                }
            }
        }

        public static void Lock() {
            lock (m_lock) {
                working = true;
            }
        }

        public static void Unlock() {
            lock (m_lock) {
                working = false;
            }

        }

        public static void WaitFor() {
            lock (m_lock) {
                try {
                    while (IsLocked) {
                        //Monitor.Wait(typeof(ActionLock), 1);
                        Thread.Sleep(1); //wait(1)
                    }
                }
                catch (ThreadInterruptedException ex) {
                    AppExtension.PrintStackTrace(ex);
                }
            }
        }
    }
}
