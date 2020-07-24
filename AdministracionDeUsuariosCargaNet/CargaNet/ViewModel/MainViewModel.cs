

namespace CargaNet.ViewModel
{
    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login { get; set; }
        public PsrViewModel Psr { get; set; }
        public RecargasViewModel Recargas { get; set; }
        public UsuariosViewModel Usuario { get; set; }

        #endregion

        public MainViewModel()
        {
            Usuario = new UsuariosViewModel();
            Psr = new PsrViewModel();
            Login = new LoginViewModel();
            Recargas = new RecargasViewModel();
        }
        private static MainViewModel instance;
        public static MainViewModel GetInstance
        {
            get
            {
                if (instance == null)
                     instance = new MainViewModel();
                return instance;
            }
        }
         
        




    }
}
