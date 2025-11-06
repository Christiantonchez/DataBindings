
using DataBindings.Coleccion.Models;
using Microsoft.Maui.Platform;

namespace DataBindings.Coleccion.Views;

public partial class MainPage : ContentPage
{


	private List<OrigenDelPaquete> _origenes;
	public MainPage()
	{
		InitializeComponent();
		_origenes = new List<OrigenDelPaquete>();
		CargarDatos();
		OriginesListView.ItemsSource = _origenes;
	}
	private void CargarDatos()
	{
		_origenes.Add(new OrigenDelPaquete
		{
			Nombre = "nuget.org",
			Origen = "https://api.nuget.org/v3/index.json",
			EstaHabilitado = true,


		}
			);

		{
			_origenes.Add(new OrigenDelPaquete
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
		_origenes.Add(origen);
		OriginesListView.ItemsSource = null;
		OriginesListView.ItemsSource = _origenes;
		OriginesListView.SelectedItem = origen;
		ActualizaCamposDeEntrada();
	}

	private void ActualizaCamposDeEntrada()
	{
		var origen = OriginesListView.SelectedItem as OrigenDelPaquete;

		if (origen != null)
		{
			NombreEntry.Text = origen.Nombre;

			OrigenEntry.Text = origen.Origen;
		}
		else
		{
            NombreEntry.Text = string.Empty;

            OrigenEntry.Text = string.Empty;
        }
	}

	private void OnRemoveButtonClicked(object sender, EventArgs e)
	{
		OrigenDelPaquete seleccionado = (OrigenDelPaquete)OriginesListView.SelectedItem;
		if (seleccionado != null)
		{
			var indice = _origenes.IndexOf(seleccionado);
			OrigenDelPaquete? nuevoSeleccionado;
			if (indice < _origenes.Count - 1)
			{
				nuevoSeleccionado = _origenes[indice + 1];

			}
			else
			{
				if(_origenes.Count > 1)
				{
                    nuevoSeleccionado = _origenes[_origenes.Count - 2];
                }
				else
				{
					nuevoSeleccionado=null;
				}

            }
			_origenes.Remove(seleccionado);
			OriginesListView.ItemsSource = null;
			OriginesListView.ItemsSource = _origenes;

            OriginesListView.SelectedItem = nuevoSeleccionado;

        }

    }

    private void OnSelectedOriginesListViews(object sender, SelectedItemChangedEventArgs e)
    {
		ActualizaCamposDeEntrada();
    }

	private void OnActualizarButtonClicked(object sender, EventArgs e)
	{
		OrigenDelPaquete? seleccionado = OriginesListView.SelectedItem as OrigenDelPaquete;
		if (seleccionado != null)
		{
			seleccionado.Nombre = NombreEntry.Text;
			seleccionado.Origen = OrigenEntry.Text;
			OriginesListView.ItemsSource = null;
            OriginesListView.ItemsSource= _origenes;
        }
	}
}