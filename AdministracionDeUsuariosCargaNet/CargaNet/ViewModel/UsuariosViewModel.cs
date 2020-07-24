using ApiConsumer.Models.Listado;
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

namespace CargaNet.ViewModel
{
    public class UsuariosViewModel:baseViewModel
    {
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnpropertyChanged(nameof(Nombre)); }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnpropertyChanged(nameof(Email)); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnpropertyChanged(nameof(Password)); }
        }
        private ObservableCollection<itemUsuarioModel> _ListadoUsuarios;
        public ObservableCollection<itemUsuarioModel> ListadoUsuarios
        {
            get { return _ListadoUsuarios; }
            set { _ListadoUsuarios = value;OnpropertyChanged(nameof(ListadoUsuarios)); }
        }
        public RelayCommand BtnCrear => new RelayCommand(x=>Crear());
        public RelayCommand BtnCargar => new RelayCommand(x=>ListarUsuarios());
        private void ListarUsuarios()
        {
            Listar(0, 20);
        }
        private void Crear()
        {
            ClaroNetService servicio = new ClaroNetService();
            var respuesta= servicio.CrearUsuario(
                new ApiConsumer.Models.UsuarioRequest 
                {
                    email = Email,
                    nombre = Nombre, 
                    password = Password, 
                    role = "ADMIN_ROLE" 
                }, globalVariables.token);
            Email = string.Empty;
            Password = String.Empty;
            Nombre = string.Empty;
            if (respuesta.Success)
            {
                 MessageBox.Show($"Se Creo Nuevo Usuario \n {respuesta.ObjectData.usuario.nombre}",
                     "Exito",
                     MessageBoxButton.OK,
                     MessageBoxImage.Information);
                     Listar(0, 20);
            }
            else
            {
                MessageBox.Show($"Ocurrio un error al consultar...\n{respuesta.StringData}");
            }
        
        
        }   
        private void Listar(int? desde,int? hasta)
        {
            ClaroNetService servicio = new ClaroNetService();
            var respuesta = servicio.ListarUsuarios(desde, hasta, globalVariables.token);
            if (respuesta.Success)
            {
                ListadoUsuarios =new ObservableCollection<itemUsuarioModel>(
                    ConvertItem(respuesta.ObjectData.usuario));
            }        
        }
        private List<itemUsuarioModel> ConvertItem(List<Usuario> listadoUsuarios)
        {
            return listadoUsuarios.Select(x => new itemUsuarioModel
            {
                email = x.email,
                estado = x.estado,
                google = x.google,
                nombre = x.nombre,
                role = x.role,
                _id = x._id,
                BtnEditar =new RelayCommand(s=>this.openPopUp(x))         

            }).ToList();
        }
        private string visibilityEditarUsuarios="Hidden";
        public string VisibilityEditarUsuarios
        {
            get { return visibilityEditarUsuarios; }
            set { visibilityEditarUsuarios = value;OnpropertyChanged(nameof(VisibilityEditarUsuarios)); }
        }
        private bool _enableUsuarios=false;
        public bool EnableUsuario
        {
            get { return _enableUsuarios; }
            set { _enableUsuarios = value;OnpropertyChanged(nameof(EnableUsuario)); }
        }
        private bool _enableGrid=true;
        public bool EnableGrid
        {
            get { return _enableGrid; }
            set { _enableGrid = value; OnpropertyChanged(nameof(EnableGrid)); }
        }
        private baseViewModel _editviewModel;
        public baseViewModel EditViewModel
        {
            get { return _editviewModel; }
            set { _editviewModel = value;OnpropertyChanged(nameof(EditViewModel)); }
        }
        private itemUsuarioModel _usuarioSeleccionado;
        public itemUsuarioModel UsuarioSelccionado
        {
            get { return _usuarioSeleccionado; }
            set { _usuarioSeleccionado = value;OnpropertyChanged(nameof(UsuarioSelccionado)); }
        }

        public Usuario Seleccionado { get; set; }

        public void openPopUp(object user)
        {
            var usuario = (Usuario)user;
            VisibilityEditarUsuarios = "Visible";
            Nombrepop = usuario.nombre;
            Emailpop = usuario.email;
            RolePOP = usuario.role;
            EstadoPop = usuario.estado;
            
            Seleccionado = usuario;
        }
        public void closePopUp()
        {
            EnableUsuario = false;
            EnableGrid = true;
            VisibilityEditarUsuarios = "Hidden";
        }
        #region PopUpProperties
        private string _nombrepop;
        public string Nombrepop
        {
            get { return _nombrepop; }
            set { _nombrepop = value; OnpropertyChanged(nameof(Nombrepop)); }
        }
        private string _emailpop;
        public string Emailpop
        {
            get { return _emailpop; }
            set { _emailpop = value; OnpropertyChanged(nameof(Emailpop)); }
        }
        private bool _EstadoPop;
        public bool EstadoPop
        {
            get { return _EstadoPop; }
            set { _EstadoPop = value; OnpropertyChanged(nameof(EstadoPop)); }
        }
        private string _rolePop;

        public string RolePOP
        {
            get { return _rolePop; }
            set { _rolePop = value; OnpropertyChanged(nameof(RolePOP)); }
        }

        public RelayCommand BtnCerrar => new RelayCommand(x => closePopUp());
        #endregion

        public RelayCommand BtnActualizar => new RelayCommand(x => this.ActualizarUsuario());

        private void ActualizarUsuario()
        {
            ClaroNetService service = new ClaroNetService();
            var response=service.EditarUsuario(
                new ApiConsumer.Models.UsuarioRequest { email=Emailpop,
                    nombre=Nombrepop,
                    password= Password,
                    role=RolePOP
                }
                , globalVariables.token, Seleccionado._id);
            if (response.Success)
            {
               MessageBox.Show($"El Usuario {Seleccionado.nombre}, fue modificado con exito",
                   "Aviso",MessageBoxButton.OK,MessageBoxImage.Information);
                Refesh();
                return;
            }
            MessageBox.Show($"El Usuario {UsuarioSelccionado.nombre},no fue modificado.. error:{response.MessageError}",
                  "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);

        }
                 
        public void Refesh()
        {
            Listar(0, 20);
            closePopUp();
        }







    }
}
