using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MefPluginsManager
{
    public class PluginsHandler : IDisposable
    {
        /// <summary>
        /// List of the plugins to import.
        /// </summary>
        [ImportMany(typeof(ILogger))]
       
        public List<ILogger> LoggerList{ get; set; }

        AggregateCatalog _catalog = new AggregateCatalog();

        public void InializePlugins()
        {
            _catalog.Catalogs.Add(new DirectoryCatalog(PluginsPath, "*.dll"));
           
            CompositionContainer cc = new CompositionContainer(_catalog);

            cc.ComposeParts(this);
        }

        public static string PluginsPath
        {
            get { return ConfigurationManager.AppSettings["PluginPath"]; }
        }

        public void Dispose()
        {
            _catalog.Dispose();
            _catalog = null;
            LoggerList.Clear();
            LoggerList = null;
        }
    }
}
