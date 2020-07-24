using ApiConsumer.Models.Listado;
using ApiConsumer.Services;
using CargaNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CargaNet.ViewModel.ItemViewModel
{
    public class itemUsuarioModel : Usuario
    {
       


        private RelayCommand _BtnEditar;

        public RelayCommand BtnEditar
        {
            get { return _BtnEditar; }
            set { _BtnEditar = value; }
        }

        private RelayCommand _BtnBorrar;

        public RelayCommand BtnBorrar
        {
            get { return new RelayCommand(x=>this.InhabilitarUsuario()); }
   
        }


        private void InhabilitarUsuario()
        {
           ClaroNetService service = new ClaroNetService();
            var response = service.Inhabilitarusuario(
                new ApiConsumer.Models.UsuarioRequest { }, globalVariables.token, this._id);
            if (response.Success)
            {
                MessageBox.Show($"El Usuario {this.nombre}, fue inhabilitado con exito",
                    "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                 return;
            }
            MessageBox.Show($"El Usuario {this.nombre},no fue inhabilitado.. error:{response.MessageError}",
                  "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);

            MainViewModel.GetInstance.Usuario.Refesh();
        }


    }
}
