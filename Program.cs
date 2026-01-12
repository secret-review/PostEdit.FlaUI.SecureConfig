using Microsoft.Extensions.Configuration;

namespace PostEdit
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }

        [STAThread]
        static void Main()
        {
            // appsettings.Local.json Çì«Ç›çûÇﬁ
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.Local.json", optional: false, reloadOnChange: true)
                .Build();

            // DB ê⁄ë±ï∂éöóÒ
            Config.ConnectionString = Configuration.GetConnectionString("Default");

            // SSH ê›íË
            var ssh = new SshSettings();
            Configuration.GetSection("SshTunnel").Bind(ssh);
            Config.Ssh = ssh;

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}