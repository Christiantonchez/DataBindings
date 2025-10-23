namespace DataBinding.ElementoXAML
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            TextLabel.Text = string.Empty;
        }

       private void OnEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
           TextLabel.Text = TextEntry.Text;
       }
    }
}
