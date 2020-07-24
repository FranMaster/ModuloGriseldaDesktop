using ApiConsumer.Models.Psr;
using ApiConsumer.Services;
using CargaNet.Model;
using CargaNet.ViewModel.ItemViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace CargaNet.ViewModel
{
    public class PsrViewModel : baseViewModel
    {
        #region Properties
        private string nombrePsr;

        public string NombrePsr
        {
            get { return nombrePsr; }
            set { nombrePsr = value; OnpropertyChanged(nameof(NombrePsr)); }
        }


        private string direccionPsr;

        public string DireccionPsr
        {
            get { return direccionPsr; }
            set { direccionPsr = value; OnpropertyChanged(nameof(DireccionPsr)); }
        }

        private string pin;

        public string Pin
        {
            get { return pin; }
            set { pin = value; OnpropertyChanged(nameof(Pin)); }
        }
        private ObservableCollection<itemPsrModel> _ListadoPcr;

        public ObservableCollection<itemPsrModel> ListadoPcr
        {
            get { return _ListadoPcr; }
            set { _ListadoPcr = value;OnpropertyChanged(nameof(ListadoPcr)); }
        }



        #endregion

        #region Command
        public RelayCommand BtnCrear => new RelayCommand(x => this.CrearPsr());


        public RelayCommand BtnListar => new RelayCommand(x => Listar());
        #endregion

        #region Methods

        private void CrearPsr()
        {
            ClaroNetService service = new ClaroNetService();
            var response = service.CrearPsr(new ApiConsumer.Models.PsrRequest
            {
                nombre = NombrePsr,
                pin = Pin,
                direccion = DireccionPsr
            }, globalVariables.token);

            if (response.Success)
            {
                MessageBox.Show("Psr Creado Satisfactoriamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Listar();
            }
            else
            {
                MessageBox.Show(response.MessageError);
            }
        }

        public void Listar()
        {
            ClaroNetService service = new ClaroNetService();
            var response = service.ListarPsr(null, null, globalVariables.token);
            if (response.Success)
            {
                ListadoPcr = new ObservableCollection<itemPsrModel>(
                    ConvertPcr(response.ObjectData.pcr));
            }
        } 
      
        
        
        
        #endregion

        public List<itemPsrModel> ConvertPcr(List<Pcr> ListadoPsr )
        {
            return ListadoPsr.Select(x => new itemPsrModel
            {
                nombre = x.nombre,
                pin = x.pin,
                direccion = x.direccion,
                _id = x._id,
                estado=x.estado            
            }).ToList();
        }
    
    }
}
