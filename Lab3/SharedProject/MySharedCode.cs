using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharedProject
{
    class MySharedCode
    {
        /// <summary>
        /// Implementa la funcionalidad para determinar la ruta de un archivo
        /// dependiendo de la plataforma en la que se esté ejecutando la aplicación.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>FilePath</returns>
        public string GetFilePath(string fileName)
        {
#if WINDOWS_UWP
            var FilePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, fileName);
#else
#if __ANDROID__
            string LibraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var FilePath = Path.Combine(LibraryPath, fileName);
#else
#if WINDOWS_WPF
            //var FilePath = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, fileName);
            var FilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, fileName);
            //System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
#endif
#endif
#endif
            return FilePath;
        }
    }
}
