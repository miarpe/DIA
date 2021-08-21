namespace TiendaReparaciones.Core
{
    using System.Collections;
    using System.Text;
    using System.Xml.Linq;
    using System.Collections.Generic;
    using System;
    using Aparatos;
    public class RegistroReparaciones : ICollection<Reparacion>
    {
        public const string ArchivoXml = "reparaciones.xml";
        public const string EtqReparaciones = "reaparaciones";

        
        public const string EtqReparacion = "reaparacion";
        public const string EtqAparato = "aparato";
        public const string EtqHoras = "horas";
        public const string EtqCoste = "coste";
        public const string EtqTipo = "tipo";

        
        public const string EtqNumSerie = "numSerie";
        public const string EtqModelo = "modelo";

        
        public const string EtqRadio = "radio";
        public const string EtqBanda = "banda";

        
        public const string EtqTelevisor = "televisor";
        public const string EtqPulgadas = "pulgadas";

        
        public const string EtqAdaptador = "adaptador";
        public const string EtqMinGrabacion = "minGrabacion";

        
        public const string EtqReproductor = "reproductor";
        public const string EtqBlueRay = "blueRay";
        public const string EtqGrabacion = "grabacion";
        public const string EtqMinutosGrabacion = "minutosGrabacion";

        private List<Reparacion> reparaciones;

        public RegistroReparaciones()
        {
            this.reparaciones = new List<Reparacion>(); 
        }

        public RegistroReparaciones(IEnumerable<Reparacion> reparaciones)
            : this()
        {
            this.reparaciones.AddRange(reparaciones);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var r in this.reparaciones)
            {
                yield return r;
            }
        }

        IEnumerator<Reparacion> IEnumerable<Reparacion>.GetEnumerator()
        {
            foreach (var r in this.reparaciones)
            {
                yield return r;
            }
        }

        public void Add(Reparacion r)
        {
            this.reparaciones.Add(r);
        }

        public void Clear()
        {
            this.reparaciones.Clear();
        }

        public bool Contains(Reparacion r)
        {
            return this.reparaciones.Contains(r);
        }

        public void CopyTo(Reparacion[] r, int i)
        {
            this.reparaciones.CopyTo(r, i);
        }

        public bool Remove(Reparacion r)
        {
            return this.reparaciones.Remove(r);
        }

        public void RemoveAt(int i)
        {
            this.reparaciones.RemoveAt(i);
        }

        public void AddRange(IEnumerable<Reparacion> rs)
        {
            this.reparaciones.AddRange(rs);
        }

        public int Count
        {
            get { return this.reparaciones.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public Reparacion this[int i]
        {
            get { return this.reparaciones[i]; }
            set { this.reparaciones[i] = value; }
        }

        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach(Reparacion r in this.reparaciones) {
                toret.AppendLine( r.ToString() );
            }
            
            return base.ToString();
        }
        
        public void GuardaXml()
        {
            var doc = new XDocument();
            var root = new XElement( EtqReparaciones );
            
            foreach(Reparacion reparacion in this.reparaciones) {
                XElement aparato = GuardarXmlAparato(reparacion);
                root.Add(
                    new XElement(EtqReparacion,
                        aparato,
                        new XAttribute(EtqHoras, reparacion.HorasReparacion),  
                        new XAttribute(EtqCoste, reparacion.CosteReparacion)
                    )
                    );
            }
            
            doc.Add( root );
            doc.Save(ArchivoXml);
        }
        
        private XElement GuardarXmlAparato(Reparacion r)
        {
            XElement root; 
            
            string tipo = r.AparatoReparacion.GetType().ToString().Split('.')[3];
            switch (tipo)
            {
                case "Radio":
                    Radio radio = (Radio)r.AparatoReparacion;
                    root = new XElement(EtqAparato,
                        new XAttribute(EtqTipo, EtqRadio),
                        new XAttribute(EtqNumSerie, radio.NumSerie),
                        new XAttribute(EtqModelo, radio.Modelo),
                        new XAttribute(EtqBanda, radio.Banda)
                        );
                    break;
                case "Televisor":
                    Televisor televisor = (Televisor)r.AparatoReparacion;
                    root = new XElement(EtqAparato,
                        new XAttribute(EtqTipo, EtqTelevisor),
                        new XAttribute(EtqNumSerie, televisor.NumSerie),
                        new XAttribute(EtqModelo, televisor.Modelo),
                        new XAttribute(EtqPulgadas, televisor.Pulgadas)
                        );
                    break;
                case "Adaptador":
                    Adaptador adaptador = (Adaptador)r.AparatoReparacion;
                    root = new XElement(EtqAparato,
                        new XAttribute(EtqTipo, EtqAdaptador),
                        new XAttribute(EtqNumSerie, adaptador.NumSerie),
                        new XAttribute(EtqModelo, adaptador.Modelo),
                        new XAttribute(EtqMinGrabacion, adaptador.MinGrabacion)
                        );
                    break;
                case "Reproductor":
                    Reproductor reproductor = (Reproductor)r.AparatoReparacion;
                    root = new XElement(EtqAparato,
                        new XAttribute(EtqTipo, EtqReproductor),
                        new XAttribute(EtqNumSerie, reproductor.NumSerie),
                        new XAttribute(EtqModelo, reproductor.Modelo),
                        new XAttribute(EtqBlueRay, reproductor.BlueRay),
                        new XAttribute(EtqGrabacion, reproductor.Grabacion),
                        new XAttribute(EtqMinutosGrabacion, reproductor.MinutosGrabacion)
                        );
                    break;
                default:
                    root = new XElement("AparatoNoEncontrado");
                    break;

            }
            return root;
        }
        
        public static RegistroReparaciones RecuperarXml()
        {
            var toret = new RegistroReparaciones();
            try
            {
                var doc = XDocument.Load(ArchivoXml);
                if (doc.Root != null &&
                    doc.Root.Name == EtqReparaciones)
                {
                    var elementos = doc.Root.Elements(EtqReparacion);
                    foreach (XElement repXml in elementos)
                    {
                        XElement aparatoElement = repXml.Element(EtqAparato);
                        Aparato ap = RecuperarAparatoXml(aparatoElement);
                        toret.Add(Reparacion.crea(ap,
                                        (double) repXml.Attribute(EtqHoras)
                                    )
                                );
                    }
                }
            }catch (Exception e)
            {
                Console.WriteLine("Error al cargar el archivo XML");
                Console.WriteLine(e.ToString());
                toret.Clear();
            }
            return toret;
        }

        private static Aparato RecuperarAparatoXml(XElement element)
        {
            Aparato toret;
            switch (element.Attribute(EtqTipo).Value)
            {
                case EtqRadio:
                    toret = new Radio(
                        element.Attribute(EtqNumSerie).Value, 
                        element.Attribute(EtqModelo).Value,
                        element.Attribute(EtqBanda).Value
                        );
                    break;
                case EtqTelevisor:
                    toret = new Televisor(
                        element.Attribute(EtqNumSerie).Value,
                        element.Attribute(EtqModelo).Value,
                        Convert.ToInt32(element.Attribute(EtqPulgadas).Value)
                        );
                    break;
                case EtqAdaptador:
                    toret = new Adaptador(
                        element.Attribute(EtqNumSerie).Value,
                        element.Attribute(EtqModelo).Value,
                        Convert.ToInt32(element.Attribute(EtqMinGrabacion).Value)
                        );
                    break;
                case EtqReproductor:
                    toret = new Reproductor(
                        element.Attribute(EtqNumSerie).Value,
                        element.Attribute(EtqModelo).Value,
                        Convert.ToBoolean(element.Attribute(EtqBlueRay).Value),
                        Convert.ToBoolean(element.Attribute(EtqGrabacion).Value),
                        Convert.ToInt32(element.Attribute(EtqMinutosGrabacion).Value)
                        );
                    break;
                default:
                    toret = null;
                    break;
            }

            return toret;
        }
    }
}    