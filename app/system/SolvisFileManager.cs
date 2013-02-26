using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvisSC2Viewer {
    internal class SolvisFileManager {
        private string[] fileArray;
        private int fileIndex;
        private bool previousEnabled;
        private bool nextEnabled;

        public void NewFileSelection(string[] files) {
            if (files.Length > 1) {
                fileArray = (string[])files.Clone();
                fileIndex = 0;
                previousEnabled = false;
                nextEnabled = true;
                AppManager.ItemManager.ToolMenu.SetFileItemsVisible(true);
                AppManager.ItemManager.ToolMenu.SetFileItemsEnabled(previousEnabled, nextEnabled);
            } else {
                AppManager.ItemManager.ToolMenu.SetFileItemsVisible(false);
                AppManager.ItemManager.ToolMenu.SetFileItemsEnabled(false, false);
            }
        }

        public void PreviousFileClick() {
            if (fileIndex <= 0) {
                return;
            }
            fileIndex--;
            nextEnabled = true;
            if (fileIndex == 0) {
                previousEnabled = false;
            }
            AppManager.ItemManager.ToolMenu.SetFileItemsEnabled(previousEnabled, nextEnabled);
            AppManager.DataManager.FillSolvisList(fileArray[fileIndex]);
        }

        public void NextFileClick() {
            if (fileIndex >= fileArray.Length - 1) {
                return;
            }
            fileIndex++;
            previousEnabled = true;
            if (fileIndex == fileArray.Length - 1) {
                nextEnabled = false;
            }
            AppManager.ItemManager.ToolMenu.SetFileItemsEnabled(previousEnabled, nextEnabled);
            AppManager.DataManager.FillSolvisList(fileArray[fileIndex]);
        }
    }
}
