using ApiConsumer.Services;
using ApiConsumer.Services.ApiConsumer.Services.RecaragsListados.Response;
using CargaNet.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaNet.ViewModel
{
    public class RecargasViewModel:baseViewModel
    {
        public RelayCommand BtnCargar => new RelayCommand(x => this.CargarRecargas());

        private ObservableCollection<GetRecarga> _listaRecargas ;

        public ObservableCollection<GetRecarga> Listado
        {
            get { return _listaRecargas; }
            set { _listaRecargas = value;OnpropertyChanged(nameof(Listado)); }
        }


        public void CargarRecargas()
        {
            ClaroNetService service = new ClaroNetService();
            var resp = service.ObtenerRecargasRecientes(globalVariables.token);
             if (!resp.Success)
                return;
            resp.ObjectData.recarga.Reverse();
            Listado = new ObservableCollection<GetRecarga>(resp.ObjectData.recarga);

        }
    }
}
