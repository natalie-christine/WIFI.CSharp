using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.CSharp.Teil1.Models
{
    /// <summary>
    /// Stellt einen Xml Dienst zum
    /// Speichern und Lesen von
    /// Anwendungskapiteln bereit
    /// </summary>
    internal class ThemenController 
        : WIFI.Anwendung.Generisch.XmlController<Themen>
    {
    }
}
