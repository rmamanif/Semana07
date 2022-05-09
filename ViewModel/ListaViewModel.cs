
using Entity;
using Semana07.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Semana07.ViewModel
{
    public class ListaViewModel: ViewModelBase
    {
        int _ID;

        public int ID
        {
            get { return _ID; }
            set
            {
                if (ID != value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<Categoria> Categorias { get; set; }
   
        public ICommand NuevoCommand { set; get; }

        public ICommand ConsultarCommand { set; get; }

        public ICommand EditCommand { set; get; } 

        public ListaViewModel()
        {
            Categorias = new Model.CategoriaModel().Categorias;

            NuevoCommand = new RelayCommand<Window>(
                param => Abrir()
                );

            EditCommand = new RelayCommand<object>(
                o =>
                {
                    new CategoriaModel().Eliminar(ID);
                }

                );


            ConsultarCommand = new RelayCommand<object>(
                o => { Categorias = new Model.CategoriaModel().Categorias; }
                );
  

            void Abrir()
            {
                View.ManCategoria window = new View.ManCategoria();
                window.ShowDialog();
            }

        }

    }
}
