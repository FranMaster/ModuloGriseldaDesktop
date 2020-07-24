using ApiConsumer.Services;
using CargaNet.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CargaNet.ViewModel
{
    public class LoginViewModel:baseViewModel
    {
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
            set { _password = value;OnpropertyChanged(nameof(Password)); }
        }


        public RelayCommand BtnLogin => new RelayCommand(x=>this.login());

        private void login()
        {
            ClaroNetService service = new ClaroNetService();
            var respuesta= service.Log(new ApiConsumer.Models.LoginRequest { email = Email, password = Password });
            Email = string.Empty;
            Password = string.Empty;
            if (respuesta.Success)
            {
                globalVariables.token = respuesta.ObjectData.token;
                MessageBox.Show($"token Generado");
            }
            else
            {
                MessageBox.Show($"Error : \n {respuesta.MessageError}");
            }
        }
    }
}
