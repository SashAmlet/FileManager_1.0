using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0
{
    internal class UpdateFileManager
    {
        public delegate void updateFileManager();
        public updateFileManager _updateFileManager;
        FileSystemWatcher watcher;
        public UpdateFileManager(string filePath, FileManagerForm myForm)
        {
            try
            {
                watcher = new FileSystemWatcher(filePath);
                watcher.EnableRaisingEvents = true;
                watcher.SynchronizingObject = myForm;
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.Deleted += new FileSystemEventHandler(OnDeleted);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
            }
            catch (Exception ex)
            {
                MessageBox.Show("UpdateFileManager:: " + ex.Message);
            }
        }
        public void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (_updateFileManager != null)
                _updateFileManager();
        }
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (_updateFileManager != null)
                _updateFileManager();
        }
        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            if (_updateFileManager != null)
                _updateFileManager();
        }
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (_updateFileManager != null)
                _updateFileManager();
        }
        private void OnError(object sender, ErrorEventArgs e)
        {
            if (_updateFileManager != null)
                _updateFileManager();
        }
    }
}
