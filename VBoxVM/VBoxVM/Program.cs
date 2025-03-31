namespace VBoxVM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            string xmlFile = $@"C:\Users\{Environment.UserName}\.VirtualBox\VirtualBox_bck.xml";

            if (!File.Exists(xmlFile))
            {
                ApplicationConfiguration.Initialize();
                MainView view = new MainView();
                MainController controller = new MainController(view);
                Application.Run(view);
            }
            else
            {
                ApplicationConfiguration.Initialize();
                RestoreView view = new RestoreView();
                RestoreController controller = new RestoreController(view);
                Application.Run(view);
            }
        }
    }
}