using Answers_APP_Examen_KeirynS.View;

namespace Answers_APP_Examen_KeirynS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
