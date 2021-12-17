/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

using NoteBulderApp.ConfigItems;
using NoteBulderApp.ConfigLoaders;
using NoteBulderApp.Progs;
using System;
using System.IO;
using System.Linq;

namespace NoteBulderApp.ProgItems
{
    public class NoteProg : IProgItem
    {
        private const string NoteDirectoryFilePrefix = "Notes_";
        private const string NoteDirectoryFileDateFormat = "yyyy-MM-dd";

        private const string NoteFileSuffix = ".txt";

        private const string NoteFileTextFormat = "Notes {0}";

        private NoteConfig _NoteConfig;

        public NoteProg(IConfigLoader configLoader)
        {
            this._NoteConfig = new NoteConfig(configLoader);
            this.Initialise();
        }

        public ProgCollection PathCollection { get; set; }

        public void Run()
        {
            this.PathCollection.Run();

            this.CreateNoteDirectory();
            this.CreateNotesFile();
        }

        private DirectoryInfo CreateNoteDirectory()
        {
            string dirPath = this.GetNoteDirectoryPath();
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            return new DirectoryInfo(dirPath);
        }

        private string GetNoteDirectoryPath()
        {
            int selectedIndex = int.Parse(this.PathCollection.Selected);
            return Path.Combine(
                this._NoteConfig.Paths.Values.ElementAt(selectedIndex),
                NoteDirectoryFilePrefix +
                DateTime.Now.ToString(NoteDirectoryFileDateFormat));
        }

        private FileInfo CreateNotesFile()
        {
            string fullPath = this.GetNoteFullPath();
            string contents = this.GetNoteText();
            if (!File.Exists(fullPath))
                File.WriteAllText(fullPath, contents);
            return new FileInfo(fullPath);
        }

        private string GetNoteFullPath()
        {
            string dirPath = this.GetNoteDirectoryPath();
            string filePath = this.GetNoteFilePath();
            return Path.Combine(dirPath, filePath);
        }

        private string GetNoteText()
        {
            return string.Format(
                NoteFileTextFormat, 
                DateTime.Now.ToString(NoteDirectoryFileDateFormat));
        }

        private string GetNoteFilePath()
        {
            return NoteDirectoryFilePrefix
                + DateTime.Now.ToString(NoteDirectoryFileDateFormat)
                + NoteFileSuffix;
        }

        private void Initialise()
        {
            this.PathCollection = new ProgCollection(this._NoteConfig.Paths.Values);
        }
    }
}
