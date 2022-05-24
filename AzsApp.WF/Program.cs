namespace AzsApp.WF
{
    internal static class Program
    {
        /// <summary>
        ///  Точка входа (запуска) в приложение.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new StationSearchForm());
        }
    }
}