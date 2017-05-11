using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLProject
{
    public class AppValidator
    {
        IDialog Dialog;

        public AppValidator(IDialog platformDialog)
        {
            Dialog = platformDialog;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Device { get; set; }

        public async void Validate()
        {
            string Result;

            /** Aquí se puede implementar la funcionalidad principal de la clase. Por el momento solo se devuelve
             * una cadena fija. */
            var ServiceClient = new SALLab04.ServiceClient();
            var SvcResult = await ServiceClient.ValidateAsync(Email, Password, Device);

            //Result = "¡Aplicación Validada!";
            Result = $"{SvcResult.Status}\n{SvcResult.Fullname}\n{SvcResult.Token}";

            /** Invocar al código específico de la plataforma*/
            Dialog.Show(Result);
        }
    }
}
