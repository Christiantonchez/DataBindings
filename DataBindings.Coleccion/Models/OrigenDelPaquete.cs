using System.ComponentModel;

namespace DataBindings.Coleccion.Models
{
    public class OrigenDelPaquete : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
    

        //public string Nombre { get; set; } = string.Empty;
        //public string Origen { get; set; } = string.Empty;
        //public bool EstaHabilitado { get; set;} = false;

        private string _nombre = string.Empty;  
        private string _origen = string.Empty;
        private bool _estaHabilitado = false;

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        public string Origen 
        {
            get => _origen;
                set
            {
                if (_origen != value) 
                {
                    _origen = value;
                    OnPropertyChanged(nameof(Origen));
                }
            }
        }


        public bool EstaHabilitado
        {


            get => _estaHabilitado;
            set
            {
                if (_estaHabilitado != value)
                {
                    _estaHabilitado = value;
                    OnPropertyChanged(nameof(EstaHabilitado));
                }
            }
        }


        public override string ToString()
        {
            return $"{Nombre} - ({Origen}";
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        


    }
}
