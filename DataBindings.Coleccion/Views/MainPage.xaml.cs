
using DataBindings.Coleccion.Models;
using System.Collections.ObjectModel;
namespace DataBindings.Coleccion.Views;

public partial class MainPage : ContentPage 
{



    private OrigenDelPaquete? _origenSeleccionado;

    private string _nombreDelOrigen = string.Empty;
    private string _rutaDelOrigen = string.Empty;

    public ObservableCollection<OrigenDelPaquete> Origenes { get; }

    public OrigenDelPaquete? OrigenSeleccionado
    {
        get => _origenSeleccionado;
        set
        {
            if (_origenSeleccionado != value)
            {
                _origenSeleccionado = value;
                OnPropertyChanged(nameof(OrigenSeleccionado));
            }
        }
    }

    public string NombreDelOrigen
    {
        get => _nombreDelOrigen;
        set
        {
            if (_nombreDelOrigen != value)
            {
                _nombreDelOrigen = value;
                OnPropertyChanged(nameof(NombreDelOrigen));
            }
        }
    }

    public string RutaDelOrigen
    {
        get => _rutaDelOrigen;


        set
        {
            if (_rutaDelOrigen != value)
            {
                _rutaDelOrigen = value;
                OnPropertyChanged(nameof(RutaDelOrigen));
            }
        }
    }

    public MainPage()
    {
        InitializeComponent();
        Origenes = new ObservableCollection<OrigenDelPaquete>();
        CargarDatos();
        BindingContext = this;
        _origenSeleccionado = Origenes[1];
        if (Origenes.Count > 0)
        {
            OrigenSeleccionado = Origenes[0];
        }
        else
        {
            OrigenSeleccionado  = null;
        }

    }
    private void CargarDatos()
    {
        Origenes.Add(new OrigenDelPaquete
        {
            Nombre = "nuget.org",
            Origen = "https://api.nuget.org/v3/index.json",
            EstaHabilitado = true,


        }
            );

        {
            Origenes.Add(new OrigenDelPaquete
            {
                Nombre = "Microsoft Visual",
                Origen = "C:\\Program Files (x86)\\Microsoft SDks\\NuGetPackages\\",
                EstaHabilitado = true,
            });


        }
    }

    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        var origen = new OrigenDelPaquete

        {
            Nombre = "Nombre del origen del paquete",
            Origen = "Url o ruta del origen del paquete",
            EstaHabilitado = false,
        };
        Origenes.Add(origen);
        _origenSeleccionado = origen;
    }


    private void OnRemoveButtonClicked(object sender, EventArgs e)
    {
        if (_origenSeleccionado != null)
        {
            var indice = Origenes.IndexOf(_origenSeleccionado);
            OrigenDelPaquete? nuevoSeleccionado;
            if (indice < Origenes.Count - 1)
            {
                nuevoSeleccionado = Origenes[indice + 1];

            }
            else
            {
                if (Origenes.Count > 1)
                {
                    nuevoSeleccionado = Origenes[Origenes.Count - 2];
                }
                else
                {
                    nuevoSeleccionado = null;
                }

            }
            Origenes.Remove(_origenSeleccionado);
            _origenSeleccionado = nuevoSeleccionado;
        }

    }


    private void OnActualizarButtonClicked(object sender, EventArgs e)
    {
        if (OrigenSeleccionado != null)
        {
            if (!OrigenSeleccionado.Nombre.Equals(NombreDelOrigen)
                || !OrigenSeleccionado.Origen.Equals(RutaDelOrigen))

            {
                OrigenSeleccionado.Nombre = NombreDelOrigen;
                OrigenSeleccionado.Origen = RutaDelOrigen;
            }
        }
    }

    private void OriginesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (OrigenSeleccionado != null)
        {
            NombreDelOrigen = OrigenSeleccionado.Nombre;
            RutaDelOrigen = OrigenSeleccionado.Origen;


        }
        else
        {
            NombreDelOrigen = string.Empty;
            RutaDelOrigen = string.Empty;

        }
    }



}