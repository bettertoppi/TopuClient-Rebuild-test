using System;
using System.IO;
using System.Threading.Tasks;
using CmlLib.Core;
using CmlLib.Core.Downloader;
using CmlLib.Core.ProcessBuilder;
using TopuClient.Models;

namespace TopuClient.Services
{
    public class LauncherService
    {
        private readonly MinecraftPath _path;

        public LauncherService()
        {
            string basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TopuClient");
            _path = new MinecraftPath(basePath);
        }

        public async Task LaunchGameAsync(Profile profile, Account account, Action<DownloadFileChangedEventArgs> onFileChanged, Action<int> onProgressChanged)
        {
            var launcher = new CMLauncher(_path);

            launcher.FileChanged += (e) => onFileChanged?.Invoke(e);
            launcher.ProgressChanged += (sender, e) => onProgressChanged?.Invoke(e.ProgressPercentage);

            // Handle Version and Loaders (Forge, Fabric, NeoForge, Quilt, Vanilla via Mojang manifest)
            string versionId = profile.VersionId;
            if (profile.LoaderType != "Vanilla")
            {
                // Custom naming convention mapping for loader versions handled by library/manifest resolver
                versionId = $"{profile.LoaderType}-{profile.LoaderVersion}-{profile.VersionId}";
            }

            var launchOption = new MLaunchOption
            {
                MaximumRamMb = profile.RamMb,
                Session = MSession.CreateMicrosoftSession(account.Username, account.AccessToken, account.Uuid),
                ScreenWidth = int.Parse(profile.Resolution.Split('x')[0]),
                ScreenHeight = int.Parse(profile.Resolution.Split('x')[1])
            };

            var process = await launcher.CreateProcessAsync(versionId, launchOption);
            process.Start();
        }
    }
}
