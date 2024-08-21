namespace Answers_APP_Examen_KeirynS.View;

public partial class QuestionsPage : ContentPage
{
    public QuestionsPage()
    {
        InitializeComponent();
    }

    private async void BtnSubmit_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Submitted", "Your answers have been submitted successfully.", "OK");

    }
}
