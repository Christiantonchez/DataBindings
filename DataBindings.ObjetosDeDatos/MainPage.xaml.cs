

using DataBindings.ObjetosDeDatos.Models;
namespace DataBindings.ObjetosDeDatos
{
    public partial class MainPage : ContentPage
    {
        private Contador _contador;


        public MainPage()
        {
            InitializeComponent();
            _contador = new Contador();
            BindingContext = _contador;


        }

        private void OnCounterClicked(object sender, EventArgs e)
        {

            _contador.Contar();
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            _contador.Reiniciar();

        }

    }
}
