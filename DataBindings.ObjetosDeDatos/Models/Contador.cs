
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBindings.ObjetosDeDatos.Models
{
    public class Contador : INotifyPropertyChanged
    {

        private int _conteo;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Conteo
        {
            get => _conteo;
            set
            {
                if(value != _conteo)
                {
                    _conteo = value;
                    OnPropertyChanged(nameof(Conteo));

                }
            }
        }

        public Contador(int conteoincial = 0) {

            Conteo = conteoincial;
        
        }


        public void Contar()
        {

            Conteo++;

        }
        public void Reiniciar()
        {

            Conteo = 0;

        }


        private void OnPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
           {
                PropertyChanged(
                   this,
                    new PropertyChangedEventArgs(propertyName));
          }

        }




    }
}
