///Fájl neve: Program.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// A Program osztály
    /// </summary>
    public class Program
    {
        /// <summary>
        /// A main függvény
        /// </summary>
        /// <param name="args">Az argumentumok</param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// A WebHost létrehozásáért felelős függvény
        /// </summary>
        /// <param name="args">Az argumentumok</param>
        /// <returns>The <see cref="IWebHost"/></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
