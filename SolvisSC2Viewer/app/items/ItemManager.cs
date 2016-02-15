using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    public sealed class ItemManager : IDisposable {

        public MenuStrip Menu { get; private set; }
        public MainToolItems ToolMenu { get; private set; }
        private List<IItemBase> loadedToolItems;
        private List<IItemBase> loadedMenuItems;
        private bool disposed;

        public ItemManager() {
            this.loadedToolItems = new List<IItemBase>();
            this.loadedMenuItems = new List<IItemBase>();
        }

        public void Init() {
            this.LoadItems();
            InitItems();
            UpdateItems();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            if (!disposed) {
                if (disposing) {
                    if (this.Menu != null && !this.Menu.IsDisposed) {
                        this.Menu.Dispose();
                    }
                    if (ToolMenu != null && !ToolMenu.IsDisposed) {
                        ToolMenu.Dispose();
                    }
                }
                disposed = true;
            }
        }

        public void LoadItems() {
            this.CreateToolMenu();
            this.CreateMenu();
        }

        public void CreateToolMenu() {
            Form shell = AppManager.MainForm;
            shell.SuspendLayout();
            ToolMenu = new MainToolItems();
            shell.Controls.Add(ToolMenu);
            this.loadedToolItems.Clear();
            this.loadedToolItems.Add((IItemBase)ToolMenu);
            shell.ResumeLayout();
        }

        public void CreateMenu() {
            Form shell = AppManager.MainForm;
            this.Menu = shell.MainMenuStrip;
            shell.SuspendLayout();
            if (this.Menu != null) {
                shell.Controls.Remove(this.Menu);
            }
            this.Menu = new MainMenu();
            shell.Controls.Add(this.Menu);
            shell.MainMenuStrip = this.Menu;
            this.loadedMenuItems.Clear();
            for (int i = 0; i < this.Menu.Items.Count; i++) {
                this.loadedMenuItems.Add((IItemBase)this.Menu.Items[i]);
            }
            shell.ResumeLayout();
        }

        public void InitItems() {
            InitItems(this.loadedToolItems);
            InitItems(this.loadedMenuItems);
        }

        private static void InitItems(List<IItemBase> items) {
            foreach (IItemBase item in items) {
                item.Init();
            }
        }

        public void UpdateItems() {
            if (true) {
                UpdateItems(this.loadedToolItems);
                UpdateItems(this.loadedMenuItems);
            }
        }

        private static void UpdateItems(List<IItemBase> items) {
            foreach (IItemBase item in items) {
                item.UpdateItems();
            }
        }

        public void LoadProperties() {
            if (true) {
                LoadProperties(this.loadedToolItems);
                LoadProperties(this.loadedMenuItems);
            }
        }

        private static void LoadProperties(List<IItemBase> items) {
            foreach (IItemBase item in items) {
                item.LoadProperties();
            }
        }
    }
}