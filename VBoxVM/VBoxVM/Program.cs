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
                Application.Run(new MainView());
            }
            else
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new RestoreView());
            }
        }
    }
}