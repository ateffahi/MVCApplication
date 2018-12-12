using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Application.Filtres
{
    public class CustomLogFilter : ActionFilterAttribute
    {
        private string filePath = @"C:\DossierTest\loggerFile.txt";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.HttpMethod.ToUpper() == "GET")
            {
                // inisialiser le fichier
                InitFile();
                //Ajouter les traces dans ce fichier 
                AddTextToFile($"La méthode appellée {filterContext.HttpContext.Request.UrlReferrer} à {DateTime.UtcNow}");
            }

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Initialiser un ficher (le creer si il n'existe pas)
        /// </summary>
        private void InitFile()
        {
            try
            {
                if (File.Exists(filePath)) return;
                using (var file = File.Create(filePath)) file.Close();
            }
            catch (Exception ex)
            {
                // Gérer les erreurs
            }
        }

        /// <summary>
        /// Ajouter du text à un fichier
        /// </summary>
        /// <param name="text"></param>
        private void AddTextToFile(string text)
        {
            File.AppendAllLines(filePath, new List<string>(){ text});

        }


    }
}