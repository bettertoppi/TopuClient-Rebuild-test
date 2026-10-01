using System.Windows;
using TopuClient.Models;
using TopuClient.Services;

namespace TopuClient.Views
{
    public partial class MainWindow : Window
    {
        private readonly AuthService _authService;
        private readonly LauncherService _launcherService;
        private Account? _currentAccount;
        private Profile _currentProfile;

        public MainWindow()
        {
            InitializeComponent();
            _authService = new AuthService();
            _launcherService = new LauncherService();
            _currentProfile = new Profile();
        }

        private async void BtnMsLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentAccount = await _authService.LoginMicrosoftAsync();
                TxtUsername.Text = _currentAccount.Username;
                MessageBox.Show($"Logged in successfully as {_currentAccount.Username}!");
            }
            catch (System.Exception ex)
            {
                // Fallback / handle error or use offline login for testing
                _currentAccount = _authService.LoginOffline("TopuOfflineUser");
                TxtUsername.Text = $"{_currentAccount.Username} (Offline)";
            }
        }

        private async void BtnLaunch_Click(object sender, RoutedEventArgs e)
        {
            if (_currentAccount == null)
            {
                _currentAccount = _authService.LoginOffline("TopuUser");
            }

            BtnLaunch.IsEnabled = false;
            BtnLaunch.Content = "DOWNLOADING...";

            await _launcherService.LaunchGameAsync(
                _currentProfile,
                _currentAccount,
                (fileEvent) => { },
                (progress) => {
                    Dispatcher.Invoke(() => PbDownload.Value = progress);
                }
            );

            BtnLaunch.Content = "LAUNCHED";
            Close();
        }
    }
}
